# getbalance 方法

根据指定的资产编号，返回钱包中对应资产的余额信息。该方法适用于全局资产及符合 [NEP-5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 标准的合约资产。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

asset_id：资产 ID（资产标识符），如果是全局资产，此处为注册资产时的 Register Transaction 或 Publish Transaction 的交易 ID，如果是合约内部资产，此处为合约的 Script Hash。

如NEO为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

NeoGas为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

RPX Sale 为：ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9

其余资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

## 调用示例

示例1：查询全局资产的余额

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

示例1：响应正文：

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


> [!Note]
>
> 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。



示例2：查询 NEP-5 资产的余额

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"],
  "id": 1
}
```

示例2：响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "10"
    }
}
```

响应说明：

balance：钱包中该资产的余额，因为 NEP-5 资产是余额系统，而非 UTXO 系统，所以返回结果中没有 confirmed，balance 即实际可用的余额。

> [!Note]
> 
>- 当未同步到发布合约的区块时，执行该 API 会报错，只有当区块同步到发布该合约资产的区块时，才会返回正确的结果。
> - 当输入的参数为非 NEP-5 标准的智能合约的 Script Hash 时，执行该 API 会报错。
>
> - 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。

