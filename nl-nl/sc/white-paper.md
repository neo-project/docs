# NeoContract White Paper

## 1. Voorwoord

Smart contracts verwijzen naar elk computerprogramma die de voorwaarden van het voorgeprogrammeerde contract automatisch kunnen uitvoeren. Het idee van een smart contract werd in 1994 voor het eerst voorgesteld, wat bijna net zo oud is als het internet zelf, door de cryptograaf Nick Szabo. Door het gebrek aan een betrouwbare uitvoeringsomgeving konden smart contracts niet grootschalig toegepast worden.

In 2008 introduceerde een man onder de naam Satoshi Nakamoto het concept Bitcoin en legde de basisconcepten van een blockchain uit. Binnen de Bitcoin blockchain gebruikt Nakamoto een aantal script talen om gebruikers te helpen meer flexibiliteit te krijgen bij het beheren van hun persoonlijke accounts en bij hun overdrachtsproces. Dit bloeide uiteindelijk op tot een ‘chain-based’ smart contract systeem.

Vervolgens publiceerde een tiener in 2013 genaamd Vitalik Buterin Ethereum. Ethereum is een chain-based, turing complete smart contract systeem. Dit systeem kan gebruikt worden om verschillende gedecentraliseerde blockchain applicaties op te ontwikkelen.

Het NEO blockchain is een digitaal activa- en applicatieplatform dat een nieuw smart contract systeem aanbiedt, genaamd NeoContract. Het platform biedt het netwerk veelzijdige functies aan zoals digitale activa (NeoAsset) en een digitale identiteit (NeoID). Hiermee kunnen gebruikers gemakkelijk digitaal handelen en zijn ze niet meer beperkt tot alleen de uitgifte van de originele tokens op de blockchain.

Dit artikel zal kenmerken van het NeoContract introduceren en niet-technische details verkennen. Voor mee informatie over de technische documentatie zie: docs.neo.org.

## 2. Kenmerken

### 2.1 Zekerheid

Als een programma op verschillende computers of op verschillende tijdstippen op dezelfde computer draait, is het gedrag van het programma deterministisch als dezelfde invoer gegarandeerd dezelfde uitvoer produceert (en visa versa).

Blockchain is een veelvoudig opslag- en berekeningsmethode waarbij de gegevens binnen dit gedistribueerde systeem het resultaat zijn van betrouwbare berekeningen waar niet geknoeid mee kan worden. Smart contracts werken binnen het multi-node gedistribueerde blockchain netwerk. Als een smart contract niet deterministisch is, kunnen de resultaten van verschillende knooppunten inconsistent zijn. Als gevolg hiervan kan er geen consensus tussen de knooppunten worden bereikt en staat het netwerk stil. Daarom moet bij het ontwerpen van een smart contract systeem een regeling plaatsvinden die factoren in betrekking neemt die kunnen leiden tot niet-deterministisch gedrag.

#### 2.1.1 Tijd

Het verkrijgen van systeemtijd is een zeer voorkomende systeemfunctie die in bepaalde tijdgevoelige contractprocedures hevig kan worden toegepast. Het verkrijgen van systeemtijd is echter een niet-deterministische systeemfunctie en het is moeilijk om een uniforme, precieze tijd in een gedistribueerd systeem te verkrijgen. Dit komt omdat de resultaten van verschillende knooppunten inconsistent kunnen zijn. NeoContract biedt een chain gebaseerde systeemoproep aan die de hele blockchain server als een tijdstempel behandelt. Deze stempel wordt verkregen wanneer een nieuwe blok wordt gegenereerd. Gemiddeld genereert het NEO netwerk elke 15 seconden een nieuw blok, zodat het contract ongeveer op hetzelfde tijdstip loopt als de laatste bloktijd (± 15 seconden).

#### 2.1.2 Willekeurigheid

