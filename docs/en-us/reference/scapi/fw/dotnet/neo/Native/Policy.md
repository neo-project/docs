# Native.Policy Method (string, object[])

Invokes the method in the Policy contract with the method name and method parameters.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern object Policy(string method, object[] arguments);
```

Parameters:

- method: The method name
- arguments: The method arguments

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger feeByte = (BigInteger)Native.Policy("getFeePerByte", new object[]{});
    }
}
```

[Back](../Native.md)