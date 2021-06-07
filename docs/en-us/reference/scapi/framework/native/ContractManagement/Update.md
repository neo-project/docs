# ContractManagement.Update Method

Update the contract.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Update(ByteString nefFile, string manifest);
public static extern void Update(ByteString nefFile, string manifest, object data = null);
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

    public static void Update()
    {
        if (!Runtime.CheckWitness(Owner)) throw new Exception("No authorization.");
        ContractManagement.Update(nef, manifest);
    }
}
```

Response body:

```json
[{"type":"Any"}]
```

Response description:

- Void type: update completed.

- Other: failed.

> [!Note] 
>
> The contract hash remains unchanged after the update.

[Back](../ContractManagement.md)