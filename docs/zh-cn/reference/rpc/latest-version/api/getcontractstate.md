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
  "params": ["0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
        "script": "VgIMFCvxc/hJ0dWRI9CXwAmqMWJNOec5YAwHAADBb/KGI2FXEAIhIUHpfTigDAEgs3BoJykAAAAhIQwUK/Fz+EnR1ZEj0JfACaoxYk055zkhQfgn7IxxI14BAAAhQel9OKAMAUCzcmonRgEAACEhQTlTbjxzeAwJYmFsYW5jZU9ml3RsJxQAAAB5EM4hNSoBAABxIyIBAAB4DAhkZWNpbWFsc5d1bScRAAAAITVrAQAAcSMDAQAAeAwGZGVwbG95l3ZuJxEAAAAhNXMBAABxI+YAAAB4DARuYW1ll3cHbwcnEQAAACE1CQIAAHEjyQAAAHgMBnN5bWJvbJd3CG8IJxEAAAAhNfkBAABxI6oAAAB4DBJzdXBwb3J0ZWRTdGFuZGFyZHOXdwlvCScRAAAAITXUAQAAcSN/AAAAeAwLdG90YWxTdXBwbHmXdwpvCicRAAAAITXSAQAAcSNbAAAAeAwIdHJhbnNmZXKXdwtvCyc+AAAAIXnKE7MQs3cPbw8nDAAAABBxIy8AAAB5EM53DHkRzncNeRLOdw5vDG8Nbw4hUzWqAQAAcSMNAAAAIRBxIwUAAABpQFcCASF4ygwBFLMQs3BoJzwAAAAMMlRoZSBwYXJhbWV0ZXIgYWNjb3VudCBTSE9VTEQgYmUgMjAtYnl0ZSBhZGRyZXNzZXMuIUU3IUGb9mfOeCFQQZJd6DFxIwUAAABpQBhAVwIBIXghQanFS0FwaCcNAAAAaBLOIwYAAAARcSMFAAAAaUBXAgAhIUGb9mfODAt0b3RhbFN1cHBseSFQQZJd6DFwIUGb9mfOIQwUK/Fz+EnR1ZEj0JfACaoxYk055zkhDAcAAMFv8oYjIVNB5j8YhCEhQZv2Z84MC3RvdGFsU3VwcGx5IQwHAADBb/KGIyFTQeY/GIQhIQshDBQr8XP4SdHVkSPQl8AJqjFiTTnnOSEMBwAAwW/yhiMhUwwIVHJhbnNmZXIUwEGVAW9hIRFxIwUAAABpQAwMRGF5IERheSBUZXN0QAwDRERBQBPDShAMBU5FUC010EoRDAVORVAtN9BKEgwGTkVQLTEw0EBXAQAhIUGb9mfODAt0b3RhbFN1cHBseSFQQZJd6DFwIwUAAABoQFcKAyF6ELZyaicMAAAAEHMjUgEAAHghQfgn7IwQs3RsJwwAAAAQcyM7AQAAecoMARSzELN1bScMAAAAEHMjJQEAACFBm/ZnznghUEGSXegxcGh6tXZuJwwAAAAQcyMFAQAAeHmzdwdvBycMAAAAEXMj8gAAAGh6s3cIbwgnGQAAACFBm/ZnznghUEEvWMXtISMXAAAAIUGb9mfOeGh6nyFTQeY/GIQhIUGb9mfOeSFQQZJd6DFxadh3CW8JJz0AAAAhDAdpZiBwYXNzIUHP50eWISFBm/Znznl6IVNB5j8YhCEMCHB1dCBwYXNzIUHP50eWISEjTwAAACEMBGVsc2UhQc/nR5YhIUGb9mfOeWl6niFTQeY/GIQhDCB0b192YWx1ZS5Bc0JpZ0ludGVnZXIoKSArIGFtb3VudCFBz+dHliEhIXh5eiFTDAhUcmFuc2ZlchTAQZUBb2EhEXMjBQAAAGtA",
        "manifest": {
            "groups": [],
            "features": {
                "storage": true,
                "payable": false
            },
            "abi": {
                "hash": "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
                "entryPoint": {
                    "name": "main",
                    "parameters": [
                        {
                            "name": "method",
                            "type": "String"
                        },
                        {
                            "name": "args",
                            "type": "Array"
                        }
                    ],
                    "returnType": "ByteArray"
                },
                "methods": [
                    {
                        "name": "balanceOf",
                        "parameters": [
                            {
                                "name": "account",
                                "type": "ByteArray"
                            }
                        ],
                        "returnType": "Integer"
                    },
                    {
                        "name": "decimals",
                        "parameters": [],
                        "returnType": "Integer"
                    },
                    {
                        "name": "deploy",
                        "parameters": [],
                        "returnType": "Boolean"
                    },
                    {
                        "name": "name",
                        "parameters": [],
                        "returnType": "String"
                    },
                    {
                        "name": "symbol",
                        "parameters": [],
                        "returnType": "String"
                    },
                    {
                        "name": "supportedStandards",
                        "parameters": [],
                        "returnType": "Array"
                    },
                    {
                        "name": "totalSupply",
                        "parameters": [],
                        "returnType": "Integer"
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
                        ],
                        "returnType": "Signature"
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
            "safeMethods": [],
            "extra": null
        }
    }
}
```

