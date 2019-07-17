# Método Blockchain.GetBlock(byte[])

Busca un bloque dentro de la blockchain por su tamaño.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Block GetBlock (byte[] hash)
```

Parámetros: Hash del bloque, array de 32 bytes.

Valor de retorno: [Block](../Block.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] block = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Block bl = Blockchain.GetBlock (block);
     }
}
```



[Volver arriba](../Blockchain.md)
