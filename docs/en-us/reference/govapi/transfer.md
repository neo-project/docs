# Function transfer

Send specified amount of token from an address to another.

> [!Note]
>
> - Will check sender's signature, whether caller is sender, whether receiver is payable, whether sender's balance is enough.

## Contract

	Nep5Token

## Parameters

- byte[] from: sender

- byte[] to: receiver

- BigInteger amount: token amount

## Sample

Request Content:

```
static byte[] from = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
static byte[] to = "NWfRjyLqixtrB8JCW5tuH8MMzgZ7QN3GHj".ToScriptHash();
...
var result = Contract.Call(nep5Hash, "transfer", new object[] { from, to, 10000 });
```

Respond Content:

```
{
	"Type":"Boolean",
	"value":"true"
}
```

Respond Illustration:

- true: transferred successfully.

- Others: failed.
