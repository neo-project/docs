# Contract.GetCallFlags Method

Gets the call privilege of the contract.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte GetCallFlags();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
        public static int GetCallFlags()
        {
            return Contract.GetCallFlags();
        }
}
```


