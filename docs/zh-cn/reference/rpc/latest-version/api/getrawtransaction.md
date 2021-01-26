# getrawtransaction 方法

根据指定的散列值，返回对应的交易信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

txid：交易 ID。

verbose：可选参数，verbose 默认值为 0。
- verbose 为 false 时返回的是区块的序列化后的信息，用 base64 编码表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
- verbose 为 true（或 1） 时返回的是对应区块的详细信息，用 JSON 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "ANgnYEm0lJgAAAAAAGjYIwAAAAAA3RYAAAL6ifssFN8PWd3fBPblZRfys0qu6wDitlMicpPpnE8pBtU1U6u0pnLfhgEAWwsC/+D1BQwU4rZTInKT6ZxPKQbVNVOrtKZy34YMFOK2UyJyk+mcTykG1TVTq7Smct+GFMAfDAh0cmFuc2ZlcgwUg6sGea1VwFChOtQ/WTbqc/XrHvZBYn1bUjkCQgxAY/4JOoJSLGwMMvxc5elWxXwHXi3zxKNgGYf2jgbVLy9FX5xI8tc39Lu1oxyCrw2BelnktKALzAhRzVgznxdI5ikMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4gtBlUQNeEIMQK3qKp7wuGlbpU5nScAgtH0hHR5NXjBRDYMCAXDeAFkTZpB9SAj0aM+0Sbi4lgIF/ckivH8MPKV24FsD699ZhrUrEQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
}
```

请求正文：

verbose = true，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0xe3173802dda4797abbc383c5208ea39999c5ab8f3d2fc932ffd215fc3d703918", true],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xe3173802dda4797abbc383c5208ea39999c5ab8f3d2fc932ffd215fc3d703918",
        "size": 382,
        "version": 0,
        "nonce": 1231038424,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "0.0999954",
        "netfee": "0.0234916",
        "validuntilblock": 5853,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "None"
            },
            {
                "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CwL/4PUFDBTitlMicpPpnE8pBtU1U6u0pnLfhgwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBSDqwZ5rVXAUKE61D9ZNupz9ese9kFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEBj/gk6glIsbAwy/Fzl6VbFfAdeLfPEo2AZh/aOBtUvL0VfnEjy1zf0u7WjHIKvDYF6WeS0oAvMCFHNWDOfF0jm",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
            },
            {
                "invocation": "DECt6iqe8LhpW6VOZ0nAILR9IR0eTV4wUQ2DAgFw3gBZE2aQfUgI9GjPtEm4uJYCBf3JIrx/DDylduBbA+vfWYa1",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "blockhash": "0xfb1fd0a25b3997ba791e9418132a9576d961d037eb637f73e6ec300742be7670",
        "confirmations": 117,
        "blocktime": 1611565978345
    }
}
```



