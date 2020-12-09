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
  "params": ["0x99042d380f2b754175717bb932a911bc0bb0ad7d"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "id": 8,
        "hash": "0x99042d380f2b754175717bb932a911bc0bb0ad7d",
        "script": "DBQKo4e1Ppa3mJpjFDGgVt0fQKBC9kH4J+yMQDTkQFcBAAwFSGVsbG9Bm/ZnzkGSXegxcGhAVwQBEnAMF0ludm9rZSBTdHJvYWdlLlB1dCBmb3IgaBpQQXvjun0MByB0aW1lcy6Li9soQc/nR5YMBUhlbGxveFBBm/ZnzkHmPxiEDAJOb0Gb9mfOQZJd6DHYqnNrJiwMAk5vDAJOb0Gb9mfOQZJd6DFK2CYFEFBF2yERnlBBm/ZnzkHmPxiEIhMhDAJObxFQQZv2Z85B5j8YhAwCTm9Bm/ZnzkGSXegxcWlK2CYFEFBF2yEaUEF747p9chXDShAMBFB1dCDQShF40EoSDB0gaW50byBzdG9yYWdlIGNvbXBsZXRlbHkgZm9yINBKE2rQShQMBiB0aW1lc9DBShEyCJ1Ti1Ai+EXbKEHP50eWeBHADARXb3JkQZUBb2FpEcAMDkludm9rZVB1dENvdW50QZUBb2FAVwECNZL+//8Qs3BoJhYMEU5vIGF1dGhvcml6YXRpb24uOnh5UEExxjMdQFcBADVn/v//ELNwaCYWDBFObyBhdXRob3JpemF0aW9uLjohQcafHfBAVgEMFAqjh7U+lreYmmMUMaBW3R9AoEL2YEA=",
        "manifest": {
            "groups": [],
            "supportedstandards": [],
            "abi": {
                "hash": "0x99042d380f2b754175717bb932a911bc0bb0ad7d",
                "methods": [
                    {
                        "name": "verify",
                        "parameters": [],
                        "offset": 28,
                        "returntype": "Boolean"
                    },
                    {
                        "name": "myMethod",
                        "parameters": [],
                        "offset": 31,
                        "returntype": "ByteArray"
                    },
                    {
                        "name": "put",
                        "parameters": [
                            {
                                "name": "word",
                                "type": "String"
                            }
                        ],
                        "offset": 54,
                        "returntype": "Void"
                    },
                    {
                        "name": "update",
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
                        "offset": 363,
                        "returntype": "Void"
                    },
                    {
                        "name": "destroy",
                        "parameters": [],
                        "offset": 406,
                        "returntype": "Void"
                    },
                    {
                        "name": "_initialize",
                        "parameters": [],
                        "offset": 447,
                        "returntype": "Void"
                    }
                ],
                "events": [
                    {
                        "name": "Word",
                        "parameters": [
                            {
                                "name": "obj",
                                "type": "String"
                            }
                        ]
                    },
                    {
                        "name": "InvokePutCount",
                        "parameters": [
                            {
                                "name": "obj",
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
            "safemethods": [],
            "extra": {
                "Author": "Neo",
                "Name": "Sample",
                "Email": "dev@neo.org",
                "Description": "This is a contract example"
            }
        }
    }
}
```

