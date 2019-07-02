# Contract.Destroy メソッド ()

スマートコントラクトの破棄です。ブロックチェーンへ発行されたスマートコントラクトは、外部から破棄できません。そのため、コントラクトを破棄する必要がある場合、開発中にロジックを書く必要があります。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern void Destroy()
```

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         var height = Blockchain.GetHeight();
         var block = Blockchain.GetBlock(height);
         if (block.Timestamp > 1514736000) // Beijing time 2018-1-1
         {
             Neo.SmartContract.Framework.Services.Neo.Contract.Destroy();
         }
     }
}
```



[戻る](../Account.md)
