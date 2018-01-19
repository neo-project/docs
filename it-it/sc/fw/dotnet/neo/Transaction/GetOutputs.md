# Metodo () Transaction.GetOutputs

Restituisce tutti gli output di transazione per la transazione.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionOutput[] GetOutputs()
```

Valore Restituito: Tutti gli output della transazione corrente come un array [TransactionOutput](../TransactionOutput.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
         TransactionOutput[] = tx.GetOutputs();
     }
}
```



[Indietro](../Transaction.md)
