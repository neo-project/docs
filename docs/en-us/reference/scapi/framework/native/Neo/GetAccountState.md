# NEO.GetAccountState Method ()

Gets the latest votes of the specified account.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```
public static extern NeoAccountState GetAccountState(DataCache snapshot, UInt160 account)
```

## Example

```
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    
    public static object Test()
    {
        return NEO.GetAccountState(account);
    }
}
```

Response body:

```
[
      {
        "type": "Struct",
        "value": [
          {
            "type": "Integer",
            "value": "900"
          },
          {
            "type": "Integer",
            "value": "9774"
          },
          {
            "type": "ByteString",
            "value": "AsNeyvySxknpefBTobcD9O\u002BQiieFUIdCtmzAWZvxQPA4"
          }
        ]
      }
]
```

Response description:

- 1st value: the current account balance, which equals to the votes cast. 
- 2nd value: The block height at last update.
- 3rd value: The public key of the account address to vote.

[Back](../Neo.md)