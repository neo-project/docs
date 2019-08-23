# 系统使用费

NEO 智能合约在部署和执行的时候都要缴纳一定的系统费和网络费，单位为 GAS。本文主要介绍智能合约执行时产生的系统费用。有关网络费的信息，请参见 [收费模型](../tooldev/concept/charging_model.md)。

## 智能合约费用

当开发者将一个智能合约部署到 NEO 区块链上时，需要向 NEO 系统支付 500 GAS 的系统费用。每执行一条智能合约的指令时也需要向 NEO 系统支付一定的执行费用。

每个智能合约在每次执行过程中有10 GAS 的免费额度，无论是开发者部署还是用户调用，因此，若智能合约的单次执行费用低于10 GAS ，则不需要支付手续费；如果超过10 GAS，则减免10 GAS 的手续费。

所有支付的智能合约手续费将作为系统手续费，并按比例重新分配给所有 NEO 的持有人。

智能合约的手续费结构请参见下表。

### 系统调用费用

| SysCall                      | 手续费 [Gas]  |
|------------------------------|-------------|
| Runtime.CheckWitness         | 0.2           |
| Blockchain.GetHeader         | 0.1           |
| Blockchain.GetBlock          | 0.2           |
| Blockchain.GetTransaction    | 0.1           |
| Blockchain.GetAccount        | 0.1           |
| Blockchain.GetValidators     | 0.2           |
| Blockchain.GetAsset          | 0.1           |
| Blockchain.GetContract       | 0.1           |
| Transaction.GetReferences    | 0.2           |
| Account.SetVotes             | 1             |
| Validator.Register           | 1000          |
| Asset.Create（系统资产）      | 5000          |
| Asset.Renew（系统资产）       | 5000          |
| Contract.Create*             | 100~1000      |
| Contract.Migrate*            | 100~1000      |
| Storage.Get                  | 0.1           |
| Storage.Put [per KB]         | 1             |
| Storage.Delete               | 0.1           |
| 其它（每行OpCode）            | 0.001         |

关于表格中API的含义，请参见 [NEO命名空间](../reference/scapi/api/neo.md)。

> [!Note]
>
> 创建智能合约与迁移智能合约目前是根据合约所需功能进行收费。其中基础的费用为 100GAS，需要存储区 +400GAS，需要动态调用 +500GAS。

### 指令费用

| Instruction                           | 手续费 [Gas] |
|---------------------------------------|-------------|
| OpCode.PUSH16 [or less]               | 0             |
| OpCode.NOP                            | 0             |
| OpCode.APPCALL                        | 0.01          |
| OpCode.TAILCALL                       | 0.01          |
| OpCode.SHA1                           | 0.01          |
| OpCode.SHA256                         | 0.01          |
| OpCode.HASH160                        | 0.02          |
| OpCode.HASH256                        | 0.02          |
| OpCode.CHECKSIG                       | 0.1           |
| OpCode.CHECKMULTISIG（每个签名）       | 0.1           |
| 其它（每行OpCode）                     | 0.001         |

