# Storage Class

Provides a set of methods to insert, query, and delete data in the persistent storage.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Attributes

| Name                                   | Description |
| ---------------------------------------- | ---------- |
| [CurrentContext](Storage/CurrentContext.md) | Returns the current storage context |
| CurrentReadOnlyContext | Returns the read-only context of the current contract storage |

## Methods

| Name                                    | Description                    |
| ---------------------------------------- | -------------------------------- |
| [Delete(StorageContext context, byte[] key)](Storage/Delete.md) | Deletes the value corresponding to byte[] key from the given storage context |
| [Delete(StorageContext context, string key)](Storage/Delete.md) | Deletes the value corresponding to string key from the given storage context |
| [Delete(string key)](Storage/Delete.md) | Deletes the value corresponding to string key from the current storage context |
| [Delete(byte [] key)](Storage/Delete.md) | Deletes the value corresponding to byte[] key from the current storage context |
| [Get(StorageContext context, byte[] key)](Storage/Get.md) | Gets the byte[] value corresponding to the given byte[] key from the given storage context |
| [Get(StorageContext context, string key)](Storage/Get.md) | Gets the byte[] value corresponding to the given string key from the given storage context |
| [Get(byte[] key)](Storage/Get.md) | Gets the byte[] value corresponding to the given byte[] key from the current storage context |
| [Get(string key)](Storage/Get.md) | Gets the byte[] value corresponding to the given string key from the current storage context |
| [Put(StorageContext context, byte[] key, byte[] value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-byte[] into the given storage context |
| [Put(StorageContext, byte[] key, string value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-string into the given storage context |
| [Put(StorageContext, string key, byte[] value)](Storage/Put.md) | Puts the key-value pair in the form of string-byte[] into the given storage context |
| [Put(StorageContext, string key, string value)](Storage/Put.md) | Puts the key-value pair in the form of string-string into the given storage context |
| [Put(StorageContext context, byte[] key, BigInteger value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-BigInteger into the given storage context |
| [Put(StorageContext context, string key, BigInteger value)](Storage/Put.md) | Puts the key-value pair in the form of string-BigInteger into the given storage context |
| [Put(byte\[\] key, byte[] value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-byte[] into the given storage context |
| [Put(byte[] key, BigInteger value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-BigInteger into the current storage context |
| [Put(byte[] key, string value)](Storage/Put.md) | Puts the key-value pair in the form of byte[]-string into the current storage context |
| [Put(string key, byte[] value)](Storage/Put.md) | Puts the key-value pair in the form of string-byte[] into the current storage context |
| [Put(string key, BigInteger value)](Storage/Put.md)          | Puts the key-value pair in the form of string-BigInteger into the current storage context |
| [Put(string key, string value)](Storage/Put.md) | Puts the key-value pair in the form of string-string into the current storage context |
| [PutEx(byte[] key, byte[] value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of byte[]-byte[] into the current storage context, and sets the data property to flags. |
| [PutEx(byte[] key, BigInteger value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of byte[]-BigInteger into the current storage context, and sets the data property to flags. |
| [PutEx(byte[] key, string value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of byte[]-string into the current storage context, and sets the data property to flags. |
| [PutEx(string key, byte[] value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of string-byte[] into the current storage context, and sets the data property to flags. |
| [PutEx(string key, BigInteger value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of string-BigInteger into the current storage context, and sets the data property to flags. |
| [PutEx(string key, string value, StorageFlags flags)](Storage/PutEx.md) | Puts the key-value pair in the form of string-string into the current storage context, and sets the data property to flags. |
| [Find(StorageContext context, byte[] prefix)](Storage/Find.md) | Finds the content of byte[] prefix in the given storage context. |
| [Find(StorageContext context, string prefix)](Storage/Find.md) | Finds the content of string prefix in the given storage context. |
| [Find(byte[] prefix)](Storage/Find.md) | Finds the content of byte[] prefix in the current storage context. |
| [Find(string prefix)](Storage/Find.md) | Finds the content of string prefix in the current storage context. |

## Constructor

The Storage class is a static class and does not require a constructor.