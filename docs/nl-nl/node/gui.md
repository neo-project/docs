# Gebruik van de Neo-GUI-Client

## Overzicht

### Introductie

De Neo-GUI client is compatible met de volgende versies van Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.

De client zelf heeft geen installatie nodig. Download de zip, pak deze uit en dubbelklik op neo-gui.exe om de client te openen. Wanneer hierbij problemen zijn en de client niet normaal kan worden gebruikt, bewaar dan het error.log bestand, welke zich in dezelfde map bevindt als neo-gui, en stuur deze naar ons technisch personeel voor hulp.

> [!Note]
> Bij de voorloperversie van Windows 10 dient [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework) te worden geïnstalleerd.

### Synchroniseren

De client moet volledig gesynchroniseerd zijn voordat deze gebruikt kan worden. Linksonderin is te zien hoeveel blocks zijn gesynchroniseerd en hoeveel blocks er in totaal in het netwerk zijn (zie het voorbeeld hieronder). Deze nummers zullen regelmatig oplopen.

![image](/assets/gui_1.png)

### Verklarende Woordenlijst

#### Wallet

Een wallet-bestand bewaart een verwijzing naar de NEO, het GAS en de account-informatie in een database met een .db3-extensie. Dit bestand is zeer belangrijk; een goede backup wordt aanbevolen.

> [!Important]
>
> Het verliezen van het wallet-bestand of -wachtwoord zal resulteren in verlies van de bijbehorende assets. Sla het wallet-bestand veilig op en onthoud het wachtwoord!

#### Account

Dit wordt gebruikt om de assets in een NEO-block bij te houden.

De account-informatie bevat: adress, private key, public key, type.

(1) Address: vergelijkbaar met het nummer van een bankrekening of credit card. Dit wordt gebruikt om assets te ontvangen tijdens transacties.

(2) Type: *Neo.Wallets.SignatureContract* geeft aan dat het adres bestaat uit een enkele public key en werkt als een '1-van-de-1' multi-signed adres. *Neo.Wallets.MultiSigContract* geeft aan dat het adres bestaat uit meerdere public keys en werkt als een 'm-van-de-n' multi-signature adres, welke gebruikt wordt bij smart contracts.

(3) Private key (*persoonlijke sleutel*): een 256-bit willekeurig getal, welke bewaard wordt door de gebruiker en niet openbaar bekend moet worden gemaakt. Dit vertegenwoordigt bezit van de account en de bijbehorende assets binnen de account.

(4) Public key (*openbare sleutel*): elke private key heeft een bijbehorende public key. De private en public keys kunnen worden gezien door met de rechter muisknop op het adres te klikken in de Neo-GUI.

> [!Important]
>
> De private key dient nooit bekend te worden gemaakt aan anderen. Wanneer dit wel wordt gedaan, kan dit resulteren in verlies van assets.

#### Assets

De assets van de account en de asset-informatie, waaronder: de naam (NEO, GAS of een asset gecreëerd door de gebruiker), het type, het saldo en de verstrekker.

#### Transaction Record

Registratie van alle transactie-informatie die met de account wordt geassocieerd.

#### Transfer

Het sturen van assets naar een ontvangend adres. Als het asset-type NEO is, dienen beide partijen de transactie te verifiëren met hun handtekening (*signature*). Assets van andere types kunnen worden uitgevoerd zonder dat verificatie van beide partijen nodig is.

#### Trade

Het uitwisselen van online assets tussen twee partijen, waarbij beide partijen de uitwisseling moeten verifiëren voordat deze kan plaatsvinden.

#### Signature

Het ondertekenen van informatie. Dit geeft aan dat de informatie wordt geverifiëerd door de gebruiker.
Voor transacties waarbij billijkheid (*equity allocation*) en het overdragen van assets een rol spelen, is de signature vereist als bewijs dat de partijen bewust akkoord zijn met de transactie.

#### Registered Assets

