# TransactionInput Class

Used to represent the data structure of the transaction input.

In a UTXO system, the input of a transaction must come from the output of another transaction that existed before. 

To confirm the outputs of the previous transactions, we require two things:

1.  The hash of the previous transaction referenced ([PrevHash](TransactionInput/PrevHash.md))
2.  The index of this input in the output list of the previous transaction ([PrevIndex](TransactionInput/PrevIndex.md))

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionInput: IApiInterface
```

## Attributes

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Returns the hash of the previous transaction            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Returns the index of this input in the output list of the previous transaction |

## Constructor

The TransactionInput object is constructed through [GetInputs()](Transaction/GetInputs.md) of the Transaction object.
