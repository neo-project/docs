# Function supportedStandards

Return supported NEP standards.

## Contract

	NativeContract

## Sample

Request Content:

```
var result = Contract.Call(nativeHash, "supportedStandards", new object[] { });
```

Respond Content:

```
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

Respond Illustration:

- Array type: supported NEP standards successfully requested.

- Others: failed.
