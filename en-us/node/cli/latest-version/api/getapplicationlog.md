# getapplicationlog method

Returns the contract log based on the specified txid. The complete contract logs are stored under the ApplicationLogs directory.

> [!Note]
>
> This method is provided by the plugin [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

txid：Transaction ID

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["b6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3"],
  "id": 1
}
```

Response body：

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xb6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x23c3aaaa31a0c373c23505157e9fb2665c7065ec",
                "vmstate": "HALT",
                "gas_consumed": "2.931",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x1578103c13e39df15d0d29826d957e85d770d8c9",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "235a717ed7ed18a43de47499c3d05b8d4a4bcf3a"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0b2f7cac1d57b9f535d35da1a5421015e4e32b19"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00f44a4f9df66d01"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```

