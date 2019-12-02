# getrawtransaction 方法

根据指定的散列值，返回对应的交易信息。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["dd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6"],
  "id": 1
}
```

### 参数说明

* txid：交易 ID。

* verbose：可选参数，verbose 默认值为 0:
  * 为 0 时，返回的是交易的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  *  为 1 时，返回的是对应交易的详细信息，用 Json 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["dd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6"],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "00000000000568123e7fe8da1745e9b549bd0bfa1a569971c77eba30cd5a4b000000000000000000000000000000000000000000000151""
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["dd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": {
        "txid": "0xdd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6", 
        "size": 55, 
        "version": 0, 
        "nonce": 0, 
        "script": "68123e7fe8", 
        "sender": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt", 
        "gas": "0", 
        "net_fee": "0", 
        "valid_until_block": 0, 
        "attributes": [ ], 
        "witness": {
            "invocation": "", 
            "verification": "51"
        }, 
        "blockhash": "0x479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be", 
        "confirmations": 6180, 
        "blocktime": 1468595301
    }
}
```
