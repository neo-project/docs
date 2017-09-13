# Método Storage.Put (StorageContext, string, string)

Operación de inserción en la forma clave-valor (string, string) en el almacenamiento persitente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern void Put (Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, string value)
```

## Parámetros

Context: Contexto de almacenamiento, tipo [StorageContext](../StorageContext.md)

Key: clave, string.

Value: valor, string.

Valor devuelto: void.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         String key = "key";
         String value = "value";
         Storage.Put (Storage.CurrentContext, key, value);
     }
}
```


[Volver arriba](../Storage.md)
