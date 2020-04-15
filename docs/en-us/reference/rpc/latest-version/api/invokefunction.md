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
  
* checkWitnessHashes: list of contract signature accounts

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
    "0x806b7fa0db3b46d6c42e1e1b0a7fd50db9d4a9b0",
    "transfer",
    [
      {
        "type": "Hash160",
        "value": "0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"
      },
      {
        "type": "Hash160",
        "value": "0x2916eba24e652fa006f3e5eb8f9892d2c3b00399"
      },
      {
        "type": "Integer",
        "value": "1000"
      }
    ],
    ["0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"]
  ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "1a0c149903b0c3d292988febe5f306a02f654ea2eb16290c146925aa554712439a9c613ba114efa3fac23ddbca13c00c087472616e736665720c14b0a9d4b90dd57f0a1b1e2ec4d6463bdba07f6b8041627d5b52",
        "state": "HALT",
        "gas_consumed": "9413130",
        "stack": [
            {
                "type": "Integer",
                "value": "1"
            }
        ]
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

- gas_consumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

> [!Note]
>
> After entering the `invokefunction` command,  the node invokes the `main` method of the contract rather than directly invokes the `operation` method, and pass `operation` and `params` as arguments. If `operation` and `params` are not processed in the `main` method, the expected result cannot be returned.

