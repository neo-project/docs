# sendmany 方法

批量转账命令，并且可以指定找零地址。

> [!Note]
> 执行此命令前需要在 Neo-CLI 节点中打开钱包。

## 参数说明

\<outputs_array> \[fee=0] \[change_address]

outputs_array：数组，数组中的每个元素的数据结构如下：

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

​	如 NEO 为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

​	NeoGas 为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

​	其余资产 ID 可以通过 [CLI 命令](../cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

​	value：转账金额。

​	address：收款地址。

fee：手续费，可选参数，默认为 0。

change_address：找零地址，可选参数，默认为钱包中第一个标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "27b9a82ed519eec17c5520927b3f472e4df28b835c24dba25645e1650ed8d2ac",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "999998",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "40844144eb6819cb094afee2db5e5da078cfc7bbe29dbc60e47b4c3b4bdf77a5fd97865ae9b5a8d8bb3fa20f1441a58a05f848b2ea49c6c0dbbfc5ed241b226665",
                "verification": "210208c5203d32f960c54c225f140c1020408b114c15d29082fc959dac6874828fccac"
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