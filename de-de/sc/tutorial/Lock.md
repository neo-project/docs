# Smart Contract Beispiel - Lock (Lock Contract)

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

Der Contract implementiert eine Funktion, welche einen bestimmten Zeitstempel spezifiziert. Vor der angegebenen Zeit ist es niemandem erlaubt Assets von Contract abzuheben. Sobald die angegebene Zeit erreicht ist, können die Inhaber des Contracts Assets abheben.

Die aktuelle Zeit, die der Contract erlangt, ist die Zeit des letzten Blocks in der Blockchain (Die Fehlertoleranz ist ca. 15 Sekunden). Details finden Sie unter [Blockchain class](../fw/dotnet/neo/Blockchain.md), [Header class](../fw/dotnet/neo/Header.md).

Dieser Vertrag kann in der Blockchain zur Verfügung gestellt werden, damit ihn Andere anrufen können. Wenn Sie einen Timelock Contract lokal zur Verfügung stellen wollen, schauen Sie bitte unter [Lock Contract](Lock2.md) nach.
