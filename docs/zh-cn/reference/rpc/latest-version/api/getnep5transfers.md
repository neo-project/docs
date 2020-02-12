# getnep5transfers 方法

返回指定地址内的所有 NEP-5 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep5Tracker](https://github.com/neo-project/neo-modules/releases) 和[LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

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
    "params": ["NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"],
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
                "timestamp": 1579170709527,
                "asset_hash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "100",
                "block_index": 54496,
                "transfer_notify_index": 0,
                "tx_hash": "0x49f40ea86de140849fc5eb1c1ab8dbbe4d1186c47807963a162338d979e79c0f"
            },
            {
                "timestamp": 1579170725318,
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "block_index": 54499,
                "transfer_notify_index": 0,
                "tx_hash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```

示例 2 - 设置起始和结束时间戳：

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getnep5transfers",
    "params": ["NNSri1QcdtidykMxryz1xpmzSFwEXeYohH", 1579170709528, 1579170725319],
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
                "timestamp": 1579170725318,
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "block_index": 54499,
                "transfer_notify_index": 0,
                "tx_hash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```


