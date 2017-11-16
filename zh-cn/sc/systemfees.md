# System Fees

## 交易费用

目前转账交易没有手续费。

## 智能合约费用

智能合约的手续费结构已经在下表列出。

每个 dApp 有 10 GAS 的免费额度。因此手续费 10 GAS 以下的 dApp 是不需要支付手续费的。

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
| Asset.Create（系统资产）       | 5000          |
| Asset.Renew（系统资产）        | 5000          |
| Contract.Create              | 500           |
| Contract.Migrate             | 500           |
| Storage.Get                  | 0.1           |
| Storage.Put [per KB]         | 1             |
| Storage.Delete               | 0.1           |
| 其它（每行OpCode）             | 0.001         |

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
| OpCode.CHECKMULTISIG（每个签名）        | 0.1           |
| 其它（每行OpCode）                      | 0.001         |

