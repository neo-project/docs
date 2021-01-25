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
  - verbose 为 true（或 1） 时返回的是对应区块的详细信息，用 Json 格式字符串表示。

## 调用示例

**示例1 - 获取序列化后的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [4],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAPKlYFvxWXWiC6fBuxNdcEdT4/vit3BJeCEOe7Igh1nh3Gj9UEwqbv772NBC0sONn35vQ2PQ3duR1T5ahI1zsdkCFbw4dwEAAAQAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEBEfgRU7VEEbzdGIYvT7NkZYBfSZfuQVkBe0j0n15WW4yr9puAfBVKKDbf35sM2JfDEPh+KHFyxa7Qc2jFj4JMgKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768A"
}
```

**示例1 - 获取 Json 格式的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [4, true],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa", true],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa",
        "size": 213,
        "version": 0,
        "previousblockhash": "0xe1598720b27b0e21784970b7e2fbe35347705d13bbc1a70ba27559f15b60a5f2",
        "merkleroot": "0xd9b1738d845a3ed591dbddd063436f7e9f8dc3d242d0d8fbfe6e2a4c50fd68dc",
        "time": 1611564586242,
        "index": 4,
        "nextconsensus": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "witnesses": [
            {
                "invocation": "DEBEfgRU7VEEbzdGIYvT7NkZYBfSZfuQVkBe0j0n15WW4yr9puAfBVKKDbf35sM2JfDEPh+KHFyxa7Qc2jFj4JMg",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "confirmations": 37,
        "nextblockhash": "0x4acb84ce4c125a08aba5e619b39db8c89a56fd9a99fdcc9affa2c218905c26ac"
    }
}
```

