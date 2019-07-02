# Block.GetTransaction Method (int)

Возвращает транзакцию, указанную индексом в текущей высоте блока.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(int index)
```

Параметры: индекс транзакции в блоке в виде целого числа.

Возвращаемое значение: Транзакция в виде типа [Transaction](../Transaction.md) Type.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction tx = block.GetTransaction(0);
     }
}
```



[Back](../Block.md)
