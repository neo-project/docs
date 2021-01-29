# getnativecontracts 方法

  获得原生合约的列表，包括原生合约的基本信息和合约描述文件（manifest.json）。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "getnativecontracts",
    "params": []
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "id": -1,
            "hash": "0xa501d7d7d10983673b61b7a2d3a813b36f9f0e43",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "D0Ea93tn",
                "checksum": 3516775561
            },
            "manifest": {
                "name": "ContractManagement",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "deploy",
                            "parameters": [
                                {
                                    "name": "nefFile",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "manifest",
                                    "type": "ByteArray"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": false
                        },
                        {
                            "name": "deploy",
                            "parameters": [
                                {
                                    "name": "nefFile",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "manifest",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "data",
                                    "type": "Any"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": false
                        },
                        {
                            "name": "destroy",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "getContract",
                            "parameters": [
                                {
                                    "name": "hash",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": true
                        },
                        {
                            "name": "getMinimumDeploymentFee",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "setMinimumDeploymentFee",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "update",
                            "parameters": [
                                {
                                    "name": "nefFile",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "manifest",
                                    "type": "ByteArray"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "update",
                            "parameters": [
                                {
                                    "name": "nefFile",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "manifest",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "data",
                                    "type": "Any"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        }
                    ],
                    "events": [
                        {
                            "name": "Deploy",
                            "parameters": [
                                {
                                    "name": "Hash",
                                    "type": "Hash160"
                                }
                            ]
                        },
                        {
                            "name": "Update",
                            "parameters": [
                                {
                                    "name": "Hash",
                                    "type": "Hash160"
                                }
                            ]
                        },
                        {
                            "name": "Destroy",
                            "parameters": [
                                {
                                    "name": "Hash",
                                    "type": "Hash160"
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
            },
            "activeblockindex": 0
        },
        {
            "id": -2,
            "hash": "0x971d69c6dd10ce88e7dfffec1dc603c6125a8764",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "AP5BGvd7Zw==",
                "checksum": 3395482975
            },
            "manifest": {
                "name": "LedgerContract",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "currentHash",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Hash256",
                            "safe": true
                        },
                        {
                            "name": "currentIndex",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getBlock",
                            "parameters": [
                                {
                                    "name": "indexOrHash",
                                    "type": "ByteArray"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": true
                        },
                        {
                            "name": "getTransaction",
                            "parameters": [
                                {
                                    "name": "hash",
                                    "type": "Hash256"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": true
                        },
                        {
                            "name": "getTransactionFromBlock",
                            "parameters": [
                                {
                                    "name": "blockIndexOrHash",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "txIndex",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": true
                        },
                        {
                            "name": "getTransactionHeight",
                            "parameters": [
                                {
                                    "name": "hash",
                                    "type": "Hash256"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        }
                    ],
                    "events": []
                },
                "permissions": [
                    {
                        "contract": "*",
                        "methods": "*"
                    }
                ],
                "trusts": [],
                "extra": null
            },
            "activeblockindex": 0
        },
        {
            "id": -3,
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
            },
            "activeblockindex": 0
        },
        {
            "id": -4,
            "hash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "APxBGvd7Zw==",
                "checksum": 3155977747
            },
            "manifest": {
                "name": "GasToken",
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
            },
            "activeblockindex": 0
        },
        {
            "id": -5,
            "hash": "0x79bcd398505eb779df6e67e4be6c14cded08e2f2",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "APtBGvd7Zw==",
                "checksum": 1136340263
            },
            "manifest": {
                "name": "PolicyContract",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "blockAccount",
                            "parameters": [
                                {
                                    "name": "account",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "getExecFeeFactor",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getFeePerByte",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getMaxBlockSize",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getMaxBlockSystemFee",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getMaxTransactionsPerBlock",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getStoragePrice",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "isBlocked",
                            "parameters": [
                                {
                                    "name": "account",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": true
                        },
                        {
                            "name": "setExecFeeFactor",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "setFeePerByte",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "setMaxBlockSize",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "setMaxBlockSystemFee",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "setMaxTransactionsPerBlock",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "setStoragePrice",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "unblockAccount",
                            "parameters": [
                                {
                                    "name": "account",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        }
                    ],
                    "events": []
                },
                "permissions": [
                    {
                        "contract": "*",
                        "methods": "*"
                    }
                ],
                "trusts": [],
                "extra": null
            },
            "activeblockindex": 0
        },
        {
            "id": -6,
            "hash": "0x597b1471bbce497b7809e2c8f10db67050008b02",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "APpBGvd7Zw==",
                "checksum": 3289425910
            },
            "manifest": {
                "name": "RoleManagement",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "designateAsRole",
                            "parameters": [
                                {
                                    "name": "role",
                                    "type": "Integer"
                                },
                                {
                                    "name": "nodes",
                                    "type": "Array"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "getDesignatedByRole",
                            "parameters": [
                                {
                                    "name": "role",
                                    "type": "Integer"
                                },
                                {
                                    "name": "index",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Array",
                            "safe": true
                        }
                    ],
                    "events": []
                },
                "permissions": [
                    {
                        "contract": "*",
                        "methods": "*"
                    }
                ],
                "trusts": [],
                "extra": null
            },
            "activeblockindex": 0
        },
        {
            "id": -7,
            "hash": "0x8dc0e742cbdfdeda51ff8a8b78d46829144c80ee",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "APlBGvd7Zw==",
                "checksum": 3902663397
            },
            "manifest": {
                "name": "OracleContract",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "finish",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "request",
                            "parameters": [
                                {
                                    "name": "url",
                                    "type": "String"
                                },
                                {
                                    "name": "filter",
                                    "type": "String"
                                },
                                {
                                    "name": "callback",
                                    "type": "String"
                                },
                                {
                                    "name": "userData",
                                    "type": "Any"
                                },
                                {
                                    "name": "gasForResponse",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "verify",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": true
                        }
                    ],
                    "events": [
                        {
                            "name": "OracleRequest",
                            "parameters": [
                                {
                                    "name": "Id",
                                    "type": "Integer"
                                },
                                {
                                    "name": "RequestContract",
                                    "type": "Hash160"
                                },
                                {
                                    "name": "Url",
                                    "type": "String"
                                },
                                {
                                    "name": "Filter",
                                    "type": "String"
                                }
                            ]
                        },
                        {
                            "name": "OracleResponse",
                            "parameters": [
                                {
                                    "name": "Id",
                                    "type": "Integer"
                                },
                                {
                                    "name": "OriginalTx",
                                    "type": "Hash256"
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
            },
            "activeblockindex": 0
        },
        {
            "id": -8,
            "hash": "0xa2b524b68dfe43a9d56af84f443c6b9843b8028c",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "tokens": [],
                "script": "APhBGvd7Zw==",
                "checksum": 3740064217
            },
            "manifest": {
                "name": "NameService",
                "groups": [],
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "addRoot",
                            "parameters": [
                                {
                                    "name": "root",
                                    "type": "String"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "balanceOf",
                            "parameters": [
                                {
                                    "name": "owner",
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
                            "name": "deleteRecord",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "type",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "getPrice",
                            "parameters": [],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": true
                        },
                        {
                            "name": "getRecord",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "type",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "String",
                            "safe": true
                        },
                        {
                            "name": "isAvailable",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": true
                        },
                        {
                            "name": "ownerOf",
                            "parameters": [
                                {
                                    "name": "tokenId",
                                    "type": "ByteArray"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Hash160",
                            "safe": true
                        },
                        {
                            "name": "properties",
                            "parameters": [
                                {
                                    "name": "tokenId",
                                    "type": "ByteArray"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Map",
                            "safe": true
                        },
                        {
                            "name": "register",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "owner",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Boolean",
                            "safe": false
                        },
                        {
                            "name": "renew",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Integer",
                            "safe": false
                        },
                        {
                            "name": "resolve",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "type",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "String",
                            "safe": true
                        },
                        {
                            "name": "setAdmin",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "admin",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "setPrice",
                            "parameters": [
                                {
                                    "name": "price",
                                    "type": "Integer"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
                            "safe": false
                        },
                        {
                            "name": "setRecord",
                            "parameters": [
                                {
                                    "name": "name",
                                    "type": "String"
                                },
                                {
                                    "name": "type",
                                    "type": "Integer"
                                },
                                {
                                    "name": "data",
                                    "type": "String"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Void",
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
                            "name": "tokensOf",
                            "parameters": [
                                {
                                    "name": "owner",
                                    "type": "Hash160"
                                }
                            ],
                            "offset": 0,
                            "returntype": "Any",
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
                                    "name": "to",
                                    "type": "Hash160"
                                },
                                {
                                    "name": "tokenId",
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
                                },
                                {
                                    "name": "tokenId",
                                    "type": "ByteArray"
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
            },
            "activeblockindex": 0
        }
    ]
}
```

