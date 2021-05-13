# GetMaxBlockSystemFee Method

Gets the maximum system fee for the block

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern long GetMaxBlockSystemFee();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        long result = Policy.GetMaxBlockSystemFee();
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Integer",
	"value":"900000000000"
}
```

响应说明：

- Integer type: Maximum system fee is obtained successfully.

- Others: failed.

[Back](../Policy.md)