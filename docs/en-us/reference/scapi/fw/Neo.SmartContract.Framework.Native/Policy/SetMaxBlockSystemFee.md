# SetMaxBlockSystemFee Method

Sets the maximum system fee for the block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool SetMaxBlockSystemFee(long value);
```

Parameter:

- value: the maximum system fee for the block

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxBlockSystemFee(4007800L);
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

- true: successfully set the maximum system fee for the block

- Others: failed.

>[!Note]
>
>The fee should not be less than 4007600.

[Back](../Policy.md)