Veel smart contractprogramma's, zoals bijvoorbeeld gokcontracten, gebruiken willekeurige nummerfuncties. Echter, willekeurige nummerfuncties zijn typische niet-deterministische functies en elke systeemoproep zal verschillende resultaten opleveren. In een gedistribueerd systeem zijn er vele manieren om dit probleem op te lossen. Eerst kan dezelfde willekeurige ‘seed’ voor alle knooppunten gebruikt worden, zodat de terugkeersequentie van de volledige willekeurige functie deterministisch is. Deze methode stelt het hele willekeurig resultaat vooraf bloot, waardoor de praktische waarde van het willekeurig getal sterk wordt verminderd. Een andere mogelijke oplossing is om alle knooppunten op een samenwerkende manier te laten communiceren om willekeurige getallen te genereren. Dit kan worden bereikt door gebruik te maken van cryptografische technieken om een ​​eerlijk willekeurig aantal te produceren, maar het nadeel hiervan ligt in de zeer slechte prestatie en de behoefte aan extra communicatie. Daarnaast kan een gecentraliseerde willekeurige nummeraanbieder worden gebruikt om willekeurige getallen te genereren die consistentie en prestatie garanderen. Het nadeel van deze aanpak is echter dat gebruikers de gecentraliseerde nummeraanbieder onvoorwaardelijk moeten vertrouwen.

Neo biedt hierbij twee deterministische gegevensbronnen aan:

Als een programma data verkrijgt tijdens de looptijd en de gegevensbron niet-deterministische data levert, kan het programma een niet-deterministisch programma worden. Bijvoorbeeld, door middel van de zoekmachine om een zoekwoord te verkrijgen van de top 10 zoekresultaten. Zoekmachines voor verschillende IP-adresbronnen kunnen namelijk verschillende soortgelijke resultaten brengen.

1) Blockchain boek
De contractprocedure heeft toegang tot alle gegevens over de gehele keten via de interactieve diensten, inclusief volledige blokken en transacties in ieder veld. De gegevens op de blokken zijn deterministisch en consistent, zodat ze veilig door middel van smart contracts toegankelijk gemaakt kunnen worden.

2) Contract storage space
Elk applicatiecontract dat op NEO wordt ingezet heeft een opslagruimte die alleen door het contract zelf toegankelijk is. Het consensusmechanisme van de kleine NEO's zorgt ervoor dat de opslagstatus op elk knooppunt consistent blijft. Om toegang te krijgen tot de gegevens buiten de keten hebben de kleine NEO's geen directe weg. Echter, door middel van de transacties die naar de keten worden gestuurd kunnen de twee soorten gegevensbronnen die bovenaan zijn vermeld omgezet worden, door middel van intelligente contracten.

2Het contractprogramma kan de hashwaarde van het blok gebruiken als een willekeurige getallengenerator, omdat de blok hash-waarde over bepaald willekeurigheid beschikt. De laatste methode kan gebruikt worden om een zwak willekeurig getal te verkrijgen

#### 2.1.3 Data Bron

Als een programma gegevens verkrijgt tijdens de looptijd kan het een niet-deterministisch programma worden als de gegevensbron niet-deterministische gegevens levert. Bijvoorbeeld door verschillende zoekmachines te gebruiken om de top 10 zoekresultaten voor een bepaald zoekwoord te verkrijgen. Hierdoor kunnen verschillende resultaten verkregen worden als er verschillende IP-adressen worden gebruikt.

Voor smart contracts biedt NEO twee soorten deterministische gegevensbronnen aan: 

**(1) Blockchain Ledger**

De contractprocedure heeft toegang tot alle gegevens over de gehele chain via de interoperabele diensten, inclusief volledige blokken en transacties. Deze gegevens zijn deterministisch en consistent zodat ze veilig door smart contracts geopend kunnen worden. 

**(2) Contract Storage Space**

Elk contract dat op het NEO netwerk wordt ingezet heeft een eigen opslagruimte die alleen door het contract zelf toegankelijk is. Het NEO consensus mechanisme zorgt vervolgens voor consistentie van de opslagstatus van elk knooppunt in het netwerk.

Voor situaties waar toegang tot data buiten de blockchain vereist is biedt NEO geen directe manier om met deze gegevens te communiceren. Deze data moeten als eerst via transacties overgebracht worden naar de NEO blockchain en vervolgens worden vertaald in de gegevensbronnen om door de smart contracts toegankelijk gemaakt te kunnen worden.

#### 2.1.4 Contractoproep

