# Storage class

Provides a way to insert, query, and delete persistent storage areas.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static class Storage
```

## Attributes

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ---------- |
[CurrentContext](Storage/CurrentContext.md) | Get the current store context |

## method

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
[Delete (StorageContext, byte[])](Storage/Delete.md) | Delete operation, in the [delete (StorageContext, byte[])] In the persistent store, delete the corresponding value
[Delete (StorageContext, string)](Storage/Delete2.md) | delete operation, in the persistence of the [Delete (StorageContext, string)] In the memory area, delete the corresponding value
[Get (StorageContext, byte[])](Storage/Get.md) | Query operation, in the [ The value of the corresponding value in the persistent store
(Get/StorageS) In the storage area, query the corresponding value
(Put (StorageContext, byte[], byte[])](Storage/Put.md) | Insert an action to insert data into the persistent store in the form of key-value
[Put (StorageContext, byte[], string)](Storage/Put2.md) | Insert operation (| To insert data into the persistent store in the form of key-value
(Put (StorageContext, string, byte[])](Storage/Put3.md) | Insert operation (| To insert data into the persistent store in the form of key-value
(Put (StorageContext, string, string)](Storage/Put4.md) | Insert the operation to the [Insert (StorageContext, string, string)](http://www.mshn.sec.s-msft.com/dynimg/IC91302.jpeg) Key-value to insert data into the persistent store

# Construction method

The Storage class is a static class and does not require a constructor.
