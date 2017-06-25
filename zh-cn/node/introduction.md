# 小蚁节点介绍                               

全节点（full nodes）是存储小蚁区块链全部数据的节点，通过 P2P 的方式与区块链网络连接，在区块链网络中，所有的全节点都是平等的，既充当客户端又充当服务器。

小蚁有两个全节点程序，一个是给普通用户使用的，有图形界面的，具有除共识外的所有功能的客户端，我们叫它 AntSharesCore-GUI。

另一个是给开发者用来使用的，命令行界面的，具有一些钱包操作的基本功能，除此之外还会对外提供 API，还可以也其它节点达成共识，参与区块的生成，我们叫它 AntSharesCore-CLI。

## 小蚁节点下载地址

|      | AntSharesCore-GUI                        | AntSharesCore-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| 程序   | [官网](https://www.antshares.org/download) 或 [Github](https://github.com/antshares/antsharescore/releases) | [Github](https://github.com/antshares/antsharescore/releases) |
| 源代码  | [Github](https://github.com/antshares/antsharescore) | [Github](https://github.com/antshares/antsharescore) |

## GUI节点与CLI节点功能比较

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| 图形界面      | ✅    |      |
| 命令行界面     |      | ✅    |
| 创建钱包      | ✅    | ✅    |
| 打开钱包      | ✅    | ✅    |
| 重建钱包索引    | ✅    | ✅    |
| 显示所有密钥对   | ✅    | ✅    |
| 导入导出密钥对   | ✅    | ✅    |
| 显示所有地址    | ✅    | ✅    |
| 显示所有资产    | ✅    | ✅    |
| 创建地址      | ✅    | ✅    |
| 转账        | ✅    | ✅    |
| 交易（资产互换）  | ✅    |      |
| 创建多方签名合约  | ✅    |      |
| 创建自定义智能合约 | ✅    |      |
| 签名        | ✅    |      |
| 选举共识节点    | ✅    |      |
| 对选举进行投票   | ✅    |      |
| 注册资产      | ✅    |      |
| 分发资产      | ✅    |      |
| 提取小蚁币     | ✅    |      |
| 批量生成地址    |      | ✅    |
| JSON-RPC  |      | ✅    |
| 参与区块的共识   |      | ✅    |

## 端口说明

如果你想让外部程序访问该节点的 API 需要开放防火墙端口，以下是端口说明，可以全部开放也可按需开放。

|                    | 主网（Main Net） | 测试网（Test Net） |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

如需了解测试网请参考 [测试网](testnet.md)。 