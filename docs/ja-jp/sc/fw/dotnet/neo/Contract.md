# Contract クラス

コントラクトを表すクラスです。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Contract
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | コントラクトのスクリプトハッシュを返す |

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | `新規` コントラクトを発行する    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | `新規` コントラクトを移行/更新する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | `新規` コントラクトを破棄する    |

## コンストラクタ

Contractオブジェクトは、[Blockchain.GetContract(byte[])](Blockchain/GetContract.md)を通じてコンストラクトされます。

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md)は、ブロックチェーン上にコントラクトを発行し、Contractオブジェクトを返します。

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md)は、コントラクトを更新し、Contractオブジェクトを返します。
