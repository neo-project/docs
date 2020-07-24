# invokefunction Method

Invokes a smart contract with its scripthash based on the specified operation and parameters and returns the result.

> [!Note]
>
> - This method is used to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* scripthash: Smart contract scripthash. You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian scripthash; if the data type is ByteArray, use the little endian scripthash.

* operation: The operation name (string)

* params: The parameters to be passed into the smart contract operation

  > [!Note]
>
  > You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian script hash; if the data type is ByteArray, use the little endian scripthash.

* signers: list of contract signature accounts
  * account: signature account
  * scopes: signature's valid scopes, allowed values: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups
  

  For example:

    ```json
    {
      "type": "String",
      "value": "Hello"
    }
    ```

    ```json
    {
      "type": "Hash160",
      "value": "39e7394d6231aa09c097d02391d5d149f873f12b"
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
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry",
          "allowedcontracts":["0xde5f57d430d3dece511cf975a8d37848cb9e0525","0x1f177332c467db9ba734d3ca85645fbadd7e13e3"],
          "allowedgroups":["0222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df121826343"]
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
  PUSHINT16 1000
  PUSHDATA1 0x2916eba24e652fa006f3e5eb8f9892d2c3b00399
  PUSHDATA1 0xcadb3dc2faa3ef14a13b619c9a43124755aa2569
  PUSHDATA1 transfer
  PUSHDATA1 0x806b7fa0db3b46d6c42e1e1b0a7fd50db9d4a9b0
  SYSCALL System.Contract.Call
  ```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 

- gasconsumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly.
> [!Note]
>
> After entering the `invokefunction` command,  the node invokes the `operation` method, and pass `params` as arguments. If `operation` and `params` are not processed in the contract, the expected result cannot be returned.

