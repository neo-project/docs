# Netwerkkosten

## Transactiekosten

Momenteel zijn er geen transactiekosten. De gebruiker kan er echter wel voor kiezen om transactiekosten te betalen voor een hogere prioriteit.

## Smart Contract Kosten

Het kostenmodel voor Smart Contracts is terug te vinden in onderstaande tabellen.

De eerste 10 GAS is altijd gratis; kosten die bij elkaar opgeteld 10 GAS of minder zijn, vereisen dus geen servicekosten.

De kosten hieronder zijn minimumkosten. De gebruiker kan extra betalen voor prioriteit.

Alle Smart Contract kosten worden gezien als servicekosten. Deze gaan naar een pot voor redistributie naar alle NEO-bezitters. De distributie verloopt proportioneel met de hoeveelheid NEO in bezit.

### Kosten van System Calls

| SysCall                               | Kosten [Gas]  |
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

### Kosten van Opdrachten

| Opdracht                              | Kosten [Gas]  |
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

