# NEO.Vote Method

Votes for the candidates.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> - Voting towards non-candidate is recorded but not taken into account in committee & validator election. However, such votes will be effective as soon as the voted address becomes a candidate.
> - Voter's signature will be checked. 

## Syntax

```c#
public static extern bool Vote(UInt160 account, ECPoint voteTo);
```

Parameters:

- account: Script hash of the voting account.
- voteTo: Public key of the account to vote.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] pubkey = "02e8ff17c567d62f274fe247cc884a2a6cd3b8fd0d779a8c5856289a560accacb4".HexToBytes();

    public static object Test()
    {
        bool result = NEO.Vote(account, (ECPoint)pubkey);
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

Respond description:

- Boolean type: voted successfully.

- Others: failed.

[Back](../Neo.md)