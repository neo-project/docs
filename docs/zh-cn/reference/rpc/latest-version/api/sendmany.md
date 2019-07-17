# sendmany 方法

批量转账命令，并且可以指定找零地址。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

`<outputs_array>[fee=0][change_address]`

- outputs_array：数组，数组中的每个元素的数据结构如下：

  `{"asset": <asset>,"value": <value>,"address": <address>}`

  - asset：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

    如 NEO 为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

    NeoGas 为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

    其余资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

  - value：转账金额。

  - address：收款地址。

- fee：可选参数，设置手续费可以提升网络处理该笔转账的优先级，默认为 0，最小值可设为0.00000001。

- change_address：找零地址，可选参数，默认为钱包中第一个标准地址。


## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ]
    ],
    "id": 1
}
```

请求正文（包含手续费和找零地址）：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        0,
        "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
    ],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x55ba819b50f5821298328f3bf9bb17e088afc900cf2ad7dbfc03d49940b5cf30",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "0x06de043b9b914f04633c580ab02d89ba55556f775118a292adb6803208857c91",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "495",
                "address": "AK5q8peiC4QKwuZHWX5Dkqhmar1TAGvZBS"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
               "invocation": "406e545e30a6b39f71a7a40f1d4937939b9e1ca38851449842a2e2318bd499afd9c89f0c96658923e3e435ee91192e9dbf101d81a240fa7c953ac0c322d2f2b980",
                "verification": "2103cf5ba6a9135f8eaeda771658564a855c1328af6b6808635496a4f51e3d29ac3eac"
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
