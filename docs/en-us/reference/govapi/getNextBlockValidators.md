# getNextBlockValidators Method

Returns validators by persisting block.

## Contract

	NeoToken

## Example

Request content:

```json
var result = Contract.Call(neoHash, "getNextBlockValidators", new object[] { });
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

- Array type: validators by persisting block are successfully requested.

- Others: failed.
