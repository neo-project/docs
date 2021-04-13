# sendfrom 方法

从指定地址，向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID（资产标识符），即 NEP-17合约的脚本哈希。

  如 NeoToken 为：0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5

  GasToken 为：0xd2a4cff31913016155e38e474a2c06d08be276cf

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
        "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5",
        "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        100000000
    ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xe01b16626dec583941c1053467100041ce868e3b35e5fe3a85e530792cc9149d",
        "size": 252,
        "version": 0,
        "nonce": 2114899852,
        "sender": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "sysfee": "9999540",
        "netfee": "1235610",
        "validuntilblock": 5810,
        "signers": [
            {
                "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CwIA4fUFDBT6ifssFN8PWd3fBPblZRfys0qu6wwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBQos62rcmn5whgds8t0Hr9VGTDicEFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEAUQ3hUPg/qi77rnSzXRgd2RYdZCsPDBa/n0a6M+sCsOpC/YyLPeeoqcVNAyh73qpocOqdX1tnGeizh+C8cXoK0",
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
