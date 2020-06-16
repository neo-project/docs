# setFeePerByte Method

Sets fee per byte for network transmission.

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

`long feePerByte`: fee per byte for network transmission

## Example

Request content:

```json
var result = Contract.Call(policyHash, "setFeePerByte", new object[] { 30 });
```

Respond content:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: successfully set fee per byte for network transmission.

- Others: failed.
