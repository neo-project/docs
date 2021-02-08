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
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
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
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x0f8232a7395661d3501ba600f9bf45a261d4b8c5400696be771562b223d35358",
        "size": 337,
        "version": 0,
        "nonce": 1372416014,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "19999080",
        "netfee": "1320550",
        "validuntilblock": 5819,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CxoMFOK2UyJyk+mcTykG1TVTq7Smct+GDBT6ifssFN8PWd3fBPblZRfys0qu6xTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5CwKA8PoCDBTitlMicpPpnE8pBtU1U6u0pnLfhgwU+on7LBTfD1nd3wT25WUX8rNKrusUwB8MCHRyYW5zZmVyDBQos62rcmn5whgds8t0Hr9VGTDicEFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DECejDPVz78go5cSN1B5gwnkmMxCsbjst2oqZFNmzFR75xjfVnYqpnwfzROAImrmC40MN6fis9MqMD/zEHcf71cu",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
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
