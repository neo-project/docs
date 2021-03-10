# Binary.Base64Decode Method

Decodes the Base64-encoded string into an equivalent byte array.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte[] Base64Decode(string input);
```

Parameters: input, Base64-encoded string

Return: byte array

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Decode()
    {
        string str = "HN37B9huZAKgFSjkHDNXEAvbX08="; // "1cddfb07d86e6402a01528e41c3357100bdb5f4f" 
        Binary.Base64Decode(str);
    }
}
```

[Back](../Binary.md)