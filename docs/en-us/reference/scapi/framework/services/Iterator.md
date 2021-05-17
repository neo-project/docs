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
| Value | Gets the element in the collection at the current position of the iterator |

## Methods

| Name                            | Name                                                     |
| ----------------------------------- | ------------------------------------------------------------ |
| Next()            | Advances the iterator to the next element of the collection |

You can also use [Storage.Find()](Storage/Find.md)  to construct the Iterator object.