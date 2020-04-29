# Transaction

Transaction is the basic operation model of the whole Neo network. Wallets, smart contracts and accounts interact with Neo network through transactions. In Neo's P2P network, information is packed as `InvPayload` for transferring (Inv is abbreviation of Inventory). Different payloads have their special data, thus three types of inventory types are created. `InventoryType = 0x2b` means transaction data is packed into `InvPayload`. Besides, there are block data package (`InventoryType = 0x2c`) and consensus data package (`InventoryType = 0x2d`).

## Structure

On Neo blockchain all transactions are of one type, which data structure is as following:

| Size | Field | Description |
|--------------|---------|------------------------------------------|
| `version`    | byte   | Transaction version, currently 0            |
| `nonce`    | uint   | Random number      |
| `validUntilBlock`    | uint   |  Transaction validity period  |
| `sender`    | UInt160   | Script hash of the sender's address |
| `sysfee`    | long   | System fee paid for network resource |
| `netfee`    | long   | Network fee paid for the validator packaging transactions |
| `attributes` | TransactionAttribute[]   | Transaction attributes                                    |
| `cosigners` | Cosigner[]   | Limits the scope of signature |
| `script`     | byte[]   | Script hash of the transaction contract |
| `witnesses`  | Witness[]   | List of scripts used to validate the transaction    |

### version

The version allows the transaction structure to be updated to make it backward compatible. The current version is 0.

### sender

Since Neo3 deprecated the UTXO model and the native assets NEO and GAS turned into NEP-5 assets, the input and outputs fields are no longer recorded in the transaction structure, instead, the `sender` is used to track the sender of the transaction. This field is the address hash of the transaction initiating account in the wallet.

### sysfee

The system fee is calculated by opcodes to be executed by the Neo virtual machine. The 10 GAS free system fee is canceled in Neo3. The total fee is subject to the quantity and type of instructions in the contract script. The calculation formula is as follows:

![](../../../zh-cn/tooldev/images/transaction/system_fee.png)

