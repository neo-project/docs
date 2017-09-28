# Storage.Get Method (StorageContext, string)

Returns a value from the persistent store based on the given key.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

Parameters:

Context: Storage context as a [StorageContext](../StorageContext.md).

Key: Key as a string.

Return Value: The value corresponding to the key as a byte array.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, "key");
     }
}
```



[Back](../Storage.md)
