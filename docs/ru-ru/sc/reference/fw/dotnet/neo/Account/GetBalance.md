# Account.GetBalance Method (byte[])

Возвращает баланс указанных активов на счете с помощью ID актива.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern long GetBalance (byte[] asset_id)
```

Параметры: ID актива, ID транзакции RegisterTransaction (когда регистрируется актив). Это байтовый массив, имеющий длину 32.

Возвращаемое значение: Баланс активов на счете в виде длинного числа (равен фактической сумме, умноженной на 100 000 000).

## Example

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount(scriptHash);
        // Take NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        long balance = account.GetBalance(asset);
    }
}
```



[Back](../Account.md)
