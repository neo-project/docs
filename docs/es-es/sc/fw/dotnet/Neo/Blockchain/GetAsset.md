# Método Blockchain.GetAsset(byte[])

Busca en la blockchain un activo basado en su ID y lo devuelve.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset (byte[] asset_id)
```

Parámetros: ID del activo, array de 32 bytes.

Valor de retorno: [Asset](../Asset.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset (asset);
    }
}
```

Dónde el activo se puede obtener previamente desde afuera, también se puede pasar como parámetro dentro del contrato inteligente. eL siguiente ejemplo muestra como obterner el activo en forma de array de bytes pasando el ID de este en formato de cadena hexadecimal mediantes una llamada a código externo.

```c#
Static void Main (string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes ("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[Volver arriba](../Blockchain.md)
