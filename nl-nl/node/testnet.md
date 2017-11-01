# Test-Netwerk

Het TestNet is een omgeving waarin de gebruiken programma's kan ontwikkelen, inzetten en testen. Het testen op het TestNet vereist netwerkkosten in de vorm van TestNet-GAS (niet echt GAS). TestNet NEO en GAS kunnen gratis worden aangevraagd op de [officiële website](https://www.neo.org/Testnet/Create).

Alle blockchain-data van het TestNet staat los van het hoofdnetwerk. Bij het ontwikkelen van een simpele smart contract of het registreren van een asset zou gebruik van het TestNet moeten volstaan. Nadat het testen is voltooid, kan het product naar het hoofdnetwerk worden verplaatst.

## TestNet Eigenschappen

1. Asset-registratie, asset-verstrekking, uitvoeren van contracten, et cetera (verbruikt geen echt geld/GAS).
2. Wereldwijde deployment op het internet.
3. Het testen van netwerkblocks; transacties en andere informatie kan eenvoudig worden bekeken in de blockchain-verkenner.
4. Smart contract-deployment in de testomgeving, waar iedereen het kan gebruiken (op het TestNet).
5. Het TestNet kan niet worden gebruik als commerciële toepassing van een daadwerkelijk platform.

## Client Downloads

De TestNet-client is gelijk aan de hoofdnetwerk-client. Door aanpassingen in de configuratie van de client, kan worden gewisseld tussen het hoofdnetwerk en het TestNet.

Zie ook: [Introduction of NEO node](introduction.md).

|          | Neo-GUI                                  | Neo-CLI                        |
| -------- | :--------------------------------------- | :--------------------------------------- |
| Versies  | [Officiële website](https://www.neo.org/download) of [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Broncode | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Wisselen naar het TestNet

1. Kopieer de inhoud van het bestand `protocol.testnet.json` naar `protocol.json` zoals hieronder. Deze zijn te vinden in de map waarin de client is geïnstalleerd. 

![image](/assets/testnet_1.png)

2. Kopieer de inhoud van het Neo-GUI-bestand `neo-gui.exe.testnet.config` naar `neo-gui.exe.config` zoals hieronder. 

![image](/assets/testnet_2.png)

> [!Note]
> Als de node draait op Neo-CLI, dient de inhoud van `config.testnet.json` naar `config.json` te worden gekopieerd.
