# setMaxBlockSize Method

Sets the maximum block size.

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

`uint blockSize`: maximum block size

## Example

Request content:

```json
var result = Contract.Call(policyHash, "setMaxBlockSize", new object[] { 3000 });
```

Respond content:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: successfully set maximum block size.

- Others: failed.
