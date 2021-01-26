# sendfrom 方法

从指定地址，向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID（资产标识符），即 NEP-17合约的脚本哈希。

  如 NeoToken 为：0xf61eebf573ea36593fd43aa150c055ad7906ab83

  GasToken 为：0x70e2301955bf1e74cbb31d18c2f96972abadb328

- from：转账地址。

- address：收款地址。

- value：转账金额。

- signers：交易签名账户。


## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendfrom",
    "params": [
        "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        20
    ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x425bf77f08dd3e0815a4e95ab9109b73773b375c6e5402c51f65a0f7537f6fec",
        "size": 249,
        "version": 0,
        "nonce": 1556413479,
        "sender": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "sysfee": "0.0999954",
        "netfee": "0.0123261",
        "validuntilblock": 6129,
        "signers": [
            {
                "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CwAUDBT6ifssFN8PWd3fBPblZRfys0qu6wwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBSDqwZ5rVXAUKE61D9ZNupz9ese9kFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEBq62IVg6HCr2qLAARGS5E/7bWLu1bm6k5Z6Njjwp4/DdNgDnPYw5wcTzeQULSlEx1QvHLsHJCht/43XZsiaz8T",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
