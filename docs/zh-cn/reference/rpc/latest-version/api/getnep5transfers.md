# getnep5transfers 方法

返回指定地址内的所有 NEP-5 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

address：要查看交易记录的地址。

timestamp (可选)：

- 如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
- 如果仅设置一个时间戳，则返回自该时间戳以后发生的交易信息。
- 如果不设置此参数，则返回近七天内的交易信息。

## 调用示例

示例 1  - 不设置时间戳：

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

示例 2 - 设置起始和结束时间戳：

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5transfers",
  "params": ["AbHgdBaWEnHkCiLtDZXjhvhaAK2cwFh5pF",1553105830, 1557305830],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "sent": [
            {
                "timestamp": 1554283931,
                "asset_hash": "1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "100000000000",
                "block_index": 368082,
                "transfer_notify_index": 0,
                "tx_hash": "240ab1369712ad2782b99a02a8f9fcaa41d1e96322017ae90d0449a3ba52a564"
            },
            {
                "timestamp": 1554880287,
                "asset_hash": "1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "100000000000",
                "block_index": 397769,
                "transfer_notify_index": 0,
                "tx_hash": "12fdf7ce8b2388d23ab223854cb29e5114d8288c878de23b7924880f82dfc834"
            },
            {
                "timestamp": 1554880302,
                "asset_hash": "093430c81a5be01047263095f564d6b56b67ca7c",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "100000000000",
                "block_index": 397770,
                "transfer_notify_index": 0,
                "tx_hash": "cc1970d714d72cdf6f1871310b61d75f0a18c340b3f5e6b00e11d871aef96f61"
            },
            {
                "timestamp": 1554880351,
                "asset_hash": "a48b6e1291ba24211ad11bb90ae2a10bf1fcd5a8",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "100000000000",
                "block_index": 397772,
                "transfer_notify_index": 0,
                "tx_hash": "254379c8b109c961b8394ffebaca689866e2696bc3041aca659696c491e3a325"
            },
            {
                "timestamp": 1556002890,
                "asset_hash": "093430c81a5be01047263095f564d6b56b67ca7c",
                "transfer_address": "AS5z6s7FxNFQJS6aCoZce3GJV3yyZtejnU",
                "amount": "1000000000",
                "block_index": 453286,
                "transfer_notify_index": 0,
                "tx_hash": "3aa3859774aefbff277a46857dd68b7d6e93d0e214bd0b17763471e84f557dff"
            }
        ],
        "received": [
            {
                "timestamp": 1555055087,
                "asset_hash": "ed5620eec5759861842e8182524fdb0321e6d831",
                "transfer_address": "AFmseVrdL9f9oyCzZefL9tG6UbvhPbdYzM",
                "amount": "200000000000000",
                "block_index": 406373,
                "transfer_notify_index": 0,
                "tx_hash": "73e55f8048367f86d7da92b29ea38b739f984e86759bdeacd2244d491e60e9eb"
            },
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


