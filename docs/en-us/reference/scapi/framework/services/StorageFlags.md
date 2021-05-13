# StorageFlags Class

This class represents the written data property. It defaults to None, allowing data to be read and written. If the property is Constant, data written to the storage can neither be modified nor deleted.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
   public enum StorageFlags : byte
    {
        None = 0x00,
        Constant = 0x01
    }
```
