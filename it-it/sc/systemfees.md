# Sistema di Commissioni

## Commissioni transazione

Correntemente non vi sono commissioni sulle transazioni. L'utente puó comunque scegliere di pagare la commissione della transazione per avere prioritá.

## Commissioni smart contract

La struttura di commissioni per gli Smart Contracts puó essere trovata nella tabella sotto.

Gli iniziali 10 GAS sono sempre gratuiti. Le commssioni che ammontano a 10 GAS o meno non richiedono alcun servizio di commissione.

Le commisioni seguenti sono commissioni minime. L'utente puó decire di pagare qualcosa in piú per avere prioritá.

Tutte le commissioni degli smart contract sono considerate come servizio di commissioni da mettere in una pool per la redistribuzione a tutti i possessori di NEO. La distribuzione é proporzionale alla quantitá di NEO.

### Commissioni per le Chiamate al Sistema

| SysCall                               | Commissione [Gas]     |
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
| Asset.Renew (system asset) [per anno] | 5000          |
| Contract.Create                       | 100~1000   |
| Contract.Migrate                      | 100~1000   |
| Storage.Get                           | 0.1           |
| Storage.Put [per KB]*                 | 1             |
| Storage.Delete                        | 0.1           |
| (Default)                             | 0.001         |

* Aggiuntivo 1 GAS minimo.

### Commissioni per le Istruzioni

| Istruzione                           | Commissione [Gas]     |
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
| OpCode.CHECKMULTISIG [per firma]  | 0.1           |
| (Default)                             | 0.001         |

