# Tokens method ()

Gets all domain names registered in the contract.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static extern Iterator<string> Tokens();
```

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object Tokens()
    {
        Iterator<string> result = NameService.Tokens();
        List<string> nameList = new List<string>();
        while (result.Next())
        {
            nameList.Add(result.Value);
        }
        return nameList;
    }
}
```


After deploying the contract in cli, then you can invoke the contract by typing `invoke 0xb51f703aae951c58ebd89d9448bf8cb4c7f2efcc tokens`，of which the response is shown as below：

```json
[{"type":"Array","value":
    [{"type":"ByteString","value":"dGVzdDMuY29t"},  //test3.com
    {"type":"ByteString","value":"dGVzdDQuY29t"},   //test4.com
    {"type":"ByteString","value":"dGVzdC5jb20="},   //test.com
    {"type":"ByteString","value":"dGVzdDIuY29t"}]   //test2.com
}]
```

Response Description：

- Array type：returns a Base64-encoded string array of all domain names registered by the system;

- Others：failed.

[Back](../NameService.md)