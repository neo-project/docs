# Método Blockchain.GetHeader(byte[])

La cabecera del bloque se encuentra en la blockchain por el tamaño del bloque.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader (uint height)
```

Parámetros: Hash del bloque, array de 32 bytes.

Valor de retorno: Bloque, del tipo [Header](../Header.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader (997027);
     }
}
```



[Volver arriba](../Blockchain.md)
