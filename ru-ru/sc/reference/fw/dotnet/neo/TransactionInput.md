# Класс TransactionInput 

Используется для представления структуру данных входа транзакции.

В системе UTXO вход транзакции должен быть получен из выхода предшествующей транзакции.

Для подтверждения выходов предыдущей транзакции нам необходима следующая информация:

1.  Хэш предыдущей транзакции ([PrevHash](TransactionInput/PrevHash.md))
2.  Индекс данного входа в списке выходов предыдущей транзакции ([PrevIndex](TransactionInput/PrevIndex.md))

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class TransactionInput: IApiInterface
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Возвращает хэш предыдущей транзакции           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Возвращает индекс данного входа в списке выходов предыдущей транзакции  |

## Конструктор

Объект TransactionInput строится с помощью  [GetInputs()](Transaction/GetInputs.md) объекта Transaction.
