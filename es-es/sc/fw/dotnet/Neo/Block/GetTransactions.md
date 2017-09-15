# Método Block.GetTransactions()

Devuelve todas las transacciones en el bloque actual.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions ()
```

Valor de retorno: Array del tipo Transaction, Transaction[].

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Block block = Blockchain.GetBlock (997027);
         Transaction[] txs = block.GetTransactions ();
     }
}
```



[Volver arriba](../Block.md)
