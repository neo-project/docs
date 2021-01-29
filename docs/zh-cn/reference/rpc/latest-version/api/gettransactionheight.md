# gettransactionheight 方法

获取交易高度。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

txid：交易 id。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "gettransactionheight",
  "params": ["0x57280b29c2f9051af6e28a8662b160c216d57c498ee529e0cf271833f90e1a53"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 14
}
```

响应说明：

返回该交易的高度。
