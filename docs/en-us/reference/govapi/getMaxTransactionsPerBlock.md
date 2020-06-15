# Function getMaxTransactionsPerBlock

Return maximum transactions in a block.

## Contract

	PolicyContract

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "getMaxTransactionsPerBlock", new object[] { });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"500"
}
```

Respond Illustration:

- Integer type: maximum transactions in a block successfully requested.

- Others: failed.
