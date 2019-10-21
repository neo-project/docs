## Structure of transactions on the NEO blockchain
A NEO transaction is a signed data package with an instruction for the network, for example a user indicating that he wants to transfer assets to another address. Each NEO block in the blockchain ledger contains one or more transactions, making each block a transaction batch. 

NEO currently has a maximum transaction size of 100 KiB and a maximum of 500 transactions per block. These limits can be increased in the future if necessary. NEO supports both the UTXO (*unspent transaction output*) and account/balance-based record-keeping models. All native assets like NEO and GAS use the UTXO model, while all contract tokens use an account/balance model.

## Structure
Each transaction has a minimum set of attributes.

| Field        | Type    | Description                              |
|--------------|---------|------------------------------------------|
| `type`       | uint8   | The type of the transaction              |
| `version`    | uint8   | Compatibility version                    |
| `attributes` | array   | Additional features for the transaction  |
| `outputs`    | array   | Destination of the attached assets       |
| `inputs`     | array   | Assets to attach with the transaction    |
| `scripts`    | array   | Scripts used to validate the transaction |

For all transactions, the unique transaction hash `txid` (uint256) and `size` (uint8) parameters will be calculated.

Read more about the transaction attributes:

- [type](#type)
- [version](#version)
- [attributes](#attributes)
  - [attributes usage types](#attributes-usage-types)
- [outputs](#outputs)
- [inputs](#inputs)
- [scripts](#scripts)
  - [invocation script](#invocation-script)
  - [verification script](#verification-script)

Example transaction:

```javascript
{
   "txid":"0xee85d489e4428a538f39c1903771e1f222a383f8327c96ed19cc02079149a1fd",
   "size":665,
   "type":"ContractTransaction",
   "version":0,
   "attributes":[

   ],
   "vout":[
      {
         "n":0,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"1000",
         "address":"Ae2d6qj91YL3LVUMkza7WQsaTYjzjHm4z1"
      },
      {
         "n":1,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"99999000",
         "address":"AWHX6wX5mEJ4Vwg7uBcqESeq3NggtNFhzD"
      }
   ],
   "vin":[
      {
         "txid":"0x3631f66024ca6f5b033d7e0809eb993443374830025af904fb51b0334f127cda",
         "vout":0
      }
   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[
      {
         "invocation":"406a159b7552c7eaedc79abc86faeca7aa50af52aaa0f14aa9a4abaf498f270a140709992253df55de1b2fd93a6ea13b5344dacbd4e54e4f661fe073edeb72e2f740e28c0866c2ea963e40f8f6edbc1e40b76181fef43a4016d234602a52b31b83f02d745d57188cd72fcb1a8394a39d77270334374848266bb87a29fa4114d1b13240c1e7eae0e8e8d33b1a16c8ece8e96bc832d8f0a069499b8b9590609d8cd2a799a555f5433bdc153466bf6eefea0a568bd08b28afabfacb673785fe8d59ab82ea404874390b85c4d37d3645e03cae571000f3ca344452c2a4018aab57f73750dfb695c5488e3c9887699a2ff69e539b7e37278f470b03bc357ebaad25c397ef3104",
         "verification":"542102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
      }
   ]
}
```

### Type
There are several different types of transactions. Each type has a different purpose and different characteristics.

- Available transaction types:
  - `ContractTransaction`
  - `InvocationTransaction`
  - `ClaimTransaction`
  - `MinerTransaction`
  - `StateTransaction`
- Deprecated transaction types that should not be used anymore:
  - `RegisterTransaction`
  - `EnrollmentTransaction`
  - `IssueTransaction`
- Removed transaction types:
  - `PublishTransaction`
  - `VotingTransaction`
  - `AgencyTransaction`

### Version
The version attribute allows updates to the transaction structure with backwards compatibility. Currently version `0` and `1` are supported for `InvocationTransaction` and version `0` is the only supported version for any other transaction type.

### Attributes
Depending on the transaction type, it is possible to add attributes. For each attribute a usage type has to be specified, together with the external data and the size of the external data.

| Field    | Type  | Description                           |
|----------|-------|---------------------------------------|
| `usage`  | uint8 | Attribute usage type                  |
| `length` | uint8 | Length of the data (if required)      |
| `data`   | uint8 | External data attached for usage type |

Example:

```javascript
{
   "attributes":[
      {
         "usage":48,
         "data":"cf62fd54fc761f291d07d68088dd81b8b35a7c444f3af8acd78a3ad4ff75d163"
      },
      {
         "usage":48,
         "data":"aac6d49da8f63cf6442c5f707317bc3e7490029af1a75b83adc0ec3b1b3e1f0f"
      },
      {
         "usage":240,
         "data":"e5a487e6b3a8e58a9fe883bde7acace4b880e6aca1e6b58be8af95efbc8ce880b6efbc81202048656c6c6f2072656d61726b73efbc81"
      },
      {
         "usage":144,
         "data":"5473685f323031372f322f382031363a31383a353931373033323132343035"
      }
   ]
}
```

#### Attributes usage types
The following usage types can be included in the transaction attributes.

| Usage type    | Name              | Description                           | Length                                  |
|---------------|-------------------|---------------------------------------|-----------------------------------------|
| `0`           | `ContractHash`    | Script hash of the contract           | `32`                                    |
| `2`           | `ECDH02`          | Public key for ECDH key exchange      | `32`                                    |
| `3`           | `ECDH03`          | Public key for ECDH key exchange      | `32`                                    |
| `32`          | `Script`          | Additional validation of transactions | `20`                                    |
| `48`          | `Vote`            | Voting payload                        | Should be specified (up to 255 bytes)   |
| `129`         | `DescriptionUrl`  | URL for description                   | Should be specified (up to 255 bytes)   |
| `144`         | `Description`     | Description                           | Should be specified (up to 255 bytes)   |
| `161` - `175` | `Hash1-Hash15`    | Storing of custom hash values         | `32`                                    |
| `240` - `255` | `Remark-Remark15` | Custom general remarks                | Should be specified (up to 65535 bytes) |

A maximum of 16 attributes can be added to each transaction.

### Outputs
An output `vout` is an amount of an asset transferred to an address as a result of the transaction. Each transaction can have up to `65536` outputs. The outputs are validated according to the transaction type being used.

| Type                        | Description                                                                                     |
|-----------------------------|-------------------------------------------------------------------------------------------------|
| `IssueTransaction`          | Requires the transaction to be signed by the asset administrative contract                      |
| `ClaimTransaction`          | Requires one or more unclaimed outputs to be referenced in the transaction `claims` attribute   |
| `MinerTransaction`          | Requires `inputs` to be empty and the amount in `outputs` to match all system fees in the block |

All other transactions require one or more unspent outputs to be referenced in the transaction `inputs` attribute.

The network will verify if the requirements are satisfied and if the total amount of an asset in the `outputs` does not exceed the available amount for that transaction. Each output in the array of outputs has a set of required attributes.

| Field     | Type    | Description                                                      |
|-----------|---------|------------------------------------------------------------------|
| `asset`   | uint256 | The transaction hash of the asset registration (unique asset id) |
| `value`   | int64   | The amount of the asset to transfer                              |
| `address` | uint160 | Address where to transfer the asset to                           |

For each output in the array of outputs a unique index `n` will be calculated. Each output can be referenced only once as an input in a new transaction.

Example:

```javascript
{
   "vout":[
      {
         "n":0,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"10000",
         "address":"AXwJzQTtLKvzy2nxHUgQFxokh1GpuxCEdf"
      },
      {
         "n":1,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"1864",
         "address":"ALaDzzomLTccNfNPPeWh7NLRW1UasyWvi5"
      }
   ]
}
```

### Inputs
An input `vin` is a reference to an unspent output from a previous transaction. This reference represents the amount of an asset transferred to an address. Each transaction can have up to `65536` inputs. Each input in the array of inputs has a set of required attributes.

| Field  | Type    | Description                                    |
|--------|---------|------------------------------------------------|
| `txid` | uint256 | The transaction hash of the referenced output  |
| `vout` | uint16  | The index of the outputs array to use as input |

Once an output from a previous transaction is used as input, it will be considered `spent` and cannot be used anymore.

Example:

```javascript
{
   "vin":[
      {
         "txid":"0xa3a6f522beb92fedeb508b4ece820ecbb34f3892af36c0082045d17aac62e6fc",
         "vout":241
      }
   ]
}
```

### Scripts
The scripts attribute is used to verify the validity and integrity of the transaction. An object in the scripts array is often referred to as `witness`. There are two attributes for each witness in the scripts array.

| Field                | Description                                                                                 |
|----------------------|---------------------------------------------------------------------------------------------|
| `InvocationScript`   | Script to push validation signatures to the verification script                             |
| `VerificationScript` | Verification script to push the public keys corresponding to the (multi-signature) contract |

If the transaction is a `ContractTransaction` with assets attached in the `inputs`, then the signature and public key that belongs to the inputs will be verified. You can add multiple witnesses to each transaction or use a multi-signature witness as well.

Example:

```javascript
{
   "scripts":[
      {
         "invocation":"406a159b7552c7eaedc79abc86faeca7aa50af52aaa0f14aa9a4abaf498f270a140709992253df55de1b2fd93a6ea13b5344dacbd4e54e4f661fe073edeb72e2f740e28c0866c2ea963e40f8f6edbc1e40b76181fef43a4016d234602a52b31b83f02d745d57188cd72fcb1a8394a39d77270334374848266bb87a29fa4114d1b13240c1e7eae0e8e8d33b1a16c8ece8e96bc832d8f0a069499b8b9590609d8cd2a799a555f5433bdc153466bf6eefea0a568bd08b28afabfacb673785fe8d59ab82ea404874390b85c4d37d3645e03cae571000f3ca344452c2a4018aab57f73750dfb695c5488e3c9887699a2ff69e539b7e37278f470b03bc357ebaad25c397ef3104",
         "verification":"542102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
      },
      {
         "invocation":"407ee3f7f7ee3e0be4c3a3bf367f710e666e8ccf0e7f08681e3df90cb69f82476c2d04e09133045f00d5cf1753c6c11bded45e96f6742dda54dbfbd7c05024eb35",
         "verification":"21027ec2a9f042a8a702b061faace75966c7199b6a6524c08002da22f54cbf4c4da0ac"
      },
      {
         "invocation":"4031c35a44fb2a24718c43bfcff92dd20e8d129f331c7944830665ea1072382233e5d368a8c8942fb60c55867bacf9aac38a7cb01470a01b41e07c509ca4b68974",
         "verification":"2102a1e6ed9a5cff73ad33b7896465af8e9206eab9c8c75502868b783deb64f232eaac"
      }
   ]
}
```

#### Invocation script
The invocation script is constructed with the following steps:
1. `0x40` (PUSHBYTES64) followed by the (first) 64 byte signature

The invocation script can push multiple signatures for a multi-signature contract by repeating these steps.

#### Verification script
The verification script with a single signature is constructed with the following steps:

1. `0x21` (PUSHBYTES33) followed by the 33 byte public key that corresponds to the signature
2. `0xAC` (CHECKSIG) to verify the signature with the provided public key

The verification script with a multi-signature contract is constructed with the following steps:

1. `0x52` (PUSH2) to `0x60` (PUSH16) to indicate the required amount of signatures
2. `0x21` (PUSHBYTES33) followed by the first 33 byte public key for the multi-signature contract, repeated for each public key in the multi-signature contract
3. `0x52` (PUSH2) to `0x60` (PUSH16) to indicate the total amount of public keys for the signature
4. `0xAE` (CHECKMULTISIG) to verify the signatures with the provided public keys

To maintain performance it is required to have the same order for public keys and signatures during the verification of a multi-signature contract.

## What's next?

[Transaction Types](3-NEO_transaction_types.md)