Smart contracts in NeoContract hebben de mogelijkheid om elkaar op te roepen. Dit is echter niet frequent. Desalniettemin kan frequente communicatie binnen het contract worden bereikt als de grenzen van het huidige contract niet overschreden worden. Bovendien moet de oproeprelatie tussen contracten statisch zijn. Dit houdt in dat de doelstelling niet kan worden gespecificeerd tijdens de looptijd. Dit stelt het gedrag van het programma volledig vast voor de uitvoering. De oproeprelatie is daarnaast ook volledig gedefinieerd voordat het kan worden uitgevoerd. Op grond hiervan kunnen meerdere contracten dynamisch worden gesplitst om een parallelle uitvoering te bereiken.

### 2.2 Hoge Prestaties

De uitvoeringsomgeving speelt een integrale rol in de uitvoering van een smart contract. Wanneer we de prestaties van ieder uitvoeringsomgeving analyseren zijn er twee indicatoren die met name belangrijk zijn: 1) de uitvoersnelheid van de instructie en 2) de startsnelheid van de uitvoeringsomgeving zelf. Voor smart contracts is de uitvoeringsomgeving vaak belangrijker dan de snelheid van de instructie uitvoering. Slimme contracten zijn meer betrokken bij de logica van de IO-operators. Hiermee kan bepaald worden waar de implementatie van de instructies gemakkelijk kan worden geoptimaliseerd. Elke keer dat het smart contract wordt gebeld moet het een nieuwe virtuele machine / container opstarten. Daarom heeft de uitvoeringssnelheid van de omgeving zelf (het starten van een virtuele machine / container) een grotere invloed op de prestaties van het smart contractsysteem.

NEO maakt gebruik van een lichtgewicht NeoVM (NEO Virtual Machine) als smart uitvoering van de contractomgeving. Deze start snel op, neemt weinig middelen op en is hiermee ideaal voor kleine programma's zoals smart contracten. Met behulp van de compilatie en caching van hotspot smart contracts met JIT (real-time compiler) kan de efficiëntie van virtuele machines aanzienlijk worden verbeterd.

### 2.3 Schaalbaarheid

#### 2.3.1 Hoge samenloop en dynamische verdeling

Bij het bespreken van de schaalbaarheid van een systeem gaat het met name om twee onderdelen: de verticale schaal en de horizontale schaal. De verticale schaal heeft betrekking op de optimalisatie van het werkstroomproces. Deze kan invloed hebben op het optimaal gebruik van de bestaande apparatuurcapaciteit. Hiermee kunnen de grenzen van het systeem gemakkelijk worden bereikt, omdat de serie-gebaseerde verwerkingscapaciteit is gebaseerd op de hardwaregrens van één apparaat. De vraag is nu of er een manier is om het systeem om te zetten in een parallel systeem wanneer we het systeem moeten gaan schalen. Dit is uiteraard mogelijk. Theoretisch zullen we alleen het aantal apparaten moeten verhogen, waardoor we bijna onbeperkt schaalbaarheid kunnen bereiken. Vervolgens is de vraag of we mogelijk onbeperkt schaalbaarheid in een verdeeld blockchain-netwerk kunnen bereiken. Met andere woorden, kan de blockchain parallelle programma's uitvoeren?

De blockchain is een gedistribueerd grootboek die verschillende gegevens registreert samen met de regels voor de veranderingen van deze gegevens. Smart contracts worden gebruikt als vervoerders om deze regels vast te leggen. Blockchains kunnen parallelle programma's verwerken alleen als meerdere smart contracts gelijktijdig en op een niet-opeenvolgende manier kunnen worden uitgevoerd. In principe is dit als (1) contracten niet met elkaar communiceren, (2) als het contract niet dezelfde gegevens wijzigt, (3) als de uitvoering niet achter elkaar loopt en (4) als de contracten tegelijkertijd kunnen lopen. Anders kunnen deze alleen in series uitgevoerd worden en kan het netwerk niet horizontaal schalen.

Op basis van de bovenstaande analyse kunnen we eenvoudig een “onbeperkt uitbreiding” ontwerpen voor het smart contract systeem. Het enige wat we moeten doen is eenvoudige regels opzetten:

(1) Een smart contract kan alleen het status wijzigen van het contract waaraan het behoort;

(2) In dezelfde transactieblok kan een contract slechts één keer worden uitgevoerd;

