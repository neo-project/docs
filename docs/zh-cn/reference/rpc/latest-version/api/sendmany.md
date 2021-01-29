# sendmany 方法

批量转账命令，并且可以指定找零地址。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

`[fromAddress]<outputs_array>`

- fromAddress： 资产出金的地址（可选）。

- outputs_array：数组，数组中的每个元素的数据结构如下：

  `{"asset": <asset>, "value": <value>, "address": <address>, "signers": <signers>}`

  - asset_id：资产 ID，即 NEP-17 合约的脚本哈希。

	  如 NeoToken 为：0xf61eebf573ea36593fd43aa150c055ad7906ab83

	  GasToken 为：0x70e2301955bf1e74cbb31d18c2f96972abadb328
  - value：转账金额。

  - address：收款地址。

  - signers：交易签名账户。


## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendmany",
    "params": [
        "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 1,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 0.5,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

请求正文（不包含 fromAddress）：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x4595231a7812d005d52ef00da438ff9d454401f431edd97cac07ac37c9ed3dc8",
        "size": 337,
        "version": 0,
        "nonce": 1728677081,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "0.1999908",
        "netfee": "0.0132055",
        "validuntilblock": 6143,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CxEMFOK2UyJyk+mcTykG1TVTq7Smct+GDBT6ifssFN8PWd3fBPblZRfys0qu6xTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5CwKA8PoCDBTitlMicpPpnE8pBtU1U6u0pnLfhgwU+on7LBTfD1nd3wT25WUX8rNKrusUwB8MCHRyYW5zZmVyDBQos62rcmn5whgds8t0Hr9VGTDicEFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEAUC+0vrddYCXqqT6UP1wsRC9N/N4tir4Pb1zeAgmGCtTKAHhnTshes+FNiQIn+OypIE6/zCUm6PMHqEHcTr3c9",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
            }
        ]
    }
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x9598b1ae5c6d339c04efe6d4a7e7f2c02dec22a7f6a77890650760becbf86ed3",
        "size": 554,
        "version": 0,
        "nonce": 1571115423,
        "sender": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8",
        "sysfee": "27023970",
        "netfee": "2554780",
        "validuntilblock": 2105186,
        "signers": [
            {
                "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
                "scopes": "CalledByEntry"
            },
            {
                "account": "0x1e01f56dbb2a9799422512752b900a5a49ca5d99",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgDh9QUMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBSYYvr8DiHKp0bSuQa/730TQVNRhBPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjgCAMLrCwwUmGL6/A4hyqdG0rkGv+99E0FTUYQMFJhi+vwOIcqnRtK5Br/vfRNBU1GEE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOBIMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBQYzhHJsUqJElJHQzwgOk2AD/UgsRPADAh0cmFuc2ZlcgwUJQWey0h406h1+RxRzt7TMNRXX95BYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEBIGjD61/KPyUq51sfsgla6MlruIbBG3eYkmI2cWXHrcGYMm6ucO6Va2Dc7v7mzF8XnQvJtrBVjv/caRpqt08OA",
                "verification": "DCECIItAHAHzOQfla6fHzYkOv5cXTzazCk9DZ6xRAlIUXH4LQZVEDXg="
            },
            {
                "invocation": "DEC5O1ZFX46Vhdm4H8uY3IfYWHMbMnIkl5QljOYK8lVIfinYfbvyFuHsELDUM1io1RrbShjwkoFiVG1UKfC0nlqC",
                "verification": "DCECi9GQLE0UGfACuCHm3mU939U1gGMgjkJnVjmL5v+jqsgLQZVEDXg="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

JSON 格式不正确，会返回 Parse error。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
