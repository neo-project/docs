# Класс Account 

Класс, который представляет  аккаунт (счет) и метод для запроса баланса. В данном случае аккаунт относится к хэшу скрипта контракта, который соответствует адресу в блокчейне. 

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Account
```

## Атрибуты

| | Имя | Описание | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Получает хэш скрипта аккаунта контракта. | [ScriptHash](Account/ScriptHash.md) | Returns the script hash of the contract account |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) |  
Возвращает информацию о голосах из этого аккаунта в другой.


## Методы

| | Имя | Описание | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Возвращает баланс актива, идентифицированного по предоставленному ID.

## Конструктор

Объект Account строится с помощью [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
