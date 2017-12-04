# System 名前空間

Systemの名前空間は、スマートコントラクトの実行環境にアクセスする方法を提供する、スマートコントラクト実行エンジン(NeoVM)によって提供されるAPIです。

| API | 説明 |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | スマートコントラクトの、スクリプトコンテナを取得する（最初のトリガ） |
| System.ExecutionEngine.GetExecutingScriptHash | 実行中のスマートコントラクトの、スクリプトハッシュを取得する  |
| System.ExecutionEngine.GetCallingScriptHash | スマートコントラクトの呼び出し元の、スクリプトハッシュを取得する |
| System.ExecutionEngine.GetEntryScriptHash | スマートコントラクトのエントリポイント（コントラクトコールチェインの開始ポイント）の、スクリプトハッシュを取得する |

注意: 上記APIのソースコードは、`Neo.VM`の`src\Neo.VM\InteropService.cs`ファイルにあります。
