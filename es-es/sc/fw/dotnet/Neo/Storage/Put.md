# Método Storage.Put (StorageContext, byte[], byte[])

Operación de inserción en la forma clave-valor (byte-array, byte-array) en el almacenamiento persistenten.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern void Put (Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, byte[] value)
```

## Parámetros:

Context: Contexto de almacenamiento, tipo [StorageContext](../StorageContext.md)

Key: clave, byte array.

Value: vaalor, byte array.

Valor devuelto: void.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] key = new byte[] {0};
         byte[] value = new byte[] {1};
         Storage.Put (Storage.CurrentContext, key, value);
     }
}
```



[Volver arriba](../Storage.md)
