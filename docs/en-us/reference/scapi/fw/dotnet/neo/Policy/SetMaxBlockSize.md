# SetMaxBlockSize Method

Sets the max block size.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool SetMaxBlockSize(uint value);
```

Parameter:

- value: the max block size

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxBlockSize(1024);
        return result;
    }
}
```

Respond body:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: successfully set maximum block size.

- Others: failed.

[Back](../Policy.md)

