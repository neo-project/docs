# getMaxBlockSize Method

Returns the maximum block size

## Contract

	PolicyContract

## Example

Request content:

```json
var result = Contract.Call(policyHash, "getMaxBlockSize", new object[] { });
```

Respond content:

```json
{
	"Type":"Integer",
	"value":"500"
}
```

Respond description:

- Integer type: maximum block size is successfully requested.

- Others: failed.
