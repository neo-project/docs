# getapplicationlog 方法

根据交易 txid 获取合约的事件信息。合约事件信息会保存到 ApplicationLogs 目录。

> [!Note]
>
> 此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- txid/blockhash：交易 ID 或区块 hash

- trigger type:  可选参数， 有以下 trigger 类型：

  - OnPersist
  - PostPersist
  - Application
  - Verification
  - System: OnPersist | PostPersist
  - All: OnPersist | PostPersist | Verification | Application

  默认获取所有类型，也可以指定某种类型。 

## 调用示例

请求正文 1：

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

响应正文 1：

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

请求正文 2：

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

响应正文 2：

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

响应说明：
gasconsumed ：该交易消耗的 gas 数量，即交易手续费。
