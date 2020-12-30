# decimals Method

Returns token decimals.

## Contract

	Nep17Token

## Example

Request content:

```json
var result = Contract.Call(nep17Hash, "decimals", new object[] { });
```

Respond content:

```json
{
	"Type":"Integer",
	"value":"0"
}
```

Respond description:

- Integer type: Token balance is obtained.

- Others: failed.
