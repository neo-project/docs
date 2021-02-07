# Binary.Base58Decode Method

Decodes the Base58-encoded string into an equivalent byte array.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte[] Base58Decode(string input);
```

Parameters: input, Base58-encoded string

Return: byte array

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Decode()
    {
        string str = "2opji9aKc4uyAZLmpYMkNV2jPWt3";
        Binary.Base58Decode(str);  // "81b9b84424acda5ebabd9ade4f7ac5b8d2a0b4d4"
    }
}
```

[Back](../Binary.md)