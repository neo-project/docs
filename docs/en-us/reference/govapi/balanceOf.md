# balanceOf Method

Returns the account balance.

## Contract

	Nep5Token

## Parameters

`byte[] account`: The account to query

## Example

Request content:

```json
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(nep5Hash, "balanceOf", new object[] { account });
```

Response content:

```json
{
	"Type":"Integer",
	"value":"100000000"
}
```

Response description:

- Integer type: account balance is successfully requested.

- Others: failed.
