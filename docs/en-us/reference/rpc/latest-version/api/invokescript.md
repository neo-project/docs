# invokescript Method

Returns the result after passing a script through the VM.

> [!Note]
>
> - This method is to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

- script: A script runnable in the VM. This is the same script that is carried in InvocationTransaction
- checkWitnessHashes: List of contact signature accounts.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",["0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"]],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",
        "state": "HALT",
        "gas_consumed": "2007570",
        "stack": [
            {
                "type": "Integer",
                "value": "9999885"
            }
        ],
        "tx": "004473771e2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000269f120000000000eae1200000003e0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b5201420c40abc3a8055c64dcfd70a922cf1a09df19f2d6ccb0b4dacf24612cd40ebab3ab0bf591dd159783c06f187088fb277cde15e8baee0ebc8c3953df22f435215c3421290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```