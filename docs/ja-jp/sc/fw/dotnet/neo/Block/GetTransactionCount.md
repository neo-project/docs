# Block.GetTransactionCount メソッド()

現在のブロック内の、トランザクション数を返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern int GetTransactionCount()
```

戻り値: integer型のトランザクション数。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Int txCount = block.GetTransactionCount();
     }
}
```



[戻る](../Block.md)
