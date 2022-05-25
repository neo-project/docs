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
  "params": ["0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "id": 383,
        "updatecounter": 0,
        "hash": "0xe7f2e74b3498d3a0d80bcbd5925bca32e4acc4f7",
        "nef": {
            "magic": 860243278,
            "compiler": "Neo.Compiler.CSharp 3.1.0",
            "source": "https://github.com/neo-project/neo",
            "tokens": [
                {
                    "hash": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd",
                    "method": "update",
                    "paramcount": 3,
                    "hasreturnvalue": false,
                    "callflags": "All"
                },
                {
                    "hash": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd",
                    "method": "destroy",
                    "paramcount": 0,
                    "hasreturnvalue": false,
                    "callflags": "All"
                },
                {
                    "hash": "0xfe924b7cfe89ddd271abaf7210a80a7e11178758",
                    "method": "request",
                    "paramcount": 5,
                    "hasreturnvalue": false,
                    "callflags": "All"
                },
                {
                    "hash": "0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0",
                    "method": "itoa",
                    "paramcount": 1,
                    "hasreturnvalue": true,
                    "callflags": "All"
                },
                {
                    "hash": "0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0",
                    "method": "jsonDeserialize",
                    "paramcount": 1,
                    "hasreturnvalue": true,
                    "callflags": "All"
                },
                {
                    "hash": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd",
                    "method": "getContract",
                    "paramcount": 1,
                    "hasreturnvalue": true,
                    "callflags": "All"
                },
                {
                    "hash": "0xda65b600f7124ce6c79950c1772a36403104f2be",
                    "method": "getTransaction",
                    "paramcount": 1,
                    "hasreturnvalue": true,
                    "callflags": "All"
                },
                {
                    "hash": "0xda65b600f7124ce6c79950c1772a36403104f2be",
                    "method": "getTransactionState",
                    "paramcount": 1,
                    "hasreturnvalue": true,
                    "callflags": "All"
                }
            ],
            "script": "WEH4J+yMQEH4J+yMQDTzQFkMBmVuYWJsZUsRzlCLUBDOQZJd6DFK2CYERRDbIRGzQErYJgRFENshQEsRzlCLUBDOQZJd6DFANLiqJhYMEU5vIGF1dGhvcml6YXRpb24uOlkMBmVuYWJsZRESTRHOUYtREM5B5j8YhEASTRHOUYtREM5B5j8YhEA1d////6omFgwRTm8gYXV0aG9yaXphdGlvbi46WQwGZW5hYmxlEBJNEc5Ri1EQzkHmPxiEQFcAAzVP////JgYiKyIpDCRQYXltZW50IGlzIGRpc2FibGUgb24gdGhpcyBjb250cmFjdCE6QFcBAzUJ////qiYWDBFObyBhdXRob3JpemF0aW9uLjoLenlB2/6odBTAcGgfDAh0cmFuc2ZlcnhBYn1bUkXCSnjPSnnPSnrPDAtVbmxvY2tFdmVudEGVAW9hEdsgIgJAQdv+qHRAQWJ9W1JAVwIAEMBwaB8MCGlzUGF1c2VkWtsoStgkCUrKABQoAzpBYn1bUnHCSmnPDA1Jc1BhdXNlZEV2ZW50QZUBb2FpIgJA2yhK2CQJSsoAFCgDOkBXAAJ5JgQiGgwFV29ybGQMBUhlbGxvQZv2Z85B5j8YhEBB5j8YhEBBm/ZnzkBXAAI1If7//6omFgwRTm8gYXV0aG9yaXphdGlvbi46C3l4NwAAQDcAAEA1+v3//6omFgwRTm8gYXV0aG9yaXphdGlvbi46NwEAQDcBAEBXAgMMCGNhbGxiYWNrcAwIdXNlcmRhdGFxemloeHk3AgBANwIAQFcDBEE5U248DBRYhxcRfgqoEHKvq3HS3Yn+fEuS/pgmEgwNVW5hdXRob3JpemVkITp6EJgmLgwiT3JhY2xlIHJlc3BvbnNlIGZhaWx1cmUgd2l0aCBjb2RlIHo3AwCL2yg6ezcEAHBocWkQznIMCnVzZXJkYXRhOiB5i9soQc/nR5YMEHJlc3BvbnNlIHZhbHVlOiBqi9soQc/nR5ZAQTlTbjxADBRYhxcRfgqoEHKvq3HS3Yn+fEuS/kA3BABAQc/nR5ZAVwACeXhBm/ZnzkHmPxiEQFcBABFwIhtZaDcDAGgSTRHOUYtREM5B5j8YhGhKnHBFaAHoA7Uk4kBXAQBB2/6odDcFAHBoFM4VziICQDcFAEBXAQBB2/6odDcFAHBoFM4TziICQFcCAEEtUQgwcGgQznHCSmk3BgDPDBBUcmFuc2FjdGlvblN0YXRlQZUBb2FpNwcAIgJAQS1RCDBANwYAQDcHAEBWAwwUwJjkrPCyCQ3Rbss9WN5CaocVhRtgDBRC5UOC6G3Nygng2ou2fi+sTUmHRGIMBWFzc2V0QZv2Z84SwGFAEsBA",
            "checksum": 1593448136
        },
        "manifest": {
            "name": "TestNetFee",
            "groups": [],
            "features": {},
            "supportedstandards": [
                "NEP-17"
            ],
            "abi": {
                "methods": [
                    {
                        "name": "verify",
                        "parameters": [],
                        "returntype": "Boolean",
                        "offset": 13,
                        "safe": false
                    },
                    {
                        "name": "getPaymentStatus",
                        "parameters": [],
                        "returntype": "Boolean",
                        "offset": 16,
                        "safe": false
                    },
                    {
                        "name": "enablePayment",
                        "parameters": [],
                        "returntype": "Void",
                        "offset": 72,
                        "safe": false
                    },
                    {
                        "name": "disablePayment",
                        "parameters": [],
                        "returntype": "Void",
                        "offset": 137,
                        "safe": false
                    },
                    {
                        "name": "onNEP17Payment",
                        "parameters": [
                            {
                                "name": "from",
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
                        "returntype": "Void",
                        "offset": 190,
                        "safe": false
                    },
                    {
                        "name": "unlock",
                        "parameters": [
                            {
                                "name": "toAssetHash",
                                "type": "Hash160"
                            },
                            {
                                "name": "toAddress",
                                "type": "Hash160"
                            },
                            {
                                "name": "amount",
                                "type": "Integer"
                            }
                        ],
                        "returntype": "Boolean",
                        "offset": 244,
                        "safe": false
                    },
                    {
                        "name": "isPaused",
                        "parameters": [],
                        "returntype": "Boolean",
                        "offset": 351,
                        "safe": false
                    },
                    {
                        "name": "_deploy",
                        "parameters": [
                            {
                                "name": "data",
                                "type": "Any"
                            },
                            {
                                "name": "update",
                                "type": "Boolean"
                            }
                        ],
                        "returntype": "Void",
                        "offset": 431,
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
                                "type": "String"
                            }
                        ],
                        "returntype": "Void",
                        "offset": 476,
                        "safe": false
                    },
                    {
                        "name": "destroy",
                        "parameters": [],
                        "returntype": "Void",
                        "offset": 518,
                        "safe": false
                    },
                    {
                        "name": "doRequest",
                        "parameters": [
                            {
                                "name": "filter",
                                "type": "String"
                            },
                            {
                                "name": "url",
                                "type": "String"
                            },
                            {
                                "name": "gasForResponse",
                                "type": "Integer"
                            }
                        ],
                        "returntype": "Void",
                        "offset": 554,
                        "safe": false
                    },
                    {
                        "name": "callback",
                        "parameters": [
                            {
                                "name": "url",
                                "type": "String"
                            },
                            {
                                "name": "userdata",
                                "type": "String"
                            },
                            {
                                "name": "code",
                                "type": "Integer"
                            },
                            {
                                "name": "result",
                                "type": "String"
                            }
                        ],
                        "returntype": "Void",
                        "offset": 592,
                        "safe": false
                    },
                    {
                        "name": "put",
                        "parameters": [
                            {
                                "name": "key",
                                "type": "String"
                            },
                            {
                                "name": "value",
                                "type": "String"
                            }
                        ],
                        "returntype": "Void",
                        "offset": 789,
                        "safe": false
                    },
                    {
                        "name": "putMulti",
                        "parameters": [],
                        "returntype": "Void",
                        "offset": 805,
                        "safe": false
                    },
                    {
                        "name": "testPermission",
                        "parameters": [],
                        "returntype": "Any",
                        "offset": 845,
                        "safe": false
                    },
                    {
                        "name": "testSupportedStandards",
                        "parameters": [],
                        "returntype": "Any",
                        "offset": 869,
                        "safe": false
                    },
                    {
                        "name": "getState",
                        "parameters": [],
                        "returntype": "Any",
                        "offset": 889,
                        "safe": false
                    },
                    {
                        "name": "_initialize",
                        "parameters": [],
                        "returntype": "Void",
                        "offset": 953,
                        "safe": false
                    }
                ],
                "events": [
                    {
                        "name": "UnlockEvent",
                        "parameters": [
                            {
                                "name": "arg1",
                                "type": "Hash160"
                            },
                            {
                                "name": "arg2",
                                "type": "Hash160"
                            },
                            {
                                "name": "arg3",
                                "type": "Integer"
                            }
                        ]
                    },
                    {
                        "name": "IsPausedEvent",
                        "parameters": [
                            {
                                "name": "obj",
                                "type": "Any"
                            }
                        ]
                    },
                    {
                        "name": "TransactionState",
                        "parameters": [
                            {
                                "name": "obj",
                                "type": "Any"
                            }
                        ]
                    }
                ]
            },
            "permissions": [
                {
                    "contract": "0x42e54382e86dcdca09e0da8bb67e2fac4d498744",
                    "methods": [
                        "test"
                    ]
                },
                {
                    "contract": "0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0",
                    "methods": [
                        "itoa",
                        "jsonDeserialize"
                    ]
                },
                {
                    "contract": "0xda65b600f7124ce6c79950c1772a36403104f2be",
                    "methods": [
                        "getTransaction",
                        "getTransactionState"
                    ]
                },
                {
                    "contract": "0xfe924b7cfe89ddd271abaf7210a80a7e11178758",
                    "methods": [
                        "request"
                    ]
                },
                {
                    "contract": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd",
                    "methods": [
                        "destroy",
                        "getContract",
                        "update"
                    ]
                }
            ],
            "trusts": [],
            "extra": {
                "Author": "Neo",
                "Email": "dev@neo.org",
                "Description": "This is a contract example"
            }
        }
    }
}
```

