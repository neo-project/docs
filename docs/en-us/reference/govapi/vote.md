# Function vote

Vote to a candidate.

> [!Note]
>
> - Voting towards non-candidate is recorded but not taken into account in committee & validator election. However, such votes will be effective as soon as voted address becomes a candidate.
> - Voter's signature will be checked. 

## Contract

	NeoToken

## Parameters

- byte[] account: voter

- byte[] voteTo: voted candidate's public key

## Sample

Request Content:

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "vote", new object[] { account, pubkey });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: voted successfully.

- Others: failed.
