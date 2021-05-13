# NEO.UnRegisterCandidate Method

Unregisters as a candidate.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> Unregistering candidate requires the candidate's signature. It means candidate unregistering is only self-determined. 

## Syntax

```c#
public static extern bool UnRegisterCandidate(ECPoint pubkey);
```

Parameter:

- pubkey: the public key of the account to be unregistered.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] pubkey = "02e8ff17c567d62f274fe247cc884a2a6cd3b8fd0d779a8c5856289a560accacb4".HexToBytes();

    public static object Test()
    {
        bool result = NEO.UnRegisterCandidate((ECPoint)pubkey);
        return result;
    }
}
```

Response body:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Response description:

- true: The candidate is successfully unregistered.

- Others: failed.

[Back](../Neo.md)