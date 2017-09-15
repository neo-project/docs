# Storage.Get method (StorageContext, string)

Operación de consulta en el area de almacenamiento persistente a través de una consulta de una clave (string), obteniendo el valor correspondiente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern void Delete (Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

## Parámetros:

Context: Context: Contexto de almacenamiento, tipo, [StorageContext](../StorageContext.md)

Key: clave, tipo string.

Valor devuelto: el valor correspondiente a la clave, byte array.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] value = Storage.Get (Storage.CurrentContext, "key");
     }
}
```



[Volver arriba](../Storage.md)
