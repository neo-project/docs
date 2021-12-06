# getnep17transfers 方法

返回指定地址内的所有 NEP-17 交易记录。

> [!Note]
>
此方法由插件提供，需要安装 [TokensTracker](https://github.com/neo-project/neo-modules/releases) 、[LevelDBStore](https://github.com/neo-project/neo-modules/releases) 和 [RpcSever](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- address：要查看交易记录的地址。

- startTime | endTime：可选参数，UTC 时间戳，统计资产开始或截止时间（含）。

  - 如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
  - 如果仅设置一个时间戳，则返回自该时间戳以后发生的交易信息。
  - 如果不设置此参数，则返回近七天内的交易信息。

## 配置说明
调用该方法之前，需要在插件 TokensTracker 的 config.json 文件中设置以下字段：

- MaxResults：最大记录数，超过数额将不会被存储。
- Network：需要与Neo-cli 的 config.json 中的Network设置相同。
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
        "sent": [],
        "received": [
            {
                "timestamp": 1612690497725,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 2,
                "transfernotifyindex": 1,
                "txhash": "0x5f957960a782514d6587c445288ee1cca7d6b0f952edc204f14d9be83b8152ff"
            },
            {
                "timestamp": 1612690513541,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "10000000000",
                "blockindex": 3,
                "transfernotifyindex": 0,
                "txhash": "0xe42108b343626035cb51fbcb54949bb38aac50c8ba278841d304e9fdce0807ac"
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
        "sent": [],
        "received": [
            {
                "timestamp": 1612690497725,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 2,
                "transfernotifyindex": 1,
                "txhash": "0x5f957960a782514d6587c445288ee1cca7d6b0f952edc204f14d9be83b8152ff"
            },
            {
                "timestamp": 1612690513541,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "10000000000",
                "blockindex": 3,
                "transfernotifyindex": 0,
                "txhash": "0xe42108b343626035cb51fbcb54949bb38aac50c8ba278841d304e9fdce0807ac"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```

