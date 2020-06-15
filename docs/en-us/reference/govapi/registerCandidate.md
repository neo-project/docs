# Function registerCandidate

Register candidate

> [!Note]
>
> - Registering candidate requires the candidate's signature. It means candidate registering is only self-determined. 

## Contract

	NeoToken

## Parameters

- byte[] publicKey: public key of registered candidate

## Sample

Request Content:

```
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "registerCandidate", new object[] { pubkey });
```

Respond Content:

```
{
   	"Type":"Boolean",
   	"value":"true"
}
```

Respond Illustration:

- true: candidate registration succeeded.

- Others: failed.
