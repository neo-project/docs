# blockAccount Method

Blocks an account.

> [!Note]
>
> The method needs to check muti-signature of committee members, and it is executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

`byte[] account`: The account address to block.

## Example

Request text：

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "blockAccount", new object[] { account });
```

Request content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true: The account is blocked successfully.

- Others: failed.
