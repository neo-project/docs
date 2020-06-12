# Function name

Return contract name.

## Contract

	NativeContract

## Sample

Request Content:

```
var result = Contract.Call(nativeHash, "name", new object[] { });
```

Respond Content:

```
{
	"Type":"ByteString",
	"value":"NEO"
}
```

Respond Illustration:

- ByteString type: contract name successfully requested.

- Others: failed.
