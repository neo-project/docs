# getbalance 方法

根据指定的资产编号，返回钱包中对应资产的余额信息。该方法适用于符合 [NEP-5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 标准的合约资产。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

asset_id：资产 ID（资产标识符），即合约的 Script Hash。

如NEO为：0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

Gas为：0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

## 调用示例

> [!Note]
>
> 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。

示例：查询 NEP-5 资产的余额

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["0x8d06bc235c2585c9d27ede8ed7085b3e13fc0c36"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "16000000000"
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

