# スマートコントラクト .NET framework

.NET FrameworkはスマートコントラクトAPIのカプセル化であるため、.NETプログラマは、.NETのクラス、メソッド、およびプロパティを直接使用してAPIと対話し、ブロックチェーンデータ、ストレージデータなどを取得できます。

## インターオペラビリティ（相互運用性）レイヤーメソッド

インターオペラビリティレイヤーの名前空間は、`Neo.SmartContract.Framework.Services.NEO`および`Neo.SmartContract.Framework.Services.System`に分けられます。詳細についてはリンクをクリックしてください。

| 名前空間 | 説明 |
| --------- | ----------- |
| [Neo](dotnet/neo.md) | NEOの名前空間は、NEOブロックチェーンによって提供されるAPIで、ブロックチェーンデータへのアクセスおよび永続化ストアの操作方法を提供します。 |
| [System](dotnet/system.md) | Systemの名前空間は、スマートコントラクト実行エンジン(NeoVM)によって提供されるAPIで、実行環境へのアクセスを提供します。 |

## フレームワークメソッド

インタオペラビリティレイヤーからメソッドを呼び出すのに加え、スマートコントラクトもまた、フレームワークによって提供されたメソッドを呼び出すことができます。これらのメソッドは`Neo.SmartContract.Framework`内にあり、スマートコントラクトで直接呼出すことができます。

### SmartContract クラスメソッド

[NEO スマートコントラクト チュートリアル](../tutorial.md)では、コントラクトが`FunctionCode`または`VerificationCode`のいずれかを継承していることが分かります。これらの2つのクラスはSmartContractを継承し、ハッシュアルゴリズムと署名メソッドを提供します。

|                                                        | 名前                                             | 説明                                             |
| ------------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                                     | SHA1を使用して入力バイトをハッシュ化する                       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                                   | SHA256を使用して入力バイトをハッシュ化する                     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                                  | SHA256、続いてRPEMD160を使用して入力バイトをハッシュ化する|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                                  | SHA256を2回使用して入力バイトをハッシュ化する               |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] pubkey, byte[] signature) | 指定のpubkeyを使用して署名をベリファイする           |

### バイト配列ヘルパーメソッド

以下のメソッドは、NET frameworkのヘルパークラスによって提供される、バイト配列のヘルパーメソッドです。

|                                                        | 名前                         | 説明                                                      |
| ------------------------------------------------------ | ---------------------------- | ---------------------------------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | 2つのバイト配列を結合する                                        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | バイト配列の一部を返す、パラメータ: index, count        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | バイト配列の一番左からXバイトを返す、パラメータ: count |
