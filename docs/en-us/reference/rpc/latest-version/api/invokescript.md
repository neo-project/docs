# invokescript Method

Returns the result after passing a script through the VM.

> [!Note]
>
> - This method is to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

- script: A script runnable in the VM. This is the same script that is carried in InvocationTransaction
- signers: list of contract signature accounts
  * account: signature account
  * scopes: signature's valid scopes, allowed values: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokescript",
  "params": [
    "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
    [
         {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CustomContracts",
          "allowedcontracts":["0xde5f57d430d3dece511cf975a8d37848cb9e0525","0x1f177332c467db9ba734d3ca85645fbadd7e13e3","0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc"],
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
        "tx": "0068f10067587389000000000046e71300000000008d1e2000011c0357464b777ecf6b5f3ac3893ace1f8b1621f6100325059ecb4878d3a875f91c51ceded330d4575fdee3137eddba5f6485cad334a79bdb67c43273171fbcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e660054180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b5201420c40840c3de238b0b876bf78bc5f83f4f42b8652554925a33d8728e2ecd2e3f7c9abfdb6c7b45a8d5a033616c97fb0c8cd26d810c819a336bb3682a9caf87a852674290c210222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df1218263430b4195440d78"
    }
}
```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 


- gasconsumed: the system fee consumed for invocation.	- gasconsumed: the system fee consumed for invocation.


- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.


- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly.
