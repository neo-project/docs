# getFeePerByte Method

Returns fee per byte for network transmission.

## Contract

	PolicyContract

## Example

Request content:

```json
var result = Contract.Call(policyHash, "getFeePerByte", new object[] { });
```

Respond content:

```json
{
	"Type":"Integer",
	"value":"300"
}
```

Respond description:

- Integer type: fee per byte for network transmission is successfully requested.

- Others: failed.
