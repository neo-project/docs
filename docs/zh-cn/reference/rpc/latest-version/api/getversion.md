# getversion 方法

获取节点的版本信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "tcpport": 10333,
        "wsport": 10334,
        "nonce": 639577408,
        "useragent": "/Neo:3.0.0-CI01171/",
        "magic": 5195086
    }
}
```

