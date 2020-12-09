# getapplicationlog method

Returns the contract event information based on the specified txid. The contract event information is stored under the ApplicationLogs directory.

> [!Note]
>
> You must install the plugins [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- txid: Transaction ID

- trigger type:  Optional. It has the following options:

  - OnPersist
  - PostPersist
  - Application
  - Verification
  - System: OnPersist | PostPersist
  - All: OnPersist | PostPersist | Verification | Application

  It defaults to All. You can specify a trigger type.

## Example

Request body 1：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getapplicationlog",
  "params": [
    "0xd6ea48f1c33defc1815562b3ace4ead99bf33a8ae67b2642cf73c2f192a717e5"
  ]
}
```

Response body 1:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xd6ea48f1c33defc1815562b3ace4ead99bf33a8ae67b2642cf73c2f192a717e5",
        "executions": [
            {
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
                                    "type": "Any"
                                },
                                {
                                    "type": "ByteString",
                                    "value": "9S37k0BBDIaRxjEhW0Sk+9lDN4s="
                                },
                                {
                                    "type": "Integer",
                                    "value": "400000000"
                                }
                            ]
                        }
                    },
                    {
                        "contract": "0xde5f57d430d3dece511cf975a8d37848cb9e0525",
                        "eventname": "Transfer",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteString",
                                    "value": "9S37k0BBDIaRxjEhW0Sk+9lDN4s="
                                },
                                {
                                    "type": "ByteString",
                                    "value": "1rSxahaE1EDW2TzNNlNk0rjQEpI="
                                },
                                {
                                    "type": "Integer",
                                    "value": "1"
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

Request body 2：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getapplicationlog",
  "params": [
    "0x0745a04ddb7803ebd549af4d80de03fc69349b0b77615a06d9ef052637de5931", "System"
  ]
}

```

Response body 2：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "blockhash": "0x0745a04ddb7803ebd549af4d80de03fc69349b0b77615a06d9ef052637de5931",
        "executions": [
            {
                "trigger": "System",
                "vmstate": "HALT",
                "gasconsumed": "2031260",
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
                                    "value": "1rSxahaE1EDW2TzNNlNk0rjQEpI="
                                },
                                {
                                    "type": "Any"
                                },
                                {
                                    "type": "Integer",
                                    "value": "11384830"
                                }
                            ]
                        }
                    },
                    {
                        "contract": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                        "eventname": "Transfer",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "Any"
                                },
                                {
                                    "type": "ByteString",
                                    "value": "1rSxahaE1EDW2TzNNlNk0rjQEpI="
                                },
                                {
                                    "type": "Integer",
                                    "value": "2376840"
                                }
                            ]
                        }
                    }
                ]
            },
            {
                "trigger": "System",
                "vmstate": "HALT",
                "gasconsumed": "2031260",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                        "eventname": "Transfer",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "Any"
                                },
                                {
                                    "type": "ByteString",
                                    "value": "1rSxahaE1EDW2TzNNlNk0rjQEpI="
                                },
                                {
                                    "type": "Integer",
                                    "value": "25000000"
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

Response description：
gasconsumed: The transaction fee, which means the gas consumed in the transaction execution. 

