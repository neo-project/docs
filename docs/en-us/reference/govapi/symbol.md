# symbol Method

Returns token symbol.

## Contract

	Nep17Token

## Example

Request content:

```json
var result = Contract.Call(nep17Hash, "symbol", new object[] { });
```

Respond content:

```json
{
	"Type":"ByteString",
	"value":"neo"
}
```

Respond description:

- ByteString type: token symbol is successfully requested.

- Others: failed.
