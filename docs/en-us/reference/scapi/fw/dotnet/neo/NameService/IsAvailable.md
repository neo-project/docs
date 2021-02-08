# IsAvailable method (string)

Checks if the specified second domain name is available.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

> [!Note]
>
> The corresponding first-level domain needs to be registered first, otherwise an exception will be thrown.

## Syntax

```c#
public static extern bool IsAvailable(string name);
```

parameters：

- name: the second domain name to be verified.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static bool IsAvailable(string name) { return NameService.IsAvailable(name); }
}
```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x614a8f0015607d72cba71659ff83dea33cadb0c1 isAvailable [{"type":"String","value":"test.com"}]`, of which the response is shown as below：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

Response description：

- Boolean type: available if true;

- Others: failed.

[Back](../NameService.md)