# Function totalSupply

Return token total supply.

## Contract

	Nep5Token

## Sample

Request Content:

```
var result = Contract.Call(nep5Hash, "totalSupply", new object[] { });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"100000000"
}
```

Respond Illustration:

- Integer type: token total supply successfully requested.

- Others: failed.
