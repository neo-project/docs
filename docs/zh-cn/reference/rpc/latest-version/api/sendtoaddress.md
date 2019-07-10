# sendtoaddress 方法

向指定地址转账。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

asset_id：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

如NEO为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

NeoGas为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

其余资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

address：收款地址。

value：转账金额。

fee：可选参数，设置手续费可以提升网络处理该笔转账的优先级，默认为 0，最小值可设为0.00000001。

change_address：找零地址，可选参数，默认为钱包中第一个标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b","AK4if54jXjSiJBs6jkfZjxAastauJtjjse",1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x06de043b9b914f04633c580ab02d89ba55556f775118a292adb6803208857c91",
        "size": 262,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "0x9c20c13f6b05691efbfd7e420b0edf470f8a5ae467e1e7ca7e11243c9b9fc333",
                "vout": 2
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "1",
                "address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
            },
            {
                "n": 1,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "497",
                "address": "AK5q8peiC4QKwuZHWX5Dkqhmar1TAGvZBS"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "4059e40a2040fe43bf8a40230e1f136dcfe7b3ca37d492ac8d6439615f7b88601c8d9b8077cd0e4f8c9f402d10a2782945bfa50e0ed3f57f7cceebd2f792453eb0",
                "verification": "2103cf5ba6a9135f8eaeda771658564a855c1328af6b6808635496a4f51e3d29ac3eac"
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。