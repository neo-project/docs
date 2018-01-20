# Metodo (byte[]) Account.GetBalance

Ottenere il saldo degli asset specificati nell'account mediante l'ID dell'asset.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern long GetBalance (byte[] asset_id)
```

Parametri: Asset ID, l'ID della transazione di RegisterTransaction quando l'asset è registrato. È una matrice di byte di lunghezza 32.

Valore restituito: Il saldo degli asset nell'account come lungo, uguale alla quantità effettiva moltiplicata per 100.000.000.

## Esempio

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount(scriptHash);
        // Take NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        long balance = account.GetBalance(asset);
    }
}
```



[Indietro](../Account.md)
