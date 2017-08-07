# sendtoaddress 方法

向指定地址转账。

> [!Note]
> 执行此命令前需要在 Neo-CLI 节点中打开钱包。

## 参数说明

asset_id：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

如NEO为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

NeoGas为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

其余资产 ID 可以通过 [CLI 命令](../cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

address：收款地址。

value：转账金额。

fee：手续费，可选参数，默认为 0。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","AK4if54jXjSiJBs6jkfZjxAastauJtjjse",1],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "txid": "fbd69da6996cc0896691a35cba2d3b2e429205a12307cd2bdea5fbdf78dc9925",
    "size": 262,
    "type": "ContractTransaction",
    "version": 0,
    "attributes": [],
    "vin": [
      {
        "txid": "19fbe968be17f4bd7b7f4ce1d27e39c5d8a857bd3507f76c653d204e1e9f8e63",
        "vout": 0
      }
    ],
    "vout": [
      {
        "n": 0,
        "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "value": "1",
        "address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
      },
      {
        "n": 1,
        "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "value": "4978980",
        "address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
      }
    ],
    "sys_fee": "0",
    "net_fee": "0",
    "scripts": [
      {
        "invocation": "40f02345c7e90245f085d0c588433ca9e89c6df58f3636b5240288aab5f081b1c67c3cad5946890de9001fcfe8d8b748b647b116891e6f1fb2393cc2f1aba45a81",
        "verification": "21027b30333e0d0e6552ae6d1da9f9409f551e35ee9719305e945dc4dcba998456caac"
      }
    ]
  }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。