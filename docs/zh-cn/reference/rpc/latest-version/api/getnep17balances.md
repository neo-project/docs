# getnep17balances 方法

返回指定地址内的所有 NEP-17 资产余额。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases)  [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- address：要查看资产余额的地址。

## 配置说明
使用时需要将TrackHistory设置为true，如果需要追溯空地址记录，则RecordNullAddressHistory需要设置为true。MaxResults表示记录的最多记录数，超过数额将不会被存储。Network需要配置为和neo-cli中的config.json中的magic相同。


```json
{
  "PluginConfiguration": {
    "DBPath": "Nep17BalanceData",
    "TrackHistory": true,
    "RecordNullAddressHistory": false,
    "MaxResults": 1000,
    "Network": 5195086
  }
}
```

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17balances",
  "params": ["NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF", 0],
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
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "amount": "3000000100000000",
                "lastupdatedblock": 2
            },
            {
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "amount": "99999900",
                "lastupdatedblock": 2
            }
        ],
        "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
    }
}
```

> [!Note]
> 
>- 当未同步到发布合约的区块时，执行该 API 会报错，只有当区块同步到发布该合约资产的区块时，才会返回正确的结果。
> - 当输入的参数为非 NEP-17 标准的智能合约的 Script Hash 时，执行该 API 会报错。
>- 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。

