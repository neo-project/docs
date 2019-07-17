# Clase Blockchain

Esta clase proporciona una cojunto de metodos para accder a los datos de la blockchain.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static class Blockchain
```

## Método

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
|GetAccount (byte-array](Blockchain/GetAccount.md) | Devuelve la cuenta (dirección) en base al hash del script del contrato.
[GetAsset (byte-array](Blockchain/GetAsset.md) | Busca un asset en base un id. de activo.|
[GetBlock (byte-array)](Blockchain/GetBlock.md) | Devuelve el bloque en función de un valor hash especificado.
[GetBlock (uint)](Blockchain/GetBlock2.md) | Busca el bloque por tamaño. (height) |
[Gethract (byte-array)](Blockchain/GetContract.md) | Devuelve el contenido del contrato. |
[Getheader (byte-array)](Blockchain/GetHeader.md) | Devuelve la cabecera del bloque en función del hash de bloque.
[Getheader (uint)](Blockchain/GetHeader2.md) | Devuelve la cabecera del bloque via tamaño (height) de bloque. |
[Getheight ()](Blockchain/GetHeight.md) | Devuelve el actual tamaño de bloque. (height) |
[GetTransaction (byte-array)](Blockchain/GetTransaction.md) | Busca una transacción en base a un id. de transacción. |
[GetValidators](Blockchain/GetValidators.md) | Devuelve la clave pública de la persona consenso. |
[RegisterValidator (byte-array)](Blockchain/RegisterValidator.md) | Se registra como una persona consenso. |

## Método del constructor

La clase Blockchain es una clase estática y no necesita un constructor.

