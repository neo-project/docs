# Block.GetTransactions Method ()

Возвращает все транзакции в текущем блоке.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions()
```

Возвращаемое значение: Массив транзакций в виде Transaction[].

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction[] txs = block.GetTransactions();
     }
}
```



[Back](../Block.md)
