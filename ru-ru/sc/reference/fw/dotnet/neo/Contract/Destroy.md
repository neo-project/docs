# Contract.Destroy Method ()

Удаление смарт-контракта. Смарт-контракт, опубликованный в блокчейн, не может быть разрушен средствами извне, поэтому, если смарт-контракт необходимо будет удалить, во время разработки следует написать логику для его удаления.

Когда контракт удаляется, то и удаляется зона хранения старого контракта. Если контракт переносится, то содержащееся в старой зоне хранения копируется в зону хранения нового контракта.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Destroy()
```

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         var height = Blockchain.GetHeight();
         var block = Blockchain.GetBlock(height);
         if (block.Timestamp > 1514736000) // Beijing time 2018-1-1
         {
             Neo.SmartContract.Framework.Services.Neo.Contract.Destroy();
         }
     }
}
```



[Back](../Account.md)
