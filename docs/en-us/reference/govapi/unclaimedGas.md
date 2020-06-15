# Function unclaimedGas

Return unclaimed GAS amount of this address.

## Contract

	NeoToken

## Parameters

- byte[] account: queried account

## Sample

Request Content:

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(neoHash, "unclaimedGas", new object[] { account });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"100000"
}
```

Respond Illustration:

- Integer type: unclaimed GAS amount of this address successfully requested.

- Others: failed.
