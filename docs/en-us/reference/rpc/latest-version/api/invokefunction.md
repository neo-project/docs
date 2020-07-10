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
* cosigners: Add signatures when required.


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
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry"      
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
        "tx": "0005d16e331c0357464b777ecf6b5f3ac3893ace1f8b1621f658738900000000001e47130000000000a81f200001011c0357464b777ecf6b5f3ac3893ace1f8b1621f60154180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b5201420c40de4c406084b738675c42519643018748215cf9de3ef9c6ec40eecf70b403250a2dddca6045e020bf713503c649ba4df0ff6cfc39459fb26929c0699aebcb0a0c290c210222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df1218263430b4195440d78"
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

- gas_consumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: It defaults to null and returns the constructed transaction (i.e. the hexadecimal string of the contract invocation transaction) when the proper signature is passed to the wallet. The transaction can be sent to the blockchain with [sendrawtransaction](sendrawtransaction.md).

> [!Note]
>
> The `invokefunction` command invokes the `operation` method and pass  `params` as arguments. If `operation` is not found in the contract abi file, the expected result cannot be returned.

