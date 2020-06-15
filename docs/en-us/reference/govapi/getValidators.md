# Function getValidators

Return current validators.

## Contract

	NeoToken

## Sample

Request Content:

```
var result = Contract.Call(neoHash, "getValidators", new object[] { });
```

Respond Content:

```
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

Respond Illustration:

- Array type: current validators successfully requested.

- Others: failed.
