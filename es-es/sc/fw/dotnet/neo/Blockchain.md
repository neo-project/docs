# Clase Blockchain

Esta clase proporciona una cojunto de metodos para accder a los datos de la blockchain.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static class Blockchain
```

## Método

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
[CreateAsset (byte, string, long, byte, byte-array, byte-array, byte-array, byte-array)](Blockchain/CreateAsset.md)| Crea un activo.|
[CreateContract (byte-array, byte-array, byte, bool, string, string, string , String)](Blockchain/CreateContract.md)| Publica un contrato inteligente.|
[GetAccount (byte-array](Blockchain/GetAccount.md) | Obtiene la cuenta (dirección) en base al hash del script del contrato.
[GetAsset (byte-array](Blockchain/GetAsset.md) | Busca un asset en base un id. de activo.|
[GetBlock (byte-array)](Blockchain/GetBlock.md) | Obtiene el bloque via hash.
[GetBlock (uint)](Blockchain/GetBlock2.md) | Busca el bloque por tamaño. (height) |
[Gethract (byte-array)](Blockchain/GetContract.md) | Obtiene el contenido del contrato. |
[Getheader (byte-array)](Blockchain/GetHeader.md) | Obtiene la cabecera del bloque via hash de bloque.
[Getheader (uint)](Blockchain/GetHeader2.md) | Obtiene la cabecera del bloque via tamaño (height) de bloque. |
[Getheight ()](Blockchain/GetHeight.md) | Obtiene el actual tamaño de bloque. (height) |
[GetTransaction (byte-array)](Blockchain/GetTransaction.md) | Busca una transacción en base a un id. de transacción. |
[GetValidators](Blockchain/GetValidators.md) | Obtiene la clave pública de la persona consenso. |
[RegisterValidator (byte-array)](Blockchain/RegisterValidator.md) | Se registra como una persona consenso. |

## Método del constructor

La clase Blockchain es una clase estática y no necesita un constructor.

