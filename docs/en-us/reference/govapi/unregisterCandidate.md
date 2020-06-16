# unregisterCandidate Method

Unregisters a candidate.

> [!Note]
>
> Unregistering candidate requires the candidate's signature. It means candidate unregistering is only self-determined. 

## Contract

	NeoToken

## Parameters

`byte[] publicKey`: unregistered a candidate

## Example

Request Content:

```json
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "unregisterCandidate", new object[] { pubkey });
```

Respond Content:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: The candidate is successfully unregistered.

- Others: failed.
