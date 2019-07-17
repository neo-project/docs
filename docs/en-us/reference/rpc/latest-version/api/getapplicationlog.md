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
  "params": ["92b1ecc0e8ca8d6b03db7fe6297ed38aa5578b3e6316c0526b414b453c89e20d"],
  "id": 1
}
```

Response body：

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x92b1ecc0e8ca8d6b03db7fe6297ed38aa5578b3e6316c0526b414b453c89e20d",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x6ec33f0d370617dd85e51d31c483b6967074249d",
                "vmstate": "HALT",
                "gas_consumed": "2.912", 
                "stack": [ 
                    { 
                        "type": "Integer", 
                        "value": "1" 
                    } 
                ],
                "notifications": [
                    {
                        "contract": "0x78e6d16b914fe15bc16150aeb11d0c2a8e532bdd",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d086ac0ed3e578a1afd3c0a2c0d8f0a180405be2"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "002ba7f83fd4d3975dedb84de27345684bea2996"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0065cd1d00000000"
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

