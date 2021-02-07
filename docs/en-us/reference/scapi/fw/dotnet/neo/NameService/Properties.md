# Properties method (string)

Gets the properties of the domain name.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Map<string, object> Properties(string name);
```

Parameters：

- name: the domain name

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object Properties(string name) { return NameService.Properties(name); }
}
```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x2ba77f19d8294e9d32c59a18b005cc82353d6ccc properties [{"type":"String","value":"test.com"}]`, of which the response is shown as below：

```json
[{
    "type":"Map","value":[
    {"key":{"type":"ByteString","value":"bmFtZQ=="},"value":{"type":"ByteString","value":"dGVzdC5jb20="}}, // admin
    {"key":{"type":"ByteString","value":"ZGVzY3JpcHRpb24="},"value":{"type":"ByteString","value":""}},  // description
    {"key":{"type":"ByteString","value":"ZXhwaXJhdGlvbg=="},"value":{"type":"Integer","value":"1643630146"}}  // expiration time
    ]
}]
```

Response Description：

- Map type: the property information of the domain name, including: admin, description and expiration time;

- Others: failed.

[Back](../NameService.md)