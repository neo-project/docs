# getnativecontracts Method

Gets the native contracts list, which includes the basic information of native contracts and the contract descriptive file manifest.json.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "getnativecontracts",
    "params": []
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "id": -1,
            "hash": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0A=",
                "checksum": 1110259869
            },
            "manifest": {
                "name": "ContractManagement",
                "groups": [],
                "features": {},
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
                            "returntype": "Array",
                            "offset": 0,
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
                            "returntype": "Array",
                            "offset": 7,
                            "safe": false
                        },
                        {
                            "name": "destroy",
                            "parameters": [],
                            "returntype": "Void",
                            "offset": 14,
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
                            "returntype": "Array",
                            "offset": 21,
                            "safe": true
                        },
                        {
                            "name": "getMinimumDeploymentFee",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 28,
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
                            "returntype": "Void",
                            "offset": 35,
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
                            "returntype": "Void",
                            "offset": 42,
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
                            "returntype": "Void",
                            "offset": 49,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -2,
            "hash": "0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0A=",
                "checksum": 1325686241
            },
            "manifest": {
                "name": "StdLib",
                "groups": [],
                "features": {},
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "atoi",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "String"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 0,
                            "safe": true
                        },
                        {
                            "name": "atoi",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "String"
                                },
                                {
                                    "name": "base",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 7,
                            "safe": true
                        },
                        {
                            "name": "base58CheckDecode",
                            "parameters": [
                                {
                                    "name": "s",
                                    "type": "String"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 14,
                            "safe": true
                        },
                        {
                            "name": "base58CheckEncode",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "String",
                            "offset": 21,
                            "safe": true
                        },
                        {
                            "name": "base58Decode",
                            "parameters": [
                                {
                                    "name": "s",
                                    "type": "String"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 28,
                            "safe": true
                        },
                        {
                            "name": "base58Encode",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "String",
                            "offset": 35,
                            "safe": true
                        },
                        {
                            "name": "base64Decode",
                            "parameters": [
                                {
                                    "name": "s",
                                    "type": "String"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 42,
                            "safe": true
                        },
                        {
                            "name": "base64Encode",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "String",
                            "offset": 49,
                            "safe": true
                        },
                        {
                            "name": "deserialize",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "Any",
                            "offset": 56,
                            "safe": true
                        },
                        {
                            "name": "itoa",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "String",
                            "offset": 63,
                            "safe": true
                        },
                        {
                            "name": "itoa",
                            "parameters": [
                                {
                                    "name": "value",
                                    "type": "Integer"
                                },
                                {
                                    "name": "base",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "String",
                            "offset": 70,
                            "safe": true
                        },
                        {
                            "name": "jsonDeserialize",
                            "parameters": [
                                {
                                    "name": "json",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "Any",
                            "offset": 77,
                            "safe": true
                        },
                        {
                            "name": "jsonSerialize",
                            "parameters": [
                                {
                                    "name": "item",
                                    "type": "Any"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 84,
                            "safe": true
                        },
                        {
                            "name": "memoryCompare",
                            "parameters": [
                                {
                                    "name": "str1",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "str2",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 91,
                            "safe": true
                        },
                        {
                            "name": "memorySearch",
                            "parameters": [
                                {
                                    "name": "mem",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "value",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 98,
                            "safe": true
                        },
                        {
                            "name": "memorySearch",
                            "parameters": [
                                {
                                    "name": "mem",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "value",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "start",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 105,
                            "safe": true
                        },
                        {
                            "name": "memorySearch",
                            "parameters": [
                                {
                                    "name": "mem",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "value",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "start",
                                    "type": "Integer"
                                },
                                {
                                    "name": "backward",
                                    "type": "Boolean"
                                }
                            ],
                            "returntype": "Integer",
                            "offset": 112,
                            "safe": true
                        },
                        {
                            "name": "serialize",
                            "parameters": [
                                {
                                    "name": "item",
                                    "type": "Any"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 119,
                            "safe": true
                        },
                        {
                            "name": "stringSplit",
                            "parameters": [
                                {
                                    "name": "str",
                                    "type": "String"
                                },
                                {
                                    "name": "separator",
                                    "type": "String"
                                }
                            ],
                            "returntype": "Array",
                            "offset": 126,
                            "safe": true
                        },
                        {
                            "name": "stringSplit",
                            "parameters": [
                                {
                                    "name": "str",
                                    "type": "String"
                                },
                                {
                                    "name": "separator",
                                    "type": "String"
                                },
                                {
                                    "name": "removeEmptyEntries",
                                    "type": "Boolean"
                                }
                            ],
                            "returntype": "Array",
                            "offset": 133,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -3,
            "hash": "0x726cb6e0cd8628a1350a611384688911ab75f51b",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dA",
                "checksum": 1592866325
            },
            "manifest": {
                "name": "CryptoLib",
                "groups": [],
                "features": {},
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "ripemd160",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 0,
                            "safe": true
                        },
                        {
                            "name": "sha256",
                            "parameters": [
                                {
                                    "name": "data",
                                    "type": "ByteArray"
                                }
                            ],
                            "returntype": "ByteArray",
                            "offset": 7,
                            "safe": true
                        },
                        {
                            "name": "verifyWithECDsa",
                            "parameters": [
                                {
                                    "name": "message",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "pubkey",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "signature",
                                    "type": "ByteArray"
                                },
                                {
                                    "name": "curve",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "Boolean",
                            "offset": 14,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -4,
            "hash": "0xda65b600f7124ce6c79950c1772a36403104f2be",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dA",
                "checksum": 529571427
            },
            "manifest": {
                "name": "LedgerContract",
                "groups": [],
                "features": {},
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "currentHash",
                            "parameters": [],
                            "returntype": "Hash256",
                            "offset": 0,
                            "safe": true
                        },
                        {
                            "name": "currentIndex",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 7,
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
                            "returntype": "Array",
                            "offset": 14,
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
                            "returntype": "Array",
                            "offset": 21,
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
                            "returntype": "Array",
                            "offset": 28,
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
                            "returntype": "Integer",
                            "offset": 35,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -5,
            "hash": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0A=",
                "checksum": 588003825
            },
            "manifest": {
                "name": "NeoToken",
                "groups": [],
                "features": {},
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
                            "returntype": "Integer",
                            "offset": 0,
                            "safe": true
                        },
                        {
                            "name": "decimals",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 7,
                            "safe": true
                        },
                        {
                            "name": "getAccountState",
                            "parameters": [
                                {
                                    "name": "account",
                                    "type": "Hash160"
                                }
                            ],
                            "returntype": "Array",
                            "offset": 14,
                            "safe": true
                        },
                        {
                            "name": "getCandidates",
                            "parameters": [],
                            "returntype": "Array",
                            "offset": 21,
                            "safe": true
                        },
                        {
                            "name": "getCommittee",
                            "parameters": [],
                            "returntype": "Array",
                            "offset": 28,
                            "safe": true
                        },
                        {
                            "name": "getGasPerBlock",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 35,
                            "safe": true
                        },
                        {
                            "name": "getNextBlockValidators",
                            "parameters": [],
                            "returntype": "Array",
                            "offset": 42,
                            "safe": true
                        },
                        {
                            "name": "getRegisterPrice",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 49,
                            "safe": true
                        },
                        {
                            "name": "registerCandidate",
                            "parameters": [
                                {
                                    "name": "pubkey",
                                    "type": "PublicKey"
                                }
                            ],
                            "returntype": "Boolean",
                            "offset": 56,
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
                            "returntype": "Void",
                            "offset": 63,
                            "safe": false
                        },
                        {
                            "name": "setRegisterPrice",
                            "parameters": [
                                {
                                    "name": "registerPrice",
                                    "type": "Integer"
                                }
                            ],
                            "returntype": "Void",
                            "offset": 70,
                            "safe": false
                        },
                        {
                            "name": "symbol",
                            "parameters": [],
                            "returntype": "String",
                            "offset": 77,
                            "safe": true
                        },
                        {
                            "name": "totalSupply",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 84,
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
                            "returntype": "Boolean",
                            "offset": 91,
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
                            "returntype": "Integer",
                            "offset": 98,
                            "safe": true
                        },
                        {
                            "name": "unregisterCandidate",
                            "parameters": [
                                {
                                    "name": "pubkey",
                                    "type": "PublicKey"
                                }
                            ],
                            "returntype": "Boolean",
                            "offset": 105,
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
                                    "type": "PublicKey"
                                }
                            ],
                            "returntype": "Boolean",
                            "offset": 112,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -6,
            "hash": "0xd2a4cff31913016155e38e474a2c06d08be276cf",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0A=",
                "checksum": 2663858513
            },
            "manifest": {
                "name": "GasToken",
                "groups": [],
                "features": {},
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
                            "returntype": "Integer",
                            "offset": 0,
                            "safe": true
                        },
                        {
                            "name": "decimals",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 7,
                            "safe": true
                        },
                        {
                            "name": "symbol",
                            "parameters": [],
                            "returntype": "String",
                            "offset": 14,
                            "safe": true
                        },
                        {
                            "name": "totalSupply",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 21,
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
                            "returntype": "Boolean",
                            "offset": 28,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -7,
            "hash": "0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dA",
                "checksum": 3443651689
            },
            "manifest": {
                "name": "PolicyContract",
                "groups": [],
                "features": {},
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
                            "returntype": "Boolean",
                            "offset": 0,
                            "safe": false
                        },
                        {
                            "name": "getExecFeeFactor",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 7,
                            "safe": true
                        },
                        {
                            "name": "getFeePerByte",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 14,
                            "safe": true
                        },
                        {
                            "name": "getStoragePrice",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 21,
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
                            "returntype": "Boolean",
                            "offset": 28,
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
                            "returntype": "Void",
                            "offset": 35,
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
                            "returntype": "Void",
                            "offset": 42,
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
                            "returntype": "Void",
                            "offset": 49,
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
                            "returntype": "Boolean",
                            "offset": 56,
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -8,
            "hash": "0x49cf4e5378ffcd4dec034fd98a174c5491e395e2",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0A=",
                "checksum": 983638438
            },
            "manifest": {
                "name": "RoleManagement",
                "groups": [],
                "features": {},
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
                            "returntype": "Void",
                            "offset": 0,
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
                            "returntype": "Array",
                            "offset": 7,
                            "safe": true
                        }
                    ],
                    "events": [
                        {
                            "name": "Designation",
                            "parameters": [
                                {
                                    "name": "Role",
                                    "type": "Integer"
                                },
                                {
                                    "name": "BlockIndex",
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
            "updatehistory": [
                0
            ]
        },
        {
            "id": -9,
            "hash": "0xfe924b7cfe89ddd271abaf7210a80a7e11178758",
            "nef": {
                "magic": 860243278,
                "compiler": "neo-core-v3.0",
                "source": "",
                "tokens": [],
                "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0A=",
                "checksum": 2663858513
            },
            "manifest": {
                "name": "OracleContract",
                "groups": [],
                "features": {},
                "supportedstandards": [],
                "abi": {
                    "methods": [
                        {
                            "name": "finish",
                            "parameters": [],
                            "returntype": "Void",
                            "offset": 0,
                            "safe": false
                        },
                        {
                            "name": "getPrice",
                            "parameters": [],
                            "returntype": "Integer",
                            "offset": 7,
                            "safe": true
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
                            "returntype": "Void",
                            "offset": 14,
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
                            "returntype": "Void",
                            "offset": 21,
                            "safe": false
                        },
                        {
                            "name": "verify",
                            "parameters": [],
                            "returntype": "Boolean",
                            "offset": 28,
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
            "updatehistory": [
                0
            ]
        }
    ]
}
```

