# **GAS.Transfer Method**

Transfers GAS

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool Transfer(UInt160 from, UInt160 to, BigInteger amount);
public static extern bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data);
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
        bool result = GAS.Transfer(from, to, 1000);
        return result;
    }
}
```

Respond:

```json
{
	"type":"Boolean",
	"value":"true"
}
```

Respond description:

- Boolean type: true means assets are transferred successfully.

- Others: failed.

[Back](../Gas.md)