# getValidators Method

Returns current validators.

## Contract

	NeoToken

## Example

Request content:

```json
var result = Contract.Call(neoHash, "getValidators", new object[] { });
```

Respond content:

```json
{
	"type": "Array",
	"value": [{
		"type": "Struct",
		"value": [{
			"type": "ByteString",
			"value": "AkuBfvN/L8PUoz/jZoflktnzD\u002BJLPigYfcjxKzs7K4Oe"
		}, {
			"type": "Integer",
			"value": "0"
		}]
	}]
}
```

Respond description:

- Array type: current validators are successfully requested.

- Others: failed.
