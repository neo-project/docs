# AntShares namespace

The AntShares namespace is the API provided by the small-ants blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories.

1, blockchain books. The contract procedure can access all the data on the entire chain chain through interactive services, including complete blocks and transactions, as well as each of their fields.

2, persistent storage area. Each application contract deployed on a AntShares has a storage space that can only be accessed by the contract itself and can be used to access the data in the contract.

Note: The `new` and deprecated places in this article are the changes to version 2.0 relative to version 1.6.
## class

| | Class | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](AntShares/Account.md)          | The class that provides a way to query the balance.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](AntShares/Asset.md)              | Used to represent the data of a structure of an asset         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](AntShares/Block.md)              | A class that represents a block that provides a way to query transactions in a query block.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](AntShares/Blockchain.md)    | This class provides a set of methods for accessing blockchain data.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](AntShares/Contract.md)        | A contract that represents a contract.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](AntShares/Enrollment.md)    | `new` Used to indicate the data structure of the registrant's registration transaction. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](AntShares/Header.md)            | Used to represent the data structure of a block header           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](AntShares/Storage.md)          | Provides a way to insert, query, and delete a persistent store   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContex](AntShares/StorageContex.md) | `new` The class used to represent the private store storage context |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](AntShares/Transaction.md)  |  The base class used to represent the transaction            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](AntShares/TransactionAttribute.md) | The data structure used to represent the transaction          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](AntShares/TransactionInput.md) | The data structure used to represent the transaction input         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](AntShares/TransactionOutput.md) | The data structure used to represent the transaction output         |

## enumeration

|  | Enumeration | description |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContex](AntShares/StorageContex2.md) | `Deprecated 'is used to represent private storage area (" x ") Storage context enumeration
