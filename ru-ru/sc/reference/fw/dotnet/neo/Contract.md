# Класс Contract 

Класс, представляющий контракт.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Contract
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | Возвращает хэш скрипта контракта  |

## Методы

| | Имя | Описание |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | `New` Публикует контракт    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | `New` Мигрирует контракт |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | `New` Удаляет контракт    |

## Конструктор

Объект Contract может быть построен с помощью [Blockchain.GetContract(byte[])](Blockchain/GetContract.md).

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) публикует контракт в блокчейн и возвращает объект Contract.

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md)  возобновляет контракт и возвращает объект Contract.