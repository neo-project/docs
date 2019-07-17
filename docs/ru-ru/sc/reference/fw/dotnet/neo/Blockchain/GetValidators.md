# Blockchain.GetValidators Method ()

Возвращает открытые ключи валидаторов (узлов консенсуса).

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte[][] GetValidators()
```

Возвращаемое значение: Массив из открытых ключей, каждый элемент которого является байтовым массивом, имеющим длину 33.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[][] validators = Blockchain.GetValidators();
     }
}
```



[Back](../Blockchain.md)