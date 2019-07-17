# Clase Storage

Proporciona una manera de insertar, consultar y borrar áreas de almancenamiento persistente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static class Storage
```

## Atributos

| Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- |
[CurrentContext](Storage/CurrentContext.md) | Devuelve el actual contexto del almacenamiento |

## Métodos

|  Name | description |
| ---------------------------------------- | ---------------------------------------- |
[Delete (StorageContext, byte-array)](Storage/Delete.md) | Operación de borrado (clave-byte[]) en el área del almacenamiento persistente.|
[Delete2 (StorageContext, string)](Storage/Delete2.md) | Operación de borrado (clave-string) en el área del almacenamiento persistente.|
[Get (StorageContext, byte-array)](Storage/Get.md) | Operación de consulta (clave-byte[]) en el area de almacenamiento persistente. |
[Get2 (StorageConext, key)](Storage/Get2.md) |Operación de consulta via (clave-string) en el area de almacenamiento persistente. |
[Put (StorageContext, byte-array, byte-array)](Storage/Put.md) | Operación de inserción en la forma clave-valor (clave-byte[], valor-byte[]) en el almacenamiento persitente. |
[Put2 (StorageContext, byte-array, string)](Storage/Put2.md) | Operación de inserción en la forma clave-valor (clave-byte[], valor-string) en el almacenamiento persitente. |
[Put3 (StorageContext, string, byte-array)](Storage/Put3.md) | Operación de inserción en la forma clave-valor (clave-string, valor-byte[]) en el almacenamiento persitente.
[Put4 (StorageContext, string, string)](Storage/Put4.md) | Operación de inserción en la forma clave-valor (clave-string, valor-string) en el almacenamiento persitente. |

## Método del constructor

La clase Storage es una clase estática y no requiere constructor.
