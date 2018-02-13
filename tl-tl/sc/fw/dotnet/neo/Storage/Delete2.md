# Storage.Delete Method (StorageContext, string)

Deletes a value from the peristent store based on the given key.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Parameters:

Context: Storage context as a [StorageContext](../StorageContext.md).

Key: Key as a string.

Return value: void.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Storage.Delete(Storage.CurrentContext, "Key");
     }
}
```



[Back](../Storage.md)
