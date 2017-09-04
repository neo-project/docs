# TransactionOutput Class

The data structure used to represent the transaction output. A transaction output has three fields:

1. Type of assets
2. Destination address
3. Amount transferred

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionOutput: IApiInterface
```

## Attributes

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Returns asset ID |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Returns the scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Returns the transaction amount |


## Constructor

The TransactionOutput object is constructed through [GetOutputs()](Transaction/GetOutputs.md) of the Transaction object.
