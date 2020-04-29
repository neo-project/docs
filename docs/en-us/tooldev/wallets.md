# Wallets

Wallets are basic components of Neo and the bridges for users to access Neo network. They are responsible for transaction operations such as transfer, contract deployment, asset registration, etc.

You can redesign and modify Neo wallets following your own thoughts, but the below rules and patterns must be followed.

## Accounts

In Neo, the account is the smart contract and the address represents a contract script. The below flow diagram shows how to derive the public key from the private key and then to the address:

![](images\wallets\privatekey-2-publickey-address.png)

### Private Key

A private key is a random value generated between 1 and n (n is a constant, less than 2^256 slightly), and is represented by a 256 bit (32 bytes) number generally.

There are two main encoding formats for private keys in Neo:

- Hexstring Format

   The hexstring format is a string that uses hexadecimal characters to represent byte array.

- WIF Format

   The wif format is to add prefix `0x80` and suffix `0x01` in the original 32-byte data, and get the string after Base58Check encoding.

![](images\wallets\wif_format.png)

 Example: 

| Format | Value |
|---|---|
| byte[] | [0xc7,0x13,0x4d,0x6f,0xd8,0xe7,0x3d,0x81,0x9e,0x82,0x75,<br>0x5c,0x64,0xc9,0x37,0x88,0xd8,0xdb,0x09,0x61,0x92,0x9e,<br>0x02,0x5a,0x53,0x36,0x3c,0x4c,0xc0,0x2a,0x69,0x62] |
| hexstring | c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962 |
| wif | L3tgppXLgdaeqSGSFw1Go3skBiy8vQAM7YMXvTHsKQtE16PBncSU |

### Public Key

The public key is a point (X, Y) calculated through the ECC algorithm with the private key. The X, Y coordinates can be represented by 32-byte data. Different from Bitcoin, Neo chooses secp256r1 as the curve of the ECC algorithm. There are two public key formats in Neo:

- Uncompressed Public Key

    0x04 + X (32 bytes) +  Y (32 bytes) 

- Compressed Public Key

    0x02/0x03 + X (32 bytes)

Example:

| Format | Value |
|----------|:-------------:|
| Private Key | c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962|
| Public Key (Compressed) | 035a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a |
| Public Key (Uncompressed)  | 045a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a35dfabcb79ac492a2a88588d2f2e73f045cd8af58059282e09d693dc340e113f  |

### Address

Address is a string of numbers and letters after a series of transformations of the public key. This section will describes the steps of conversion from a public key to an address in Neo.

> [!Note]
>
> The address script in Neo3 has changed not using the Opcode.CheckSig and OpCode.CheckMultiSig but the interoperable service call `SysCall "Neo.Crypto.ECDsaVerify".hash2uint`, `SysCall "Neo.Crypto.ECDsaCheckMultiSig".hash2unit` instead.

#### Ordinary Address

1. Build a `CheckSig` script with the public key, and the format is as follows:

    ```
    0x0C + 0x21 + Public Key(Compressed 33 bytes) + 0x0B + 0x41 + 0x0a906ad4
    ```

    ![](images\wallets\account_address_script_checksign.png)

2. Calculate script hash of the contract (20 bytes, make once SHA256 and RIPEMD160 of the script). 

3. Add the version prefix in the hash (Currently, the Neo version is `0x53`).

4. Make Base58Check encoding for the above byte data.

Example：

| Format | Value |
|----------|:-------------:|
| Private Key | 3bf2c2c3a43ee817c5a7704b60e5265e73e585eb85b17091c451ddf72fd80c41 |
| Public Key (Compressed) | 02208aea0068c429a03316e37be0e3e8e21e6cda5442df4c5914a19b3a9b6de375 |
| Script | 0c2102208aea0068c429a03316e37be0e3e8e21e6cda5442df4c5914a19b3a9b6de3750b410a906ad4 |
| Address | NWRRMt1FGSZiiT8Wg7naBwrEKLN4SXcUzH |

#### Multi-Signature Address