Het creëren van een nieuwe, door een gebruiker aangevraagde asset binnen het NEO-block. De gebruiker kan het type, de naam en andere eigenschappen van de asset definiëren, en aangeven welke account de administrator van de asset is. De aanmaak van assets vereist betaling van een bepaalde hoeveelheid GAS als aanvullende servicekosten; de huidige prijs is 10.000 GAS (op het testnetwerk is dit honderd maal zo weinig als op het hoofdnetwerk).

#### Distribute Assets

De aangemaakte asset wordt gedistribueerd naar een adres, aangegeven door de verstrekker. Dit aantal moet binnen de bovenste grens van de totale hoeveelheid van de asset zijn, welke is aangegeven door de maker van de asset. Het distribueren van assets vereist een betaling van aanvullende servicekosten; de huidige prijs is 500 GAS (ook hierbij is dit op het testnetwerk honderd maal minder). 

#### Election

Wanneer iemand een NEO-validator wil zijn, moet deze worden aangesteld door middel van een verkiezing. Door een bepaalde hoeveelheid NEO te storten, kunnen aan de validator-eisen worden voldaan. Deze functie is nog niet geïmplementeerd; wacht hiervoor op verdere updates.

#### Vote

Bezitters van NEO kunnen stemmen op een validator-kandidaat naar keuze. Op deze manier wordt bepaald of een validator geaccepteerd wordt. Deze functie is nog niet geïmplementeerd; wacht hiervoor op verdere updates.

#### Broadcast

Na het tekenen van een transactie, wordt deze verzonden naar het gehele netwerk (*'to broadcast'* = uitzenden), waarbij bevestiging nodig is van een node voordat de transactie wordt voltooid. Op dit moment is deze functie alleen aanwezig in de signature.

#### Monitor Address

Het is mogelijk een adres van een andere partij te importeren, om assets van dat adres te zien.

## Wallet
### New Wallet Database

(1) Klik op de  `wallet`, `New Wallet Database`. De `new wallet` pop-up zal verschijnen.

![image](/assets/gui_2.png)

(2) Klik op `browse` om de opslaglocatie van het wallet-bestand te selecteren, geef het bestand een naam en klik op `Save`.

![image](/es-es/node/assets/gui/gui_3.png)

(3) Vul het wachtwoord in onder `password` en `repeat password` en bewaar deze zorgvuldig.

![image](/assets/gui_4.png)

(4) Klik op `OK` om de wallet aan te maken. Deze bevat een standaard account. 

> [!Note]
> Wanneer er 'wisselgeld' wordt gegeven, zullen de overgebleven assets standaard worden overgezet naar het eerste adres. Om deze reden wordt het aanbevolen om de bijbehorende private key en wallet te bewaren.

### Open Wallet Database

(1) Elke keer dat de client wordt geopend, dient te worden geklikt op `Open Wallet Database` om te selecteren welke wallet geopend moet worden (zie afbeelding hieronder).

![image](/assets/gui_5.png)

(2) Klik op `browse` om de wallet te selecteren (standaard is de laatst geopende wallet geselecteerd), voer het wachtwoord in en klik op `OK` om de wallet te openen.

> [!Note]
> Wanneer de wallet een foutmelding geeft, kan dit mogelijk worden opgelost door de wallet te openen met behulp van de 'repair mode'.

### Change Password

Dit kan worden gebruikt om het wachtwoord van de wallet te wijzigen.

![image](/assets/gui_6.png)

Nadat het wachtwoord is veranderd, is het van belang een nieuwe backup te maken van de wallet, aangezien oudere versies niet het nieuwe wachtwoord zullen bevatten.

### Rebuild the Wallet Index

Deze functie bestaat om de client te herstellen wanneer een fout ontstaat. Het kan nodig zijn de Wallet Index opnieuw op te bouwen in de volgende situaties:

1. Na het importeren van een private key.

2. Bij een transactie die na lange tijd nog niet bevestigd is.

3. Wanneer de wallet assets of de  blockchain data niet kloppen.

Als de block-hoogte hoog is, kan het opnieuw bouwen van de Wallet Index verscheidene minuten duren. Wees a.u.b. geduldig.

### Restore the Account

