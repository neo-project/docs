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
  "params": ["0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295"],
  "id": 1
}
```

Response body：

```
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "txid": "0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295",
        "trigger": "Application",
        "vmstate": "HALT",
        "gasconsumed": "9007990",
        "stack": [],
        "notifications": [
            {
                "contract": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "eventname": "Transfer",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteString",
                            "value": "+pU2/Hks6bMS9XhEc3F6o2fineE="
                        },
                        {
                            "type": "ByteString",
                            "value": "GM4RybFKiRJSR0M8IDpNgA/1ILE="
                        },
                        {
                            "type": "Integer",
                            "value": "1223300000000"
                        }
                    ]
                }
            }
        ]
    }
}
```

Response description：
gasconsumed: The transaction fee, which means the gas consumed in the transaction execution. 

