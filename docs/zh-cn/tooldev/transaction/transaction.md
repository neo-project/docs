# 交易

NEO区块去掉区块头部分就是一串交易构成的区块主体，因而交易是整个NEO系统的基础部件。钱包、智能合约、账户和交易相互作用但最终都转化成交易被记入区块链中。在NEO的P2P网络传输中，信息被打包成`InvPayload`信息包来传送（Inv即Inventory）。不同信息包有自己需要的特定数据，因此衍生出三种类型的数据包。`InventoryType = 0x01`来标定网络中的InvPayload信息包内装的是交易数据。除交易数据包之外，还有块数据包(`InventoryType = 0x02`)和共识数据包(`InventoryType = 0xe0`)。

## 数据结构

一笔普通交易的数据结构如下：

| 字节数 | 字段 | 类型 | 描述 |
|-----|-----|------|-------|
| 1   | Type    | byte | 交易类型 |
| 1 | Version | byte | 交易版本号，目前为0 |
| ? | - | - | 特定交易的数据 |
| ?*? | Attributes | tx_attr[] | 该交易所具备的额外特性 |
| 34*? | Inputs | tx_in[] | 输入 |
| 60 * ? | Outputs | tx_out[] | 输出 |
| ?\*? | Scripts | Witness[] | 用于验证该交易的脚本列表 |

### Input

Input数组中存放了每一个输入的信息。每笔交易中可以有多个Input，也可能没有Input。在之后会提到的MinerTransaction中Input就为空。Input的数据结构如下： 

| 字节数 | 字段 | 类型 | 描述 |
|---|-------|------|------|
| 32 | PrevHash | UInt256 | 被引用交易的散列值 |
| 2 | PrevIndex | ushort | 被引用交易输出的索引 |

PrevHash和PrevIndex合起来就可以找到这个Input对应于哪个交易的第几个Output。从而Input和Output之间可以连接起来，构成了UTXO模型的基础。UTXO模型的具体信息请参见`UTXO模型`部分。

### Output

每个交易中最多只能包含 65536 个Output，代表资金转出。Output的数据结构如下：

| 字节数 | 字段 | 类型 | 描述 |
|---|-------|------|------|
| 32 | AssetId | UIntBase | 资产Id |
| ?  | Value | BigDecimal | 转账金额 |
| 20 | ScriptHash | UInt160 | 地址，即账户地址或合约地址 |

### Attribute

| 字节数 | 字段 | 类型 | 描述 |
|---|-------|------|------|
| 1 | Usage | byte | 属性类型 |
| 0\|1 | length | uint8 | 数据长度（特定情况下会省略） |
| ? | Data | byte[length] | 特定用途的外部数据 |

TransactionAttributeUsage，交易属性使用表数据结构如下：

| 字段 | 值 | 描述 |
|-------|-----|----|
| ContractHash | 0x00 | 外部合同的散列值 |
| ECDH02 | 0x02 | 用于ECDH密钥交换的公钥，该公钥的第一个字节为0x02 |
| ECDH03 | 0x03 | 用于ECDH密钥交换的公钥，该公钥的第一个字节为0x03 |
| Script | 0x20 | 用于对交易进行额外的验证, 如股权类转账，存放收款人的脚本hash |
| Vote | 0x30 |  |
| DescriptionUrl | 0x81 | 外部介绍信息地址 |
| Description | 0x90 | 简短的介绍信息 |
| Hash1 - Hash15 | 0xa1-0xaf | 用于存放自定义的散列值 |
| Remark-Remark15 | 0xf0-0xff | 备注 |

ContractHash、ECDH02-03、Vote和Hash1-15的数据长度固定为 32 字节，所以省略length字段。<br/>
Script固定20字节，存放地址。<br/>
DescriptionUrl必须明确给出数据长度，且长度不能超过 255字节。<br/>
Description和Remark1-15，也必须明确给出数据长度，且最大存储不超过 65535字节。

### Witness

每笔交易(transaction，tx)对象在被放进block时，需经过数字签名，确保在后续传输和处理中能随时验证交易是否被篡改。Neo采用的ECDSA数字签名方法。交易的转帐转出方地址，为ECDSA签名时所用的公钥publicKey。Neo系统没有使用比特币中的SegWit，每笔交易都包含自己的Script.witness，而Script.Witness使用的是智能合约。

