# onPersist Method

Manually performs actions the Nep17 contract will do upon block persisting.

## Contract

	NativeContract

## Parameters

Request content:

```json
var result = Contract.Call(nativeHash, "onPersist", new object[] { });
```

Respond content:

```json
{
	"Type":"Void",
	"value":"NULL"
}
```

Respond description:

- Void type: The method is successfully performed.

- Others: failed.
