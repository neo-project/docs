# ContractManagement.Deploy Method

Deploys the contract.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Contract Deploy(ByteString nefFile, string manifest);
public static extern Contract Deploy(ByteString nefFile, string manifest, object data);
```

Parameters:

- nefFile: nef data of the contract in byte array.
- manifest: Metadata of the contract in Json string.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static byte[] nef = "4e4546336e656f6e00000000000000000000000000000000000000000000000000000000332e302e302e30000000000000000000000000000000000000000000000000000211407060ba5f".HexToBytes();
    private static string manifest = "{\"name\":\"\",\"groups\":[],\"supportedstandards\":[],\"abi\":{\"methods\":[{\"name\":\"update\",\"parameters\":[],\"offset\":0,\"returntype\":\"Any\",\"safe\":false}],\"events\":[]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"extra\":null}";

    public static object Deploy()
    {
        Contract contract = ContractManagement.Deploy(nef, manifest);
        return contract.Hash;
    }
}
```

Response body:

```json
[{
    "type":"ByteString",
    "value":"fbKpbpzeGaTQ5xgyBeVh0JkNcPo="
}]
```

Response description:

- ByteString string: the deployed contract hash.

- Other: failed.

Usually, you can define the method `_deploy` in the contract and execute the neo-cli command `deploy contract.nef` to deploy the contract.

```c#
public static void _deploy(object data, bool update)
{
    if (update) return;
    // Add other logics after the contract is deployed
}
```

[Back](../ContractManagement.md)