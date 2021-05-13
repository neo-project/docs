# GetFeePerByte Method

Gets fee per byte

Namespace：[Neo.SmartContract.Framework.Native](../Neo.SmartContract.Framework.Native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger GetFeePerByte();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        BigInteger result = Policy.GetFeePerByte();
        return result;
    }
}
```

Response body:

```json
{
	"type":"Integer",
	"value":"300"
}
```

Response description:

- Integer type: fee per byte for network transmission is successfully requested.

- Others: failed.

[Back](../Policy.md)