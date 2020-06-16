# getMaxTransactionsPerBlock Method

Returns maximum transactions in a block.

## Contract

	PolicyContract

## Example

Request content:

```
var result = Contract.Call(policyHash, "getMaxTransactionsPerBlock", new object[] { });
```

Respond content:

```
{
	"Type":"Integer",
	"value":"500"
}
```

Respond description:

- Integer type: maximum transactions in a block are successfully requested.

- Others: failed.
