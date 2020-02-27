# Iterator Class

The customized iterator for smart contracts.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Iterator<TKey, TValue>
```

## Attributes

| Name | Description          |
| ----- | ------------------------ |
| Key | Gets the current Key value of the iterator |
| Value | Gets the current value of the iterator |
| Keys | Gets the iterator for all keys of the iterator   |
| Values | Gets the iterator for all values of the iterator |

## Methods

| Name                            | Name                                                     |
| ----------------------------------- | ------------------------------------------------------------ |
| Create(Map\<TKey, TValue\> entry) | Static method that creates iterators                         |
| Create(IEnumerable\<TValue\> entry)  | Static method that creates iterators            |
| Concat(Iterator\<TKey, TValue\> value) |Connects iterators |
| Next()            | Returns if there is a next element in the iterator and if yes, locates to the next element |
