# getbestblockhash 方法

获取主链中高度最大的区块的散列。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbestblockhash",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0xbee7a65279d6b31cc45445a7579d4c4a4e52d1edc13cc7ec7a41f7b1affdf0ab"
}
```

响应说明：

result：主链中高度最大的区块的散列。

