# Function getFeePerByte

Return fee per byte for network transmission.

## Contract

	PolicyContract

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "getFeePerByte", new object[] { });
```

Respond Content:

```
{
	"Type":"Integer",
	"value":"300"
}
```

Respond Illustration:

- Integer type: fee per byte for network transmission successfully requested.

- Others: failed.
