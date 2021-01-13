# Create<T, TResult>(Func<TResult>)

Creates callback functions.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Callback Create<TResult>(Func<TResult> func);
```

Parameters:
- func: Delegate method object. The method parameter is blank, and return value type is `TResult`.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateCallback()
    {
        var callback = Callback.Create(new Func<int>(test));
        return callback.Invoke(new object[0]);
    }

    public static int test()
    {
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