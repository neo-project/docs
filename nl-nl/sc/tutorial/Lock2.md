# Lock Contract Deployen

Lees de volgende handleidingen voor het lezen van deze pagina:
- [NEO smart contracts schrijven met C#](../getting-started-csharp.md)
- [NEO Smart Contract handleiding](../tutorial.md)
- [Smart contract voorbeeld - lock](Lock.md)

We gaan er nu vanuit dat je inmiddels basiskennis hebt opgedaan over smart contracts. Nu zullen we laten zien hoe een lock-contract naar een adres te deployen is met behulp van de wallet.

Deze tutorial is gebaseerd op de demo van Smart Contract 2.0. Download de laatste **testnetwerk client** van [GitHub](https://github.com/neo-project/neo-gui/releases) (op dit moment is [dit](https://github.com/neo-project/neo-gui/releases/tag/v2.3.2) de meest recente versie).

> [!Note]
> De volgende handelingen zullen plaatsvinden op het **testnetwerk**, aangezien het hoofdnetwerk nog niet werkt met Smart Contract 2.0.
> Om het TestNet te gebruiken, moeten twee aanpassingen worden gemaakt in de configuratiebestanden:
1. Pak de Neo-GUI client uit.
2. Kopiëer de inhoud van de bestanden met `testnet` in de naam naar de gelijknamige bestanden zonder `testnet` (maar ook zonder `mainnet`!). Bijvoorbeeld: van `config.testnet.json` naar `config.json`.

## Wallet aanmaken

Deze stap is simpel: open de PC-versie van de client, klik op `wallet`, `create the wallet database`, kies de opslaglocatie voor de wallet en kies een naam en wachtwoord.

![](/assets/lock2_1.png)

## Public Key

De nieuwe wallet zal automatisch een standaard account hebben gegenereerd. Klik met de rechter muisknop op de account, bekijk de private key en kopiëer deze van de tweede regel, zoals in de afbeelding hieronder:

![](/assets/lock2_2.png)

> [!Caution]
> Let op: houd je private key voor jezelf! Deze dient niet met anderen gedeeld te worden.

We schrijven een programma om de public key om te zetten in een byte-array met behulp van C#:

```c#
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vervang de lange code hieronder met de gekopiëerde private key
            byte[] b = HexToBytes("0285eab65f4a0126e4b85b4e5d8b7e303aff7efb360d595f2e3189bb90487ad5aa");
            foreach (var item in b)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();
        }

        static byte[] HexToBytes(string hexString)
        {
            hexString = hexString.Trim();
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
    }
}
```

Als dit is uitgevoerd, geeft het programma een byte-array. Kopiëer deze en sla deze op; deze gebruiken we in een latere stap.

## Schrijf een smart contract

Maak een smart contract project aan en schrijf het volgende smart contract:

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Lock : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            Header header = Blockchain.GetHeader(Blockchain.GetHeight());
            if (header.Timestamp < 1499328600) // 2017-6-6 18:10
                return false;
            // Paste the public key byte array here
            return VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature);
        }
    }
}
```

Het contract hierboven is gebaseerd op VerificationCode, met als doel het creëren van een contract-authenticatie-account, oftewel: een contract in het wallet-adres.

Het lock-contract heeft twee belangrijke variabelen die aangepast kunnen worden: de public key en het tijdslot (lock time).

1. Plak in de code van het contract de gekopiëerde pulic key byte-array.

2. Verander het tijdslot in de voorbeeldcode (een Unix-tijdstempel). Bereken deze zelf, bijvoorbeeld met behulp van een [website](https://unixtime.51240.com/).

Nadat de twee variabelen zijn aangepast, compileer dan het contract om een Lock.avm-bestand te krijgen.

## Deploy lock Contract

Om het contract te deployen, moet eerst het contract script verkregen worden. Lees hiervoor [deze handleiding](verify.md).


## Testen

Hieronder volgt een test van de smart contract authenticatie-account. Als assets uit een smart contract-account worden overgemaakt, zullen de consensus nodes het contract uitvoeren bij het valideren van de transactie. Als het contract succesvol gevalideerd is (`return true`), dan is de transactie bevestigd. Tot het resultaat `true` ontvangen is, zal de transactie de status 'onbevestigd' hebben. Als test worden eerst wat assets naar de contract-authenticatie-account overgemaakt, en vervolgens weer overgemaakt vanuit de account.

> [!Note]
> Om zeker te zijn van de geldigheid van de test is het van belang dat er geen andere assets in de wallet aanwezig zijn, anders kan het onbekend zijn of de asset vanuit de standaard-account was overgemaakt, of vanuit de contract-account (tenzij je het 'change search'-algoritme van de client kent en er zeker van kan zijn dat de transactie wordt uitgevoerd vanuit het smart contract-adres).

### Asset overmaken naar contract address

Maak een bepaalde hoeveelheid assets over naar de contract-account:

![Transfer asset to contract address](/assets/verify_9.png)

### Assets overmaken vanuit contract address

Maak een bepaalde hoeveelheid assets over vanuit de contract-account:

![Transfer contract amount](/assets/lock2_11.png)

Als bovenstaande handelingen juist worden uitgevoerd, gebeurt het volgende als de asset wordt overgemaakt:

Als de huidige tijd eerder is dan de lockout time, zal de transactie niet bevestigd worden en dus mislukken

Na klikken op `Rebuild Index` zal na ongeveer 5 minuten de afgewezen transactie verdwijnen en zullen de assets terugkeren naar hun vorige staat.

Als de huidige tijd later is dan de lock time, zal de transactie succesvol zijn.
