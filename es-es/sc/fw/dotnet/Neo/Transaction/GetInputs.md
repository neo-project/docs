# Método Transaction.GetInputs()

Devuelve todas transacciones para la transacción actual.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionInput[] GetInputs ()
```

Valor de retorno: Array del tipo [TransactionInput](../TransactionInput.md) con todas las transacciones para la transacción actual.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction (transaction);
         TransactionInput[] inputs = tx.GetInputs ();
     }
}

```



[Volver arriba](../Transaction.md)
