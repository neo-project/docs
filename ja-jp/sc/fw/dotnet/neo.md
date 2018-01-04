# NEO名前空間

NEOの名前空間は、NEOブロックチェーンによって提供されるAPIで、ブロックチェーンデータへのアクセスおよび永続化ストアの操作方法を提供します。これらのAPIは2つのカテゴリに分けられます:

1. ブロックチェーン台帳。コントラクトはインターオペラビリティレイヤーを通じてブロックチェーン全体のデータにアクセスすることができ、そのデータは完全なブロックやトランザクションで、それらの各フィールドも同様です。

2. 永続化ストア。NEOにデプロイされた各アプリケーションコントラクトには、コントラクト自体によってアクセス可能なストレージ空間があります。提供されるこれらのメソッドは、コントラクト内のデータにアクセスすることができます。

注意: 本記事における`新規`および`廃止予定`のタグは、バージョン1.6に対するバージョン2.0への変更です。

## クラス

| | クラス | 説明 |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | アカウントを表すクラスで、残高を問い合わせるメソッドを提供する。      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | アセットとそのデータ構造を表すクラス。         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | ブロックを表すクラスで、ブロック内のトランザクションを問い合わせるメソッドを提供する。  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | ブロックチェーンデータにアクセスするための一連のメソッドを提供する。    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | コントラクトを表すクラス。                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `新規` ブックキーパーの登録トランザクションのデータ構造を表す。 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | ブロックヘッダのデータ構造を表す。           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `新規` スマートコントラクト実行中の一連のメソッドを提供する。   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | 永続化ストアの追加、問い合わせ、削除をするための一連のメソッドを提供する。   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `新規` 永続化ストアのストレージコンテキストを表すクラス。  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  トランザクションを表す基底クラス。            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | トランザクションの属性を表すデータ構造。          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | トランザクションの入力を表すデータ構造。         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | トランザクションの出力を表すデータ構造。         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `新規` コンセンサスノードのための一連のメソッドを提供する。      |

## 列挙

|  | 列挙 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `廃止予定` ストレージコンテキストの列挙型（enum）を表す。 |
