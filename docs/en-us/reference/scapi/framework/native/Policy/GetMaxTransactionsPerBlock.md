# GetMaxTransactionsPerBlock Method

Sets max transaction per block

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetMaxTransactionsPerBlock();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        uint result = Policy.GetMaxTransactionsPerBlock();
        return result;
    }
}
```

Response body:

```json
{
	"Type":"Integer",
	"value":"500"
}
```

Response description:

- Integer type: maximum transactions in a block are successfully requested.

- Others: failed.

[Back](../Policy.md)



