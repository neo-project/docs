# NEO.Transfer Method 

Transfers NEO.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> The method will check sender's signature, whether caller is sender, whether receiver is payable, and whether sender's balance is enough.

## Syntax

```c#
public static extern bool Transfer(UInt160 from, UInt160 to, BigInteger amount);
```

Parameters:

- from: Script hash of the account you transfer from
- to: Script hash of the account you transfer to
- amount: The amount to be transferred.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 from = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly UInt160 to = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Test()
    {
        BigInterger value = 1000;
        bool result = NEO.Transfer(from, to, value);
        return result;
    }
}
```

Response body:

```json
{
	"type":"Boolean",
	"value":"true"
}
```

Response description:

- true:  assets are transferred successfully.

- Others: failed.

[Back](../Neo.md)