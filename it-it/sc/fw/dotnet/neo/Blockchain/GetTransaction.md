# Metodo (byte[]) Blockchain.GetTransaction 

Restituisce una transazione dato l'ID di una transazione.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(byte[] hash)
```

Parametri: ID della transazione (Hash della transazione) come array di byte di lunghezza 32.

Valore restituito: [Transaction](../Transaction.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
     }
}
```



[Indietro](../Blockchain.md)
