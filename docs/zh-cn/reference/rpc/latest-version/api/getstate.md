# getstate 方法

通过 root hash，合约 hash 和 storage key 查询 state。

> [!Note]
>
> 此方法由插件提供，需要安装 [StateService](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- roothash：state root 的 root hash。

- scripthash：合约 hash。

- key：存储区 key 值，使用 Base64 编码格式。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getstate",
  "params": ["0xec31cdb14da4143e2ab471a8b5812d895b88fc1c12d54e112791491feca9b5f4","0xb1fbb6b0096919071769906bb23b2ca2ec51eea7","AQFM8QSIkBuHVYOd2kiRmQXXOI833w=="],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "nMJ4AQ=="
}
```