# Function balanceOf

Return account balance.

## Contract

	Nep5Token

## Parameters

- byte[] account: queried account

## Sample

Request Content:

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(nep5Hash, "balanceOf", new object[] { account });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"100000000"
}
```

Respond Illustration:

- Integer type: account balance successfully requested.

- Others: failed.
