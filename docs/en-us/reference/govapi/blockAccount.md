# blockAccount Method

Blocks an account.

> [!Note]
>
> Need to check muti-signature of committee members. Will be executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

`byte[] account`: blocked account

## Example

Request text：

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "blockAccount", new object[] { account });
```

Request Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: account blocked successfully.

- Others: failed.
