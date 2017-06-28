# Blockchain.GetAccount method (byte[])

Obtain an account (address) based on the hash of the contract script.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Account GetAccount (byte[] script_hash)
```

Parameters: Script hash, 20 bytes byte array.

Return Value: Account, [Account](../Account.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account acc = Blockchain.GetAccount (scriptHash);
    }
}
```

Which script hash can be obtained in advance, can also be passed as a parameter into the smart contract. The following is in the external code call the SDK into the script hash.

```c#
Static void Main (string[] args)
{
    byte[] scriptHash = AntShares.Wallets.Wallet.ToScriptHash ("AK4if54jXjSiJBs6jkfZjxAastauJtjjse"). ToArray ();
}
```



[Return to superior](../Blockchain.md)
