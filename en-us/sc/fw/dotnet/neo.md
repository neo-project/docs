# NEO namespace

The NEO namespace is the API provided by the small-ants blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories.

1, blockchain books. The contract procedure can access all the data on the entire chain chain through interactive services, including complete blocks and transactions, as well as each of their fields.

2, persistent storage area. Each application contract deployed on a NEO has a storage space that can only be accessed by the contract itself and can be used to access the data in the contract.

Note: The `new` and deprecated places in this article are the changes to version 2.0 relative to version 1.6.
## class

| | Class | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | The class that provides a way to query the balance.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Used to represent the data of a structure of an asset         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | A class that represents a block that provides a way to query transactions in a query block.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | This class provides a set of methods for accessing blockchain data.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | A contract that represents a contract.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `new` Used to indicate the data structure of the registrant's registration transaction. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Used to represent the data structure of a block header           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Provides a way to insert, query, and delete a persistent store   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContex](neo/StorageContex.md) | `new` The class used to represent the private store storage context |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  The base class used to represent the transaction            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | The data structure used to represent the transaction          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | The data structure used to represent the transaction input         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | The data structure used to represent the transaction output         |

## enumeration

|  | Enumeration | description |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContex](neo/StorageContex2.md) | `Deprecated 'is used to represent private storage area (" x ") Storage context enumeration
