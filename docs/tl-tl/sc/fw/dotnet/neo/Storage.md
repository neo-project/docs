# Storage Class

Provides a set of methods to insert, query, and delete data in the persistent store.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Attributes

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | Returns the current context of the store |

## Methods

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | Deletes a value from the persistent store based on the given key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | Deletes a value from the persistent store based on the given key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | Returns a value from the persistent store based on the given key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | Returns a value from the persistent store based on the given key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | Inserts a given value to the given key in the persistent store |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | Inserts a given value to the given key in the persistent store |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | Inserts a given value to the given key in the persistent store |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | Inserts a given value to the given key in the persistent store |

## Constructor

The Storage class is a static class and does not require a constructor.
