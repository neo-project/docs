# 开发相关

## 如何申请测试币？

你可以在 [NGD faucet](https://neowish.ngd.network/) 上每天自动领取最多1000 个 GAS 和 1000 个 NEO。如果需要更多测试币，可以访问 https://neo.org/testcoin/apply 并填写申请表单。如果申请成功，你将在三到五个工作日内收到通知。

## 有哪些方法可以搭建私链：

要搭建私链，有以下方法可供选择：

- [单节点模式快速搭建](../../docs/zh-cn/network/private-chain/solo.md)
- [在本地主机搭建私有链](../../docs/zh-cn/network/private-chain/private-chain2.md)

还可以参见 [社区文章](../../articles/zh-cn/index.md)，学习更多私链搭建方法。

## 可以使用哪些语言开发智能合约？

Neo 支持多种主流编程语言，可以使用 C#、Python、Go、JS 和 Jave 进行开发。目前在 Neo 生态中，C# 与 Python具有非常完善的基础设施，提供多种编译器可供开发者选择。

## 如何获取 NEP-5 资产的 Hash?

可以使用区块链浏览器 https://scan.nel.group 进行查看：

  1. 进入浏览器后，点击页面上方导航栏中的 Assets。 

  2. 在 Assets 列表中选择 NEP-5。

  3. 在列表中点击要查看的资产，可进入详情页面查看到该资产的 Hash。

## 搭建私链后，从多方签名合约中提取资产， 为什么签名时显示钱包中没有对象的私钥？

搭建私链后，在 (n/2+1) 个共识节点的钱包中都需要进行相同的操作：添加多方签名地址和重建钱包索引。

## Neo 提供了哪些 SDK 供开发者使用？

针对主流高级语言如C#、JavaScript、Java等，Neo 开发社区开发并维护了多样的Neo SDK，如下所示：

- C# SDK: [neo](https://github.com/neo-project/neo)
- JavaScript SDK: [neon-js](http://cityofzion.io/neon-js/)
- Java SDK: [neow3j](https://github.com/neow3j)
- Go: [neo-gogogo](https://github.com/neo-ngd/neo-gogogo) / [neo-go](https://github.com/nspcc-dev/neo-go)
- Python: [neo-python](https://github.com/CityOfZion/neo-python) 