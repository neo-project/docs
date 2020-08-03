# sendtoaddress 方法

向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID，即 NEP-5 合约的脚本哈希

  如 NEO 为：0xde5f57d430d3dece511cf975a8d37848cb9e0525

  GAS 为：0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc

  以上资产可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

- address：收款地址。

- value：转账金额。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "sendtoaddress",
  "params": ["0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc","NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch",21]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xfa17173184bce48315f72e11e42362f94019b345e72ca07fd630f186ae29f79f",
        "size": 378,
        "version": 0,
        "nonce": 1657481343,
        "sender": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8",
        "sysfee": "9007990",
        "netfee": "2378780",
        "validuntilblock": 2105205,
        "signers": [
            {
                "account": "0x84515341137defbf06b9d246a7ca210efcfa6298",
                "scopes": "FeeOnly"
            },
            {
                "account": "0xb120f50f804d3a203c43475212894ab1c911ce18",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgB1K30MFCUnUAaADnPMZChnU6OnMkIlIcjkDBQYzhHJsUqJElJHQzwgOk2AD/UgsRPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEBvKiq5NHkE3PsjbXe0YvNmSDq9c6PzoK1fsDljhEAvvoPSqhhoSj+gVyAuQqUKFuBM0O/+HM5xorM8vdm60hNb",
                "verification": "DCECIItAHAHzOQfla6fHzYkOv5cXTzazCk9DZ6xRAlIUXH4LQZVEDXg="
            },
            {
                "invocation": "DEAbhpq036r6sZaRSPXjv+cC6G85rhIDcnpvcFvNmsNFlFoUVUIoyBDUqa/1wxajj5yjH0VPgsvhlBwoK7hGOMZU",
                "verification": "DCECi9GQLE0UGfACuCHm3mU939U1gGMgjkJnVjmL5v+jqsgLQZVEDXg="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
