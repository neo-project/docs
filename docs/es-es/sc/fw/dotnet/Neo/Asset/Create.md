# Método Blockchain.CreateAsset(byte, string, long, byte, byte[], byte[], byte[])

Al llamar a este método dentro de un contrato inteligente permite registrar un activo dentro de un bloque pequeño.

El método reemplaza a RegistTransaction en la versión 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset CreateAsset (byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

parámetros:

Asset_type: el tipo de saldo, de tipo byte. Para más información ver [AssetType](../Asset/AssetType.md).

Name: el nombre del activo, de tipo string.

Amount: el total del saldo, de tipo long. El valor debe ser igual a la cantidad total del saldo x 10 puts.

Precision: la precisión del activo (el número mínimo de divisiones), el número de bits después de la coma, tipo byte.

Owner: el propietario del activo (clave pública), array de 33 bytes.

Admin: el administrador del activo (dirección del contrato), este tiene el derecho de atribuir los activos (el total, nombre, etc) para modificar el array de 20 bytes.

Issuer: el emisor del activo (dirección del contrato), este tiene permisos para emitir activos, array de 20 bytes.

Valor de retorno: El saldo creado, del tipo [Asset](../Asset.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        Byte assetType = 0x60; // Token
        String name = "Star Wars movie ticket";
        Long amount = 1000;
        Byte precision = 0;
        byte[] owner = {2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202};
        byte[] admin = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        byte[] issuer = admin;
        Asset ass = Blockchain.CreateAsset (assetType, name, amount, precision, owner, admin, issuer);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Volver arriba](../Blockchain.md)
