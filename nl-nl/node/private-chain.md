# Bouw een Private Chain met een NEO Node

In een voorafgaande pagina is uitgelegd hoe een node op te zetten is op Windows en Linux. Deze handleiding zal uitleggen hoe een Private of Alliance Chain kan worden gemaakt en welke stappen moeten worden doorlopen om NEO en GAS op deze private chains te verkrijgen.

Voor het deployen van een NEO private chain zijn op zijn minst vier servers nodig om een consensus te bereiken, waarbij elke server gelijk staat aan een consensus node en een NEO-wallet.

## 1. Configuratie van de Virtual Machine

Voor demonstratieve doeleinden zijn in de volgende situatie vier Windows virtual machines gemaakt op Azure met grootte Standard DS1 v2 (1 core, 3,5 GB RAM). Private chains kunnen worden gemaakt op een LAN of een virtual machine.

![image](/assets/privatechain_1.png)

Om port 10331-10334 te openen, ga je naar `firewall`, `advanced settings`, `inbound rules` en voeg je de port toe.

> [!Note]
> Als je de virtual machine op een cloud-server aanmaakt, log dan in op de virtual machine's administratieve achtergrond en maak een network security groep.
>
> De Azure setupmethode is: `network interface` `network security group` `inbound security rules` `add` add port 10331-10334.

Als de virtual machine eenmaal is aangemaakt, is het van belang om de IP-adressen van de vier virtual machines te bewaren voor later gebruik.

## 2. Installatie van de NEO Node

De installatie van een NEO-node wordt toegelicht in een andere sectie; zie de [Installatie sectie](setup.md).

## 3. Aanmaken van een Wallet

Eerst maken we vier wallet-bestanden aan: wallet1.db3 t/m wallet4.db3. Deze stap kan worden uitgevoerd in Neo-GUI of Neo-CLI, waarbij de volgende afbeelding weergeeft hoe het eruit zou zien bij Neo-CLI:

![image](/assets/privatechain_3.png)

Als een wallet is aangemaakt en de bijbehorende public key is opgeslagen (bijvoorbeeld in een .txt-bestand), kopieer dan de public keys en bewaar deze. Kopieer hierna de vier wallets naar de vier virtual machine node mappen.

## 4. Wijzig de Node Configuratie

Open het node-configuratiebestand `protocol.json`.

Pas als eerste de `Magic`-waarde aan. Magic wordt gebruikt om het bronnetwerk van een bericht te identificeren; het aanpassen van de Magic zorgt ervoor dat de data niet in andere netwerken terecht komt.

> [!Note]
> De waarde van Magic moet tussen de 0 - 4294967295 liggen.

Verander de `StandbyValidators` en vul hier de vier public keys in die zijn gekopieerd in stap 3.

Pas uiteindelijk de `SeedList` aan en vul hierbij de IP-adressen in uit de eerste stap, bijvoorbeeld:

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```

`SystemFee` is de servicekosten op de blockchain, welke momenteel als volgt zijn:

Registratie voor boekhouders: 1000 GAS, Verstrekken van Assets: 500 GAS, Smart Contracts: 500 GAS, Assets Registreren: 10.000 GAS.

Hier kunnen de servicekosten voor de private chain worden ingevuld.

Hierna dient de aangepaste `protocol.json` naar de vier node client mappen te worden gekopieerd, waarbij de al bestaande `protocol.json` bestanden worden overschreven.

Vervolgens kunnen de volgende commands in de vier virtual machines worden uitgevoerd (bekijk de [CLI Commands](cli.md) bij twijfel).

Start node:

`Dotnet neo-cli.dll`

Open wallet:

`Open wallet walletX.db3` (waarbij X 1-4 is)

> [!Note]
> Elke node moet een verschillende wallet openen.

`Start consensus`

Als bovenstaande opdrachten succesvol zijn uitgevoerd, zullen de vier nodes een consensusproces beginnen zoals hieronder.

![image](/assets/privatechain_8.png)

Vier nodes kunnen zelfs wanneer een apparaat uitstaat nog consensus bereiken:

![image](/assets/privatechain_9.png)

## 5. NEO en GAS Bemachtigen

Installeer Neo-GUI en pas het configuratiebestand `protocol.json` aan om met de private chain te verbinden.

Open de wallet. Als de getallen linksonder niet 0 zijn en tot hetzelfde block zijn gesynchroniseerd, betekent dit dat de client succesvol is verbonden met de private chain.

Open wallet1.db3 in Neo-GUI, voeg het multi-party signature adres toe, voer de vier public keys in in `protocol.json` en zet het minimum aantal signatures naar 3 (aantal consensus nodes/2 + 1) zoals hieronder.

![image](/assets/privatechain_12.png)

Klik op `OK`. Om de wallet index opnieuw op te bouwen, klik je op `wallet` in de menubalk, waar te zien is dat het contract adres 100.000.000 NEO bevat.

![image](/assets/privatechain_14.png)

> [!Note]
> Alle vier de wallets moeten de multi-party signature adressen toevoegen en de wallet index opnieuw opbouwen.

Om NEO van het contract-adres te sturen naar een normaal adres, moet een van de vier wallets worden geopend. Klik op `transaction`, `transfer` en voer het ontvangende adres in om 100.000.000 NEO naar dat adres te sturen.

Het systeem zal je erop wijzen dat er niet genoeg signatures zijn om de transactie te voltooien. Kopieer de code naar je klembord, open de tweede wallet, klik op `transaction`, `signature` en plak de code die je net hebt gekopieerd. Klik op `signature` en kopieer de kode. Open de derde wallet en herhaal deze stap. Wanneer bij de derde wallet op `signature` wordt geklikt, zal de `broadcast`-knop linksonderin verschijnen, wat betekent dat er nu genoeg signatures zijn om de transactie goed te keuren. Klik op `broadcast`. Wanneer de transactie begint uit te zenden, duurt het grofweg 15 seconden voordat het resultaat geeft.

![image](/assets/privatechain_20.png)

Het proces om GAS te bemachtigen verloopt vergelijkbaar. Klik op `Advanced`, `Claim GAS`, `Claim` zoals hieronder. Onthoud het wallet-adres aangezien je deze later nodig zult hebben.

![image](/assets/privatechain_21.png)

De volgende handelingen lijken op die voor de transactie van NEO. Kopieer de code met onvoldoende signatures, open de tweede wallet, klik op `transaction`, `transfer` en plak de code. Klik op `signature` en kopieer de code. Open de derde wallet, klik op `transactie`, `transfer` en plak de code. Klik op `signature` en `broadcast` om de transactie uit te zenden en je GAS te claimen. Het duurt ongeveer 15 seconden voor het GAS in de wallet terug te zien is.

Na succesvolle bemachtiging van het GAS zal het naar het eerste adres van de wallet gaan (vanaf waar de bemachtiging van GAS is opgezet), zoals hieronder:

![image](/assets/privatechain_26.png)
