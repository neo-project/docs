# sendfrom 方法

从指定地址，向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID（资产标识符），即 NEP-5合约的脚本哈希。

  如 NEO 为：0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

  Gas 为：0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

- from：转账地址。

- address：收款地址。

- value：转账金额。


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendfrom",
  "params": ["0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789","NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1","NZos4XyLUEUrD7RQBn9J1A1PyeCwQKqwtT", 100],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xce199d5e5234b3e6090c92eec809839f5f0c89c1fca496612715a7135e031147",
        "size": 265,
        "version": 0,
        "nonce": 1328111799,
        "sender": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "sys_fee": "100000000",
        "net_fee": "1265390",
        "valid_until_block": 2139664,
        "attributes": [],
        "cosigners": [
            {
                "account": "0x39e7394d6231aa09c097d02391d5d149f873f12b",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AGQMFJhqJxj678F6Dhr7cKZZf5jiYWxuDBQr8XP4SdHVkSPQl8AJqjFiTTnnORPADAh0cmFuc2ZlcgwUiXcg2M129PAKv6N8Dt2InCCP3ptBYn1bUjk=",
        "witnesses": [
            {
                "invocation": "DECZTw4d1vAWFBCV3hTDNmxeXKv4tBciY3n2rS1HLlSfcbqh86qs5C+hxNse/L7+WVI+i9KpFUx2eqdIF/P4QGKk",
                "verification": "DCEDucRsbVxnHvXCG8eqfDBGiusIGi44lSaa35R3GNZQzh4LQQqQatQ="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
