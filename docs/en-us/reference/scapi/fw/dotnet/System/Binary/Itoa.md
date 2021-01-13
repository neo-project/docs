# Itoa(BigInteger, int)

Converts the specific type of value to a decimal or hexadecimal string. The default is decimal.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string Itoa(BigInteger value, int @base = 10);
```

Parameters:
- value: The specific type value
- base: The value base.

Return: Base64-encoded string

> [!Note]
>
> `value` can be `BigInteger`, `int`, `uint`, `long`, `ulong`, `short`, `ushort`, `byte`, `sbyte`.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Convert()
    {
        return Binary.Itoa(-1, 16); // Convert.ToBase64String(((ByteString)"f").GetSpan())
    }
}
```

Response body:

```json
[{
    "type":"ByteString",
    "value":"Zg=="
}]
```

Response description:

- ByteString type: Base64-encoded string
- Other: failed.

[Back](../Binary.md)