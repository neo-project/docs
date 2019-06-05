# NEO 客户端插件

从 NEO 2.9.0 开始，一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 NEO-CLI时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。点击此处下载 [Plugins](https://github.com/neo-project/neo-plugins/releases)。

| 插件                                                         | 功能                                                         |                                                    |
| ------------------------------------------------------------ | ------------------------------------------------------------ | -------------------------------------------------- |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ApplicationLogs.zip) | 在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。 | 交易所必选                                         |
| [CoreMetrics](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/CoreMetrics.zip) | 查询历史区块的时间戳。                                       | 交易所推荐使用                                     |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ImportBlocks.zip) | 同步离线包。                                                 | 必选                                               |
| [RpcWallet](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcWallet.zip) | 提供钱包相关的 RPC 功能。                                    | 必选                                               |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/SimplePolicy.zip) | 启用共识的简单策略。                                         | 搭建私链必选，且从 NEO-CLI 2.10.2 开始，交易所必选 |
| [RpcSecurity](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcSecurity.zip) | 提升 RPC 安全。                                              | 可选                                               |
| [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcSystemAssetTracker.zip) | 查询 UTXO 资产相关信息。                                     | 交易所推荐使用                                     |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/StatesDumper.zip) | 导出 NEO-CLI 状态数据。                                      | 可选                                               |
| [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcNep5Tracker.zip) | 提供 NEP-5 余额及交易历史的 RPC 查询功能。                   | 交易所推荐使用                                               |

## 安装插件

要安装插件，在客户端根目录下新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中，如下所示在neo-cli根目录下安装：

![plugins.png](../../assets/plugins.png)

## 插件中的 API 接口

### getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。完整的合约日志会记录到 ApplicationLogs 目录。

此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ApplicationLogs.zip) 插件才可以调用。

#### 参数说明

txid：交易ID

#### 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["b6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xb6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x23c3aaaa31a0c373c23505157e9fb2665c7065ec",
                "vmstate": "HALT",
                "gas_consumed": "2.931",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x1578103c13e39df15d0d29826d957e85d770d8c9",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "235a717ed7ed18a43de47499c3d05b8d4a4bcf3a"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0b2f7cac1d57b9f535d35da1a5421015e4e32b19"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00f44a4f9df66d01"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```

说明：
其中 gas_consumed 表示该交易消耗的 gas 数量，即交易手续费。每笔交易会有10 gas 的免费额度。如果数量小于10，则不收取手续费，如果大于10，那么收取超过10的那部分作为手续费并向上取整。例如 gas_consumed = 12.3，那么实际收取的手续费为3 gas.
