# Metodo () Transaction.GetAttributes 

Restituisce tutti gli attributi della transazione.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionAttribute[] GetAttributes()
```

Valore Restituito: Tutti gli attributi della transazione corrente, come array [TransactionAttribute](../TransactionAttribute.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
         TransactionAttribute[] txa = tx.GetAttributes();
     }
}
```



[Indietro](../Transaction.md)
