# Native.NEO Method (string, object[])

Invokes the method in the Neo contract with the method name and method parameters.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern object NEO(string method, object[] arguments);
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
        byte[] from = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW".ToScriptHash();
        byte[] to = "NUo4WsPRJCrSLriRhKwduWvoG2CxHwsdfi".ToScriptHash();
        BigInterger value = new BigInteger(1000);
        bool result = Native.NEO("transfer", new Object[]{from, to, value.AsByteArray()});
        return result;
    }
}
```

[Back](../Native.md)