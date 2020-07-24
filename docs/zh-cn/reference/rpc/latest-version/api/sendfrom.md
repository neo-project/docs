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
  "id": 1,
  "method": "sendfrom",
  "params": ["0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc","NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y","NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8", 20]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5530ac26a55ec9652ee2300879ba8dcbe0abe2d4a077426fc6783bbc269ba39b",
        "size": 248,
        "version": 0,
        "nonce": 737954039,
        "sender": "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y",
        "sysfee": "9007990",
        "netfee": "1248390",
        "validuntilblock": 2105164,
        "signers": [
            {
                "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgCUNXcMFJhi+vwOIcqnRtK5Br/vfRNBU1GEDBQcA1dGS3d+z2tfOsOJOs4fixYh9hPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DECnvSyJY/EnXpncenAA8AL9ufUrmskkxE+J+ODbjro7VgLp2sHV2tffyA2fYsqAaZzsqhnZK/Ay8sEUSozOyT+n",
                "verification": "DCECIthRUYTH1i/6mbgprrSTjEcE7LDdfjQOhC6d8SGCY0MLQZVEDXg="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
