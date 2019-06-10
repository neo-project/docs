# getnep5balances 方法

返回指定地址内的所有 NEP-5 资产余额。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

address：要查看资产余额的地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5balances",
  "params": ["1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3"],
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
                "asset_hash": "a48b6e1291ba24211ad11bb90ae2a10bf1fcd5a8",
                "amount": "50000000000",
                "last_updated_block": 251604
            },
            {
                "asset_hash": "1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3",
                "amount": "50000000000",
                "last_updated_block": 251600
            }
        ],
        "address": "AY6eqWjsUFCzsVELG7yG72XDukKvC34p2w"
    }
}
```



> [!Note]
> 
>- 当未同步到发布合约的区块时，执行该 API 会报错，只有当区块同步到发布该合约资产的区块时，才会返回正确的结果。
> - 当输入的参数为非 NEP-5 标准的智能合约的 Script Hash 时，执行该 API 会报错。
>
> - 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。

