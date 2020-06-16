# registerCandidate Method

Register the candidate

> [!Note]
>
> Candidate registration requires the candidate's signature. It means candidate registering is only self-determined. 

## Contract

	NeoToken

## Parameters

`byte[] publicKey`: public key of the registered candidate

## Example

Request content:

```json
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "registerCandidate", new object[] { pubkey });
```

Respond content:

```json
{
   	"Type":"Boolean",
   	"value":"true"
}
```

Respond description:

- true: candidate registration is succeeded.

- Others: failed.
