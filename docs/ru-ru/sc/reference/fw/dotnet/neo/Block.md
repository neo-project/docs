# Класс Block 

Класс, представляющий блок и предоставляющий способ для запроса транзакций в блоке.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Block: Header
```

## Методы

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Возвращает указанную транзакцию в блоке |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Возвращает число транзакций в блоке |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Возвращает все транзакции в блоке |

## Конструктор

Объект Block строится с помощью [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md).

Объект Block строится с помощью [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
