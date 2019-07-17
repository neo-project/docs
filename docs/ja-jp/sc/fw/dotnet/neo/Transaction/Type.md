# Transaction.Type プロパティ

トランザクションのタイプを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern byte Type {get;}
```

属性値: byte型のトランザクションタイプ。

タイプ:

```c#
// コンセンサストランザクション、バイトチャージ割当のための特別トランザクション
MinerTransaction = 0x00,
// アセット分配のための特別トランザクション
IssueTransaction = 0x01,
// GAS配布のための特別トランザクション
ClaimTransaction = 0x02,
// バリデーター候補者としての登録のための特別トランザクション
EnrollmentTransaction = 0x20,
// アセット登録のための特別トランザクション
RegisterTransaction = 0x40,
// 最も一般的に使用されるコントラクトトランザクション
ContractTransaction = 0x80,
// トランザクション委託
AgencyTransaction = 0xb0,
// スマートコントラクトトランザクション
PublishTransaction = 0xd0,
// スマートコントラクトトランザクションの呼び出し
InvocationTransaction = 0xd1
```



[戻る](../Transaction.md)
