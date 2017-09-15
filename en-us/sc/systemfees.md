# System Fees

## Transaction fees

There are currently no transaction fees. The user can however choose to pay transaction fee for priority.

## Smart Contract Fees

The fee structure for Smart Contracts can be found in the tables below.

The initial 10 GAS is always free. Fees that sum up to 10 GAS or less will thus not require a service fee.

The fees below are minimum fees. The user can choose to pay extra for priority.

All Smart Contract fees are considered as Service fee to be put in a pool for re-distribution to all NEO holders. The distribution is proportional to amount of NEO.

### Fees for System Calls

| SysCall                               | Fee [Gas]     |
|---------------------------------------|:-------------:|
| Runtime.CheckWitness                  | 0.2           |
| Blockchain.GetHeader                  | 0.1           |
| Blockchain.GetBlock                   | 0.2           |
| Blockchain.GetTransaction             | 0.1           |
| Blockchain.GetAccount                 | 0.1           |
| Blockchain.GetValidators              | 0.2           |
| Blockchain.GetAsset                   | 0.1           |
| Blockchain.GetContract                | 0.1           |
| Transaction.GetReferences             | 0.2           |
| Account.SetVotes                      | 1             |
| Validator.Register                    | 1000          |
| Asset.Create (system asset)           | 5000          |
| Asset.Renew (system asset) [per year] | 5000          |
| Contract.Create                       | 500           |
| Contract.Migrate                      | 500           |
| Storage.Get                           | 0.1           |
| Storage.Put [per KB]                  | 1             |
| Storage.Delete                        | 0.1           |
| (Default)                             | 0.001         |

### Fees for Instructions

| Instruction                           | Fee [Gas]     |
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
| OpCode.CHECKMULTISIG [per signature]  | 0.1           |
| (Default)                             | 0.001         |

