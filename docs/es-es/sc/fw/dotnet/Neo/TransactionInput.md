# Clase TransactionInput

Se utiliza para representar la estructura de datos de la entrada de una transacción. En un sistema UTXO (Number of Unspent Transaction Outputs), la entrada de una transacción debe venir de la salida de otra transación que previamente exista. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class TransactionInput: IApiInterface
```

## Atributos

|  Nombre | Descripción | 
| ---------------------------------------- | ---------------------------------------- |
| [PrevHash](TransactionInput/PrevHash.md) | El hash de la transacción de la transacción previa. |
| [PrevIndex](TransactionInput/PrevIndex.md) | :boom: revisar 

## Método de construcción

El objeto TransactionInput se contruye con el metodo [GetInputs ()](Transaction/GetInputs.md) del objeto Transaction.

