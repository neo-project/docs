# Clase Header

Usado para representar la estructura de datos de la cabecera de un bloque.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../AntShares.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class Header: IScriptContainer
```

## Atributos

| | Nombre| Descripción |
| ---------------------------------------- | ------------------------------------ | -------- |
|[ConsensusData](Header/ConsensusData.md) | Obtiene los datos consenso del bloque.|
|[Hash](Header/ConsensusData.md) | Obtiene el hash del bloque.|
|[MerkleRoot](Header/MerkleRoot.md) | Obtiene el arbol Merkle de todas la transaciones. |
|[PrevHash](Header/PrevHash.md) | Obtiene el hash del bloque previo. |
|[Timestamp](Header/Timestamp.md) | Obtiene el timestamp del bloque. |
|[Version](Header/Version.md) | Obtiene la version del bloque. |


## Método del constructor

El objeto Header se contruye con [Blockchain.GetHeader (byte-array)](Blockchain/GetHeader.md) o bien con [Blockchain.GetHeader (uint)](Blockchain/GetHeader2.md)

