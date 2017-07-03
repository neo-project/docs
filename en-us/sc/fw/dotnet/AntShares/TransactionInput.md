# TransactionInput class

Used to represent the data structure of the transaction input.

In a UTXO system, the input of a transaction must come from the output of another transaction that existed before. ([PrevHash](TransactionInput/PrevHash.md)), and the output of all the output of the previous transaction ([PrevIndex](PrevHash.md)), and the output of the previous transaction, TransactionInput/PrevIndex.md)).

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class TransactionInput: IApiInterface
```

## Attributes

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
(PrevHash) (TransactionInput/PrevHash.md) | Transactional Hedding of Transactions Involved | |[][]()
| [PrevIndex](TransactionInput/PrevIndex.md) | The transactions that are referenced are output in its entire transaction output list (https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) In the index

## Construction method

The TransactionInput object is constructed by the [GetInputs ()](Transaction/GetInputs.md) method of the Transaction object.
