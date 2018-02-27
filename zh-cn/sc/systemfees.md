# System Fees

## 交易费用

目前转账交易没有手续费。

## 智能合约费用

智能合约的手续费结构已经在下表列出。

每个智能合约在每次执行过程中有10 GAS 的免费额度，无论是开发者部署还是用户调用，因此，单次执行费用在 10 GAS 以下的智能合约是不需要支付手续费的。当单次执行费用超过10 GAS，会减免10 GAS 的手续费。

所有支付的智能合约手续费将作为系统手续费，并按比例重新分配给所有 NEO 的持有人。

### 智能合约中系统调用的手续费：

| SysCall                      | 手续费 [Gas]  
|------------------------------|:-------------:|
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

\* 创建智能合约与迁移智能合约目前是根据合约所需功能进行收费。其中基础的费用为 100GAS，需要存储区 +400GAS，需要动态调用 +500GAS。

### 指令费用

| Instruction                           | 手续费 [Gas] 
|---------------------------------------|:-------------:|
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

