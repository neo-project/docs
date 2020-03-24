# 交易介绍
NEO 交易是一个带有网络操作指令的签名数据包，例如，将资产转移到另一个地址。区块链账本中的每个 NEO 区块都包含有一个或多个交易，使得每个区块可以对交易进行批处理。要使用 NEO 区块链，我们需要先对交易的工作原理加以了解。

**[交易结构](2-Structure_of_NEO_transactions.md)**

- [type](2-Structure_of_NEO_transactions.md#type)
- [version](2-Structure_of_NEO_transactions.md#version)
- [attributes](2-Structure_of_NEO_transactions.md#attributes)
- [outputs](2-Structure_of_NEO_transactions.md#outputs)
- [inputs](2-Structure_of_NEO_transactions.md#inputs)
- [scripts](2-Structure_of_NEO_transactions.md#scripts)

## 交易类型

NEO 网络中有几种不同类型的交易，每种交易具有不同的用途和属性。部分先前使用的交易类型现在已被弃用或删除了，所以在主网上创建交易时不应该再使用这些类型。

**[交易类型](3-NEO_transaction_types.md)**

- [MinerTransaction](3-NEO_transaction_types.md#minertransaction)
- [ClaimTransaction](3-NEO_transaction_types.md#claimtransaction)
- [ContractTransaction](3-NEO_transaction_types.md#contracttransaction)
- [StateTransaction](3-NEO_transaction_types.md#statetransaction)
- [InvocationTransaction](3-NEO_transaction_types.md#invocationtransaction)
- [Registering assets](3-NEO_transaction_types.md#registering-assets)

## 交易费用
要使用NEO网络，交易需要支付一定的费用。NEO网络中有两种不同的费用结构，即系统费用和网络费用。所有费用均通过系统的功能代币GAS（NeoGas）进行支付。

**[交易费用](4-NEO_transaction_fees.md)**

- [System fees](4-NEO_transaction_fees.md#system-fees)
- [Network fees](4-NEO_transaction_fees.md#network-fees)
- [Utility fee in applications](4-NEO_transaction_fees.md#utility-fee-in-applications)

## 广播
一旦交易创建完成，就可以将其发送到网络的其他节点。如果节点通过了对该交易的验证，就会将它放置在内存池中，并将该交易广播转发到网络中的其他节点。最终，共识节点（NEO区块链中的验证人）会接收到该交易并将交易进行打包。

## 阅读下节

[交易结构](2-Structure_of_NEO_transactions.md)

