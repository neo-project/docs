# getnep17transfers 方法

返回指定地址内的所有 NEP-17 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcNep17Tracker](https://github.com/neo-project/neo-modules/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

address：要查看资产余额的地址。

startTime：可选参数，UTC 时间戳，统计资产开始时间（含）。

endTime：可选参数，UTC 时间戳，统计资产截止时间（含）。

- 如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
- 如果仅设置一个时间戳，则返回自该时间戳以后发生的交易信息。
- 如果不设置此参数，则返回近七天内的交易信息。

## 调用示例

示例 1  - 设置起始时间戳：

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17transfers",
  "params": ["NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ", 0],
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
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "received": [
            {
                "timestamp": 1611715807166,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 4,
                "transfernotifyindex": 2,
                "txhash": "0x2e7ffdeaa9f74f1c0a85eb545d412b98d9821e9ebaffc373b116d17767e40c49"
            },
            {
                "timestamp": 1611715807166,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "1",
                "blockindex": 4,
                "transfernotifyindex": 1,
                "txhash": "0x9be136667651d0abd02f6976ff08b317f0c4689e0e95b4d1fb5f1fafefc4bfc1"
            },
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```

示例 2 - 设置起始和结束时间戳：

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getnep17transfers",
    "params": ["NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ", 1611716619654, 2011716619654],
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
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "received": [
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```


