## 交易介绍
NEO交易是一个带有网络操作指令的签名数据包，例如，将资产转移到另一个地址。区块链账本中的每个NEO区块都包含有一个或多个交易，使得每个区块可以对交易进行批处理。要使用NEO区块链，我们需要先对交易的工作原理加以了解。

- **[交易结构](transactions.md)**
  - [type](transactions.md#type)
  - [version](transactions.md#version)
  - [attributes](transactions.md#attributes)
  - [outputs](transactions.md#outputs)
  - [inputs](transactions.md#inputs)
  - [scripts](transactions.md#scripts)

### 交易类型
NEO网络中有几种不同类型的交易，每种交易具有不同的用途和属性。部分先前使用的交易类型现在已被弃用或删除了，所以在主网上创建交易时不应该再使用这些类型。

- **[交易类型](types.md)**
  - [MinerTransaction](types.md#minertransaction)
  - [ClaimTransaction](types.md#claimtransaction)
  - [ContractTransaction](types.md#contracttransaction)
  - [StateTransaction](types.md#statetransaction)
  - [InvocationTransaction](types.md#invocationtransaction)
  - [注册资产](types.md#registering-assets)

### 交易费用
要使用NEO网络，交易需要支付一定的费用。NEO网络中有两种不同的费用结构，即系统费用和网络费用。所有费用均通过系统的功能代币GAS（NeoGas）进行支付。

- **[交易费用](fees.md)**
  - [系统费](fees.md#system-fees)
  - [网络费](fees.md#network-fees)
  - [应用的使用费用](fees.md#utility-fee-in-applications)

## 广播
一旦交易创建完成，就可以将其发送到网络的其他节点。如果节点通过了对该交易的验证，就会将它放置在内存池中，并将该交易广播转发到网络中的其他节点。最终，共识节点（NEO区块链中的验证人）会接收到该交易并将交易进行打包。

[下一节](2-NEO交易结构.md)或者[返回目录](README.md#目录)