Als gevolg hiervan kunnen alle smart contracts parallel worden uitgevoerd, aangezien opeenvolgende volgordes irrelevant zijn voor het resultaat. Echter, als voor een smart contract alleen het status van het contract waaraan het behoort gewijzigd kan worden, betekent dit dat de contracten elkaar niet kunnen oproepen. Elk contract is een geïsoleerd eiland, waarbij dezelfde transactieblok slechts één keer uitgevoerd kan worden. Dit betekent dat een digitaal activa dat verwerkt is door een smart contract slechts één transactie per blok kan verwerken. Dit is een wereld van verschil met de oorspronkelijke ontwerpdoelstellingen van "smart" contracts, waarbij ze eigenlijk ophouden om smart te zijn. Onze ontwerpdoelstellingen omvatten immers dat in hetzelfde blok meerdere en wederzijdse oproepen tussen contracten mogelijk is.

Gelukkig hebben smart contracts in NEO een statische oproeprelatie, en kan tijdens de doorlooptijd de oproep doelstelling niet gespecificeerd worden. Dit stelt het gedrag van het programma volledig voor de uitvoering vast en zorgt ervoor dat de oproeprelatie volledig gedefinieerd is voordat het kan worden uitgevoerd. Wij vereisen dat elk contract expliciet duidt op de contracten die waarschijnlijk zullen worden opgeroepen, zodat de werkomgeving de volledige oproep boom kan berekenen voordat de contractprocedure wordt uitgevoerd. Dit maakt ook mogelijk voor een verdeling van de uitvoering van de contracten op basis van de oproep boom. Contracten die de status van het verslag kunnen aanpassen worden op een opeenvolgende manier uitgevoerd in dezelfde partitie, waardoor verschillende partities parallel uitgevoerd kunnen worden.

#### 2.3.2 Lage Koppeling

Een koppeling is een meetinstrument om de afhankelijkheid tussen twee of meer entiteiten te berekenen. Het NeoContract systeem maakt gebruik van een lage koppelingsontwerp dat wordt uitgevoerd in de NeoVM en communiceert met de gegevens die niet in de blockchain bevinden via de interoperabele servicelaag. Als gevolg hiervan kan het merendeel van de upgrades naar de smart contractfuncties worden behaald door de application programming interface (API) van interoperabele diensten te verhogen.

## 3. Contract Use

### 3.1 Contract Verificatie

In tegenstelling tot het publieke sleutelaccountsysteem dat in Bitcoin wordt gebruikt, gebruikt NEO's accountsysteem het contractaccountsysteem. Elk account in NEO komt overeen met een verificatiecontract en de hashwaarde van het verificatiecontract is het accountadres. De programma logica van het verificatiecontract controleert de eigendom van het account. Bij het overmaken van een account moet u eerst het verificatiecontract voor dat account uitvoeren. Een validatiecontract kan een set van parameters accepteren (meestal een digitale handtekening of andere criteria). Deze zal na de verificatie vervolgens een ‘booleanwaarde’ teruggeven, waarin het succes van de verificatie naar het systeem wordt aangegeven.

De gebruiker kan het verificatiecontract vooraf aan de blockchain implementeren of de contract inhoud rechtstreeks in de transactie publiceren tijdens het overdrachtsproces.

### 3.2 Contract Applicatie

The application contract is triggered by a special transaction, which can access and modify the global state of the system, and the private state of the contract (storage area) at run time. For example, you can create a global digital asset in a contract, vote, save data, and even dynamically create a new contract, when the contract is running.

De uitvoering van het aanvraagcontract vereist dat u op instructie kosten moet rekenen. Wanneer de transactiekosten op zijn zal het contract falen en de uitvoering stoppen. Alle status wijzigingen worden vervolgens teruggerold. Daarnaast heeft het succes van het contract geen invloed op de geldigheid van de transactie.

### 3.3 Contract Functie

Het functiecontract wordt gebruikt om bepaalde openbare of veelgebruikte functies te leveren die door andere contracten opgeroepen kunnen worden. De smart contractcode kan hergebruikt worden zodat ontwikkelaars in staat zijn om complexere bedrijfslogica te schrijven. Elk functioneel contract, wanneer geïmplementeerd, kan kiezen om een privé-opslagruimte te kiezen die of gelezen of bewerkt kan worden in een toekomstig contract. Hierdoor kan staatspersistentie worden bereikt. 

