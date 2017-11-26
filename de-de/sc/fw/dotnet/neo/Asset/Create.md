# Asset.CreateAsset Methode (byte, string, long, byte, byte[], byte[], byte[])

Diese Methode registriert ein Asset in der Neo Blockchain.

Diese Methode ersetzt die RegisterTransaction in der Version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

Eigenschaften:

asset_type: Ein Asset Typ als ein Byte. Für Details klicken Sie bitte hier [AssetType](../Asset/AssetType.md).

name: Der Name eines Asset als String

amount: Der Wert eines Assets als Long. Der Eingabewert sollte hier mit Multiplikator 100,000,000 eingeben werden.

precision: Die kleinste Teilbarkeit des Assets，oder die Nummer der Dezimalstellen die das Asset als Byte kennen soll.

owner: Der öffentliche Schlüssel des Eigentümers als Byte Array mit einer länge von 33.

admin: Die Contract Address des Administrators als Byte Array mit einer Länge von 20.

issuer: Die Contract Address des Ausstellers als Byte Array mit einer länger von 20.

Return value: Das neu registrierte Asset als ein [Asset](../Asset.md) Objekt.

## Beispiel

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte assetType = 0x60; //Token
        string name = "StarWarsMovieTicket";
        long amount = 1000;
        byte precision = 0;
        byte[] owner = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        byte[] admin = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        byte[] issuer = admin;
        Asset ass = Asset.Create(assetType, name, amount, precision, owner, admin, issuer);
        uint blockIndex = ass.Renew(1);
    }
}
```



[Back](../Asset.md)
