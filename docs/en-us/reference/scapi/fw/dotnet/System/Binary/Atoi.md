# Atoi(string, int @base = 10)

Converts a character string to a specific base value, decimal or hexadecimal. The default is decimal.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger Atoi(string value, int @base = 10);
```

Parameters:
- value: The string to convert.
- base: The value base.

Return: Equivalent value.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Convert()
    {
        return Binary.Atoi("ff", 16); 
    }
}
```

Response body:

```json
[{
    "type":"Integer",
    "value":"-1"
}]
```

Response description：

- Integer type: Equivalent value.

- Other: failed.

[Back](../Binary.md)

