# Método Blockchain.GetValidators()

Devuelve la clave pública de la persona de consenso.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern byte[][] GetValidators ()
```

Valor de retorno: Un array con la clave pública, cada elemento en el array es otro array de 33 bytes.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[][] validators = Blockchain.GetValidators ();
     }
}
```



[Volver arriba](../Blockchain.md)
