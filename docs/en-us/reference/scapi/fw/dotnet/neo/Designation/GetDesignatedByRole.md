# GetDesignatedByRole Method (DesignationRole, uint)

Gets the node public key array for the specific role.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern ECPoint[] GetDesignatedByRole(DesignationRole role, uint index);
```

Parameters:

- role: system role
- index: block height

`DesignationRole`, the enumeration type, which can be:

- `StateValidator`: the validator node
- `Oracle`: the Oracle node

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        ECPoint[] oracles = Designation.GetDesignatedByRole(DesignationRole.Oracle, 1000);
        return oracles;
    }
}
```

Response body:

```json
[{
	"type": "Array",
	"value": [{
		"type": "ByteString",
		"value": "Auj/F8Vn1i8nT\u002BJHzIhKKmzTuP0Nd5qMWFYomlYKzKy0"
	}]
}]
```

Response description:

- Array type: Oracle nodes list

- Other: failed.


