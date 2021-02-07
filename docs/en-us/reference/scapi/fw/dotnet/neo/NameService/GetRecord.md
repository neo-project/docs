# GetRecord method (string, RecordType)

Gets the record data.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static extern string GetRecord(string name, RecordType type);
```

parameters：

- name: domain name;
- RecordType: record type.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static string GetRecord(string name, byte type) { return NameService.GetRecord(name, (RecordType)type); }
}
```
After deploying the contract in cli, then you can invoke the contract by typing `invoke 0x2d3b9ae14534f5b324dcd36f141272eac403e955 getRecord [{"type":"String","value":"test.com"},{"type":"Integer","value":"1"}]`，of which the response is shown as below：

```json
[{
    "type":"ByteString",
    "value":"MTI3LjAuMC4x"  // 127.0.0.1
}]
```

Response description：

- ByteString type：the Base64-encoded string of the corresponding type data of the domain name;

- Others：failed.

[Back](../NameService.md)