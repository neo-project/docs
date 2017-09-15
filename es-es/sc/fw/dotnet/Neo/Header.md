# Clase Header

Usado para representar la estructura de datos de la cabecera de un bloque.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class Header: IScriptContainer
```

## Atributos

| | Nombre| Descripción |
| ---------------------------------------- | ------------------------------------ | -------- |
|[ConsensusData](Header/ConsensusData.md) | Devuelve los datos consenso del bloque.|
|[Hash](Header/ConsensusData.md) | Devuelve el hash del bloque.|
|[MerkleRoot](Header/MerkleRoot.md) | Devuelve el arbol Merkle de todas la transaciones. |
|[PrevHash](Header/PrevHash.md) | Devuelve el hash del bloque previo. |
|[Timestamp](Header/Timestamp.md) | Devuelve el timestamp del bloque. |
|[Version](Header/Version.md) | Devuelve la version del bloque. |


## Método del constructor

El objeto Header se contruye con [Blockchain.GetHeader (byte-array)](Blockchain/GetHeader.md) o bien con [Blockchain.GetHeader (uint)](Blockchain/GetHeader2.md)

