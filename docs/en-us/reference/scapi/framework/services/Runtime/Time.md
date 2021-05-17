# Runtime.Time Attribute

Gets the current block time stamp.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint Time
```

Attribute: unix time stamp. Unsigned Integer.

## Example

```c#
public static bool Main()
{
    if (Runtime.Time >= 1587959138)
    {
        // do something;
    }
}
```



[Back](../Runtime.md)