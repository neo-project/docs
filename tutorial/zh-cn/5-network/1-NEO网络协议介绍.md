# NEO协议和网络教程

[NEO](https://neo.org/)是一个面向去中心化应用的开源平台。NEO区块链使用了 [dBFT](https://docs.neo.org/en-us/basic/consension/consension.html)共识机制，与以太坊类似，可支持部署和运行智能合约。

本教程主要受众是那些希望通过编写NEO P2P客户端来参与到这种分布式系统的开发人员/学生。本教程不会对分布式系统的细节做太多的说明，读者应该具备分布式系统的基础知识，熟悉网络协议和Golang编程语言。

NEO网络由两种协议组成：与本地客户端和钱包进行通信的协议，以及与NEO网络中其他节点通信的外部协议。与本地节点进行连接使用的是[JSON-RPC](https://www.jsonrpc.org/)协议。也可以通过JSON-RPC连接到外部节点。但是，本教程会重点介绍另一个协议，即[NEO协议](https://docs.neo.org/en-us/network/network-protocol.html)。在本教程中，我们将学习如何与其他NEO节点进行通信。
```
                          +--------------+
+----------+              | +----------+ |
|          | NEO 协议| |          | |
| NEO 节点+----------------+ NEO 对等节点| |
|          |              | |          | |
+----------+              | +----+-----+ |
                          |      |       |
                          |      |JSON   |
                          |      |RPC    |
                          |      |       |
                          | +----+-----+ |
                          | |          | |
                          | |本地节点| |
                          | |          | |
                          | +----------+ |
                          +--------------+
                              NEO 节点
```

在本教程中，我们将重点介绍另一个协议，[NEO协议](https://docs.neo.org/en-us/network/network-protocol.html)。我们将使用Golang语言来学习如何与NEO节点通信。

[点击此链接开始学习](2-使用Golang实现NEO-ping功能.md)或者[返回目录](README.md#目录)
