# Класс ExecutionEngine 

Представляет виртуальный процессор виртуальной машины, обеспечивающий доступ к инициатору вызова и контейнеру выполнения (execution container).

Пространство имен: [Neo.SmartContract.Framework.Services.System](../System.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class ExecutionEngine
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | Возвращает хэш скрипта инициатора вызова контракта           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | Возвращает хэш скрипта входных точек контракта (в цепочке вызова контракта) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | Возвращает хэш скрипта выполяющегося контракта             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | Возвращает контейнер скрипта текущего контракта (initial trigger)      |