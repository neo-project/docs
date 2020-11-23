# RegisterCandidate Method (byte[])

Registers as a candidate.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool RegisterCandidate(byte[] pubkey);
```

Parameter：

- pubkey: The public key of the account to be registered.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] pubkey = new byte[] { 0x02, 0xe8, 0xff, 0x17, 0xc5, 0x67, 0xd6, 0x2f, 0x27, 0x4f, 0xe2,
         0x47, 0xcc, 0x88, 0x4a, 0x2a, 0x6c, 0xd3, 0xb8, 0xfd, 0x0d, 0x77, 0x9a, 0x8c, 0x58, 0x56, 0x28, 0x9a, 0x56, 0x0a, 0xcc, 0xac, 0xb4 };

    public static object Main()
    {
        bool result = NEO.RegisterCandidate(pubkey);
        return result;
    }
}
```

[Back](../Neo.md)