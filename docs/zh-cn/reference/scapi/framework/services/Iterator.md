# Iterator 类

智能合约中的迭代器。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Iterator
public class Iterator<T> : Iterator, IApiInterface
```

## 属性

| 名称  | 说明                               |
| ----- | ---------------------------------- |
| Value | 获取集合中位于迭代器当前位置的元素 |

## 方法

| 名称                                | 说明                                                         |
| ----------------------------------- | ------------------------------------------------------------ |
| Next()            | 将迭代器推进到集合的下一个元素 |

也可通过 [Storage.Find()](Storage/Find.md) 来构造 Iterator 对象。