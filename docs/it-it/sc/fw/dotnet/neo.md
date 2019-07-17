# NEO Namespace

Il NEO namespace e l'API fornita dalla blockchain NEO, che fornisce un modo per accedere ai dati della blockchain e manipolare la memoria persistente. Queste API sono divise in due categorie:

1. Registro blockchain. Il contratto puó accedere a tutti i dati dell'intera blockchain attraverso al livello di interoperabilitá, inclusi blocchi e transazioni, cosí come ognuno dei loro campi.

2. Memoria persistente. Ogni applicazione contratto distribuito su NEO ha uno spazio di memoria al quale puó accedere solo il contratto stesso. Questi metodi forniti possono accedere ai dati nel contratto.

Nota: I tag `New` e `Deprecated` di questo articolo sono cambiamenti della versione 2.0 relativi alla versione 1.6.

## Classe

| | Classe | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | Una classe rappresentante l'account, fornisce un metodo per interrogare il saldo.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Una classe rappresentante un asset e la sua struttura dati.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | Una classe rappresentante un blocco, fornisce metodi per interrogare le transazioni nel blocco.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Fornisce un set di metodi per accedere ai dati della blockchain.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | Una classe rappresentante un contratto.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `New` Rappresenta la struttura dati della transazione registrata da un bookkeeper. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Rappresenta la struttura dati dell'intestazione di un blocco           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `New` Fornisce un set di metodi durante l'esecuzione di uno smart contract.   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Fornisce un set di metodi per inserire, interrogare o eliminare dati da una memoria persistente.   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `New` Una classe rappresentante il contesto di memoria dell'archivio persistente. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  La classe base rappresentante la transazione.            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | La struttura dati rappresentante gli attributi della transazione.          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | La struttura dati rappresentante gli input della transazione.        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | La struttura dati rappresentante gli output della transazione.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `New` Fornisce un set di metodi per i nodi di consenso.      |

## Enumerazione

|  | Enumerazione | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `Deprecated`  Rappresenta l'enumerazione del contesto di memoria. |
