# Base64Encode Method (byte[])

Converts the byte array into a Base64-encoded string.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string Base64Encode(byte[] input);
```

Parameters: input, the byte array to convert. 

Return: Base64-encoded string

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static byte[] ScriptHash = "0x4f5fdb0b1057331ce42815a002646ed807fbdd1c".HexToBytes(reverse: true);

    public static object Encode()
    {
        return Binary.Base64Encode(ScriptHash);
    }
}
```

Response body:

```json
[{
    "type":"ByteString", 
    "value":"SE4zN0I5aHVaQUtnRlNqa0hETlhFQXZiWDA4PQ=="
}]
```

Response description:

- ByteString type: Base64-encoded string
- Other: failed.

[Back](../Binary.md)