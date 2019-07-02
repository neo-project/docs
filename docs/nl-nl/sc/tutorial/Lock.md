# Smart Contract Voorbeeld - Lock (Lock Contract)

```c#
public class Lock : FunctionCode
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (header.Timestamp < timestamp)
            return false;
        return VerifySignature(pubkey, signature);
    }
}
```

Het contract implementeert een functie die een tijdstempel specificeert. Voordat deze tijd gegeven wordt, is het onmogelijk om assets uit het contract te halen. Wanneer de genoemde tijd is bereikt, kunnen de contracteigenaars wel hun assets opnemen.

Op dit moment is de verkregen tijd de duur van het laatst gemaakte block in de blockchain (grofweg 15 seconden). Kijk voor details naar de documentatie over [Blockchain class](../fw/dotnet/neo/Blockchain.md) en [Header class](../fw/dotnet/neo/Header.md).

Dit contract is gebaseerd op `FunctionCode`, wat betekent dat het bedoeld is om op de blokchcain te worden gezet om door anderen gebruikt te worden. Als je lokaal een tijdslot-contract wil opstellen, kijk dan bij [Lock Contract](Lock2.md).
