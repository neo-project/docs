# Blockchain.GetHeight Method ()

Возвращает текущую высоту блока блокчейна. Высота блока = индекс блока = количество блоков - 1.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetHeight()
```

Возвращаемое значение: Возвращает высоту текущего блока.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Uint height = Blockchain.GetHeight();
     }
}
```



[Back](../Blockchain.md)
