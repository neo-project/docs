# unblockAccount Method

Unblocks an account.

> [!Note]
>
> The method needs to check muti-signature of committee members and it is executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

`byte[] account`: unblocked account

## Example

Request content:

```json
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "unblockAccount", new object[] { account });
```

Respond content:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: The account is successfully unblocked.

- Others: failed.
