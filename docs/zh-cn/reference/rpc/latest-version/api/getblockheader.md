# getblockheader 方法

根据指定的哈希或索引，返回对应的区块头信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- hash | index：区块哈希或索引（即区块高度 = 区块数 - 1）

- verbose：可选参数，verbose 默认值为 0。
  - verbose 为 0 时返回的是区块的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 1 时返回的是对应区块的详细信息，用 Json 格式字符串表示。

## 调用示例

**示例1 - 使用区块哈希调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768A"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x7b895d302b435fb452e94f7938df416129da62caa0abbbb77a69a4c656281223",
        "merkleroot": "0xc30fa2a389b4f9d86ec4e952c1fb010014b1aca0f17722f85c5b288d390b0aeb",
        "time": 1605687708300,
        "index": 7368,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wC",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "confirmations": 12,
        "nextblockhash": "0x1545a328149baf8037873793d7e45d27385221dd69ddb606ee55434eb173a3ff"
    }
}
```

**示例2 - 使用区块索引调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [7368],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768A"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [7368, 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x7b895d302b435fb452e94f7938df416129da62caa0abbbb77a69a4c656281223",
        "merkleroot": "0xc30fa2a389b4f9d86ec4e952c1fb010014b1aca0f17722f85c5b288d390b0aeb",
        "time": 1605687708300,
        "index": 7368,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wC",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "confirmations": 16,
        "nextblockhash": "0x1545a328149baf8037873793d7e45d27385221dd69ddb606ee55434eb173a3ff"
    }
}
```

