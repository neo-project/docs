# totalSupply Method

Returns token total supply.

## Contract

	Nep17Token

## Example

Request content:

```json
var result = Contract.Call(nep17Hash, "totalSupply", new object[] { });
```

Respond content:

```json
{
	"Type":"Integer",
	"value":"100000000"
}
```

Respond description:

- Integer type: token total supply is successfully requested.

- Others: failed.
