# 从 Neo Legacy 迁移到 Neo N3

本教程将指导开发人员通过转账的方式将 Neo Legacy 上的资产 NEO/GAS/nNEO/cGAS 迁移到 Neo N3。

## 迁移流程

1. 在 Neo Legacy 端, 用户构建一笔转账交易 (Invocation Transaction/Contracttransaction) 将迁移资产发送到指定地址 `ANeo2toNeo3MigrationAddressxwPB2Hz`, 在这笔交易中将 N3 合法地址 (base58 string to bytes) 放入交易的 `attribute` 中，使用 **Remark14** 作为 Key。

   多语言交易代码可参考示例：[Demos](https://github.com/neo-ngd/sdkDemo)

   > [!Caution]
   >
   > 发送交易前，请确保该交易满足以下所有要求，否则该交易不会被处理且迁移的资产无法找回！
   >
   > - 交易中的 N3 地址合法且 `attribute` 里仅包含一个 Remark14。
   > - 迁移资产大于等于 10 NEO 或 20 GAS 是免费的。如果迁移资产小于该金额，必须附加 **1 GAS** 作为网络费。 
   > - 除了作为网络费的 GAS，一笔交易仅包含一种资产。

   > [!Note]
   >
   > nNEO 不支持小数部分迁移，N3 发放 NEO 时会根据 nNEO 的数量做向下取整。

2. 我们将扫描所有 Neo legacy 上发送到上述特定地址的交易，如果验证交易合法，将每隔一段时间（最长一个工作日）将对应金额的资产发送到指定的N3 地址。

## 相关参考

- [资产合约 Hash](https://github.com/neo-ngd/sdkDemo/blob/master/contracthash.md)
- [Neo N3 迁移页面指南](migration-guide.md)
