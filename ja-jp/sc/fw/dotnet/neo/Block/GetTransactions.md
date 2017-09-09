# Block.GetTransactions メソッド ()

現在のブロック内の、全てのトランザクションを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions()
```

戻り値: Transaction[]型の、Transactionの配列。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction[] txs = block.GetTransactions();
     }
}
```



[戻る](../Block.md)
