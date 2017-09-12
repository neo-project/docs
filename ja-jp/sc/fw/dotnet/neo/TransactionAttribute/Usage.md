# TransactionAttribute.Usage プロパティ

トランザクションの目的を返します。

名前空間：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ：Neo.SmartContract.Framework

## 構文

```c#
public extern byte Usage {get;}
```

属性値：トランザクションの目的を表すバイト配列。

パーポス:

```c#
// 外部契約のハッシュ値
ContractHash = 0x00,
// ECDH鍵交換のための公開鍵、公開鍵の先頭バイトは0x02
ECDH02 = 0x02,
// ECDH鍵交換のための公開鍵、公開鍵の先頭バイトは0x03
ECDH03 = 0x03,
// トランザクションの追加承認用
Script = 0x20,
// 投票情報
Vote = 0x30,
// トランザクションの説明URL
DescriptionUrl = 0x81,
// 説明
Description = 0x90,
// ハッシュデータの操作に使用可能
Hash1 = 0xa1,
Hash2 = 0xa2,
Hash3 = 0xa3,
Hash4 = 0xa4,
Hash5 = 0xa5,
Hash6 = 0xa6,
Hash7 = 0xa7,
Hash8 = 0xa8,
Hash9 = 0xa9,
Hash10 = 0xaa,
Hash11 = 0xab,
Hash12 = 0xac,
Hash13 = 0xad,
Hash14 = 0xae,
Hash15 = 0xaf,
// トランザクション備考
Remark = 0xf0,
Remark1 = 0xf1,
Remark2 = 0xf2,
Remark3 = 0xf3,
Remark4 = 0xf4,
Remark5 = 0xf5,
Remark6 = 0xf6,
Remark7 = 0xf7,
Remark8 = 0xf8,
Remark9 = 0xf9,
Remark10 = 0xfa,
Remark11 = 0xfb,
Remark12 = 0xfc,
Remark13 = 0xfd,
Remark14 = 0xfe,
Remark15 = 0xff
```



[戻る](../TransactionAttribute.md)
