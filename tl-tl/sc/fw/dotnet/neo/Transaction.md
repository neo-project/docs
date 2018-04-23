# Transaction Class

Used to represent the base class of a transaction.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Transaction: IScriptContainer
```

## Attributes

| | Name | Description |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Returns the hash of the transaction |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Returns the type of the transaction |

## Methods

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | Returns all attributes of the transaction |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | Returns all [TransactionInput](TransactionInput.md) of the transaction |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | Returns all [TransactionOutput](TransactionOutput.md) of the transaction |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | Returns all outputs referenced by the inputs of the transaction |

## Constructor

The Transaction object is constructed through [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
