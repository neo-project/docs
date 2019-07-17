# invokescript Method

Returns the result after passing a script through the VM.

> [!Note]
>
> - This method is to test your VM script as if they were ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - This method is provided by the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

script: A script runnable by the VM. This is the same script that is carried in InvocationTransaction

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["00046e616d656724058e5e1b6008847cd662728549088a9ee82191"],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "00046e616d656724058e5e1b6008847cd662728549088a9ee82191",
        "state": "HALT",
        "gas_consumed": "0.161",
        "stack": [
            {
                "type": "ByteArray",
                "value": "4e45503520474153"
            }
        ],
        "tx": "d1011b00046e616d656724058e5e1b6008847cd662728549088a9ee82191000000000000000000000000"
    }
}
```
