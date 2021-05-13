# SetMaxTransactionsPerBlock Method

Sets the max transactions can be packaged by each block.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool SetMaxTransactionsPerBlock(uint value);
```

Parameter：

- value: Maximum number of transactions to be set

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxTransactionsPerBlock(1024);
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

Response description:

- true: successfully set maximum transactions in a block

- Others: failed.

[Back](../Policy.md)