# ExecutionEngine クラス

仮想マシンの実行エンジンで、呼び出し元および実行コンテナへのアクセスができます。

名前空間: [Neo.SmartContract.Framework.Services.System](../System.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class ExecutionEngine
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | コントラクトの呼び出し元のスクリプトハッシュを返す           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | （コントラクト呼び出しチェーンにおける）コントラクトのエントリポイントのスクリプトハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | 実行中のコントラクトのスクリプトハッシュを返す             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | 現在のコントラクトのスクリプトコンテナを返す（最初のトリガ）      |
