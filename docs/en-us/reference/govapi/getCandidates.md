# getCandidates Method

Returns all candidates.

## Contract

	NeoToken

## Example

Request Content:

```json
var result = Contract.Call(neoHash, "getCandidates", new object[] { });
```

Respond Content:

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

- Array type: candidates are successfully requested.

- Others: failed.
