# getnep17transfers 方法

返回指定地址内的所有 NEP-17 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep17Tracker](https://github.com/neo-project/neo-modules/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

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
    "method": "getnep17transfers",
    "params": ["NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"],
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
                "timestamp": 1611565978345,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "99999999",
                "blockindex": 94,
                "transfernotifyindex": 1,
                "txhash": "0xe3173802dda4797abbc383c5208ea39999c5ab8f3d2fc932ffd215fc3d703918"
            }
        ],
        "received": [
            {
                "timestamp": 1611565978345,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": null,
                "amount": "4499999955",
                "blockindex": 94,
                "transfernotifyindex": 0,
                "txhash": "0xe3173802dda4797abbc383c5208ea39999c5ab8f3d2fc932ffd215fc3d703918"
            },
            {
                "timestamp": 1611565978345,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "99999999",
                "blockindex": 94,
                "transfernotifyindex": 1,
                "txhash": "0xe3173802dda4797abbc383c5208ea39999c5ab8f3d2fc932ffd215fc3d703918"
            }
        ],
        "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
    }
}
```

示例 2 - 设置起始和结束时间戳：

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getnep17transfers",
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
                "assethash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transferaddress": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "blockindex": 54499,
                "transfernotifyindex": 0,
                "txhash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```

目前显示的金额是不带精度的，需要自己换算成正确的数值，如将 `3000004699999955` GAS 换算成 `30000046.99999955` GAS，之后可能会修改，以最新的代码为准。
