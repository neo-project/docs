# SetGasPerBlock Method (BigInteger)

Sets the number of GAS generated in each block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Syntax

```c#
public static extern bool SetGasPerBlock(BigInteger gasPerBlock);
```

Parameter：

- gasPerBlock: the number of GAS generated in each block.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger gasPerBlock  = 10;
        bool result = NEO.SetGasPerBlock(gasPerBlock);
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

- Boolean type: true means transfer is succeeded.

- Others: failed

[Back](../Neo.md)

