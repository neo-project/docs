# GetFeePerByte Method ()

Gets fee per byte

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger GetFeePerByte();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = Policy.GetFeePerByte();
        return result;
    }
}
```

[Back](../Policy.md)