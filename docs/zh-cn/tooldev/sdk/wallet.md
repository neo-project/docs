# 钱包相关用法

### 创建钱包文件

```c#
//创建钱包
var wallet = new new NEP6Wallet(new WalletIndexer("Index_00746E41"), "wallet.json"); //钱包索引和文件名
wallet.Unlock("password"); //设置钱包密码
wallet.CreateAccount();
wallet.Save();
//输出钱包地址
var accounts = wallet.GetAccounts();
foreach (var item in accounts)
{
    Console.WriteLine(item.Address);
}
```

使用本段代码可以创建 NEP-6（钱包标准）的钱包文件。

### 打开钱包文件

```c#
var wallet = new new NEP6Wallet(new WalletIndexer("Index_00746E41"), "wallet.json"); //钱包索引和文件名
try
{
    wallet.Unlock("password"); //钱包密码
    var accounts = wallet.GetAccounts();
    foreach (var item in accounts)
    {
        Console.WriteLine(item.Address);
    }
}
catch (Exception)
{
    Console.WriteLine("密码错误");
}
```

解锁钱包时，如果密码错误，则会抛出异常。



更多常见用法正在补充中。
