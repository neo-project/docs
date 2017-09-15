# Método Asset.Renew(byte[])

Renueva un activo.

El método es una nueva versión del de la versión 2.0. En la versión 2.0 de la cadena, después del registro de activos es necesario pagar una tasa anual para su uso.

Cuando el activo expira, es necesaria su renovación. Cuando el saldo no está congelado, la tasa de renovación es desde la expiración del activo. Por lo tanto, no habrá atrasos después de la renovación de tasas.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern uint Renew (byte years)
```

Parámetros: período de renovación, un año es igual a 2.000.000 bloques, de tipo byte.

Valor de retorno: The height del bloque donde el activo puede ser usado después de la renovación.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset (asset);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Volver arriba](../Asset.md)
