# Base58Encode Method (byte[])

Converts the byte array into a Base58-encoded string.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string Base58Encode(byte[] input);
```

Parameters: input, the byte array to convert. 

Return: Base58-encoded string

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 Owner = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Encode()
    {
        return Binary.Base58Encode((byte[])Owner);
    }
}
```

Response body:

```json
[{
    "type":"ByteString", 
    "value":"2opji9aKc4uyAZLmpYMkNV2jPWt3"
}]
```

Response description:

- ByteString type: Base58-encoded string

- Other: failed.

[Back](../Binary.md)