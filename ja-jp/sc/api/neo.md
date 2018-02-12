# NEO 名前空間

NEO 名前空間には、NEOブロックチェーンによって提供されるAPIが含まれています。APIのメソッドを使用すると、永続化ストアの操作とブロックチェーンのクエリを実行することができます。

注：`新規`および`廃止予定`タグは、バージョン1.6とバージョン2.0の間の変更点を示しています。

## 読み取り専用API

Blockchain クエリAPI：

| API                           | 説明 |
| ----------------------------- | -------------------------- |
| Neo.Blockchain.GetHeight      | 現在のブロックの高さを取得する |
| Neo.Blockchain.GetHeader      | ブロックの高さ、またはブロックハッシュによるブロックヘッダを検索する |
| Neo.Blockchain.GetBlock       | ブロックの高さ、またはブロックハッシュによりブロックを検索する |
| Neo.Blockchain.GetTransaction | トランザクションIDを使用してトランザクションを検索する |
| Neo.Blockchain.GetAccount     | コントラクトのスクリプトハッシュに基づいてアカウントを取得する |
| Neo.Blockchain.GetValidators  | `新規` コンセンサスノードの公開鍵を取得する |
| Neo.Blockchain.GetAsset       | アセットIDに基づいてアセットを取得する |
| Neo.Blockchain.GetContract    | `新規` コントラクトハッシュに基づいてコントラクトの内容を取得する |

Block クラスAPI：

| API                           | 説明 |
| ----------------------------- | -------------------------- |
| Neo.Header.GetHash            | ブロックのハッシュを取得する |
| Neo.Header.GetVersion         | ブロックのバージョン番号を取得する |
| Neo.Header.GetPrevHash        | 前のブロックのハッシュを取得する |
| Neo.Header.GetMerkleRoot      | ブロック内のすべてのトランザクションのMerkle Treeのルートを取得する |
| Neo.Header.GetTimestamp       | ブロックのタイムスタンプを取得する |
| Neo.Header.GetConsensusData   | ブロックのコンセンサスデータを取得する（コンセンサスノードによって生成された擬似乱数） |
| Neo.Header.GetNextConsensus   | 次のブックキーパーコントラクトのハッシュ値を取得する |
| Neo.Block.GetTransactionCount | 現在のブロック内のトランザクション数を取得する |
| Neo.Block.GetTransactions     | 現在のブロック内のすべてのトランザクションを取得する |
| Neo.Block.GetTransaction      | 現在のブロックで指定されたトランザクションを取得する |

Transaction クラスAPI：

| API | 説明 |
| ----------------------------- | -------------------------- |
| Neo.Transaction.GetHash       | 現在のトランザクションのハッシュを取得する |
| Neo.Transaction.GetType       | 現在のトランザクションタイプを取得する |
| Neo.Enrollment.GetPublicKey   | `廃止予定` Neo.Blockchain.GetValidatorsに置き換える |
| Neo.Transaction.GetAttributes | 現在のトランザクションのすべてのプロパティを照会する |
| Neo.Transaction.GetInputs     | 現在のトランザクションに対してすべてのトランザクションを照会する |
| Neo.Transaction.GetOutputs    | 現在のトランザクションに対してすべてのトランザクションの出力を照会する |
| Neo.Transaction.GetReferences | 現在のトランザクションのすべての入力が参照するトランザクション出力を照会する |
| Neo.Attribute.GetUsage        | トランザクションの目的を取得する |
| Neo.Attribute.GetData         | トランザクションの目的外の余剰なデータを取得する |
| Neo.Input.GetHash             | 参照されている前のトランザクションのハッシュを取得する |
| Neo.Input.GetIndex            | 参照されている前のトランザクションの出力リスト内の入力のインデックス |
| Neo.Output.GetAssetId         | アセットIDを取得する |
| Neo.Output.GetValue           | トランザクションの量を取得する |
| Neo.Output.GetScriptHash      | スクリプトハッシュを取得する |

Account クラスAPI：

| API | 説明 |
| ------------------------- | ------------------ |
| Neo.Account.GetScriptHash | コントラクトアカウントのスクリプトハッシュを取得する |
| Neo.Account.GetVotes      | アカウントが投じた票の情報を取得する |
| Neo.Account.GetBalance    | アセットIDが与えられたアカウント内のアセットの残高を取得する |

Asset クラスAPI：

| API | 説明 |
| ---------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId   | アセットのIDを取得する |
| Neo.Asset.GetAssetType | アセットのカテゴリを取得する |
| Neo.Asset.GetAmount    | アセットの総額を取得する |
| Neo.Asset.GetAvailable | 発行されたアセットの数量を取得する |
| Neo.Asset.GetPrecision | アセットの分割数、小数点以下の桁数を取得する |
| Neo.Asset.GetOwner     | アセットの所有者を取得する（公開鍵） |
| Neo.Asset.GetAdmin     | アセットの管理者（コントラクトアドレス）を取得する |
| Neo.Asset.GetIssuer    | アセットの発行者（コントラクトアドレス）を取得する |

Contract クラスAPI：

| API | 説明 |
| ---------------------- | -------- |
| Neo.Contract.GetScript | コントラクトのスクリプトハッシュを取得する |

Storage クラスAPI：

| API | 説明 |
| ---------------------- | ------------------------------- |
| Neo.Storage.GetContext | `新規` 現在のストアコンテキストを取得する |
| Neo.Storage.Get        | 任意のキーに基づいてインスタントストアの値を返す |

Runtime クラスAPI：

| API | 説明 |
| ------------------------ | --------------------------------- |
| Neo.Runtime.CheckWitness | `新規` 呼び出し元のコントラクトがトランザクション/ブロックに必要なスクリプトハッシュを承認したことを確認する |
| Neo.Runtime.Notify       | `新規` スマートコントラクト実行中のクライアントにお知らせを通知する |
| Neo.Runtime.Log          | `新規` スマートコントラクト実行中のクライアントにログメッセージを通知する |

注意：ソースコードは`NEO`内の`src/neo/SmartContract/StateReader.cs`ファイルの中にあります。

## 読み取り/書き込みAPI

このタイプのAPIは、スマートコントラクトのステータスを修正します。

| API | 説明 |
| ------------------------------ | -------------------------------- |
| Neo.Account.SetVotes           | アカウントの投票情報を設定する |
| Neo.Validator.Register         | `新規` ブックキーパーとして登録する |
| Neo.Asset.Create               | `新規` 新しいアセットを登録する |
| Neo.Asset.Renew                | `新規` アセットを更新する |
| Neo.Contract.Create            | `新規` スマートコントラクトを公開する |
| Neo.Contract.Migrate           | `新規` スマートコントラクトの移行/更新 |
| Neo.Contract.Destroy           | `新規` スマートコントラクトを破棄する |
| Neo.Contract.GetStorageContext | `新規` コントラクトのストレージコンテキストを取得する |
| Neo.Storage.Put                | 任意のキーに基づいて永続化ストアに値を挿入する |
| Neo.Storage.Delete             | 任意のキーに基づいて永続化ストアから値を削除する |

注意：上記APIのソースコードは`NEO`内の、`src/neo/SmartContract/StateMachine.cs`ファイルの中にあります。
