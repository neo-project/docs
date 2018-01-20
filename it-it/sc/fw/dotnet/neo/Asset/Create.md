# Metodo (byte, string, long, byte, byte[], byte[], byte[]) Asset.CreateAsset 

Questo metodo registra un asset sulla blockchain di NEO.

Questo metodo rimpiazza la RegisterTransaction nella versione 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi:

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

Parametri:

asset_type: Un tipo di asset come byte. Per dettagli, si prega di far riferimento a [AssetType](../Asset/AssetType.md).

name: Il nome dell'asset come stringa.

amount: La quantità dell'asset come lungo. Qui il valore in input dovrebbe essere inteso come valore moltiplicato per 100,000,000.

precision: La divisione più piccola dell'asset, o il numero di posti decimali che l'asset può prendere come byte. 

owner: La chiave pubblica del proprietario come array di byte di lunghezza 33.

admin: L'indirizzo del contratto dell'amministratore come array di byte di lunghezza 20.

issuer: L'indirizzo del contratto dell'emittente come array di byte di lunghezza 20.

Valore restituito: Il nuovo asset registrato come oggetto [Asset](../Asset.md).

## Esempio

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



[Indietro](../Asset.md)
