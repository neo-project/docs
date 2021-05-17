# NEO.RegisterCandidate Method

Registers as a candidate.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> Candidate registration requires the candidate's signature. It means candidate registering is only self-determined. 

## Syntax

```c#
public static extern bool RegisterCandidate(ECPoint pubkey);
```

Parameter：

- pubkey: The public key of the account to be registered.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] pubkey = "02e8ff17c567d62f274fe247cc884a2a6cd3b8fd0d779a8c5856289a560accacb4".HexToBytes();

    public static object Test()
    {
        bool result = NEO.RegisterCandidate((ECPoint)pubkey);
        return result;
    }
}
```

Response body:

```json
{
   	"type":"Boolean",
   	"value":"true"
}
```

Response description:

- Boolean type: true means candidate registration is succeeded.

- Others: failed.

[Back](../Neo.md)