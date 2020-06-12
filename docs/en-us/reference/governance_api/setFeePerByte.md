# Function setFeePerByte

Set fee per byte for network transmission.

> [!Note]
>
> - Need to check muti-signature of committee members. Will be executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

- long feePerByte: fee per byte for network transmission

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "setFeePerByte", new object[] { 30 });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: successfully set fee per byte for network transmission.

- Others: failed.
