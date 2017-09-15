# Storage.Delete method (StorageContext, string)

Delete the operation, in the persistent storage area through the key to delete the corresponding value.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern void Delete (Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

## Parámetros

Context: Contexto de almacenamiento [StorageContext](../StorageContext.md) type.

Key: clave, tipo string

Valor devuelto: void.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Storage.Delete (Storage.CurrentContext, "Key");
     }
}
```



[Volver arriba](../Storage.md)
