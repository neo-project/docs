# Класс Blockchain 

Данный класс предоставляет набор методов для доступа к данным блокчейна.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public static class Blockchain
```

## Методы

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | Возвращает аккаунт (адрес) из данного хэша скрипта |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | Возвращает актив из ID данного актива         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | Возвращает блок из хэша данного блока       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | Возвращает блок из высоты данного блока           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `New` Возвращает содержание контракта из хэша данного контракта   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | Возвращает заголовок блока из хэша данного блока      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | Возвращает заголовок блока из высоты данного блока         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | Возвращает высоту текущего блока             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Возвращает транзакцию из ID данной транзакции       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `New` Возвращает открытые ключи валидаторов       |

## Конструктор

Класс BlockChain  является статическим и не нуждается в конструкторе.

