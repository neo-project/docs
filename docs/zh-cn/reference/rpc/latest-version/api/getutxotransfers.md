# getutxotransfers 方法

返回指定地址在指定时间段内的 utxo 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

#### 参数

- address：要查看交易记录的地址。

- asset (可选): 资产名称，NEO 或 GAS。

- timestamp (可选)：
  - 如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
  - 如果仅设置一个时间戳，则返回自该时间戳以后发生的交易信息。
  - 如果不设置此参数，则返回近七天内的交易信息。

#### 调用示例

**示例 1  - 不设置时间戳**：

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getutxotransfers",
  "params": ["AGHHM8Wx5FiWAC9iRtoeQQLoK9tgTcetpM"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "address": "AGHHM8Wx5FiWAC9iRtoeQQLoK9tgTcetpM",
        "sent": [
            {
                "asset_hash": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "asset": "NEO",
                "total_amount": "1",
                "transactions": [
                    {
                        "block_index": 4680390,
                        "timestamp": 1597119352,
                        "txid": "0x036c0bc099b63c554feb0a9a9446c1dca7c1610e733c904772311ab8bc3d28bd",
                        "amount": "1"
                    }
                ]
            },
            {
                "asset_hash": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "asset": "GAS",
                "total_amount": "0",
                "transactions": []
            }
        ],
        "received": [
            {
                "asset_hash": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "asset": "NEO",
                "total_amount": "3",
                "transactions": [
                    {
                        "block_index": 4680382,
                        "timestamp": 1597119217,
                        "txid": "0x9f15dba17bd5c18bd69941a669c63955d1692af8348dbc2d0364111baad60fff",
                        "amount": "1"
                    },
                    {
                        "block_index": 4680384,
                        "timestamp": 1597119250,
                        "txid": "0x03417a463e81b59cfabb5239d642ab641fb78ebb6947e719713219961ead72bf",
                        "amount": "1"
                    },
                    {
                        "block_index": 4680392,
                        "timestamp": 1597119384,
                        "txid": "0xafe6a8b28bda3162869ff1b9279f19b63c552c6c3688af38dbde87d15e1bf270",
                        "amount": "1"
                    }
                ]
            },
            {
                "asset_hash": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "asset": "GAS",
                "total_amount": "0",
                "transactions": []
            }
        ]
    }
}
```

**示例 2 - 设置资产名，起始和结束时间戳**：

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getutxotransfers",
  "params": ["ALfnhLg7rUyL6Jr98bzzoxz5J7m64fbR4s","NEO",1499153921,1499259981],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "address": "ALfnhLg7rUyL6Jr98bzzoxz5J7m64fbR4s",
        "sent": [
            {
                "asset_hash": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "asset": "NEO",
                "total_amount": "14948",
                "transactions": [
                    {
                        "block_index": 231858,
                        "timestamp": 1499153921,
                        "txid": "0x0ef708e1228e58f3746e5709f54f14ff0954239f67888aa2368ab559885cd521",
                        "amount": "5000"
                    },
                    {
                        "block_index": 236240,
                        "timestamp": 1499243153,
                        "txid": "0xbd3fad33faab91c4becfc9be181a042cfc721a797187ced6cdd94e0fefadd294",
                        "amount": "4999"
                    },
                    {
                        "block_index": 236273,
                        "timestamp": 1499243796,
                        "txid": "0xed0ce9ae267bf9b861d32cc181796df2b2f92c02ca773651a2c6c91f9b89e90e",
                        "amount": "4949"
                    }
                ]
            }
        ],
        "received": [
            {
                "asset_hash": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "asset": "NEO",
                "total_amount": "14798",
                "transactions": [
                    {
                        "block_index": 231858,
                        "timestamp": 1499153921,
                        "txid": "0x0ef708e1228e58f3746e5709f54f14ff0954239f67888aa2368ab559885cd521",
                        "amount": "4999"
                    },
                    {
                        "block_index": 236138,
                        "timestamp": 1499241166,
                        "txid": "0x8981b8599fa42b4ae0bd9f3947f1b8218c25b908a4a9e0b88f12ba98160099f3",
                        "amount": "1"
                    },
                    {
                        "block_index": 236240,
                        "timestamp": 1499243153,
                        "txid": "0xbd3fad33faab91c4becfc9be181a042cfc721a797187ced6cdd94e0fefadd294",
                        "amount": "4949"
                    },
                    {
                        "block_index": 236273,
                        "timestamp": 1499243796,
                        "txid": "0xed0ce9ae267bf9b861d32cc181796df2b2f92c02ca773651a2c6c91f9b89e90e",
                        "amount": "4849"
                    }
                ]
            }
        ]
    }
}
```