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

> [!Note]
>
> You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian script hash; if the data type is ByteArray, use the little endian scripthash.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokefunction",
  "params": [
    "0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "0xe4b0b6fa65a399d7233827502b178ece1912cdd4"
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
        "script": "0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14266f539addd5bd84340e6cb13dc11e2411d0f4b741627d5b52",
        "state": "HALT",
        "gas_consumed": "3553180",
        "stack": [
            {
                "type": "Integer",
                "value": "10000000000000000"
            }
        ]
    }
}
```

Response description:

- script：合约的调用脚本，参考 [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter)  项目，可以将脚本转为如下OpCode（NeoVM 是基于栈的虚拟机，执行时从下向上执行）：

  ```
  PUSHDATA1 0xe4b0b6fa65a399d7233827502b178ece1912cdd4
  PUSHDATA1 balanceOf
  PUSHDATA1 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
  SYSCALL System.Contract.Call
  ```

- state: the vm state, where `HALT` means the vm is executed successfully, and`FAULT` means the vm is exited due to an exception. 

- gas consumed: the system fee consumed during invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

> [!Note]
>
> After entering the `invokefunction` command, the node does not directly invoke the operation method in the contract. Instead, it invokes the `main` method of the contract, and pass `operation` and `params` as arguments. If `operation` and `params` are not processed in the `main` method, the expected result cannot be returned.

