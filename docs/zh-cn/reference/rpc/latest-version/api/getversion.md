# getversion 方法

获取查询节点的版本信息。
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
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "tcpPort": 21333,
        "wsPort": 21334,
        "nonce": 1403108496,
        "userAgent": "/Neo:3.0.0-preview1/"
    }
}
```

