# sendtoaddress 方法

向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID，即 NEP-5 合约的脚本哈希

  如 NEO 为：0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

  Gas 为：0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

  以上资产可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

- address：收款地址。

- value：转账金额。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b","NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch", 5000],
  "id": 1
}
```

响应正文：

```json
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x09df034eee12224964ccc0c93fcfbfce8d922ab2b0b673388fd8951d2f25d5d9",
        "size": 272,
        "version": 0,
        "nonce": 760727272,
        "sender": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "sys_fee": "100000000",
        "net_fee": "1272390",
        "valid_until_block": 2136389,
        "attributes": [],
        "cosigners": [
            {
                "account": "0x39e7394d6231aa09c097d02391d5d149f873f12b",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AwCIUmp0AAAADBQlJ1AGgA5zzGQoZ1OjpzJCJSHI5AwUK/Fz+EnR1ZEj0JfACaoxYk055zkTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEBPVJeyFAroQcgVtVi9qmbemtAV1cIIdivDELileXwlbNFanQqRXq9UV5CxHA5qQ/U7beaJcLdQBiAPIkvGXSdZ",
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