# Asset.Renew メソッド (byte[])

アセットの更新に使用します。

このメソッドはバージョン2.0で新たに追加されました。アセットは登録後、年間手数料を支払う必要があり、そうでなければ凍結状態になります。

アセットが期限切れになる際はアセットを更新する必要があります。アセットが凍結されていない場合、更新料はアセットの有効期限から期間を延長します。アセットが凍結されている場合、更新料は支払い時点から考慮されます。このため、更新料の支払い後に滞ることはありません。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern uint Renew (byte years)
```

パラメータ: バイト型の更新期間で、1年は2,000,000ブロックに等しいです。

戻り値: ブロックの高さで、アセットの更新後はその高さまでアセットが使用できます。

## 例

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Taking NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[戻る](../Asset.md)