Het functiecontract moet vooraf worden ingezet op de keten om opgeroepen te worden en kan uit de ketting verwijderd worden door een "zelfvernietigende" systeemfunctie. Deze zal niet meer gebruikt kunnen worden en de privé-opslag wordt vervolgens ook vernietigd. De oude contractgegevens kunnen automatisch worden gemigreerd naar een ander subcontract voordat het vernietigd wordt, met behulp van contract migratie tools.

## 4. Virtule Machine

### 4.1 Virtule Hardware

NeoVM biedt een virtuele hardwarelaag aan om de uitvoering van smart contracts te ondersteunen, waaronder: 

**(1) CPU**

CPU is verantwoordelijk voor het lezen en opvolgen van de uitvoering van instructies in het contract door middel van de functie van de instructiestroomcontrole, rekenkundige operaties en de logica operaties. De toekomst van de CPU-functie kan worden verlengd met de introductie van de JIT-functie (real-time compiler), waardoor de uitvoering van de efficiëntie-instructie wordt verbeterd. 

**(2) Oproep Stapel**

De oproepstapel wordt gebruikt om de contextinformatie van de programma-uitvoering bij elk functiegesprek vast te houden, zodat het blijvend uitgevoerd kan worden in de huidige context nadat de functie is teruggevoerd en voltooid. 

**(3) Berekeningsstapel**

Alle NeoVM’s looptijd data worden opgeslagen in de berekeningsstapel. Dit gebeurt wanneer de stapel na de implementatie van verschillende instructies wordt berekend op de overeenkomstige data-elementen van de operatie. Bijvoorbeeld wanneer aanvullende instructies worden uitgevoerd, worden de twee operaties die deelnemen aan de toevoeging uit de berekeningsstapel uitgeworpen en wordt het resultaat van de toevoeging naar de bovenkant van de stapel geduwd. Functie oproep parameters moeten ook van rechts naar links worden berekend, wat overeen moet komen met de volgorde van de stapel. Nadat de functie succesvol is uitgevoerd kan de eerstvolgende op de stapel via de de ophaal functie de waarde teruggeven.

**(4) Reservestapel**

Als u elementen in de stapel wilt plannen of herschikken, kunt u de elementen tijdelijk opslaan in de reserve stack en ze in de toekomst ophalen.

### 4.2 Instructie set

NeoVM biedt een reeks eenvoudige en praktische instructies voor het opbouwen van smart contractprogramma's. Volgens de functies zijn de hoofdcategorieën als volgt:

(1) Constante instruction

(2) Procesregeling instructie

(3) Stapelbediening instructie

(4) String instructie

(5) Logic instruction

(6) Rekenkundige operatie instructie

(7) Cryptografische instructie

(8) Gegevensoperatie instructie

Het is belangrijk om aan te duiden dat de NeoVM instructieset een reeks cryptografische instructies biedt, zoals ECDSA, SHA en andere algoritmes om de efficiëntie van de implementatie van cryptografische algoritmen in slimme contracten te optimaliseren. Daarnaast ondersteunen de gegevensmanipulatie instructies rechtstreeks arrays en complexe data-structuren.

### 4.3 Interoperabele service laag

De virtuele machine waar smart contracts op uitgevoerd worden is vergelijkbaar met een ‘zandbakomgeving’. Deze heeft een interoperabele service laag nodig in tijden wanneer het toegang tot gegevens nog heeft buiten de zandbak om de looptijd data persistent te houden. Binnen de interoperabele dienstlaag kan het NEO contract een reeks systeemfuncties en diensten openen met het smart contractprogramma, en deze contracten kunnen vervolgens worden opgeroepen en toegankelijk gemaakt worden zoals gewone functies. Alle systeemfuncties worden gelijktijdig uitgevoerd, zodat men geen zorgen hoeft te maken over de schaalbaarheid.

### 4.4 Debugging Functie	

Vaak is de ontwikkeling van smart contracts erg moeilijk door het gebrek aan goede debugging en testmethoden. NeoV biedt ondersteuning voor programma-debugging op het virtuele machineniveau, waarbij men het breekpunt kan instellen op de contractcode of van de één-stap-uitvoering van een proces. Dankzij het lage koppelingsontwerp tussen de virtuele machine en de blockchain is het gemakkelijk om NeoVM direct te integreren met verschillende IDE’s om hiermee een testomgeving te leveren die consistent is met de uiteindelijke productieomgeving.

## 5. High-level talen

### 5.1 C#, VB.Net, F#

