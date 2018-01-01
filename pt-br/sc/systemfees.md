# Tarifas de Sistema

## Tarifas de Transação

Atualmente não há tarifas de transação. O usuário pode, entretanto, optar pelo pagamento dessa tarifa para ter prioridade.

## Tarifas de *Smart Contract*

A estrutura de tarifa para *Smart Contracts* pode ser encontrado nas tabelas abaixo.

Os primeiros 10 GAS são de graça. Assim, tarifas somando até 10 GAS não terão custo de serviço. 

As tarifas abaixo são tarifas mínimas. O usuário pode optar pelo pagamento extra para ter prioridade.

Todas as tarifas de *Smart Contract* são consideradas Tarifas de Serviço a serem re-distribuidas a todos portadores de NEO. A distribuição é proporcional à quantia de NEO.


### Tarifas para Chamadas de Sistema (namespace *System*)

| SysCall (chamada)                     | Tarifa em GAS |
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
| Asset.Create (ativo do sistema)       | 5000          |
| Asset.Renew (ativo do sistema) [por ano] | 5000          |
| Contract.Create                       | 500           |
| Contract.Migrate                      | 500           |
| Storage.Get                           | 0.1           |
| Storage.Put [por KB]                  | 1             |
| Storage.Delete                        | 0.1           |
| (Default/padrão)                      | 0.001         |

### Tarifas para Instruções

| Instrução                             | Tarifa em GAS |
|---------------------------------------|:-------------:|
| OpCode.PUSH16 [ou menos]               | 0             |
| OpCode.NOP                            | 0             |
| OpCode.APPCALL                        | 0.01          |
| OpCode.TAILCALL                       | 0.01          |
| OpCode.SHA1                           | 0.01          |
| OpCode.SHA256                         | 0.01          |
| OpCode.HASH160                        | 0.02          |
| OpCode.HASH256                        | 0.02          |
| OpCode.CHECKSIG                       | 0.1           |
| OpCode.CHECKMULTISIG [por assinatura]  | 0.1           |
| (Default/padrão)                      | 0.001         |

