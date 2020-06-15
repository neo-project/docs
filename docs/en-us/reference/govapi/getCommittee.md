# Function getCommittee

Return committee members.

## Contract

	NeoToken

## Sample

Request Content:

```
var result = Contract.Call(neoHash, "getCommittee", new object[] { });
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

- Array type: committee members successfully requested.

- Others: failed.
