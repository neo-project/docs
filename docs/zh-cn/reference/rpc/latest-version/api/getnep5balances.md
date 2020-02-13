# getnep5balances 方法

返回指定地址内的所有 NEP-5 资产余额。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases) 和[LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

address：要查看资产余额的地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5balances",
  "params": ["NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": [
            {
                "asset_hash": "0x8d06bc235c2585c9d27ede8ed7085b3e13fc0c36",
                "amount": "9990000000000000",
                "last_updated_block": 17418
            },
            {
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "amount": "1002531616708175",
                "last_updated_block": 54499
            },
            {
                "asset_hash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "amount": "9999785",
                "last_updated_block": 54496
            },
            {
                "asset_hash": "0x433f0891e80c107b9e63d5f5b7cddf1fc35eb0b9",
                "amount": "9999200000000000",
                "last_updated_block": 19810
            },
            {
                "asset_hash": "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
                "amount": "9995000000000000",
                "last_updated_block": 17145
            }
        ],
        "address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1"
    }
}
```



> [!Note]
> 
>- 当未同步到发布合约的区块时，执行该 API 会报错，只有当区块同步到发布该合约资产的区块时，才会返回正确的结果。
> - 当输入的参数为非 NEP-5 标准的智能合约的 Script Hash 时，执行该 API 会报错。
>
> - 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。

