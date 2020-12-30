# transfer Method

Sends specified amount of token from an address to another.

> [!Note]
>
> The method will check sender's signature, whether caller is sender, whether receiver is payable, and whether sender's balance is enough.

## Contract

	Nep17Token

## Parameters

- `byte[] from`: sender

- `byte[] to`: receiver

- `BigInteger amount`: token amount

## Example

Request content:

```json
static byte[] from = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
static byte[] to = "NWfRjyLqixtrB8JCW5tuH8MMzgZ7QN3GHj".ToScriptHash();
...
var result = Contract.Call(nep17Hash, "transfer", new object[] { from, to, 10000 });
```

Respond content:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond description:

- true:  assets are transferred successfully.

- Others: failed.
