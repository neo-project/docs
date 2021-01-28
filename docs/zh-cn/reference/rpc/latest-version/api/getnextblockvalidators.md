# getnextblockvalidators 方法

  获得下个区块的验证人列表。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnextblockvalidators",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": [
    {
      "publickey": "03aa052fbcb8e5b33a4eefd662536f8684641f04109f1d5e69cdda6f084890286a",
      "votes": "0",
      "active": true
    }
  ]
}
```

result 返回一个数组，里面会有多个验证人。

每个验证人包含 3 个信息，公钥、票数、是否是验证人。

> [!Note]
>
> 在没有投票时，默认的验证人票数为 0。