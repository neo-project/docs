# getnep17balances 方法

返回指定地址内的所有 NEP-17 资产余额。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

address：要查看资产余额的地址。

startTime：可选参数，UTC 时间戳，统计资产开始时间（含）。

endTime：可选参数，UTC 时间戳，统计资产截止时间（含）。

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
                "amount": "3000004699999955",
                "lastupdatedblock": 94
            },
            {
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "amount": "99999999",
                "lastupdatedblock": 94
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
> - 目前显示的金额是不带精度的，需要自己换算成正确的数值，如将 `3000004699999955` GAS 换算成 `30000046.99999955` GAS，之后可能会修改，以最新的代码为准。

