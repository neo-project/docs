# SetMaxTransactionsPerBlock Method (uint)

Sets max transaction per block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool SetMaxTransactionsPerBlock(uint value);
```

Parameter：

- value: Maximum number of transactions to be set

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetMaxTransactionsPerBlock(1024);
        return result;
    }
}
```

[Back](../Policy.md)