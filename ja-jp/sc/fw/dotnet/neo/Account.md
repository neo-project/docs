# Account クラス

アカウントを表すクラスで、残高を問い合わせるメソッドを提供します。ここのアカウントは、ブロックチェーン上のアドレスに対応するコントラクトスクリプトのハッシュを参照します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Account
```

## 属性

| | 名前 | 説明 | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | コントラクトアカウントのスクリプトハッシュを取得する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | このアカウントから他への投票情報を返す |

## メソッド

| | 名前 | 説明 | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | 提供されたアセットIDによって識別されるアセットの残高を返す |

## コンストラクタ

Accountオブジェクトは、[Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md)を通じてコンストラクトされます。
