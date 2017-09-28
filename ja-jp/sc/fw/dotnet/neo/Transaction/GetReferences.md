# Transaction.GetReferences メソッド ()

トランザクションのトランザクション入力によって参照される、すべてのトランザクションの出力を返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionOutput[] GetReferences()
```

戻り値: [TransactionOutput](../TransactionOutput.md)配列型の、トランザクションの出力。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
         TransactionOutput[] references = tx.GetReferences();
     }
}
```



[戻る](../Transaction.md)
