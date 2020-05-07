# Contract Class

The class representing a contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attributes

| Name | description |
| ---------------------------- | ---------- |
| [IsPayable](Contract/IsPayable.md) | Represents if the contract can receive NEP-5 assets |
| [Script](Contract/Script.md) | Returns the scripthash of the contract |
| [StorageContext](Contract/StorageContext.md) | Returns the storage context of the contract |

## Methods

| Name | Description |
| -------------------------------- | ------ |
| [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | Publishes the contract    |
| [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | Migrates / renews the contract |
| [Destroy()](Contract/Destroy.md)         | Destroys the contract    |

## Constructor

The Contract object can be constructed through [Blockchain.GetContract(byte[])](Blockchain/GetContract.md).

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) publishes the contract onto the blockchain and returns a Contract object.

[Contract.Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) renews the contract and returns a Contract object.
