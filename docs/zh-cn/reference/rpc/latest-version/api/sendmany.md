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

  `{"asset": <asset>,"value": <value>,"address": <address>}`

  - asset_id：资产 ID，即 NEP-5 合约的脚本哈希。

	  如 NEO 为：0xde5f57d430d3dece511cf975a8d37848cb9e0525

	  GAS 为：0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc
  - value：转账金额。

  - address：收款地址。


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "sendmany",
  "params": [
    "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y",
    [
      {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 2,
                "address": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8"
            },
            {
                "asset": "0xde5f57d430d3dece511cf975a8d37848cb9e0525",
                "value": 2,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
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
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 2,
                "address": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8"
            },
            {
                "asset": "0xde5f57d430d3dece511cf975a8d37848cb9e0525",
                "value": 2,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
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
                "account": "0x84515341137defbf06b9d246a7ca210efcfa6298",
                "scopes": "CalledByEntry"
            },
            {
                "account": "0xb120f50f804d3a203c43475212894ab1c911ce18",
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
