# FindOptions Enumeration

Defines find options for searching storage. This is used in the Storage.Find method.

Namespace: Neo.SmartContract

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum FindOptions : byte
{
    None = 0,

    KeysOnly = 1 << 0,
    RemovePrefix = 1 << 1,
    ValuesOnly = 1 << 2,
    DeserializeValues = 1 << 3,
    PickField0 = 1 << 4,
    PickField1 = 1 << 5
}
```

##### Description

- None: Search all

- KeysOnly: Search Key only. It cannot be used together with ValuesOnly, DeserializeValues, PickField0, and PickField1.
- RemovePrefix: Similar to KeysOnly. It will filter to the first byte of Key, i.e., the prefix of Key. It cannot be used together with ValuesOnly
- ValuesOnly: Search Value only. It cannot be used together with KeysOnly and RemovePrefix.
- DeserializeValues: Search Value and then deserialize the Value.
- PickField0: Search the first element of Value array. It must be used together with DeserializeValues, not with PickField1.
- PickField1: Search the second element of Value array. It must be used together with DeserializeValues, not with PickField0.
- FindOptions is used in [Storage.Find(StorageContext, ByteString, FindOptions)](Storage/Find.md) 

