# Create<T, TResult>(Func<T, TResult>)

Creates callback functions.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Callback Create<T, TResult>(Func<T, TResult> func);
```

Parameters:
- func: Delegate method object. The method parameter type is `T`, and return value type is `TResult`.

> [!Note]
>
> Currently up to 16 delegate method parameters are supported 

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateCallback2()
    {
        var callback = Callback.Create(new Func<bool, int>(test));
        return callback.Invoke(new object[] { true });
    }

    public static int test(bool flag)
    {
        if (!flag) return -1;
        return 1024;
    }
}
```

Response body:

```json
[{
    "type":"Integer",
    "value":"1024"
}]
```

Response description:

- Integer type: The return value of callback function is `1024`.

- Other: failed.

[Back](../Callback.md)