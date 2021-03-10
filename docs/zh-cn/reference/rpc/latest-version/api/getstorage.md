# getstorage 方法

根据合约脚本散列和存储的 key，返回存储的 value，key 和 value 均为 Base64 编码。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

script_hash/id: 合约脚本散列或合约id。

key: 存储区的键，Base64 编码格式。

## 调用示例

请求正文：

`hello` 转 Base64 `aGVsbG8=`。

```json
{
    "jsonrpc": "2.0",
    "method": "getstorage",
    "params": ["0x99042d380f2b754175717bb932a911bc0bb0ad7d", "aGVsbG8="],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "d29ybGQ="
}
```

`d29ybGQ=` 转字符串 `world`。