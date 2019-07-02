# Metodo (byte[]) Blockchain.GetAsset 

Restituisce un asset sulla blockchain dato l'ID di un asset.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset (byte[] asset_id)
```

Parametri: ID dell'asset come array di byte di lunghezza 32.

Valore restituito: [Asset](../Asset.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
    }
}
```

L'ID dell'asset può essere ottenuto in anticipo e può essere passato come parametro negli smart contract. Quanto segue utilizza l'SDK per convertire la stringa esadecimale in una matrice di byte.

```c#
Static void Main(string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[Indietro](../Blockchain.md)
