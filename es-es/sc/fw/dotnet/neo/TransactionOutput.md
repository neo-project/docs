# Clase TransactionOutput

La estructura de datos usada para representar la salida de la transación. La salida de la transación tiene tres campos:
La transferencia del activo, la direcció y cuanto dinero transferido.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class TransactionOutput: IApiInterface
```

## Atributos

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- | ------ |
| [AssetId](TransactionOutput/AssetId.md) | Obtiene el id. del asset |
| [ScriptHash](TransactionOutput/ScriptHash.md) | Obtiene el hash del script | 
| [Value](TransactionOutput/Value.md) | Obtiene la cantidad de tranferida |

## Método de constructor

El objeto TransactionOutput se construye con el metodo [GetOutputs ()](Transaction/GetOutputs.md) del objeto Transaction.


