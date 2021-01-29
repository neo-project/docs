# getcontractstate 方法

根据合约脚本散列或原生合约名称，查询合约的信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

script_hash / name：合约脚本散列或者原生合约的名称。

因为用户部署的合约名称可重复，所以这里搜索的合约名称仅限于原生合约。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["neotoken"],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["0xf61eebf573ea36593fd43aa150c055ad7906ab83"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "id": -3,
        "updatecounter": 0,
        "hash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "nef": {
            "magic": 860243278,
            "compiler": "neo-core-v3.0",
            "tokens": [],
            "script": "AP1BGvd7Zw==",
            "checksum": 3921333105
        },
        "manifest": {
            "name": "NeoToken",
            "groups": [],
            "supportedstandards": [
                "NEP-17"
            ],
            "abi": {
                "methods": [
                    {
                        "name": "balanceOf",
                        "parameters": [
                            {
                                "name": "account",
                                "type": "Hash160"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Integer",
                        "safe": true
                    },
                    {
                        "name": "decimals",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Integer",
                        "safe": true
                    },
                    {
                        "name": "getCandidates",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Array",
                        "safe": true
                    },
                    {
                        "name": "getCommittee",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Array",
                        "safe": true
                    },
                    {
                        "name": "getGasPerBlock",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Integer",
                        "safe": true
                    },
                    {
                        "name": "getNextBlockValidators",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Array",
                        "safe": true
                    },
                    {
                        "name": "registerCandidate",
                        "parameters": [
                            {
                                "name": "pubkey",
                                "type": "ByteArray"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Boolean",
                        "safe": false
                    },
                    {
                        "name": "setGasPerBlock",
                        "parameters": [
                            {
                                "name": "gasPerBlock",
                                "type": "Integer"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Boolean",
                        "safe": false
                    },
                    {
                        "name": "symbol",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "String",
                        "safe": true
                    },
                    {
                        "name": "totalSupply",
                        "parameters": [],
                        "offset": 0,
                        "returntype": "Integer",
                        "safe": true
                    },
                    {
                        "name": "transfer",
                        "parameters": [
                            {
                                "name": "from",
                                "type": "Hash160"
                            },
                            {
                                "name": "to",
                                "type": "Hash160"
                            },
                            {
                                "name": "amount",
                                "type": "Integer"
                            },
                            {
                                "name": "data",
                                "type": "Any"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Boolean",
                        "safe": false
                    },
                    {
                        "name": "unclaimedGas",
                        "parameters": [
                            {
                                "name": "account",
                                "type": "Hash160"
                            },
                            {
                                "name": "end",
                                "type": "Integer"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Integer",
                        "safe": true
                    },
                    {
                        "name": "unregisterCandidate",
                        "parameters": [
                            {
                                "name": "pubkey",
                                "type": "ByteArray"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Boolean",
                        "safe": false
                    },
                    {
                        "name": "vote",
                        "parameters": [
                            {
                                "name": "account",
                                "type": "Hash160"
                            },
                            {
                                "name": "voteTo",
                                "type": "ByteArray"
                            }
                        ],
                        "offset": 0,
                        "returntype": "Boolean",
                        "safe": false
                    }
                ],
                "events": [
                    {
                        "name": "Transfer",
                        "parameters": [
                            {
                                "name": "from",
                                "type": "Hash160"
                            },
                            {
                                "name": "to",
                                "type": "Hash160"
                            },
                            {
                                "name": "amount",
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
            "extra": null
        }
    }
}
```

