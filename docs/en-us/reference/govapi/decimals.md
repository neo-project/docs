# Function decimals

Return Token decimals.

## Contract

	Nep5Token

## Sample

Request Content:

```
var result = Contract.Call(nep5Hash, "decimals", new object[] { });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"0"
}
```

Respond Illustration:

- Integer type: Token balance successfully requested.

- Others: failed.
