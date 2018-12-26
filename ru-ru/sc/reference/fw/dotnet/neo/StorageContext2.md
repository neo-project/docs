# StorageContext Enumeration

Используется для представления перечисления контекста частной зоны хранения.

> [!Caution]
> Обратите внимание: устарел в версии 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum StorageContext: byte
```

## Перечисление

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [CallingContract](StorageContext/CallingContract.md) | Контекст хранилища инициатора вызова |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [Current](StorageContext/Current.md) | TКонтекст хранилища текущего контракта |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [EntryContract](StorageContext/EntryContract.md) | Входная точка контракта (начальная точка цепочки вызова контракта) |
