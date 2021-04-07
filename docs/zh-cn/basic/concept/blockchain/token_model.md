# 通证模型

## 原生通证

Neo系统中定义了两种原生通证，NEO 和 NeoGas（缩写符号GAS）。

NEO是治理通证（Governing Token）。持有NEO可以参与Neo网络的治理，包括投票选举共识节点和修改网络参数等。NEO的总量为1亿，最小单位为1，且不可分割。在创世块中注册了NEO资产，并存放在备用共识节点（StandbyValidators）的多方签名合约地址上。

GAS是燃料通证（fuel token），用于Neo网络的资源控制，最小单位0.00000001。使用Neo网络进行转账、注册资产、发行资产、运行DApp等操作需要支付一定的GAS手续费。用户可以涌过提取或者购买获取GAS。

Neo N3的创世区块将铸造准确数量的GAS代币，以对标NEO legacy链上流通的所有GAS代币。

关于GAS的分配规则，可参考[治理与激励](../../governance.md)。

## NEP17 资产

NEP17 通证需要通过智能合约生成和管理，使用智能合约的存储区来存储信息，使用了账户模型。具体信息请见 [NEP-17](../../../develop/write/nep17.md)。