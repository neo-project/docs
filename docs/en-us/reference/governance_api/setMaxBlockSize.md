# Function setMaxBlockSize

Set the maximum block size.

> [!Note]
>
> - Need to check muti-signature of committee members. Will be executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

- uint blockSize: maximum block size

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "setMaxBlockSize", new object[] { 3000 });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: successfully set maximum block size.

- Others: failed.
