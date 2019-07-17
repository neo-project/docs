# Storage.Put Method (StorageContext, byte[], string)

Inserts a given value to the given key in the persistent store.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, string value)
```

Parameters:

Context: Storage context as a [StorageContext](../StorageContext.md).

Key: Key as a byte array.

Value: Value as a string.

Return value: void.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] key = new byte[] {0};
         String value = "value";
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Back](../Storage.md)
