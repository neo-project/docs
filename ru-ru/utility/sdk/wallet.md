# Кошелек

### Создание кошелька

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

Указанный выше код может быть использован для создания файла стандартного кошелька NEP-6.

### Открытие кошелька

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

Если введен неверный пароль для разблокировки кошелька, выдается исключение.
