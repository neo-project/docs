# Function unblockAccount

Unblock an account.

> [!Note]
>
> - Need to check muti-signature of committee members. Will be executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

- byte[] account: unblocked account

## Sample

Request Content:

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "unblockAccount", new object[] { account });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: successfully unblocked account.

- Others: failed.
