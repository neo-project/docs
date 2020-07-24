# getcontractstate 方法

根据合约脚本散列，查询合约信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

script_hash：合约脚本散列。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["0x27c229e71e2e7b4aa8062f695586e4243ae60a49"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "id": 4,
        "hash": "0x27c229e71e2e7b4aa8062f695586e4243ae60a49",
        "script": "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",
        "manifest": {
            "groups": [],
            "features": {
                "storage": true,
                "payable": true
            },
            "supportedstandards": [
                "NEP-5",
                "NEP-10"
            ],
            "abi": {
                "hash": "0x27c229e71e2e7b4aa8062f695586e4243ae60a49",
                "methods": [
                    {
                        "name": "deploy",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "migrate",
                        "parameters": [
                            {
                                "name": "script",
                                "type": "ByteArray"
                            },
                            {
                                "name": "manifest",
                                "type": "String"
                            }
                        ],
                        "offset": 258,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "destroy",
                        "parameters": [],
                        "offset": 329,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "mint",
                        "parameters": [],
                        "offset": 459,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "verify",
                        "parameters": [],
                        "offset": 946,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "name",
                        "parameters": [],
                        "offset": 979,
                        "returntype": "String"
                    },
                    {
                        "name": "symbol",
                        "parameters": [],
                        "offset": 997,
                        "returntype": "String"
                    },
                    {
                        "name": "decimals",
                        "parameters": [],
                        "offset": 1016,
                        "returntype": "Integer"
                    },
                    {
                        "name": "supportedStandards",
                        "parameters": [],
                        "offset": 1023,
                        "returntype": "Array"
                    },
                    {
                        "name": "totalSupply",
                        "parameters": [],
                        "offset": 1119,
                        "returntype": "Integer"
                    },
                    {
                        "name": "balanceOf",
                        "parameters": [
                            {
                                "name": "account",
                                "type": "ByteArray"
                            }
                        ],
                        "offset": 1170,
                        "returntype": "Integer"
                    },
                    {
                        "name": "transfer",
                        "parameters": [
                            {
                                "name": "from",
                                "type": "ByteArray"
                            },
                            {
                                "name": "to",
                                "type": "ByteArray"
                            },
                            {
                                "name": "amount",
                                "type": "Integer"
                            }
                        ],
                        "offset": 1274,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "_initialize",
                        "parameters": [],
                        "offset": 1776,
                        "returntype": "Void"
                    }
                ],
                "events": [
                    {
                        "name": "Transfer",
                        "parameters": [
                            {
                                "name": "arg1",
                                "type": "ByteArray"
                            },
                            {
                                "name": "arg2",
                                "type": "ByteArray"
                            },
                            {
                                "name": "arg3",
                                "type": "Integer"
                            }
                        ]
                    }
                ]
            },
            "permissions": [
                {
                    "contract": "*",
                    "methods": "*"
                }
            ],
            "trusts": [],
            "safemethods": [],
            "extra": {
                "Author": "Neo",
                "Email": "dev@neo.org",
                "Description": "This is a NEP5 example"
            }
        }
    }
}
```