Deze functie bestaat om het adres van een wallet-bestand te herstellen wanneer deze per ongelijk is verwijderd. 

> [!Opmerking]
> Het wordt afgeraden om een handeling vanuit de client te verwijderen, om verlies van assets te voorkomen.

## Trade

### Transfer

#### Token Asset Transfer

(1) Klik op `Transaction`, `Transfer`, `+` en voer de transactie-informatie in.

![image](/assets/gui_10.png)

(2) Klik op `OK`.

![image](/assets/gui_11.png)

(3) Klik op `OK`.

![image](/zh-cn/node/assets/i.png)

#### Equity Asset Transfer

(1) Klik op `Transaction`, `Transfer`, `+` en voer de transactie-informatie in.

![image](/zh-cn/node/assets/j.png)

(2) Klik op `OK`.

![image](/zh-cn/node/assets/k.png)

(3) Klik op `OK` zoals in de afbeelding hieronder, waar een signature nodig is.

![image](/zh-cn/node/assets/l.png)

(4) Zie voor de signature-functie [signature](#sign).

#### Batch Transfer

Deze functie wordt gebruik om transacties van een bepaalde asset naar verschillende adressen makkelijker te maken.

![image](/assets/gui_14.png)

Het data-format is `adres transfer hoeveelheid` (gescheiden door spaties). 

![image](/assets/gui_15.png)

> [!Note]
> Het data-format zoals dat hierboven is aangegeven dient strikt te worden gevolgd, aangezien extra spaties meestal leiden tot het mislukken van de transactie.

#### Remarks

Deze functie wordt gebruikt om een omschrijving van transacties op de blockchain op te slaan. De [NEO blockchain verkenner](https://www.antchain.xyz) kan worden gebruikt om transactie-informatie op te zoeken.

![image](/zh-cn/node/assets/o.png)

Op het moment zijn er nog geen eisen voor de format van het bericht.

![image](/zh-cn/node/assets/p.png)

De omschrijving van de transactie kan op de hierboven genoemde verkenner worden gelezen.

![image](/zh-cn/node/assets/oo.png)

### Trade

#### Een Uitwisseling Opzetten

(1) Deze transactie vereist dat beide partijen een transactie-aanvraag opzetten om de details van de asset die wordt gezonden te bepalen, evenals de ontvanger.

![image](/assets/gui_18.png)

(2) Klik op `initiate` om de transactie-aanvraag te genereren. Deze kan worden gebruikt om de voorwaarden van de transactie te ontvangen.

![image](/assets/gui_19.png)

#### Combineren van de Uitwisseling

(1) Na het afronden van de transactie-aanvraag, zal een pop-up verschijnen voor het samenvgoegen van de transacties.

![image](/assets/gui_20.png)

(2) Dit zorgt ervoor dat de transactie van de andere partij wordt getoond. Om de geldigheid van de aanvraag van de andere partij na te gaan, klik op `validate`. In het daarop volgende venster kan de aanvraag van de andere partij worden geaccepteerd met `accept` en geweigerd met `refuse`.

![image](/assets/gui_24.png)

(3) Als beide partijen akkoord zijn en op `accept` hebben geklikt, dienen beide partijen te tekenen en te broadcasten. Zie voor de details hiervan de signature-sectie hieronder.

<a id="sign"> </a>
### Signature
(1) Dit zorgt ervoor dat de transactie van de andere partij wordt gekopiëerd naar de input-box. Klik op `sign` om de output-data te genereren. Hierbij zal de `broadcast`-knop verschijnen.

![image](/zh-cn/node/assets/u.png)

(2) Klik op `broadcast` om de transactie te zenden. Deze transactie is nu compleet. Een transactie ID (TXID) zal worden getoond wanneer de transactie succesvol is.

![image](/assets/gui_30.png)

<a  id="offline"></a>

## Advanced

### Blockchain Data Downloaden

Om de netwerksynchronisatie te versnellen, kan een kopie van de blockchain tot een bepaalde block-hoogte worden gedownload. Dit zorgt ervoor dat de client alleen de blocks die daarna zijn toegevoegd hoeft te downloaden, in plaats van de hele blockchain.

**Downloaden**

Download het bestand van [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip").

**Openen**

Sluit de Neo-GUI-client en open chain.acc.zip. Pak het chain.acc bestand uit in de Neo-GUI map zoals in de afbeelding hieronder.

![](/assets/gui_58.png)

**Synchroniseren**

Open hierna de Neo-GUI-client. Deze zal tot een bepaalde block-hoogte gesynchroniseerd zijn en verder gaan vanaf dit punt. 

![](/assets/gui_59.png)

**Voltooien**

Wanneer de blockchain tot een bepaalde block-hoogte is gesynchroniseerd, zal het bestand (chain.acc) worden verwijderd, waarna synchronisatie zal doorgaan vanuit het NEO-netwerk.

![](/assets/gui_60.png)

### Aanmaak van GAS

GAS wordt aangemaakt met elk nieuw blok en wordt verdeeld over de adressen van NEO-bezitters. Het getal binnen de blokhaken dat te zien is in het tabblad `Asset` is de hoeveelheid GAS die kan worden geclaimd. De NEO-bezitter kan op elk gewenst moment ervoor kiezen om deze GAS-claim te vervullen en het GAS te sturen naar het corresponderende NEO-adres. Op het moment heeft alleen de PC-versie van de client de mogelijkheid om GAS te claimen.

De specifieke stappen zijn als volgt:

(1) Transfer alle NEO in de wallet door middel van een transactie-uitvoering naar het huidige adres. Wanneer de claim voltooid is, kan het GAS worden opgenomen. Zie voor een meer technische uitleg van dit proces de White Paper.

(2) Klik op `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Request Certificate

> [!Note]
> Deze functie kan alleen een certificaat-aanvraag aanmaken; de gebruiker dient alsnog een verzoek in te dienen bij de relevante authoriteit om het certificaat daadwerkelijk te bemachtigen.

Klik op `Advanced`, `Request Certificate` en vul de gevraagde informatie in.

![image](/assets/gui_39.png)

het gegenereerde bestand zal er als volgt uitzien:

![image](/zh-cn/node/assets/y.png)

### Asset Registration

Er zijn twee types assets: Tokens en Shares. We gebruiken hier Tokens als voorbeeld. Voer de gevraagde informatie in:

![image](/assets/gui_43.png)

> [!Note]
> Het registreren van een asset vereist het betalen van een significante hoeveelheid GAS of NEO (op het hoofdnetwerk 10.000 GAS, op het testnetwerk 100 NEO). Dit kan niet ongedaan worden gemaakt.

### Asset Distribution

![image](/assets/gui_46.png)

> [!Note]
> Het verstrekken van een asset vereist het betalen van een significante hoeveelheid GAS of NEO (op het hoofdnetwerk 500 NEO, op het testnetwerk 5 NEO). Dit kan niet ongedaan worden gemaakt. Het wordt aangeraden de verstrekking in één keer te doen.

### Deploy Contract

Wordt later toegevoegd.

### Invoke Contract

Wordt later toegevoegd.

### Election

Met deze functie kan men zich opgeven als NEO Blockchain Validator-kandidaat.

![image](/assets/gui_57.png)

> [!Note]
> Het deelnemen aan de verkiezing vereist het betalen van een significante hoeveelheid GAS of NEO (op het hoofdnetwerk 1.000 GAS, op het testnetwerk 10 GAS). Dit kan niet ongedaan worden gemaakt. Deze functie is nog niet beschikbaar.

It should be noted that the election incurs a significant fee. (The main network fee is 1000 GAS, test network fee is 10 GAS) Please exercise caution. The validator function is not available yet, please wait for further updates.

### 4.8 Option

*Wordt later toegevoegd.*

## Help

### View Help

*Wordt later toegevoegd.*

### Official Website

De officiële NEO-website is https://neo.org/.

### Developers tools

*Wordt later toegevoegd.*

### About NEO

Het versie-nummer van de NEO-client.