见证人，实际上是可执行的验证脚本。`InvocationScript`脚本传递了`VerificationScript`脚本所需要的参数。只有当脚本执行返回真时，验证成功。

| 字节数 | 字段 | 类型 | 描述 |
|--|-------|------|------|
| ?  | InvocationScript | byte[] |调用脚本，补全脚本参数 |
| ?  | VerificationScript | byte[] | 验证脚本  |

调用脚本进行压栈操作相关的指令，用于向验证脚本传递参数（如签名等）。脚本解释器会先执行调用脚本代码，然后再执行验证脚本代码。

`Block.NextConsensus`所代表的多方签名脚本，填充签名参数后的可执行脚本，如下图所示，[`Opt.CHECKMULTISIG`](../neo_vm.md#checkmultisig) 在NVM内部执行时，完成对签名以及公钥之间的多方签名校验。

[![nextconsensus_witness](../images/blockchain/nextconsensus_witness.jpg)](../../images/blockchain/nextconsensus_witness.jpg)


## 交易类型

NEO 中一共定义了9种不同类型的交易，如下表所示。

| 编号 | 类型名 | 值  | 系统费用(GAS) |  描述  |
|------|--------|-----|----------|----------|
|  1  | MinerTransaction | 0x00 | 0 | 块的第一条交易，用于分配字节费的交易 |
|  2  | RegisterTransaction | 0x40 | 10000/0 | （已弃用）注册资产，仅用于NEO和GAS |
|  3  | IssueTransaction | 0x01 | 500/0 |分发资产|
|  4  | ClaimTransaction | 0x02 | 0 | 提取GAS |
|  5  | StateTransaction | 0x90 | 1000/0 |申请见证人或共识节点投票|
|  6  | EnrollmentTransaction | 0x20 | 1000 | (已弃用) 报名成为共识候选人 |
|  7  | ContractTransaction | 0x80 | 0 | 合约交易，这是最常用的一种交易 |
|  8  | PublishTransaction | 0xd0 | 500\*n | (已弃用) 智能合约发布 |
|  9  | InvocationTransaction | 0xd1 | 具体的指令GAS消耗 | 调用合约，部署合约后或生成新资产之后会使用 |

关于详细的交易处理流程，请参见 [交易流程](../advanced/tx_execution.md)。

> [!NOTE]
>
> 系统手续费： 不同的交易类型，不同的收费标准，设置在配置文件`protocol.json`中，最后分红给持有NEO用户。
>
> 交易网络费： `NetworkFee = tx.inputs.GAS - tx.outputs.GAS - tx.SystemFee`， 共识过程中，对议长打包交易的奖励，存于共识新块的第一笔交易`MinerTransaction`中。交易的网络费设置得越高，越容易被打包。

## 如何使用交易

以上这9种交易并不能完成所有的功能实现，比如部署合约和生成NEO和GAS以外的NEP5新资产时，通过系统调用来完成，以InvocationTransaction交易的形式来将这个事情加入到区块链中。下面给出的创世块的生成例子，展示了使用提供的交易类型完成资产注册。

### 例1：生成创始块

创世块（GenesisBlock）是默认已经定义在代码中不可修改的区块链的第一个区块，高度为0。在创世块中注册了NEO和GAS资产，并分发了NEO资产。注意，只有NEO和GAS是使用RegisterTransaction完成注册，其他全局资产和NEP5代币都是通过系统调用的方式生成。

创始块的区块头信息如下：

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
|  4  | Version | 区块版本 | uint | `0` |
| 32   | PrevHash | 上一个区块Hash | UInt256 |  `0x0000000000000000000000000000000000000000000000000000000000000000` |
|  32  | MerkleRoot | Merkle树Root | uint256 |`0x803ff4abe3ea6533bcc0be574efa02f83ae8fdc651c879056b0d9be336c01bf4`  |
| 4  | Timestamp |  创世时间 | uint | 创世时间为：`2016-07-15 | 23:08:21` |
| 4   | Index | 创世块高度 | uint | `0` |
|  8  | ConsensusData | Nonce | ulong | `2083236893`, 比特币创世块nonce值，向比特币致敬  |
| 20  | NextConsensus | 下一个共识地址 | UInt160 | 参与下一轮出块的共识节点的多方签名合约地址   |
| 1  | - | - | uint8 | 	固定为 1   |
|  ?   | Witness | 见证人 |  Witness |  `0x51`, 代表`PUSHT`指令，返回永真 |
|  ?\*? | **Transactions** | 交易 |  Transaction[] | 目前存了4笔交易， 见后续表 |

第一笔交易，MinerTransaction，即“挖矿”交易。所有的block的第一笔交易，都必须是MinerTransaction。Neo中没有挖矿的概念，这里主要记录一个区块的网络费奖励。

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
| 1   | Type    | uint8 | 交易类型 | `0x00` |
| 1 | Version | uint8 |  交易版本号 | `0` |
| 8 | Nonce | ulong | nonce  | `2083236893` |
| ?\*? | Attributes | tx_attr[] | 该交易所具备的额外特性 |    空 |
| 34\*? | Inputs | tx_in[] | 输入 | 空 |
| 60\*? | Outputs | tx_out[] | 输出 | 空 |
| ?\*? | Scripts | Witness[] | 用于验证该交易的脚本列表 | 空 |

第二笔交易，RegisterTransaction，注册NEO代币

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
| 1   | Type    | byte | 交易类型 | `0x40` |
| 1 | Version | byte |  交易版本号 | `0` |
| 1 | AssetType | byte | 资产类型  | `0x00` |
| ? | Name | string | 资产名字  | `NEO` |
| 8 | Amount | Fix8 | 总量  | `100000000` |
| 1 | Precision | byte | 精度  | `0` |
| ? | Owner | ECPoint | 所有者公钥  |  |
| 32 | Admin | UInt160 | 管理者  | `0x51`.toScriptHash |
| ?\*? | Attributes | tx_attr[] | 该交易所具备的额外特性 |    空 |
| 34\*? | Inputs | tx_in[] | 输入 | 空 |
| 60\*? | Outputs | tx_out[] | 输出 | 空 |
| ?\*? | Scripts | Witness[] | 用于验证该交易的脚本列表 | 空 |

`NEO`名称定义 = `[{"lang":"zh-CN","name":"小蚁股"},{"lang":"en","name":"AntShare"}]`

第三笔交易，RegisterTransaction，注册GAS代币

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
| 1   | Type    | byte | 交易类型 | `0x40` |
| 1 | Version | byte |  交易版本号 | `0` |
| 1 | AssetType | byte | 资产类型  | `0x01` |
| ? | Name | string | 资产名字  | `GAS` |
| 8 | Amount | Fix8 | 总量  | `100000000` |
| 1 | Precision | byte | 精度  | `8` |
| ? | Owner | ECPoint | 所有者公钥  | |
| 32 | Admin | UInt160 | 管理者  | `0x00`.toScriptHash, 即 `OpCode.PUSHF`指令脚本 |
| ?\*? | Attributes | tx_attr[] | 该交易所具备的额外特性 |    空 |
| 34\*? | Inputs | tx_in[] | 输入 | 空 |
| 60\*? | Outputs | tx_out[] | 输出 | 空 |
| ?\*? | Scripts | Witness[] | 用于验证该交易的脚本列表 | 空 |

`GAS`名称定义 =  `[{"lang":"zh-CN","name":"小蚁币"},{"lang":"en","name":"AntCoin"}]`

第四笔交易，IssueTransaction，发放NEO到合约地址

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
| 1   | Type    | byte | 交易类型 | `0x01` |
| 1 | Version | byte |  交易版本号 | `0` |
| ?*? | Attributes | tx_attr[] | 该交易所具备的额外特性 |    空 |
| 34*? | Inputs | tx_in[] | 输入 | 空 |
| 60 * ? | Outputs | tx_out[] | 输出 | 有一笔output，见下表 |
| ?*? | Scripts | Witness[] | 用于验证该交易的脚本列表 | `0x51`, 代表 `OpCode.PUSHT` |

其中，Output定义了将所有的NEO代币，转移到共识节点多方签名合约地址上。而Scripts为空，表示交易因为是创世块交易，不需要再验证。

| 尺寸 | 字段 | 名称  | 类型 | 值 |
|----|-----|-------|------|------|
| 1   | AssetId    | byte | 资产类型 | `0x00`， 即NEO代币 |
| 8 | Value | Fix8 |  转账总量 | `100000000` |
| 20 | ScriptHash | UInt160 |  收款脚本hash |  备用共识节点多方签名合约地址 |
