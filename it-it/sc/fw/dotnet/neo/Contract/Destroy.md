# Metodo () Contract.Destroy 

Distruzione degli smart contract. Lo smart contract pubblicato sulla blockchain non può essere distrutto dall'esterno, quindi se il contratto deve essere distrutto, la logica deve essere scritta durante lo sviluppo.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern void Destroy()
```

## Esempio

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



[Indietro](../Account.md)
