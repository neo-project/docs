# GetMaxBlockSize Method

Gets max block size

Namespace: [Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetMaxBlockSize()；
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        uint result = Policy.GetMaxBlockSize();
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

- Integer type: maximum block size is successfully requested.

- Others: failed.

[Back](../Policy.md)