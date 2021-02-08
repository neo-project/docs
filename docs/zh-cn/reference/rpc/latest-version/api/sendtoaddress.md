# sendtoaddress 方法

向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID，即 NEP-17 合约的脚本哈希

  如 NeoToken 为：0xf61eebf573ea36593fd43aa150c055ad7906ab83

  GasToken 为：0x70e2301955bf1e74cbb31d18c2f96972abadb328

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
    "params": [
        "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        1
    ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5c721fb081d70ff4d6af716793130d024702fa789800c35e0f6763244a7589df",
        "size": 246,
        "version": 0,
        "nonce": 376451427,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "9999540",
        "netfee": "1229550",
        "validuntilblock": 5786,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CxEMFOK2UyJyk+mcTykG1TVTq7Smct+GDBT6ifssFN8PWd3fBPblZRfys0qu6xTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEB9iM26NTkdhHkiIji4Cwk+5Ng9cfThzzPiOqz71ymvFWVKBx4/GMK4LQzaSO6PQwyGe8jrlieB2JEHWCf18mXX",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
