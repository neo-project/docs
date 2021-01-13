# CreateFromMethod(UInt160, string)

Creates a callback function with the specified method of the specified contract.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Callback CreateFromMethod(UInt160 hash, string method);
```

Parameters:
- hash: contract hash
- method: contract method

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateFromMethod()
    {
        return Callback.CreateFromMethod(NEO.Hash, "totalSupply").Invoke(new object[0]);
    }
}
```

Response body:

```json
[{
    "type":"Integer",
    "value":"100000000"
}]
```

Response description:

- Integer type: The total supply of NEO is 100000000.

- Other: failed.

[Back](../Callback.md)