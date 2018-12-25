# Blockchain.GetHeader Method (byte[])

Возвращает заголовок блока при наличии хэша блока.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(byte[] hash)
```

Параметры: Хэш блока в виде байтового массива, имеющего длину 32.

Возвращаемое значение: [Header](../Header.md).

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] Header = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Header bl = Blockchain.GetHeader(Header);
     }
}
```



[Back](../Blockchain.md)
