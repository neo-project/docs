# Clase Block

Un clase que representa un bloque. Proporciona una manera de consultar transaciones de un bloque.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class Block: Header
```

## Método

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- | ------------ |
[GetTransaction (int)](Block/GetTransaction.md) | Devuelev la transacción de un bloque específico.|
[GetTransactionCount (int)](Block/GetTransactionCount.md) | Devuelve el número de transaciones en el actual bloque. |
[GetTransactions (array)](Block/GetTransactions.md) | Devuelve todas las transaciones en el actual bloque. |

## Método del constructor

El objeto Block se contruye con [Blockchain.GetBlock (byte[])](Blockchain/GetBlock.md).

El objeto Block se contruye con  [Blockchain.GetBlock (uint)](Blockchain/GetBlock2.md).