Ontwikkelaars kunnen NeoContract gebruiken voor bijna elke taal. De eerste groep ondersteunde talen zijn C #, VB.Net, F #, enz. Wij bieden compilers en invoegtoepassingen voor deze talen, waardoor deze talen op hoog niveau in de instructieset kan worden samengesteld en ondersteund kan worden door NeoVM. Aangezien de compiler zich concentreert op MSIL (Microsoft intermediate language) tijdens het compileren kan in theorie elk Net taal worden vertaald in een MSIL taal en vervolgens direct ondersteund worden.

Een groot aantal ontwikkelaars zijn vaardig in deze talen en de bovengenoemde talen hebben een zeer sterke geïntegreerde ontwikkelomgeving. Ontwikkelaars kunnen ontwikkelen, genereren, testen en debuggen, allemaal binnen Visual Studio, waar ze in staat zijn om optimaal gebruik te maken van de smart contractontwikkelingsjablonen die we aanbieden, om hiermee een voorsprong te krijgen.

### 5.2 Java, Kotlin

Java en Kotlin vormen de tweede groep ondersteunde talen, waar we compilers en IDE-plugins voor deze talen bieden. Hiermee kunnen we ontwikkelaars helpen de JVM-gebaseerde taal te gebruiken om de Smart Contract-toepassingen van NEO te ontwikkelen.

Java wordt veel gebruikt en Kotlin is onlangs de officiële Android-ontwikkeltaal van Google. Wij zijn van mening dat het ondersteunen van deze talen drastisch zal bijdragen tot het aantal NEO smartcontractontwikkelaars.

### 5.3 Overige talen

NeoContract zal ook ondersteuning bieden voor overige talen, afhankelijk van de moeilijkheidsgraad, in het ontwikkelproces van de compiler. Voorbeelden van de talen die ondersteund kunnen worden zijn:

(1) C, C++, GO

(2) Python, JavaScript

In de toekomst zullen we nog meer taalondersteuning bieden. Ons doel is om meer dan 90% van de NEO ontwikkelaars te ondersteunen met hun NeoContract ontwikkelen, zonder dat men een nieuwe taal hoeft te leren. Daarnaast is het zelfs mogelijk om de bestaande bedrijfssysteemcode direct over te brengen op de blockchain.

## 6. Service	

### 6.1 Blockchain Grootboek

NEO Smart Contracts kunnen volledige blokgegevens verkrijgen voor de NEO blockchain, inclusief volledige blokken en transacties. Deze gegevens kunnen ook verkregen worden voor elk veld tijdens de looptijd via de systeemfuncties die door de interoperabele service geleverd worden. Specifiek kunt u deze gegevens opvragen: 

(1) Hoogte van de blockchain；

(2) Blokkop, huidige blok;

(3) Transacties；

(4) Type transactie, attributen, invoer, uitvoer, etc;

Via deze gegevens kan men interessante toepassingen ontwikkelen, zoals automatische dividenden en smart contracts op basis van bewijs van werklast.

### 6.2 Digitale Activa

Door de interoperabele diensten die de digitale asset interface biedt, kunnen smart contracts niet alleen de NEO blockchain op eigenschappen en statistieken van diverse digitale activa vragen, maar ook nieuwe digitale activa creëren tijdens de looptijd. Digitale activa die gecreëerd zijn door smart contracts kunnen worden afgegeven, overgedragen en verhandeld worden buiten het contract. Ze zijn hetzelfde als oorspronkelijk activa op NEO en kunnen worden beheerd met elke NEO compatibele wallet-software. Deze specifieke interface bevat: 

(1) Activa attributen inquiry；

(2) Activa statistiek query；

(3) Activa life cycle management: creëren, wijzigen, verwijderen, etc；

(4) Asset management: multi-taal naam, totale verandering, precisie verandering, wijzigingen in de beheerder；

### 6.3 Persistentie

Elk smart contractprogramma dat wordt ingezet op de NEO blockchain heeft een eigen opslagruimte die alleen door het contract zelf gelezen en geschreven kan worden. Smart contracts hebben volledige operationele machtigingen op de gegevens in hun eigen opslag. Deze kunnen kunnen gelezen, geschreven, gewijzigd en/of verwijderd worden. De data wordt daarnaast opgeslagen in de vorm van sleutel/waarde paren en biedt de volgende interfaces aan: 

