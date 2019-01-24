# Block.GetTransactionCount Method ()

Возвращает число транзакций в текущем блоке.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern int GetTransactionCount()
```

Возвращаемое значение: Число транзакций в виде целого числа.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Int txCount = block.GetTransactionCount();
     }
}
```



[Back](../Block.md)
