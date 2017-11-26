# NEO Namespace

Der NEO Namespace ist die API der NEO Blockchain, mithilfe der API kann man kann man auf Blockchaindaten zugreifen und diese verändern. Die API ist in zwei Bereiche unterteilt.

1. Blockchain ledger. Der Smart Contract kann mithilfe Kompatibilitätsschicht auf alle Daten der Blockchain inklusive aller Blockchain Blöcke, Transaktionen und dessen Eigenschaftenfelder zugreifen.

2. Persistenter Speicher. Jeder Application Contract auf NEO Basis hat einen Datenspeicher auf diesen nur der Contract selbst zugreifen kann. Diese Methode kann auf die Daten im Contract zugreifen.

Anmerkung: Die Tags `Neu` und `Veraltet` in diesem Artikel sind Änderungen von der Version 1.6 auf die Version 2.0.

## Klasse

| | Klasse | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | Eine Klasse die den Account darstellt und es ermöglicht den Saldo abzurufen.     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Eine Klasse die die Datenstruktur von Assets darstellt.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | Eine Klasse die einen Block darstellt und die Methoden zum Abfragen von Transaktionen in dem Block bereitstellt. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Stellt mehrere Methoden da um auf die Blockchaindaten zuzugreifen.|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | Eine Klasse die den Contract darstellt.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `Neu` Stellt die Datenstruktur einer Registrierungstransaktion eines Bookkeepers dar.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Stellt die Datenstruktur eines Block Headers dar.|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `Neu` Stellt mehrere Methoden dar die während einer Smart Contract Execution genutzt werden können.|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Stellt mehrere Methoden da um, Daten im persistenten Speicher einzufügen, abzurufen oder zu löschen.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `Neu` Eine Klasse die den Zusammenhang des persistenten Speicher darstellt.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  Die Basisklasse einer Transaktion.            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | Die Datenstruktur der Transaktionseigenschaften.          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | Die Datenstruktur der Transaktionseingaben         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) |Die Datenstruktur der Transaktionsausgaben|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `Neu` Stellt mehrere Methoden für die Konsensknoten dar.    |

## Aufzählung

|  | Aufzählung | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `Veraltet`  Stellt die Aufzählung des Datenkontext bereit. |
