# System Fees

NEO smart contracts cost certain system fees and network fees upon publishing and execution. In this section we focus on system fees occurred by execution of smart contracts. For information about network fees, refer to [Charging Model](../tooldev/concept/charging_model.md).

## Smart Contract Fees

The initial 10 GAS during each execution of every smart contract is always free, including smart contract deployment and invoking. That is, fees that sum up to 10 GAS or less will not require a service fee.

The fees below are minimum fees. The user can choose to pay extra for priority.

All Smart Contract fees are considered as Service fee to be put in a pool for re-distribution to all NEO holders. The distribution is proportional to amount of NEO.

The fee structure for Smart Contracts can be found in the tables below.

### Fees for System Calls

| SysCall                               | Fee [Gas] |
| ------------------------------------- | :-------: |
| Runtime.CheckWitness                  |    0.2    |
| Blockchain.GetHeader                  |    0.1    |
| Blockchain.GetBlock                   |    0.2    |
| Blockchain.GetTransaction             |    0.1    |
| Blockchain.GetAccount                 |    0.1    |
| Blockchain.GetValidators              |    0.2    |
| Blockchain.GetAsset                   |    0.1    |
| Blockchain.GetContract                |    0.1    |
| Transaction.GetReferences             |    0.2    |
| Account.SetVotes                      |     1     |
| Validator.Register                    |   1000    |
| Asset.Create (system asset)           |   5000    |
| Asset.Renew (system asset) [per year] |   5000    |
| Contract.Create                       | 100~1000  |
| Contract.Migrate                      | 100~1000  |
| Storage.Get                           |    0.1    |
| Storage.Put [per KB]*                 |     1     |
| Storage.Delete                        |    0.1    |
| (Default)                             |   0.001   |

* Additional to 1 GAS minimum

For the description of API in the table above, refer to [NEO Namespace](../reference/scapi/api/neo.md)

> [!Note]
>
> The cost of creating or migrating a smart contract is the basic 100 GAS plus fees of functions the contract requires. If the storage area is required, the function fee is 400 GAS, and if the dynamic call is needed, the function fee is 500 GAS.

### Fees for Instructions

| Instruction                          | Fee [Gas] |
| ------------------------------------ | :-------: |
| OpCode.PUSH16 [or less]              |     0     |
| OpCode.NOP                           |     0     |
| OpCode.APPCALL                       |   0.01    |
| OpCode.TAILCALL                      |   0.01    |
| OpCode.SHA1                          |   0.01    |
| OpCode.SHA256                        |   0.01    |
| OpCode.HASH160                       |   0.02    |
| OpCode.HASH256                       |   0.02    |
| OpCode.CHECKSIG                      |    0.1    |
| OpCode.CHECKMULTISIG [per signature] |    0.1    |
| (Default)                            |   0.001   |