1. Construct an N-of-M `CheckMultiSig` script with multiple addresses. The script format is as follows: 

   ```
   emitPush(N) + 0x0C + 0x21 + Public Key1(Compressed 33 bytes)  + .... + 0x0C + 0x21 + Public KeyM + emitPush(M) +  0x0B + 0x41 + 0x3073b3bb
   ```

   [![address checksign](https://github.com/Tommo-L/NEO3-Development-Guide/raw/master/images/account_address_script_multi_checksign.png)](https://github.com/Tommo-L/NEO3-Development-Guide/blob/master/images/account_address_script_multi_checksign.png)

2. Calculate script hash of the contract (20 bytes, make once SHA256 and RIPEMD160 of the script).

3. Add the version prefix in the hash. (Currently, the Neo version is `0x53`)

4. Make Base58Check encoding for the above byte data.

Example:

| Format                  | Value                                                        |
| ----------------------- | ------------------------------------------------------------ |
| Private Key             | 97374afac1e801407d6a60006e00d555297c5019788795f017d4cd1fff3df529， aab9d4e4223e088aa6eb1f0ce75c11d149625f6d6a19452d765f8737200a4c35 |
| Public Key (Compressed) | 035fdb1d1f06759547020891ae97c729327853aeb1256b6fe0473bc2e9fa42ff50，03eda286d19f7ee0b472afd1163d803d620a961e1581a8f2704b52c0285f6e022d |
| Script                  | 120c21035fdb1d1f06759547020891ae97c729327853aeb1256b6fe0473bc2e9fa42ff500c2103eda286d19f7ee0b472afd1163d803d620a961e1581a8f2704b52c0285f6e022d120b413073b3bb |
| Address                 | Nh6qrufMRfPNsRh3sNo6asWvvQXrzWdwoK                           |

> [!Note]
>
> Please pay attention to the interval of the number for the usage of `emitPush(number)`. Here is an example in the case of the number being BigInteger, where data = number.ToByteArray():

| Number           | Emit OpCode                        | Value            |
| ---------------- | ---------------------------------- | ---------------- |
| -1 <= number <= 16  | OpCode.PUSH0 + (byte)(int)number | 0x10 + number   |
| data.Length == 1  | OpCode.PUSHINT8 + data | 0x00 + data   |
| data.Length == 2  | OpCode.PUSHINT16 + data | 0x01 + data   |
| data.Length <= 4  | OpCode.PUSHINT32 + data | 0x02 + PadRight(data, 4)   |
| data.Length <= 8  | OpCode.PUSHINT64 + data | 0x03 + PadRight(data, 8)   |
| data.Length <= 16  | OpCode.PUSHINT128 + data | 0x04 + PadRight(data, 16) |
| data.Length <= 32  | OpCode.PUSHINT256 + data | 0x05 + PadRight(data, 32) |

## Wallet Files

### db3 files

The db3 wallet is commonly used in wallets of the exchange to facilitate a large amount of account information storage and the retrieval queries.

A db3 wallet file uses SQLite to store data, and the file name extension is `.db3`. There are four tables created in db3 file：

- Account

  | Field               | Type          | isRequired | Note             |
  | ------------------- | ------------- | ---------- | ---------------- |
  | PrivateKeyEncrypted | VarBinary(96) | Yes        | AES256 encrypted |
  | PublicKeyHash       | Binary(20)    | Yes        | Primary Key      |

- Address

  | Field      | Type       | isRequired | Note        |
  | ---------- | ---------- | ---------- | ----------- |
  | ScriptHash | Binary(20) | Yes        | Primary Key |

- Contract

  | Field         | Type       | isRequired | Note                                               |
  | ------------- | ---------- | ---------- | -------------------------------------------------- |
  | RawData       | VarBinary  | Yes        |                                                    |
  | ScriptHash    | Binary(20) | Yes        | Primary Key，Foreign Key，associated Address table |
  | PublicKeyHash | Binary(20) | Yes        | Index，Foreign Key，associated Account table       |

- Key

  | Field | Type        | isRequired | Note        |
  | ----- | ----------- | ---------- | ----------- |
  | Name  | VarChar(20) | Yes        | Primary Key |
  | Value | VarBinary   | Yes        |             |

In `Key` table，it mainly stores the AES256 attributes:

- `PasswordHash`: the hash of the passowrd, by using SHA256 hash operation.

- `IV`: an initial vector of AES, randomly generated.

- `MasterKey`: an encrypted ciphertext, obtained by encrypting the private key using AES256 algorithm with `PasswordKey`, `IV` parameters.

- `Version`: the version of the wallet

The db3 wallet uses the AES (symmetrical encryption) as its encryption and decryption method.

### NEP6 files

An NEP6 wallet file complies with the NEP6 standard, and the file name extension is `.json`. The JSON format is as follows:

```json
{
	"name": null,
	"version": "3.0",
	"scrypt": {
		"n": 16384,
		"r": 8,
		"p": 8
	},
	"accounts": [{
		"address": "Nhet9QtFPWzBNB7sRXcRPPbMdjVmkYWCC5",
		"label": null,
		"isDefault": false,
		"lock": false,
		"key": "6PYV2baXHjFYhEN8z1M9ca6Tmj6v1MmugtFeEfVfEL1vUQxMVpPHCtr7bW",
		"contract": {
			"script": "IQNCaDWy3nPIdBMO4YprNZasTMXDs\u002BjS2iue5GxBTltOp1BoCpBq1A==",
			"parameters": [{
				"name": "signature",
				"type": "Signature"
			}],
			"deployed": false
		},
		"extra": null
	}],
	"extra": null
}
```

| Field                           | Description                                                  |
| ------------------------------- | ------------------------------------------------------------ |
| name                            | a label that the user attaches to the wallet file            |
| version                         | currently fixed at 1.0 and will be used for functional upgrades in the future |
| scrypt（n/r/p）                 | (n/r/p) are parameters for scrypt algorithm used for encrypting and decrypting the private keys in the wallet |
| accounts                        | an array of Account objects which describe the details of each account in the wallet |
| account.address                 | account address                                              |
| account.label                   | account label, null by default                               |
| account.isDefault               | whether is the default account of wallet                     |
| account.lock                    | whether the account is locked                                |
| account.key                     | export nep2key of the privatekey                             |
| account.contract                | the contract of the script                                   |
| account.contract.script         | address script                                               |
| account.contract.parameters     | parameter list for the address script contract               |
| account.contract.parameter.name | parameter name for the address script contract               |
| account.contract.parameter.type | parameter name for the address script contract               |
| account.contract.deployed       | whether is deployed                                          |
| account.extra                   | additional attributes of the account, null by default        |
| extra                           | additional attributes of the wallet, null by default         |

An NEP6 wallet uses scrypt algorithm as the core method of wallet encryption and decryption.

#### Encryption steps

![](images\wallets\nep2key.png)

1. The address is derived from the public key, and the address hash is the first four bytes of `SHA256(SHA256(Address))`

2. Calculate a `derivedkey` by the scrypt algorithm, and divide the 64-byte data into two halves as `derivedhalf1` and `derivedhalf2` Scrypt uses the following parameters:

    - ciphertext: The entered password (UTF-8 format)
	- salt: address hash
	- n: 16384
	- r: 8
	- p: 8
	- length: 64

3. Do xor operation on the private key and `derivedhalf1`, and then get `encryptedkey` by using AES256 to encrypt it with `derivedhalf2`

4. Concatenate data according to the following format and obtain `NEP2Key` by using Base58Check encoding of it

	`0x01` + `0x42` + `0xe0` + address hash + `encryptedkey`

**Decryption steps**：

1. Decode NEP2Key by using Base58Check decoding

2. Check whether the length of decoded data is 39 bytes, and the first three bytes (data[0-2]) are `0x01`, `0x42` and `0xe0`

3. Take data[3-6] as `addresshash`

4. Put the password and addresshash into the Scrypt algorithm. Specify the result length to 64. Then get the `derivedkey`

5. Take Derivedkey[0-31] as `Derivedhalf1`, and Derivedkey[32-63] as `Derivedhalf2`

6. Take data[7-38] as `Encryptedkey` (32 bytes), and decrypt it using AES256 with `derivedhalf2` as the initial vector

7. Do xor operation on the decrypted data and `derivedhalf1` to obtain the private key

8. Get the public key from the private key with ECC algorithm, and then get the address. Check whether the first four bytes of the result of `SHA256(SHA256(Address))` is equal to the `addresshash`. If it's the same, then you get the correct private key

More details about NEP2 and NEP6 proposals are in the Neo document.

NEP2 proposal: <https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki>

NEP6 proposal：<https://github.com/neo-project/proposals/blob/master/nep-6.mediawiki>

## Signature

Neo employs the `ECDSA` algorithm to sign the transaction through the wallet component and take the `nistP256` or `Secp256r1` as the ECC curve and SHA256 as the hash algorithm.

C# code：

```c#
 public byte[] Sign(byte[] message, byte[] prikey, byte[] pubkey)
 {
     using (var ecdsa = ECDsa.Create(new ECParameters
                                     {
                                         Curve = ECCurve.NamedCurves.nistP256,
                                         D = prikey,
                                         Q = new ECPoint
                                         {
                                             X = pubkey.Take(32).ToArray(),
                                             Y = pubkey.Skip(32).ToArray()
                                         }
                                     }))
     {
         return ecdsa.SignData(message, HashAlgorithmName.SHA256);
     }
 }
```

Java code：

```java
   public byte[] sign(byte[] message, byte[] privateKey, byte[] publicKey) {
        ECDSASigner signer = new ECDSASigner();
        BigInteger d = new BigInteger(1, privateKey);
        ECPrivateKeyParameters privateKeyParameters = new ECPrivateKeyParameters(d, ECC.Secp256r1);
        signer.init(true, privateKeyParameters);

        BigInteger[] bi = signer.generateSignature(sha256(message));
        byte[] signature = new byte[64];
        System.arraycopy(BigIntegers.asUnsignedByteArray(32, bi[0]), 0, signature, 0, 32);
        System.arraycopy(BigIntegers.asUnsignedByteArray(32, bi[1]), 0, signature, 32, 32);
        return signature;
    }
```

Example:

| Format     | Value                                                        |
| ---------- | ------------------------------------------------------------ |
| data       | hello world                                                  |
| PrivateKey | f72b8fab85fdcc1bdd20b107e5da1ab4713487bc88fc53b5b134f5eddeaa1a19 |
| PublicKey  | 031f64da8a38e6c1e5423a72ddd6d4fc4a777abe537e5cb5aa0425685cda8e063b |
| signature  | 261e894dd456a190f9e99e39cea9f64ca4f939b24cf47ee3498bf883967035b446f554753d5f76219397bc2abb281a13a3c3acce43978c02c510ccb91cb03f87 |

## Wallet Function

| Function Name   |  Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| Import wallet file     |  Import the account information from the specified wallet file   |
| Export wallet file     |  Store the account information (including private key, password, address, etc.) in the specified wallet file such as db3 wallet file, nep6 json file.  			  |
| Unlock wallet         | Verify user password to prevent leaks                   |
| Create private key         | Recommend safe random generator			     	  |
| Import private key         | Add new private key to the wallet with wif format or digital certificate   |
| Export private key         | Export accounts' private key         			  |
| Generate public key         | Obtain public key by ECC algorithm with private key |
| Generate address         |  Generate address based on private key               |
| Import address         | Add new address to the wallet  						  |
| Export address         | Export accounts' address                               |
| Import offline data |  Load block data in `chain.acc` file to reduce synchronization time    |
| Export offline data | Export block data in `chain.acc` file 				  |
| Synchronize block data     |                                        		      |
| Transfer             | Transfer to other addresses                              |
| Sign             | Sign data, such as transactions                              |
| Claim Gas          | Claim the newly allocated gas from the neo held by the account |
| Get balance         | Show the balance of current wallet  |
| Get transaction         | Show transaction history of current wallet |
| Construct multi-signature contract | Construct multi-signature contract  |
| Extend         |                                                                |
| Deploy smart contract     |  Deploy smart contract |
| Test smart contract     | Test smart contract |

## Wallet software

### Full-node wallet

The full-node wallet is a complete backup of blockchain data, which saves all the onchain data and participates in p2p network, therefore it needs a large storage space.

Neo-CLI and Neo-GUI are all full-node wallet. For more information refer to [Neo node](../node/introduction.md).

### SPV wallet

The SPV (Simplified Payment Verification) wallet is different from full-node wallet. It dosen't store all block data, only block header data, and verifies the data by using bloom filter and merkle tree algorithm. It's mostly used in mobile app or light client, as it can save storage space effectively.

For developing SPV wallet, refer to the NEO network protocol interface.

Usage:

   1. The SPV wallet sends a bloom filter to the full node, and the full node loads the bloom filter.

   2. The SPV wallet sends the bloom filter's parameters to the full node, and the full node load the parameters. (Optional)

   3. The SPV wallet queries transactions from the full node, and the full node returns the transaction data after filtering with the bloom filter and the constructed merkle tree path.

   4. The SPV wallet uses the merkle tree path to verify the transaction data.

   5. The SPV wallet sends `clear the bloom filter` instruction to the full node, and the full node clear it.
