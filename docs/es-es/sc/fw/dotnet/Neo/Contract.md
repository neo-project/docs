# Clase Contrato

La case que representa un contrato.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class contract
```

## Atributos

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------- | ---------- |
[Script](Contract/Script.md) | Devuelve el hash del script del contrato. |

## Métodos

| | Nombre | Descripción |
| ---------------------------------------- | -------------------------------- | ------ |
[Create](Contract/Create.md) | Crea un contrato inteligente. |
[Migrate](Contract/Migrate.md) | Migra un contrato inteligente. |
[Destroy](Contract/Destroy.md) | Destruye un contrato inteligente. |

## Método del constructor

El objecto Contracto se contruye con el metodo [Blockchain.GetContract (byte-array)](Blockchain/GetContract.md)

Para publicar un contrato inteligente en la blockchain y devolver un objecto usa [Blockchain.createContract (byte-array, byte-array, byte, bool, string, string, string, string, string)](Blockchain/CreateContract.md)
