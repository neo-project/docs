# Asset クラス

アセットのデータ構造を表します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Asset
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md) | アセットの属性(合計、名前など)を変更する権利を持つアセットの管理者（コントラクトアドレス）を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | アセットの合計額を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | アセットのIDを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | このアセットのタイプを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | 発行されたアセットの数量を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | 資産を発行する権利を持つ資産の発行者（コントラクトアドレス）を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | アセットの所有者（パブリックキー）を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | アセットの精度（最小区分）、つまり小数点以下の桁数を返す |

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) | `新規` ブロックチェーンにアセットを登録する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            | `新規` アセットの更新      |

## コンストラクタ

Assetオブジェクトは、[Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md)メソッドを通じでコンストラクトされます。

[Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md)メソッドは、ブロックチェーンに新しいアセットを登録するのに使用し、Assetオブジェクトを返します。
