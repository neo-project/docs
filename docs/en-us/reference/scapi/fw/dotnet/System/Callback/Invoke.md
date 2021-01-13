# Invoke(object)

Invokes the callback function.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern object Invoke(object[] args);
```

Parameters:
- args: The parameter of callback function

Return: The return value of callback function

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Invoke()
    {
        var callback = Callback.Create(new Func<int, int, int>(test));
        return callback.Invoke(new object[] { 1, 2 });
    }

    public static int test(int a, int b)
    {
        return a + b;
    }
}
```

Response body:

```json
[{
    "type":"Integer",
    "value":"3"
}]
```

Response description:

- Integer type: The return value of callback function is `3`.

- Other: failed.

[Back](../Callback.md)