# FindOptions 枚举

定义搜索存储区时的搜索选项，用在 Storage.Find 方法中。

命名空间：Neo.SmartContract

程序集：Neo.SmartContract.Framework

## 语法

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

##### 说明

- None：搜索全部

- KeysOnly：仅搜索 Key，不能与 ValuesOnly、DeserializeValues、 PickField0、PickField1 同时使用

- RemovePrefix：与KeysOnly类似，但会过滤到Key的第一个字节，一般Key的第一个字节为Key的前缀。不能与 ValuesOnly 同时使用

- ValuesOnly：仅搜索 Value，不能与 KeysOnly、RemovePrefix 同时使用

- DeserializeValues：搜索 Value，并将 Value 反序列化

- PickField0：搜索Value数组的第一个元素，必须和DeserializeValues一同使用，不能与PickField1同时使用

- PickField1：搜索Value数组的第二个元素，必须和DeserializeValues一同使用，不能与PickField0同时使用

- FindOptions 用在 [Storage.Find(StorageContext, ByteString, FindOptions)](Storage/Find.md) 方法中。


