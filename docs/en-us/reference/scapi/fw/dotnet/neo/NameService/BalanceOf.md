# BalanceOf method (UInt160)

Gets the registered domains of the specified address.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework


## Syntax

```c#
public static extern BigInteger BalanceOf(UInt160 owner);
```

Parameters：

- owner: the address hash to be queried. 

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static object BalanceOf(UInt160 Owner) => NameService.BalanceOf(Owner);
}
```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x1b75e6ea52b9a825ec8d55038296970bf4641696 balanceOf [{"type":"Hash160","value":"0x75b75932a1451cc0c56a95eff7fcc01de45aa5a3"}]`，of which the response is shown as below：

```json
[{
    "type":"Integer",
    "value":"1"
}]
```

Response description:

- Integer type：the number of the domain of the specified address;

- Others：Failed.

[Back](../NameService.md)