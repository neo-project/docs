# getBlockedAccounts Method

Returns the blocked accounts.

## Contract

	PolicyContract

## Example

Request content:

```json
var result = Contract.Call(policyHash, "getBlockedAccounts", new object[] { });
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

- Array type: account address is successfully requested.

- Others: failed.
