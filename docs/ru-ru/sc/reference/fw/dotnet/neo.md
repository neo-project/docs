# Пространство имен NEO 

Пространство имен NEO - это API, предоставляемый блокчейном Neo для доступа к его данным и управления постоянным хранилищем. Данные API делятся на две категории:

1. Регистр блокчейна. Благодаря слою интерактивных сервисов (interops) контракт может получить доступ ко всем данным блокчейна, включая полные блоки и транзакции, а также их поля.

2. Постоянное хранилище. Каждый прикладной контракт (application contract), развернутый в NEO, имеет пространство для хранения, доступ к которому может получить только сам контракт. Предоставленные методы имеют доступ к данным в контракте.

Примечание: тэги `New` и `Deprecated` в данном разделе означают изменения в версии 2.0 относительно версии 1.6.

## Список класов

| | Класс | Описание |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | Класс, представляющий учетную запись (счет) и метод для запроса баланса.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Класс, представляющий актив и структуру его данных.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | Класс, представляющий блок и методы для запроса транзакций в блоке. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Предоставляет набор методов для доступа к данным блокчейна.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | Класс, представляющий контракт.               |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `New`Представляет структуру данных регистрационной транзакции (registration transaction) буккипера. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Представляет структуру данных заголовка блока.           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `New` Предоставляет набор методов во время выполнения смарт-контракта.   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Предоставляет набор методов для добавления, запроса или удаления данных постоянного хранилища.   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `New` Класс, представляющий  контекст хранения постоянного хранилища.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  Базовый класс, представляющий транзакцию.            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | Структура данных, представляющая атрибуты транзакции.          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | Структура данных, представляющая входы транзакции (transaction inputs).         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | Структура данных, представляющая выходы транзакции (transaction outputs).         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `New` Предоставляет набор методов для узлов консенсуса.      |

## Перечисления

|  | Перечисление | Описание |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `Deprecated`  Представляет перечисление (enum) контекста хранения. |
