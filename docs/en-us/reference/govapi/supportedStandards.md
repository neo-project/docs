# supportedStandards Method

Returns supported NEP standards.

## Contract

	NativeContract

## Example

Request content:

```json
var result = Contract.Call(nativeHash, "supportedStandards", new object[] { });
```

Respond content:

```json
{
	"type": "Array",
	"value": [{
		"type": "ByteString",
		"value": "NEP-5"
	}, {
		"type": "ByteString",
		"value": "NEP-10"
	}]
}
```

Respond description:

- Array type: supported NEP standards successfully requested.

- Others: failed.
