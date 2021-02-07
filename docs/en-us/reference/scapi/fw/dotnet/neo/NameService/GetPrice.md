# GetPrice method ()

Gets the price of registering or renewing a domain name.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static extern long GetPrice();
```

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static long GetPrice() { return NameService.GetPrice(); }
}
```
After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x0830764620067b85f374ef72b2e4f61b7020c620 getPrice`，of which the response is shown as below：

```json
[{
    "type":"Integer",
    "value":"1000000000"
}]
```

Response description：

- Integer type：10 Gas(the decimal is 8)。

- Others: failed.

[Back](../NameService.md)