# Класс TransactionOutput 

Структура данных, используемая для представления выхода транзакции. Выход транзакции имеет три поля:

1. Тип активов
2. Адрес назначения
3. Сумма перевода

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class TransactionOutput: IApiInterface
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Возвращает ID актива |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Возвращает хэш скрипта |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Возвращает сумму транзакции |


## Конструктор

Объект TransactionOutput строится с помощью [GetOutputs()](Transaction/GetOutputs.md) объекта Transaction.
