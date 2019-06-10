# NEO 客户端插件

从 NEO 2.9.0 开始，一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 NEO-CLI时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。点击此处下载 [Plugins](https://github.com/neo-project/neo-plugins/releases)。

| 插件                                                         | 功能                                                         |                                                    |
| ------------------------------------------------------------ | ------------------------------------------------------------ | -------------------------------------------------- |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ApplicationLogs.zip) | 在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。 | 交易所必选                                         |
| [CoreMetrics](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/CoreMetrics.zip) | 查询历史区块的时间戳。                                       | 交易所推荐使用                                     |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ImportBlocks.zip) | 同步离线包。                                                 | 必选                                               |
| [RpcWallet](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcWallet.zip) | 提供钱包相关的 RPC 功能。                                    | 必选                                               |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/SimplePolicy.zip) | 过滤非法交易。                                         | 必选                                                 |
| [RpcSecurity](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcSecurity.zip) | 提升 RPC 安全。                                              | 可选                                               |
| [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcSystemAssetTracker.zip) | 查询 UTXO 资产相关信息。                                     | 交易所推荐使用                                     |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/StatesDumper.zip) | 导出 NEO-CLI 状态数据。                                      | 可选                                               |
| [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcNep5Tracker.zip) | 提供 NEP-5 余额及交易历史的 RPC 查询功能。                   | 交易所推荐使用                                               |

## 安装插件

要安装插件，在客户端根目录下新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中，如下所示在neo-cli根目录下安装：

![plugins.png](../../assets/plugins.png)


