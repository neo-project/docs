# getbalance 方法

根据指定的资产编号，返回钱包中对应资产的余额信息。

> [!Note]
> 执行此命令前需要在 Neo-CLI 节点中打开钱包。

## 参数说明

asset_id：资产 ID（资产标识符），即该资产在注册时的交易 ID。

如NEO为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

NeoGas为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

其余资产 ID 可以通过 [CLI 命令](../cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "balance": "1.01",
    "confirmed": "1.01"
  }
}
```

响应说明：

balance：钱包中该资产的真实余额。

confirmed：钱包中该资产的已确认的金额，只有已确认的金额可以用来转账。

balance 和 confirmed 二者可能会不相等，仅在从钱包中转出一笔钱，而且有找零未确认时时，confirmed 值会小于balance。当这笔交易确定后，二者会变得相等。

