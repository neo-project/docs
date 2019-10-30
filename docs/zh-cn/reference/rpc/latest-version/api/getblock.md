# getblock 方法

根据指定的散列值，返回对应的区块信息。

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [hash, verbose],
  "id": 1
}
```
### 参数说明

* hash：区块散列值

* verbose：可选参数，verbose 默认值为 0
  *  verbose = 0：返回的是区块序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  * verbose = 1：返回的是对应区块的详细信息，用 Json 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be"],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "0000000000000000000000000000000000000000000000000000000000000000000000008e29af06ec157a3d85717b1eb7317c3ef4049a7222d76c6dd4d5a24598c6571665fc885700000000f071d5fc6d2e2978a45842f05b1ac970e87d197700015102001dac2b7c0000000000000000000568123e7fe8da1745e9b549bd0bfa1a569971c77eba30cd5a4b000000000000000000000000000000000000000000000151"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "hash": "0x479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be",
        "size": 164,
        "version": 0,
        "previousblockhash": "0x0000000000000000000000000000000000000000000000000000000000000000",
        "merkleroot": "0x1657c69845a2d5d46d6cd722729a04f43e7c31b71e7b71853d7a15ec06af298e",
        "time": 1468595301,
        "index": 0,
        "nextconsensus": "AdhEBzaBZujuj5kEiwvKmMVy5ydqj3AC3V",
        "witness": {
            "invocation": "",
            "verification": "51"
        },
        "consensus_data": {
            "primary": 0,
            "nonce": "000000007c2bac1d"
        },
        "tx": [
            {
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
                }
            }
        ],
        "confirmations": 6180,
        "nextblockhash": "0x1c00023b24ba5328918f4a0adc35607c8f97913fdda88b4eb4c571e7bc613bf4"
    }
}
```
