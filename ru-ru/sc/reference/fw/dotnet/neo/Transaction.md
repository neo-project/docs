# Класс Transaction 

Используется для представления базового класса транзакции.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Transaction: IScriptContainer
```

## Атрибуты

| | Имя | Description |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Возвращает хэш транзакции |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Возвращает тип транзакции |

## Методы

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | Возвращает все атрибуты транзакции |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | Возвращает все [TransactionInput](TransactionInput.md) Возвращает все |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | Возвращает все [TransactionOutput](TransactionOutput.md) Возвращает все |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | Возвращает все выходы, на которые ссылаются входы транзакции |

## Конструктор

Объект Transaction строится с помощью [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
