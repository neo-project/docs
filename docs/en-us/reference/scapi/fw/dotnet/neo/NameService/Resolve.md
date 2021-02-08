# Resolve method (string, RecordType)

Resolves a domain name.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string Resolve(string name, RecordType type);
```

parameters：

- name: domain name;
- type: record type.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static string Resolve(string name, byte type) { return NameService.Resolve(name, (RecordType)type); }
}
```

After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x64405d6cc3b144cd0c2470dac7410ac797b134dc resolve [{"type":"String","value":"test.com"},{"type":"Integer","value":"1"}]`, of which the response is shown as below：

```json
[{
    "type":"ByteString",
    "value":"MTI3LjAuMC4x" // 127.0.0.1
}]
```

Response description：

- ByteString type: the Base64-encoded string of the resolution result；

- Others: failed.

[Back](../Neo.md)