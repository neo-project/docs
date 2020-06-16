# unclaimedGas Method

Returns unclaimed GAS amount of this address.

## Contract

	NeoToken

## Parameters

`byte[] account`: queried account

## Example

Request content:

```json
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(neoHash, "unclaimedGas", new object[] { account });
```

Respond content:

```json
{
	"Type":"Integer",
	"value":"100000"
}
```

Respond description:

- Integer type: unclaimed GAS amount of this address is successfully requested.

- Others: failed.
