# Wallet related operations

### Creating a wallet

```c#
//Create a wallet
var wallet = new new NEP6Wallet(new WalletIndexer("Index_00746E41"), "wallet.json"); //The wallet index and file name
wallet.Unlock("password"); //The wallet password
wallet.CreateAccount();
wallet.Save();
//Print the wallet address
var accounts = wallet.GetAccounts();
foreach (var item in accounts)
{
    Console.WriteLine(item.Address);
}
```

The above code can be used to create the NEP-6 standard wallet file.

### Opening a wallet

```c#
var wallet = new new NEP6Wallet(new WalletIndexer("Index_00746E41"), "wallet.json"); //The wallet index and file name
try
{
    wallet.Unlock("password"); //The wallet password
    var accounts = wallet.GetAccounts();
    foreach (var item in accounts)
    {
        Console.WriteLine(item.Address);
    }
}
catch (Exception)
{
    Console.WriteLine("The password is wrong");
}
```

If the password is wrong for unlocking the wallet, an exception will be thrown.



To be continued.
