# Iterator 类

智能合约中的迭代器。

命名空间：[Neo.SmartContract.Framework.Services](../Neo.SmartContract.Framework.Services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Iterator
public class Iterator<T> : Iterator, IApiInterface
```

## 属性

| 名称  | 说明               |
| ----- | ------------------ |
| Value | 获得迭代器当前的值 |

## 方法

| 名称                                | 说明                                                         |
| ----------------------------------- | ------------------------------------------------------------ |
| Create(Map\<TKey, TValue\> entry) | 静态方法，创建迭代器                                         |
| Create(IEnumerable\<TValue\> entry)  | 静态方法，创建迭代器                                                |
| Concat(Iterator\<TKey, TValue\> value) |合并迭代器 |
| Next()            | 获得迭代器中是否有下个元素，如果有则迭代器将当前位置定位到下个元素 |

也可通过 [Storage.Find()](Storage/Find.md) 来构造 Iterator 对象。