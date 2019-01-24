# ExecutionEngine.ScriptContainer Property

Возвращает контейнер скрипта текущего контракта (начальный триггер). Обычно это транзакция, если данный контракт был инициирован транзакцией из счета контракта, то ScriptContainer будет относиться к этой транзакции. Если текущий контракт был инициирован Invocation Transaction, то ScriptContainer будет относиться к этой Invocation Transaction.

Namespace: [Neo.SmartContract.Framework.Services.System](../../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.IScriptContainer ScriptContainer {get;}
```

Значение атрибута: Контейнер скрипта в виде IScriptContainer. Если вы знаете, что триггером является Transaction, то вы можете привести его к типу [Transaction](../../neo/Transaction.md).



[Back](../ExecutionEngine.md)
