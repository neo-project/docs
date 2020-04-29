# validateaddress 方法

验证地址是否是正确的 NEO 地址。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

address：地址。

> [!Note]
>
> 由于 Neo3 的 AddressVersion 已修改为53，所以标准地址均以 N 开头。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "isvalid": true
    }
}
```

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "152f1muMCNa7goXYhYAQC61hxEgGacmncB",
        "isvalid": false
    }
}
```



