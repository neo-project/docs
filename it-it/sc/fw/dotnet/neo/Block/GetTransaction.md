#  Metodo (int) Block.GetTransaction 

Restituisce la transazione specificata nell'indice del blocco corrente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(int index)
```

Parametri: L'indice della transazione nel blocco come un integer.

Valore restituito: Transazione come un tipo di [Transazione](../Transaction.md).

## Esempio

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



[Indietro](../Block.md)
