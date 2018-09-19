# NEO SDK - 构造交易

注：本文档中使用的 NEO SDK 版本为 2.9.0

### 构造交易

构造交易的代码比较复杂，请参考：[github.com/chenzhitong/createtransaction](https://github.com/chenzhitong/createtransaction)

### 交易签名

```c#
private static Transaction SignWithWallet(Transaction tx)
{
    if (tx == null)
    {
        throw new ArgumentNullException("tx");
    }
    try
    {
        tx.ToJson();
    }
    catch (Exception)
    {
        throw new FormatException("交易格式错误");
    }

    var wallet = new NEP6Wallet(new WalletIndexer("Index_00746E41"), "1.json");
    try
    {
        wallet.Unlock("password");
    }
    catch (Exception)
    {
        Console.WriteLine("password error");
    }

    //Signature
    var context = new ContractParametersContext(tx);
    wallet.Sign(context);
    if (context.Completed)
    {
        Console.WriteLine("签名成功");
        tx.Witnesses = context.GetWitnesses();
    }
    else
    {
        Console.WriteLine("签名失败");
    }
    return tx;
}
```

### 验证交易

```c#
var system = new NeoSystem(new LevelDBStore("Chain_00746E41"));
var tx = makeTransaction(); //构造交易
tx.Verify(Blockchain.Singleton.GetSnapshot(), new List<Transaction> { tx });
```



更多 NEO SDK 常见用法正在补充中……