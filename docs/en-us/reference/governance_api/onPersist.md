# Function onPersist

Manually perform actions this Nep5 contract will do upon block persisting.

## Contract

	NativeContract

## Parameters

Request Content:

```
var result = Contract.Call(nativeHash, "onPersist", new object[] { });
```

Respond Content:

```
{
	"Type":"Void",
	"value":"NULL"
}
```

Respond Illustration:

- Void type: successfully perfromed.

- Others: failed.
