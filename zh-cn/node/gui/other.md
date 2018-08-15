# 其它功能

## 提取 NeoGas

NeoGas（简称 GAS） 伴随着每个新区块的生成而产生，会按照 NEO 的持股比例，记录在 NEO 地址上（资产余额中的括号里的数目即为待认领的 GAS 数目）。NEO 持有人可以在任意时间进行发起一笔提取交易，将这些 GAS 提取到 NEO 的地址上。

每一个 NEO 都有两种状态：unspent 和 spent。每一个未提取的 GAS 也有两种状态，available 和 unavailable。一个 NEO 的生命周期以转入地址起始，转出地址截止，转入时状态变为 unspent，转出时状态变为 spent。当 NEO 处于 unspent 状态时，所产生的 Gas 为 unavailable 状态，即不可提取。当 NEO 处于 spent 状态时，期间所产生的 GAS 变为 available，用户可以提取。如何将钱包中的所有 unavailable GAS 转为 available GAS 呢？很简单，将钱包中的所有 NEO 转到钱包中的任意一个地址即可。

更多关于 GAS 的信息，请参考 [NEO 白皮书](../../index.html#neo-的管理模式)。

具体操作步骤为：

1. 在 NEO-GUI 中，对钱包中的所有 NEO 进行一次转账操作（可以直接转到目前地址），待认领的 NeoGas 才会结算一次，变得可提取。
2. 点击 `高级` ->`提取 NeoGas` ->`全部提取`，提取完成。

![](../assets/gui_37.png)

## 申请证书

> [!Note]
>
> 该功能只可以生成一个证书申请文件，用户仍需去相关数字证书颁发机构申请证书。

在 NEO-GUI 中，点击 `高级` ->`申请证书`，然后填写证书申请向导。

![](../assets/gui_39.png)

最终会生成一个如下图所示的文件：

![](../assets/y.png)