# DApp 开发介绍

在 Neo 上进行 DApp 的开发主要包含两部分工作，智能合约的开发和与区块链的集成。如果已经完成智能合约的开发、测试和部署，请直接阅读下节 [Dapp集成](integ.md)。

通常开发一个 DApp 的流程如下：

1. 搭建网络环境

  在 Neo上开发部署智能合约需要消耗一定量的Gas作为手续费，考虑到开发成本以及方便性，建议开发者首先搭建Neo私链或者使用Neo测试网，用于初期的开发和测试。详情请参考：

  - [搭建 Neo 私链](../network/private-chain/solo.md)；
  - [使用 Neo-local 快速搭建本地网络](../network/private-chain/neolocal.md);
  - [使用 Neo 测试网](../network/testnet.md)

2. 运行 Neo 节点

  针对不同开发者的偏好和经验，Neo 提供了命令行和用户界面两种节点供开发者选择，详情请参考 [Neo 节点](../node/introduction.md)

3. 开发智能合约

  智能合约实现了 DApp 的核心业务逻辑，请参考 [智能合约开发](../sc/gettingstarted/introduction.md) 完成自己项目需要使用的智能合约。

4. DApp 集成

  完成智能合约开发、测试和部署以后，开发者需要进行前端的集成开发，实现 DApp 与区块链的交互，详情请阅读下节。
  
