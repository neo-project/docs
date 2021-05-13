# Iterator Class

The iterator for smart contracts.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Iterator
public class Iterator<T> : Iterator, IApiInterface
```

## Attributes

| Name | Description          |
| ----- | ------------------------ |
| Value | Gets the current value of the iterator |

## Methods

| Name                            | Name                                                     |
| ----------------------------------- | ------------------------------------------------------------ |
| Create(Map\<TKey, TValue\> entry) | Static method that creates iterators                         |
| Create(IEnumerable\<TValue\> entry)  | Static method that creates iterators            |
| Concat(Iterator\<TKey, TValue\> value) |Connects iterators |
| Next()            | Returns if there is a next element in the iterator and if yes, locates to the next element |

You can also use [Storage.Find()](Storage/Find.md)  to construct the Iterator object.