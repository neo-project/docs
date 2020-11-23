# BlockAccount Method (byte[])

Sets the blocked accounts

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool BlockAccount(byte[] account);
```

Parameter

- account: The account to be added to the block list

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM".ToScriptHash();

    public static object Main()
    {
        bool result = Policy.BlockAccount(account);
        return result;
    }
}
```

[Back](../Policy.md)