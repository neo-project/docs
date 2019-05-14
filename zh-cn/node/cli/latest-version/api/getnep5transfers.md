# getnep5transfers 方法

返回指定地址内的所有 NEP-5 交易记录。

## 参数说明

address：要查看交易记录的地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5transfers",
  "params": ["AbHgdBaWEnHkCiLtDZXjhvhaAK2cwFh5pF"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "sent": [],
        "received": [
            {
                "timestamp": 1555651816,
                "asset_hash": "600c4f5200db36177e3e8a09e9f18e2fc7d12a0f",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "1000000",
                "block_index": 436036,
                "transfer_notify_index": 0,
                "tx_hash": "df7683ece554ecfb85cf41492c5f143215dd43ef9ec61181a28f922da06aba58"
            }
        ],
        "address": "AbHgdBaWEnHkCiLtDZXjhvhaAK2cwFh5pF"
    }
}
```


