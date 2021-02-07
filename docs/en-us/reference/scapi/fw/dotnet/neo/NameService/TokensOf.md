# TokensOf method (UInt160)

Gets all domain names owned by the specified address.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Iterator<string> TokensOf(UInt160 owner);
```

parameters：

- owner: the hash of the address to be queried.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object TokensOf(UInt160 owner)
    {
        Iterator<string> result = NameService.TokensOf(owner);
        List<string> nameList = new List<string>();
        while (result.Next())
        {
            nameList.Add(result.Value);
        }
        return nameList;
    }
}
```


After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x5da989558a73c4418d2c05e86cbdd9d07f9edd8b tokensOf [{"type":"Hash160","value":"0x75b75932a1451cc0c56a95eff7fcc01de45aa5a3"}]`, of which the response is shown as below：

```json
[{
    "type":"Array","value":
    [{"type":"ByteString","value":"dGVzdDMuY29t"},  //test3.com
    {"type":"ByteString","value":"dGVzdDQuY29t"}]   //test4.com
}]
```

Response Description：

- Array type：returns the Base64-encoded string array of the domain name owned by the address;

- Others：failed.

[Back](../NameService.md)