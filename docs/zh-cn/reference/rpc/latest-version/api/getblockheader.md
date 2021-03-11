# getblockheader 方法

根据指定的哈希或索引，返回对应的区块头信息。

该方法与 getblock 方法的用法一样，区别是 getblockheader 只获取区块头，而 getblock 获取完整区块。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- hash | index：区块哈希或区块索引（即区块高度=区块数-1）。
- verbose：可选参数，verbose 默认值为 false。
  - verbose 为 false 时返回的是区块的序列化后的信息，用 base64 编码表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 true（或 1） 时返回的是对应区块的详细信息，用 JSON 格式字符串表示。

## 调用示例

**示例1 - 获取序列化后的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [140],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAFrf0tgylRv20FkZygEC2UDiMHJTukXJPQ/DFP5sezdzm3A7VffHxK0b4rwXh/xR/zV24Mj6+Vhq25qoN1WlxRIBIKp7dwEAAIwAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/sKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768A"
}
```

**示例2 - 获取 JSON 格式的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [140, true],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getblockheader",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c", true]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x73377b6cfe14c30f3dc945ba537230e240d90201ca1959d0f61b9532d8d2df5a",
        "merkleroot": "0x12c5a55537a89adb6a58f9fac8e07635ff51fc8717bce21badc4c7f7553b709b",
        "time": 1612687482881,
        "primary": 0,
        "index": 140,
        "nextconsensus": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "witnesses": [
            {
                "invocation": "DEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/s",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "confirmations": 41,
        "nextblockhash": "0xd087785fc3cf5b59c6a4631bdbdd63ed3e44947c22eb69ba866ea9291473b2b5"
    }
}
```

