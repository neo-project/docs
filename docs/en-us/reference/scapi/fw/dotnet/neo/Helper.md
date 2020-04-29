# Helper Class

An auxiliary method of the contract storage, including creating StorageMap objects, retrieving elements, deleting elements, and updating elements.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Helper
```

## Methods

| Name                                                   | Description                                                  |
| ------------------------------------------------------ | ------------------------------------------------------------ |
| CreateMap(this StorageContext context, string prefix)  | Creates StorageMap objects                                   |
| CreateMap(this StorageContext context, byte[] prefix)  | Creates StorageMap objects                                   |
| CreateMap(this StorageContext context, byte prefix)    | Creates StorageMap objects                                   |
| Delete(this StorageMap map, byte[] key)                | Deletes the key of the byte array type given in the storage context |
| Delete(this StorageMap map, string key)                | Deletes the key of the string given in the storage context   |
| Get(this StorageMap map, byte[] key)                   | Gets the byte array type value corresponding to the key of the byte array type given in the storage context |
| Get(this StorageMap map, string key)                   | Gets the byte array type value corresponding to the key of the string given in the storage context |
| Put(this StorageMap map, byte[] key, byte[] value      | Puts the byte array type value to the key of the byte array type for the given storage context |
| Put(this StorageMap map, byte[] key, BigInteger value) | Puts the BigInteger type value to the key of the byte array type for the given storage context |
| Put(this StorageMap map, byte[] key, string value)     | Puts the string type value to the key of the byte array type for the given storage context |
| Put(this StorageMap map, string key, byte[] value)     | Puts the byte array type value to the key of the string type for the given storage context |
| Put(this StorageMap map, string key, BigInteger key)   | Puts the BigInteger type value to the key of the string type for the given storage context |
| Put(this StorageMap map, string key, string value)     | Puts the string type value to the key of the string type for the given storage context |

## Constructor

Helper is a static class and does not require a constructor.

