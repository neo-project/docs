# Function setMaxTransactionsPerBlock

Set maximum transactions in a block.

> [!Note]
>
> - Need to check muti-signature of committee members. Will be executed as long as it's signed by more than half of the committee members.

## Contract

	PolicyContract

## Parameters

- uint maxTransactions: maximum transactions in a block

## Sample

Request Content:

```
var result = Contract.Call(policyHash, "setMaxTransactionsPerBlock", new object[] { 1000 });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: successfully set maximum transactions in a block

- Others: failed.
