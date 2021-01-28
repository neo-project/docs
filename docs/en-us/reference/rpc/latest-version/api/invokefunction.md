# invokefunction Method

Invokes a smart contract with its scripthash based on the specified operation and parameters and returns the result.

> [!Note]
>
> - This method is used to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* scripthash: Smart contract scripthash. You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian scripthash; if the data type is ByteArray, use the little endian scripthash.

* operation: The operation name (string)

* params: Optional. The parameters to be passed into the smart contract operation

* signers: Optional. List of contract signature accounts.

  > [!Note]
  >
  > You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian script hash; if the data type is ByteArray, use the little endian scripthash.

  * account: signature account
  * scopes: signature's valid scopes, allowed values: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups
  

You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian script hash; if the data type is ByteArray, use the little endian scripthash.

For example:

```json
  {
    "type": "String",
    "value": "Hello"
  }

  {
    "type": "Hash160",
    "value": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
  }

  {
    "type": "ByteArray",
    "value": "7472616e73666572"
  }
```

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "invokefunction",
    "params": [
        "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "transfer",
        [
            {
                "type": "Hash160",
                "value": "0x86df72a6b4ab5335d506294f9ce993722253b6e2"
            },
            {
                "type": "Hash160",
                "value": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa"
            },
            {
                "type": "Integer",
                "value": "10000"
            },
            {
                "type": "String",
                "value": ""
            }
        ],
        [
            {
                "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                "scopes": "CalledByEntry",
                "allowedcontracts": [],
                "allowedgroups": []
            }
        ]
    ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "DAABECcMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBTitlMicpPpnE8pBtU1U6u0pnLfhhTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I=",
        "state": "HALT",
        "gasconsumed": "0.0999972",
        "exception": null,
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": "AI3PBQRolZgAAAAAAMrSEgAAAAAAtRcAAAHitlMicpPpnE8pBtU1U6u0pnLfhgEAWQwAARAnDBT6ifssFN8PWd3fBPblZRfys0qu6wwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBSDqwZ5rVXAUKE61D9ZNupz9ese9kFifVtSAUIMQB87UjubTE7Kb/fOe8Yu2QDUQJ6c5pL9LjcoFaNkEiJzLY5yd72jrsvVbVFNZ6ObWloAmLkjCgDXw9enkVtwVBMrEQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
    }
}
```

Response description:

- script: the invocation script of the contract. You can analysis from https://neo.org/converter:

  ```
  SYSCALL System.Contract.Call
  PUSHDATA1 0xf61eebf573ea36593fd43aa150c055ad7906ab83
  PUSHDATA1 transfer
  PUSHDATA1 0x86df72a6b4ab5335d506294f9ce993722253b6e2
  PUSHDATA1 0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa
  PUSHINT16 10000
  PUSHDATA1
  ```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 

- gasconsumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly.