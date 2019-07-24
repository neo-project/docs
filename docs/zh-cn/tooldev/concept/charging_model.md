# 收费模型

NEO生态的各参与方，在使用NEO网络时，需要支付网络费(Network Fee)和系统费(System Fee)，数量单位GAS。网络费将作为选举的共识节点出块奖励，而系统费和GAS的区块奖励，将作为持有NEO的用户权益分红，可通过`ClaimTransaction`交易提取相应GAS到对应账户。费用分配如下图描述。

[![economic model](../images/blockchain/economic_model.jpg)](../../images/blockchain/economic_model.jpg)

参照"交易"部分，一笔交易的inputs和outputs的数据信息中给出了相关地址上交易前后的GAS数量。总手续费可由其差值得出：

总手续费 = 网络费 + 系统费 = sum(inputs 中的 GAS) - sum(outputs 中的 GAS)

## **网络费**

网络费，作为支付交易被打包确认的费用，用户可自行设定网络费。理论上，每单位字节的网络费越高，越容易被打包确认。在当前主网上，一个块最多支持500笔交易，其中提供最多20笔免费交易。

## **系统费**
系统费，作为支付交易被NEO网络执行消耗的资源费用。由两部分计算。首先，在系统配置文件`protocol.json`中设置的特殊交易的系统费，包括如下： 

| 交易类型               |     系统费    |
|-----------------------|---------------|
| EnrollmentTransaction |      1000     |
| IssueTransaction      |       500     |
| PublishTransaction    |       500     |
| RegisterTransaction   |     10000     |

其次，运行智能合约时，产生的系统调用或虚拟机对指令的执行，都将产生费用。该费用也被归入到系统费中。具体收费标准参见"智能合约"部分。




