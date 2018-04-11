# getaccountstate 方法

根据账户地址，查询账户资产信息。

## 参数说明

address：账户地址，以 A 开头的 34 位长度的字符串，如 AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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
        "script_hash": "1179716da2e9523d153a35fb3ad10c561b1e5b1a",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "94"
            }
        ]
    }
}
```

响应说明：

script_hash：合约脚本散列，在 NEO 中所有账户都是合约账户。

frozen：该账户是否冻结。

votes：查询该地址用于投票的 NEO

balance：该地址的资产余额。

asset：资产 ID

value：资产金额。

