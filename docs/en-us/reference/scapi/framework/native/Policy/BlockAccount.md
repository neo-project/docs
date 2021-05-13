# BlockAccount Method

Sets the blocked accounts. Transactions sent from the blocked accounts will not be packaged by consensus nodes.

Namespace：[Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool BlockAccount(UInt160 account);
```

Parameter

- account: The account to be added to the block list

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM".ToScriptHash();

    public static object Test()
    {
        bool result = Policy.BlockAccount(account);
        return result;
    }
}
```

Response body:

```json
{
	"type":"Boolean",
	"value":"true"
}
```

Response description:

- true: The account is blocked successfully.

- Others: failed.

[Back](../Policy.md)