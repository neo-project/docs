# Storage Class

Provides a set of methods to insert, query, and delete data in the persistent store.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Attributes

| Name | Description |
| ---------------------------------------- | ---------- |
| [CurrentContext](Storage/CurrentContext.md) | Returns the current context of the store |

## Methods

- Delete methods, which delete a value from the persistent storage based on the given key:
  - [Delete(StorageContext, string)](Storage/Delete.md) 
  - [Delete(StorageContext, byte[])](Storage/Delete.md)
  - [Delete(byte[])](Storage/Delete.md) 
  - [Delete(string)](Storage/Delete.md)

- Find methods, which find the value collection from the persistent storage based on the given key prefix:
  - [Find(StorageContext, byte[])](Storage/Find.md)
  - [Find(StorageContext, string)](Storage/Find.md) 
  - [Find(byte[])](Storage/Find.md)
  - [Find(string)](Storage/Find.md)

- Get methods, which query a value from the persistent storage based on the given key:
  - [Get(StorageContext, byte[])](Storage/Get.md)
  - [Get(StorageContext, string)](Storage/Get.md) 
  - [Get(byte[])](Storage/Get.md) 
  - [Get(string)](Storage/Get.md)

- Put methods, which put data in key-value format into the persistent storage:
  - [Put(StorageContext, byte[], byte[])](Storage/Put.md)
  - [Put(StorageContext, byte[], string)](Storage/Put.md)
  - [Put(StorageContext, byte[], BigInteger)](Storage/Put.md) 
  - [Put(StorageContext, string, byte[])](Storage/Put.md)
  - [Put(StorageContext, string, string)](Storage/Put.md)
  - [Put(StorageContext, string, BigInteger)](Storage/Put.md)
  - [Put(byte[], byte[])](Storage/Put.md) 
  - [Put(byte[], string)](Storage/Put.md)
  - [Put(byte[], BigInteger)](Storage/Put.md)
  - [Put(string, byte[])](Storage/Put.md)
  - [Put(string, string)](Storage/Put.md) 
  - [Put(string, BigInteger)](Storage/Put.md)

> [!Note]
>
> For all these methods if StorageContext is not passed in, CurrentContext is used by default.

## Constructor

The Storage class is a static class and does not require a constructor.
