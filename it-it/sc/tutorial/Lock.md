# Esempio di Smart Contract - Lock (Contratto di Blocco)

```c#
public class Lock : SmartContract
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (header.Timestamp < timestamp)
            return false;
        return VerifySignature(signature，pubkey);
    }
}
```

Il contratto implementa una funzione che specifica un certo timestamp. Prima del tempo specificato, nessuno è autorizzato a ritirare alcun bene dal contratto. Quando il tempo specificato viene raggiunto, i proprietari del contratto possono ritirare gli assets.

Il tempo corrente ottenuto dal contratto equivale al tempo dell'ultimo blocco nella blockchain (l'errore è di circa 15 secondi). Per dettagli, fare riferimento a [Blockchain class](../fw/dotnet/neo/Blockchain.md), [Header class](../fw/dotnet/neo/Header.md).

Questo contratto puó essere implementato sulla chain affinché altri lo possano richiamare. Se desideri implementare un contratto timelock localmente, per favore fai riferimento a [Lock Contract](Lock2.md)

