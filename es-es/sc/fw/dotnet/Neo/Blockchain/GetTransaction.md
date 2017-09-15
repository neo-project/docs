# Método Blockchain.GetTransaction(byte[])

Devuelve transacciones por su ID de transacción.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction (byte[] hash)
```

Parámetros: ID de la transacción (hash de la transacción), array de 32 bytes.

Valor de retorno: [Transaction](../Transaction.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction (transaction);
     }
}
```



[Volver arriba](../Blockchain.md)