(1) Doorsnijden van de opgeslagen records;

(2) Terug naar een specifiek record volgens de opgegeven sleutel;

(3) Wijzigen of schrijven van nieuwe records volgens de opgegeven sleutel;

(4) Verwijderen van het record volgens de opgegeven sleutel;

Over het algemeen kan een contract alleen gegevens lezen en schrijven van hun eigen opslag, met één uitzondering: wanneer een contract wordt ingeroepen kan het aangevraagde contract toegang krijgen tot de opslag van de beller via een cross-domain-aanvraag, mits de beller toestemming geeft. Daarnaast, voor een subcontract dat dynamisch wordt gecreëerd op het moment van de contractuitvoering, krijgt het ouderlijk contract direct toegang tot zijn winkel.

Verzoeken op meerdere domeinen stellen NeoContract in staat om rijke bibliotheekfuncties te implementeren, die hoge schaalbare gegevensbeheermogelijkheden bieden voor de bellers.

## 7. Tarieven

### 7.1 Invoer tarief

NEO's gedistribueerde architectuur biedt een hoge redundantie van opslagcapaciteit en het gebruik hiervan is niet gratis. Het implementeren van een smart contract op het NEO netwerk vereist een vergoeding, wat momenteel is vastgesteld op 500 GAS die door het systeem wordt verzameld en geregistreerd als systeemwinst. Toekomstige kosten worden aangepast aan de werkelijke bedrijfskosten in het systeem. Het smart contract dat op de blockchain wordt ingezet kan meerdere keren worden gebruikt tot het contract door de gebruiker die het het contract ingevoerd wordt vernietigd.

### 7.2 Implementatie Tarief

NEO biedt een bruikbare uitvoeringsomgeving voor smart contracts. De uitvoering van de contracten vereist het verbruik van computergebruikers voor elk knooppunt. Daarom moeten gebruikers betalen voor de uitvoering van hun smart contracts. De vergoeding wordt bepaald door de berekeningsmiddelen die bij elke uitvoering worden verbruikt. De eenheidsprijs is hierbij ook in GAS. Als de implementatie van het mart contract mislukt door gebrek aan GAS, worden de kosten van verbruik niet geretourneerd. Dit voorkomt kwaadaardige aanvallen op het stroomverbruik van het netwerk.

De meest eenvoudige contracten kunnen gratis worden uitgevoerd zolang de uitvoeringskosten onder 10 GAS blijven. Hierdoor kunnen de kosten voor de gebruiker aanzienlijk worden verminderd.

## 8. Applicatie Scenario's

### 8.1 Supergeleidende Transacties

Digitale activa op het blockchain hebben een dergelijke vorm van liquiditeit nodig. Meestal kunnen punt tot punt transacties niet voldoende liquiditeit bieden, waardoor het nodig is om uitwisselingen te verlenen om gebruikers te voorzien van handelsdiensten. De uitwisseling van digitale activa kan in grote lijnen verdeeld worden in twee categorieën: 1) centrale uitwisselingen, waar de gebruiker de digitale activa moet storten bij de uitwisseling en daaropvolgende de openstaande orders moet plaatsen voor de handel op de website 2) decentrale uitwisselingen, waarbij het handelssysteem is ingebouwd in de blockchain en het systeem de bijbehorende diensten levert.

Centrale wisselkoersen kunnen zeer hoge prestaties en gediversifieerde diensten leveren. Echter hebben deze een hoog kredietgarantie nodig anders kan er moreel wangedrag voordoen, zoals het misbruik van gebruikersfondsen, fraude, enz. Bij gedecentraliseerde uitwisselingen, echter, kan er vrijwel geen moreel wangedrag zich voordoen. Alleen is bij deze uitwisselingen de gebruikerservaring slecht en er is een groot prestatieknelpunt. Is er een manier om beide oplossingen te combineren en het beste van beide werelden te bereiken?

