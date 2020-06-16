# totalSupply Method

Returns token total supply.

## Contract

	Nep5Token

## Example

Request content:

```json
var result = Contract.Call(nep5Hash, "totalSupply", new object[] { });
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
