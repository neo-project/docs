# getbalance 方法

根据指定的资产编号，返回钱包中对应资产的余额信息。该方法适用于符合 [NEP-5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 标准的合约资产。

> 执行此命令前需要在 Neo-CLI 节点中打开钱包。
>
> 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。



```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": [asset_id],
  "id": 1
}
```



### 参数说明

* asset_id：资产 ID（资产标识符）, 即NEP-5合约的scripthash。



## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "1000000000"
    }
}
```

响应说明：

balance：钱包中该资产的余额

> * 当未同步到发布合约的区块时，执行该 API 会报错，只有当区块同步到发布该合约资产的区块时，才会返回正确的结果。
> * 当输入的参数为非 NEP-5 标准的智能合约的 Script Hash 时，执行该 API 会报错。
> * 当区块未完全同步时，返回的资产余额可能不是最新的，请确保使用该 API 时区块已经同步到最新高度。
