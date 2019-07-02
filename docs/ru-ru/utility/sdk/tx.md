# Создание транзакции

### Создание транзакций

Код для создания транзакции см. в  [github.com/chenzhitong/createtransaction](https://github.com/chenzhitong/createtransaction)

### Подпись транзакции

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
        throw new FormatException("The transaction format is wrong");
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
        Console.WriteLine("Signed successfully");
        tx.Witnesses = context.GetWitnesses();
    }
    else
    {
        Console.WriteLine("Signed unsuccessfully");
    }
    return tx;
}
```

### Верификация транзакций

```c#
var system = new NeoSystem(new LevelDBStore("Chain_00746E41"));
var tx = makeTransaction(); //construct the transaction
tx.Verify(Blockchain.Singleton.GetSnapshot(), new List<Transaction> { tx });
```

### Оплата сетевой комиссии

Для того чтобы оплатить сетевую комиссию, вам необходимо просто изменить входы и выходы транзакции. Формула выглядит следующим образом: сетевая комиссия = GAS на входах - GAS на выходах – системная комиссия. Ниже приведен пример, сумма комиссия в котором составляет 0,001 GAS.

```c#
//Transaction input is 1 GAS
var inputs = new List<CoinReference> {
    new CoinReference(){
        PrevHash = new UInt256("0x21b64eb35881e7261c72c70f38bd6d5eb6aa18f232e08ba3022220b46c13d9a2".Remove(0, 2).HexToBytes().Reverse().ToArray()),
        PrevIndex = 0
    }
}.ToArray();

//Transaction output is 0.999 GAS, and get the original address
var outputs = new List<TransactionOutput>{ new TransactionOutput()
{
    AssetId = Blockchain.UtilityToken.Hash,
    ScriptHash = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(),
    Value = new Fixed8((long)(0.999 * (long)Math.Pow(10, 8)))
}}.ToArray();

//The network fee is 0.001 GAS
```
