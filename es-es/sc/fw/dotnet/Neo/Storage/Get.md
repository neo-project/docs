# Método Storage.Get (StorageContext, byte[])

Operación de consulta en el area de almacenamiento persistente a través de una consulta de una clave (byte-array), obteniendo
el valor correspondiente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern byte[] Get (Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

## Parámetros:

Context: Contexto de almacenamiento, tipo, [StorageContext](../StorageContext.md)

Key: clave, del tipo byte array.

Valor devuelto: el valor correspondiente a la clave, byte array.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] value = Storage.Get (Storage.CurrentContext, new byte[] {0});
     }
}
```



[Voler arriba](../Storage.md)
