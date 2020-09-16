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

* sender: Optional. The transaction sender and the account paying transaction fee. By default it is the first account in signers. 

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
    "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
    "transfer",
    [
      {
        "type":"Hash160",
        "value":"0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
        },
      {
        "type":"Hash160",
        "value":"0x1f177332c467db9ba734d3ca85645fbadd7e13e3"
        },
      {
        "type":"Integer",
        "value":"8"
        }        
    ],
    "0x1f5da2e47b37c4b96668a98da4ed8feb94bdf146",
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry",
          "allowedcontracts":[],
          "allowedgroups":[]
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
        "script": "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
        "state": "HALT",
        "gasconsumed": "9007960",
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": null
    }
}
```

Response description:

- script: the invocation script of the contract. By reference to [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter) you can convert the script to the following OpCode (NeoVM is a stack-based virtual machine that executes from bottom to top when executing):

  ```
  PUSHINT16 8
  PUSHDATA1 0x1f177332c467db9ba734d3ca85645fbadd7e13e3
  PUSHDATA1 0xf621168b1fce3a89c33a5f6bcf7e774b4657031c
  PUSHDATA1 transfer
  PUSHDATA1 0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc
  SYSCALL System.Contract.Call
  ```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 

- gasconsumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly.
> [!Note]
>
> After entering the `invokefunction` command,  the node invokes the `operation` method, and pass `params` as arguments. If `operation` and `params` are not processed in the contract, the expected result cannot be returned.
