# TransactionOutput class

The data structure used to represent the transaction output. A transaction output has three fields, which is the transfer of assets, transfer to which address, how much money transferred.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class TransactionOutput: IApiInterface
```

## Attributes

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ------ |
| [AssetId](TransactionOutput/AssetId.md) | Get Asset ID | | [Asset_id
| [ScriptHash](TransactionOutput/ScriptHash.md) | Get Script Hash | Get [ScriptHash](ScriptOashput; ScriptHash.md) 
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Get Transaction Amount      | [Value](TransactionOutput/Value.md) |

## Construction method

The TransactionOutput object is constructed by the [GetOutputs ()](Transaction/GetOutputs.md) method of the Transaction object.
