# getapplicationlog method

Returns the contract log based on the specified txid. The complete contract logs are stored under the ApplicationLogs directory.

> [!Note]
>
> You must install the plugins [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

txid: Transaction ID

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0x760dffe5ac809baa81b002864e8d8a7cec90dc6905d38fdc7e9c5fdc70d2cb64"],
  "id": 1
}
```

Response body：

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x760dffe5ac809baa81b002864e8d8a7cec90dc6905d38fdc7e9c5fdc70d2cb64",
        "trigger": "Application",
        "vmstate": "HALT",
        "gas_consumed": "12196370",
        "stack": [],
        "notifications": [
            {
                "contract": "0xf8bf38f68c72e9a529ca2324cfbf2dccbd8f7daa",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteArray",
                            "value": "VHJhbnNmZXI="
                        },
                        {
                            "type": "ByteArray",
                            "value": "K/Fz+EnR1ZEj0JfACaoxYk055zk="
                        },
                        {
                            "type": "ByteArray",
                            "value": "z2FL7K8LazAkM1WYGuB6RhOqV/4="
                        },
                        {
                            "type": "Integer",
                            "value": "500000000000"
                        }
                    ]
                }
            }
        ]
    }
}
```

Response description：
gas_consumed: The transaction fee, which means the gas consumed in the transaction execution. 

