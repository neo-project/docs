# Json.Serialize Method

Serializes the object to Json strings.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern static string Serialize(object obj);
```

Parameter:

- account: The script hash of the account to query.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Test()
    {
        var mapName = nameIndex;
        storageMap.Put(mapName, Json.Serialize(new Map<string, uint>()));
        var map = Json.Deserialize(storageMap.Get(mapName)) as Map<string, uint>;
		map["hello"] = 100;
        storageMap.Put(mapName, Json.Serialize(map));
    }
}
```

[Back](../Json.md)