# OwnerOf method (string)

Gets the address of the specified second domain.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

> [!Note]
>
> Only the query for the second domain is supported。

## Syntax

```c#
public static extern UInt160 OwnerOf(string name);
```

Parameters：

- name: the second domain name to be queried.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static UInt160 OwnerOf(string name) => NameService.OwnerOf(name);
}

```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0xb35825371fd5ba98a58b4b043aa62e7b0082fd88 ownerOf [{"type":"String","value":"test.com"}]`，of which the response is shown as below：

```json
[{
    "type":"ByteString",
    "value":"o6Va5B3A/PfvlWrFwBxFoTJZt3U="
}]
```

Response description:

- ByteString type：Base64 encoded string of the account address to which the domain name belongs;

- Others: failed.

[Back](../NameService.md)