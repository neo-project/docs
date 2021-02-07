# Renew method (string)

Updates the TTL of the domain name (unit: second). Each call will extend the validity period of the domain name by one year.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

> [!Note]
> Only supports to renew the second domain name.

## Syntax

```c#
public static extern uint Renew(string name);
```

parameter：

- name: the domain name.

## Example

```c#
pusing Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static uint Renew(string name) { return NameService.Renew(name); }
}
```
After deploying the contract in cli, then you can invoke the contract by typing `invoke 0xa09b9567b74fc195dd1aded35ec72a6246776b8c renew [{"type":"String","value":"test.com"}]`，of which the response is shown as below：

```json
[{
    "type":"Integer",
    "value":"1737883400"
}]
```

Response description：

- Integer type：the expiration of the domain;

- Others：failed.

[Back](../NameService.md)