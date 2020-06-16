# name Method

Returns contract name.

## Contract

	NativeContract

## Example

Request content:

```json
var result = Contract.Call(nativeHash, "name", new object[] { });
```

Respond content:

```json
{
	"Type":"ByteString",
	"value":"NEO"
}
```

Respond description:

- ByteString type: contract name is successfully requested.

- Others: failed.
