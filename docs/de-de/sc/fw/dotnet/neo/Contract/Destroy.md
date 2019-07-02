# Contract.Destroy Methode ()

Löschung von Smart Contracts. Der Smart Contract der auf der Blockchain veröffentlicht wurde kann nicht von außen gelöscht werden. Wenn der Contract gelöscht werden soll muss die Logik bereits während der Entwicklung beachtet werden.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Destroy()
```

## Beispiel

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
