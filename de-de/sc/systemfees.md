# Systemgebühren

## Transaktionsgebühren

Zurzeit gibt es keine Transaktionsgebühren, aber der User kann freiwillig eine Gebühr bezahlen um bevorzugt behandelt zu werden.

## Smart Contract Gebühren

Die Gebührenstruktur für Smart Contracts kann aus der Tabelle weiter unten entnommen werden.

Die ersten 10 GAS müssen nie bezahlt werden. Folglich muss keine Gebühr bezahlt werden, wenn der Gesamtbetrag unter 10 GAS bleibt.

Die unten angegebenen Gebühren sind Mindestgebühren. Der User kann freiwillig mehr bezahlen um bevorzugt zu werden.

Alle Smart Contract Gebühren werden als Servicegebühren behandelt und in einem Pool für die Rückverteilung an alle NEO Halter gesammelt. Die Verteilung erfolgt proportional zur Menge von NEO.

### Gebühren für System Calls

| SysCall                               | Gebühr [Gas]  |
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
| Asset.Renew (system asset) [pro Jahr] | 5000          |
| Contract.Create                       | 500           |
| Contract.Migrate                      | 500           |
| Storage.Get                           | 0.1           |
| Storage.Put [pro KB]                  | 1             |
| Storage.Delete                        | 0.1           |
| (Default)                             | 0.001         |

### Gebühren für Instructions

| Instruction                           | Gebühr [Gas]  |
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
| OpCode.CHECKMULTISIG [pro signature]  | 0.1           |
| (Default)                             | 0.001         |
