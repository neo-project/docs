# CLI Commands

Open de command interface, navigeer naar de map waar het programma zich bevindt en voer de volgende command in om de command line wallet te starten:

`dotnet neo-cli.dll`

Deze handleiding zal alle commands in de command line wallet uitleggen. De wallet kan worden aangepast met commands zoals het creëren van een wallet, het starten van een transactie, et cetera.

Eerst lichten we de verschillende commands toe die tevoorschijn komen met de command `help` gevolgd door een return command.

![image](/assets/cli_2.png)

Hieronder volgt een beschrijving van alle commands en de betekenis van de haakjes:
- Gehoekte haakjes `<>` geven een parameter aan.
- Blokhaken `[]` geven een optionele parameter aan.
- Een verticale lijn `|` geeft fill parameters aan, welke van elk mogelijk type kunnen zijn.
- Het is-teken `=` geeft de standaardwaarde van een optionele parameter aan wanneer geen input gegeven wordt.

## 1. Console-Instructies

| Command      | Functieomschrijving                   |
| :----------- | :------------------------------------ |
| version      | Geef de huidige software-versie weer  |
| help         | Helpmenu                              |
| clear        | Leeg het scherm                       |
| exit         | Sluit het programma                   |

## 2. Wallet Functies

| Command                                      | Functieomschrijving | Opmerkingen |
| :------------------------------------------- | :-------------------------------- | :------ |
| create wallet \<path>                        | Creëer een wallet-bestand |
| open wallet \<path>                          | Open een wallet-bestand |
| rebuild wallet index                         | Bouw de wallet index opnieuw op | Wallet moet open zijn |
| list all the accounts in the wallet          | Toon alle accounts in een wallet | Wallet moet open zijn |
| list asset                                   | Toon alle assets in een wallet | Wallet moet open zijn |
| list key                                     | Toon alle public keys in een wallet | Wallet moet open zijn |
| create address [n = 1]                       | Creëer een adres of een batch adressen | Wallet moet open zijn |
| import key \<wif\|path>                      | Importeer een of meerdere private keys | Wallet moet open zijn |
| export key \[address] [path] 				   | Exporteer de private key | Wallet moet open zijn |
| send \<id\|alias> \<address> \<value> [fee=0]| Stuur naar het genoemde adres | Wallet moet open zijn |

Hieronder worden verschillende commands nader toegelicht.

👉 `rebuild index`

Deze command wordt gebruikt om de wallet index opnieuw op te bouwen.
Waarom is het nodig om dit te doen?

Er is een veld in de wallet waar de huidige hoogte van de blockchain waarmee de wallet is gesynchroniseerd wordt bijgehouden. Bij elk nieuw block synchroniseert de wallet client de blocks en update het de assets en transacties binnen de wallet. Stel dat de huidige opgenomen blockhoogte 100 is en je de `import key`-command uitvoert om de private key te importeren; de wallet zal dan alsnog de asset berekenen vanaf blockhoogte 100. Als het geïmporteerde adres transacties had toen de blockhoogte nog onder de 100 was, dan zullen de transacties (en bijbehorende assets) niet terug te zien zijn in de wallet als de index niet opnieuw wordt opgebouwd. Bij het uitvoeren van `rebuild index` wordt de wallet geforceerd om de assets te berekenen vanaf blockhoogte 0.

De nieuwe wallet hoeft niet de wallet index opnieuw op te bouwen; alleen de private key is nodig.


👉 `create address [n = 1]`

Deze command kan gebruikt worden om een nieuw adres te maken. Het is ook mogelijk om bijvoorbeeld `create address 100` in te voeren om 100 nieuwe adressen aan te maken. De aanmaak van adressen per batch zal automatisch worden geëxporteerd naar het address.txt bestand.

👉 `export key [address] [path]`

Het is mogelijk om te specificeren naar welke adressen de private keys moeten worden geëxporteerd. Het is ook mogelijk om de export naar een bestand uit te voeren (zie hieronder voor voorbeelden). Deze command vereist ook invoer van het wallet-wachtwoord.

`Export key`

`Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b`

`Export key key.txt`

`Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt`

👉 `import key <wif | path>`

Bij het importeren van de private key is het mogelijk om aan te geven welke private key of welk bestand met meerdere private keys moet worden geïmporteerd. Zie hieronder voor voorbeelden.

`Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH`

`Import key key.txt`

Als er een bestand is aangeduid, dient het bestand in de private key format te zijn geschreven. Zie de `export key key.txt` output voor dit format.

👉 `send <id | alias> <address> <value> [fee = 0]`

Voor transacties zijn er in totaal vier parameters: Asset ID, ontvangend adres, de hoeveelheid en de betaalde kosten (standaard 0, kan leeg worden gelaten). De command heeft het wachtwoord van de wallet nodig. Om bijvoorbeeld 100 NEO over te maken naar het adres "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", zou de volgende command moeten worden uitgevoerd:

`Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100`

Wanneer je niet zeker bent van de asset ID, gebruik dan de `list asset`-command om alle assets in de wallet te bekijken.

## 3. Node Functies

| Command    | Functieomschrijving |
| :--------- | :----------------------            
| show state | Toon de huidige status van blockchainsynchronisatie 
| show node  | Toon het adres en de port van verbonden nodes 
| show pool  | Toon de transacties die momenteel worden verwerkt (in de memory pool)

## 4. Geavanceerde Functies

| Command | Functieomschrijving |
| --------------- | ---- |
| Start consensus | Begin het consensus-proces

Wanneer de wallet de mogelijkheid heeft tot het starten van een consensus, kan worden getracht consensus te bereiken op het netwerk door middel van stemmen. Bij een private chain kan de public key van de consensus worden opgesteld in `protocol.json`; zie [Private Chain](private-chain.md) voor meer informatie.
