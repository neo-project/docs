# Helper Class

An auxiliary method of the contract storage, including creating StorageMap objects, retrieving elements, deleting elements, and updating elements.

Helper class contains a series of extension methods to make coding easier.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Helper
```

## Methods

| Name                                                   | Description                                                  |
| ------------------------------------------------------ | ------------------------------------------------------------ |
| CreateMap(this StorageContext context, ByteString prefix)  | Creates StorageMap objects with string prefix                                  |
| CreateMap(this StorageContext context, byte[] prefix)  | Creates StorageMap objects with byte array prefix                                  |
| CreateMap(this StorageContext context, byte prefix)    | Creates StorageMap objects with byte prefix                                  |
| Delete(this StorageMap map, ByteString key) | Deletes the key of the string given in the storage context   |
| Get(this StorageMap map, ByteString key)  | Gets the byte array type and string type value corresponding to the key of the string given in the storage context |
| Put(this StorageMap map, ByteString key, ByteString value | Puts the byte array type and string type value to the key of the byte array type for the given storage context |
| Put(this StorageMap map, ByteString key, BigInteger value) | Puts the BigInteger type value to the key of the byte array type for the given storage context |

## Constructor

Helper is a static class and does not require a constructor.

