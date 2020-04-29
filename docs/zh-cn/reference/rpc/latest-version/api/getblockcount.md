# getblockcount 方法

获取主链中区块的数量。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 991991
}
```

