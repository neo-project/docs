# Enumerator Class

Customized enumerators in smart contracts.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly:  Neo.SmartContract.Framework

## Syntax

```c#
public class Enumerator<TValue>
```

## Attributes

| Name | Description          |
| ----- | ------------------------ |
| Value | Returns the current enumerator location |

## Methods

| Name                                | Description                                                  |
| ----------------------------------- | ------------------------------------------------------------ |
| Create(IEnumerable\<TValue\> entry) | The static method that creates enumerators                   |
| Concat(Enumerator\<TValue\> value)  | Collects two enumerators                                     |
| Next()                              | Returns if there is a next element in the enumerator and if yes, locates to the next element |