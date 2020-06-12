# Function symbol

Return token symbol.

## Contract

	Nep5Token

## Sample

Request Content:

```
var result = Contract.Call(nep5Hash, "symbol", new object[] { });
```

Respond Content:

```
{
	"Type":"ByteString",
	"value":"neo"
}
```

Respond Illustration:

- ByteString type: token symbol successfully requested.

- Others: failed.
