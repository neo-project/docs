# Designation Class

Provides a set of methods of the native contract Designation, which hash is `0xc0073f4c7069bf38995780c9da065f9b3949ea7a`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Designation
```

## Methods

| Name | Description   |
| ---- | ------------- |
| Hash | Contract hash |

## Constructor

| Name                                                         | Description |
| ------------------------------------------------------------ | ----------- |
| [GetDesignatedByRole(DesignationRole role, uint index)](Designation/GetDesignatedByRole.md) |             |

Where `DesignationRole` represents node types which have the following values:

```
public enum DesignationRole : byte
{
    StateValidator = 4,
    Oracle = 8
}
```

