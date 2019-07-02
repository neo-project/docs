# Blockchain.GetAccount Method (byte[])

Возвращает счет (адрес) на основе хэша хэша скрипта контракта.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Account GetAccount(byte[] script_hash)
```

Параметры: Хэш скрипта в виде байтового массива, имеющего длину 20.

Возвращаемое значение: [Account](../Account.md).

## Пример

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account acc = Blockchain.GetAccount(scriptHash);
    }
}
```
Хэш скрипта можно получить заранее и передать его в качестве параметра в смарт-контракт. Следующий код использует SDK, чтобы преобразовать адрес в хэш скрипта.

```c#
Static void Main(string[] args)
{
    byte[] scriptHash = Neo.Wallets.Wallet.ToScriptHash("AK4if54jXjSiJBs6jkfZjxAastauJtjjse").ToArray();
}
```



[Back](../Blockchain.md)
