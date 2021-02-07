# TotalSupply method ()

Gets the total supply of the domain token.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> Does not count in the top level domains.

## Syntax

```c#
public static extern BigInteger TotalSupply();
```

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static object TotalSupply() => NameService.TotalSupply();
}
```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0xe1b3691318ebc7450e58866c520a1f893b305307 totalSupply`, of which the response is shown as below：

```json
[{
    "type":"Integer",
    "value":"1"
}]
```

Response description：

- Integer type: the total supply of the registered domains;

- Others: failed。

[Back](../NameService.md)