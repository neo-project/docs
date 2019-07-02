# Класс TransactionAttribute 

Структура данных, представляющая атрибуты транзакции.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class TransactionAttribute: IApiInterface
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | -------------------------------------- | ----------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Data](TransactionAttribute/Data.md)   | Возвращает данные, не относящиеся цели транзакции  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Usage](TransactionAttribute/Usage.md) | Возвращает данные, относящиеся цели транзакции        |

## Конструктор

Объект TransactionAttribute строится с помощью [GetAttributes ()](Transaction/GetAttributes.md) объекта Translation.

