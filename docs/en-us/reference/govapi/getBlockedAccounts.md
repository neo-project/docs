# Function getBlockedAccounts

Return blocked accounts.

## Contract

	PolicyContract

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "getBlockedAccounts", new object[] { });
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

- Array type: account balance successfully requested.

- Others: failed.
