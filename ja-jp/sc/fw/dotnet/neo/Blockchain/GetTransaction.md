# Blockchain.GetTransaction メソッド (byte[])

指定のトランザクションIDから、トランザクションを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(byte[] hash)
```

パラメータ: 長さが32のバイト配列のトランザクションID(トランザクションハッシュ)。

戻り値: [Transaction](../Transaction.md)。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
     }
}
```



[戻る](../Blockchain.md)