where *OpcodeSet* is opcode set, *OpcodePrice<sub>i</sub>* is the cost of opcode i, *n<sub>i</sub>* is the execution times of instruction i in the contract script. For each opcode fee refer to [Fees for Instructions](../../sc/fees.md#fees-for-instructions).

### netfee

The network fee is charged when the user submits a transactions to Neo blockchain as a reward for consensus nodes generating blocks. There is a  base fee for each transaction. The transaction is only executed if the fee paid by the user is greater than or equal to the base fee; otherwise, the transaction will be treated as invalid. The calculation formula is as follows:

![network fee](../../../zh-cn/tooldev/images/transaction/network_fee.png)

where *VerificationCost* is the fee for instructions executed by NeoVM to verify transaction signatures, *tx.Length* is the transaction data byte length, and *FeePerByte* is transaction fee per byte, currently 0.00001 GAS.

### attributes

Additional attributes are allowed to be added to transactions of specific types. You need to define the usage type, internal and external data size for each attribute.

| Size | Field | Description |
| ------- | ------ | -------------- |
| `usage` | uint8  | Usage type |
| `data`  | byte[] | Transaction script to be verified |

#### usage

The following usage type can be included in the transaction attributes.

| Value  | Name | Description                                  | Type   |
| ------ | ---- | -------------------------------------------- | ------ |
| `0x81` | `Url | Address of external introduction information | `byte` |

Up to 16 attributes can be added to each transaction.

### cosigners

The current transaction signature is globally effective. In order to allow users to control the signature scope at a finer level of granularity, the cosigners field in the transaction structure has been changed in Neo3, so that the signature can be used only for verifying the specified contract. 

When checkwitness is used for transaction verification, cosigners except the transaction sender need to define the scope of their signature.

| Field              | Description                                      | Type           |
| ------------------ | ------------------------------------------------ | -------------- |
| `Account`          | Script hash of the account                       | `UInt160`      |
| `Scopes`           | Effective range of the signature                 | `WitnessScope` |
| `AllowedContracts` | Signs array of the allowed contract scripts      | `UInt160[]`    |
| `AllowedGroups`    | Signs public keys of the allowed contract groups | `ECPoint[]`    |

#### Scopes

Scopes defines the effective range of the signature, including these types:

| Field  | Name              | Description                                                  | Type   |
| ------ | ----------------- | ------------------------------------------------------------ | ------ |
| `0x00` | `Global`          | The signature is globally effective. It is the default value of Neo2 and is backward compatible. | `byte` |
| `0x01` | `CalledByEntry`   | The signature is only effective to the contract script called by Entry | `byte` |
| `0x10` | `CustomContracts` | The signature is only effective to the specified contract script | `byte` |
| `0x20` | `CustomGroups`    | The signature is effective to contracts in the group.        | `byte` |


### script

Script of the contract executed by vm.

### witnesses

witnesses verifies the validity and integrity of a transaction. It includes two attributes.

| Field                | Description                                                  |
| -------------------- | ------------------------------------------------------------ |
| `InvocationScript`   | Executes the script and passes parameters to the verification script |
| `VerificationScript` | Verification script                                          |

You can add multiple witnesses to each transaction, or use witnesses with multiple signatures.

#### InvocationScript

Construct a invocation script:

1.	`0x0C`（PUSHDATA1）`0x40` followed with a 64-byte signature

By repeating this step, the invocation script can push multiple signatures for the multi-signature contract.

#### VerificationScript

Verification script, commonly known as address script, includes normal address script and multi-signature address script. The address script can be directly obtained from the wallet account. For information about the construction refer to [Wallets](../wallets#address).

It can also be used as a custom authentication contract script.

## Transaction serialization

In Neo all variable-length integer types except IP addresses and port numbers are stored in little-endian order. When the transaction is serialized, it is executed in the following field order:

| Field             | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| `version`         | -                                                            |
| `nonce`           | -                                                            |
| `sender`          | -                                                            |
| `systemFee`       | -                                                            |
| `networkFee`      | -                                                            |
| `validUntilBlock` | -                                                            |
| `attributes`      | Need to serializes `WriteVarInt(length)` first and then other elements of the array |
| `cosigners`       | Need to serializes `WriteVarInt(length) `first and then other elements of the array |
| `script`          | Need to serializes `WriteVarInt(length) `first and then the byte array |
| `witnesses`       | Need to serializes `WriteVarInt(length) `first and then other elements of the array |


> [!Note]
>
> WriteVarInt (value)  stores a non-fixed-length type based on the value of value, and determines the storage size according to the range of values.

| Value Range         | Storage Type         |
| ------------------- | -------------------- |
| value < 0xFD        | byte(value)          |
| value <= 0xFFFF     | 0xFD + ushort(value) |
| value <= 0xFFFFFFFF | 0xFE + uint(value)   |
| value > 0xFFFFFFFF  | 0xFF + value         |

## Transaction Signature

The transaction signature is to sign the data of the transaction itself by ECDSA method (not including the signature data, i.e. the witnesses part) and then fill in the witnesses in the transaction body.

Here is an example of a transaction data structure, where the script and witnesses fields use Base64 instead of the original Hexstring encoding:

```Json
{
  "hash": "0x2b03f7a8db3649c9e2cb6d429dd358819b3fd536825d2a698e19de237583e60a",
  "size": 57,
  "version": 0,
  "nonce": 0,
  "sender": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
  "sys_fee": "0",
  "net_fee": "0",
  "valid_until_block": 0,
  "attributes": [],
  "cosigners": [],
  "script": "aBI+f+g=",
  "witnesses": [
    {
      "invocation": "",
      "verification": "UQ=="
    }
  ],
  "blockhash": "0x7d581e115ebe1c512eef985fd52d75336acb77826dafacc3281399a0e6204958",
  "confirmations": 1,
  "blocktime": 1468595301000,
  "vmState": "HALT"
}
```

