# Contract Class

The class representing a contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attributes

| | Name | description |
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | Returns the scripthash of the contract |

## Methods

| | Name | Description |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | `New` Publishes the contract    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | `New` Migrates / renews the contract |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | `New` Destroys the contract    |

## Constructor

The Contract object can be constructed through [Blockchain.GetContract(byte[])](Blockchain/GetContract.md).

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) publishes the contract onto the blockchain and returns a Contract object.

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) renews the contract and returns a Contract object.