Ja dat kan door middel van wat men supergeleidende transacties noemt. Gebruikers hoeven hierbij geen activa te deponeren, waarbij ze dus hun eigen activa op de blockchain kunnen gebruiken in de handel. Transactieafhandeling kunnen voltooid worden op de blockchain, maar het proces van bijbehorende orders treedt buiten de keten om door een centrale uitwisseling die bijbehorende diensten levert. Aangezien de koppeling buiten de keten wordt uitgevoerd is de efficiëntie ervan gelijk aan gecentraliseerde uitwisselingen, maar de activa blijven onder de controle van de gebruiker. Uitwisselingen maken daarnaast gebruik van het handelsdoel van de gebruiker om bijbehorende diensten te verrichten, zonder moreel wangedrag, zoals misbruik van gebruikersfondsen, fraude, enz.

Momenteel, binnen de NEO gemeenschap, is het ontwikkelen van smart contracts om de supergeleidende transacties van blockchain te bereiken aan het groeien.

### 8.2 Smart Fonds

Smart fondsen hebben op basis van de blockchain het voordeel om gedecentraliseerd, open en transparant te zijn, met een hogere mate van veiligheid en vrijheid in vergelijking met traditionele fondsen. Deze smart fondsen zijn ook grensoverschrijdend en open voor beleggers wereldwijd, waar uitstaande projecten kunnen worden gefinancierd met kapitaal van over de hele wereld.

Nest is een smart fonds-project, wat ontwikkeld is op NeoContract. Dit project heeft veel overeenkomst met het ThedaO-project van Ethereum. Nest onderzoekt op het moment verbeterde beveiligingsmaatregelen om de fouten van de TheDAO (hackers) te vermijden.

### 8.3 Interoperatibiliteit van de cross-chain

In de nabije toekomst zal er een groot aantal publieke ketens bestaan, samen met duizenden alliantieketens en particuliere ketens wereldwijd. Deze geïsoleerde blockchain systemen zijn eilanden van waarde en informatie die niet interoperabel met elkaar zijn. Via het cross-chain interoperabiliteitsmechanisme kunnen talloze geïsoleerde blockchains worden gekoppeld, zodat de waarden in verschillende blokketens met elkaar kunnen worden uitgewisseld om de echte waarde te bereiken van het internet.

NeoContract biedt ondersteuning voor de implementatie van cross-chain interoperabiliteit aan samen met het waarborgen van consistentie in cross-chain asset exchange, de cross-chain distributie transacties en uitvoering van smart contracts op verschillende blokketens aan.

### 8.4 Oracle Machines

De mythe van orakels in volksverhalen ligt in het vermogen dat deze entiteiten over bepaalde bovennatuurlijke krachten beschikken die bepaalde complexe reeks vragen kunnen beantwoorden. In de blockchain openen orakelmachines de deur naar de buitenwereld voor smart contracts, waardoor het mogelijk is om voor smart contracts in de echte wereld informatie te gebruiken als voorwaarden voor de contractuitvoering.

NeoContract biedt geen mogelijkheid om direct toegang te krijgen tot externe gegevens (zoals toegang tot bronnen op het internet) omdat dit niet deterministisch gedrag zal introduceren. Dit kan voor inconsistenties zorgen tussen nodes tijdens de executie van het contract. Het implementeren van de orakelmachine in NeoContract vereist dat externe gegevens door een vertrouwde derde worden verzonden naar de blockchain, waarbij de data feeds worden geïntegreerd als onderdeel van de blockchain grootboek. Hierdoor kan niet-determinisme waarden worden verwijderd.

De hierboven genoemde derde partijen kan een persoon of instelling zijn die door beide partijen in het contract wordt vertrouwd, of een gedecentraliseerde gegevensaanbieder die door economische prikkels wordt gegarandeerd. Op deze manier kan NeoContract gebruikt worden bij de implementatie van dergelijke Oracle-machines.

### 8.5 Ethereum DAPP

Bitcoin creëerde het tijdperk van blockchains en elektronisch geld en Ethereum creëerde het tijdperk van slimme contracten. Ethereum, de pionier ontwikkelaar van een smart contract op de blockchain heeft grote bijdragen gemaakt aan het ontwerpidee, het economische model en de technologische realisatie van een smart contractsysteem. Tegelijkertijd heeft het Ethereum-platform een groot aantal DAPP-programma's (gedistribueerde applicaties) waargenomen, waaronder functionaliteiten zoals, gokovereenkomsten, digitale activa, elektronisch goud, een gamingplatform, medische verzekering, huwelijksplatform, etc. In principe kunnen alle DAPP's gemakkelijk worden overgebracht op het NeoContract platform, als een NEO applicatie.
