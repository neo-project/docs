# ExecutionEngine.ScriptContainer プロパティ

現在のコントラクトのスクリプトコンテナを返します（最初のトリガです）。これは通常トランザクションです。このコントラクトが、コントラクトアカウントからのトランザクションによってトリガーされた場合、スクリプトコンテナはそのトランザクションのものになります。現在のコントラクトが呼び出しトランザクションによってトリガーされた場合、スクリプトコンテナはその呼び出しトランザクションのものになります。

名前空間: [Neo.SmartContract.Framework.Services.System](../../System.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern Neo.SmartContract.Framework.IScriptContainer ScriptContainer {get;}
```

属性値: IScriptContainer型のScriptContainer。トリガがトランザクションであると分かっている場合、[Transaction](../../neo/Transaction.md)にキャストできます。



[戻る](../ExecutionEngine.md)


