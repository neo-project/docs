# Vote Method (byte[], byte[])

Votes for the candidates.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool Vote(byte[] account, byte[] voteTo);
```

Parameters:

- account: Script hash of the voting account.
- voteTo: Public key of the account to vote.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] voteTo = new byte[] { 0x02, 0xe8, 0xff, 0x17, 0xc5, 0x67, 0xd6, 0x2f, 0x27, 0x4f, 0xe2,
         0x47, 0xcc, 0x88, 0x4a, 0x2a, 0x6c, 0xd3, 0xb8, 0xfd, 0x0d, 0x77, 0x9a, 0x8c, 0x58, 0x56, 0x28, 0x9a, 0x56, 0x0a, 0xcc, 0xac, 0xb4 };
         
    public static object Main()
    {
        bool result = NEO.Vote(account, voteTo);
        return result;
    }
}
```

[Back](../Neo.md)