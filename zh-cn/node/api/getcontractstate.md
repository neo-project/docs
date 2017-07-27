# getcontractstate 方法

根据合约脚本散列，查询合约信息。

## 参数说明

script_hash：合约脚本散列。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "id": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "type": "SystemShare",
        "name": [
            {
                "lang": "zh-CN",
                "name": "小蚁股"
            },
            {
                "lang": "en",
                "name": "AntShare"
            }
        ],
        "amount": "100000000",
        "available": "100000000",
        "precision": 0,
        "owner": "00",
        "admin": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "issuer": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "expiration": 2000000,
        "frozen": false
    }
}
```

