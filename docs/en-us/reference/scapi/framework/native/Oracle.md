# Oracle Class

Provides a series of methods of the native contract Oracle, which contract hash is `0xfe924b7cfe89ddd271abaf7210a80a7e11178758`.

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Oracle
```

## Attribute

| Name | Description       |
| ---- | ----------------- |
| Hash | The contract hash |

## Method

| Name                                                         | Description                          |
| ------------------------------------------------------------ | ------------------------------------ |
| GetPrice()                                                   | Gets the price for an Oracle request |
| [Request(string url, string filter, string callback, object userData, long gasForResponse)](Oracle/Request.md) | Initiates an Oracle request          |