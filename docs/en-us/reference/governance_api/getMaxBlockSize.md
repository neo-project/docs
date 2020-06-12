# Function getMaxBlockSize

Return the maximum block size

## Contract

	PolicyContract

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "getMaxBlockSize", new object[] { });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"500"
}
```

Respond Illustration:

- Integer type: maximum block size successfully requested.

- Others: failed.
