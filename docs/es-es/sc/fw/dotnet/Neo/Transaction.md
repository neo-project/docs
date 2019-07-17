# Clase Transaction

Usada para representar la clase base de una transacción.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class Transaction: IScriptContainer
```

## Atributos

| | Nombre | Descripción |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Get Hash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Get the current type of transaction    |

## Método 

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
(Get/getAttributes.md) | Query all properties of the current transaction |
(Get/WriteInputs.md) | Query all transaction inputs for the current transaction ([ TransactionIntput](TransactionInput.md)) |
(Get/Letoutputs.md) | Query all transaction output for current transaction ([ TransactionOutput](TransactionOutput.md)) |
[GetReferences ()](Transaction/GetReferences.md) | Query all the input of the current transaction referenced by the [...] [quote_rightRe_us] Transaction output

## Construction method

Constructs a Transaction object via [Blockchain.GetTransaction (byte[])](Blockchain/GetTransaction.md).
