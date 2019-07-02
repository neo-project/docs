# Block.GetTransaction メソッド (int)

インデックスにより指定された、現在のブロック内のトランザクションを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(int index)
```

パラメータ: integer型の、ブロック内のトランザクションのインデックス。

戻り値: [Transaction](../Transaction.md)型のトランザクション。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction tx = block.GetTransaction(0);
     }
}
```



[戻る](../Block.md)
