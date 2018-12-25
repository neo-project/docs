# Blockchain.GetHeader Method (uint)

Возвращает заголовок блока при наличии высоты блока.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(uint height)
```

Параметры: Высота блока в виде целого числа без знака.

Возвращаемое значение: [Header](../Header.md).

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader(997027);
     }
}
```



[Back](../Blockchain.md)
