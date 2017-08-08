# Método Blockchain.GetHeader(byte[])

Devuelve la cabecera del bloque según un hash.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader (byte[] hash)
```

Parámetros: Hash del bloque, array de 32 bytes.

Valor de retorno: Cabecera del bloque del tipo [Header](../Header.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] Header = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Header bl = Blockchain.GetHeader (Header);
     }
}
```



[Volver arriba](../Blockchain.md)
