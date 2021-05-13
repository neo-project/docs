# SetFeePerByte Method

Sets network fee required for transactions per byte.

Namespace: [Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool SetFeePerByte(long value);
```

Parameter:

- value: fee per byte

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetFeePerByte(1200);
        return result;
    }
}
```

Response body:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: successfully set fee per byte for network transmission.

- Others: failed.

[Back](../Policy.md)