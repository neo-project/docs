# Network Protocol

NEO maakt gebruik van een P2P netwerkstructuur, waarbij nodes met elkaar communiceren door TCP/IP protocol. In deze structuur zijn er twee soorten nodes: peer nodes en validating nodes (ook wel 'Bookkeepers' geheten). Peer nodes kunnen transacties en blocks uitzenden, ontvangen en overzetten, terwijl validating nodes blocks kunnen aanmaken.

Het netwerkprotocol van NEO lijkt op dat van Bitcoin, maar de datastructuur zoals blocks of transacties verschillen.

Conventies
----

1. Byte Order

    Alle integertypes van NEO zijn Little Endian behalve IP-adressen en port nummers, welke Big Endian zijn.

2. Hash

    Twee verschillende hash-functies worden gebruikt in NEO: SHA256 en RIPEMD160. SHA256 wordt gebruikt om een lange hash te genereren, terwijl RIPEMD160 wordt gebruik om een korte hash te genereren. In het algemeen wordt de hashwaarde van een object berekend door de hash-functie tweemaal te gebruiken. Bijvoorbeeld: we gebruiken SHA256 tweemaal als we de hash van een block of transactie willen genereren. Wanneer we een contract-adres willen genereren, gebruiken we eerst SHA256 en daarna RIPEMD160.
    
    Hiernaast gebruikt de block ook een hash-structuur genaamd Merkle Tree. Deze berekent de hash van elke transactie en combineert deze, om vervoglens weer de hash te berekenen; dit proces wordt herhaald tot er slechts één hash over is, de Merkle Root Hash.

3. Variable Length Type

   + Variant: een integer van variabele lengte. Can gecodeerd worden om ruimte te besparen.

      |Waarde|Lengte|Format|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + Varstr: een string van variabele lengte, bestaande uit een variable length integer gevolgd door strings. De string is gecodeerd met UTF8.

      |Grootte|Veld|DataType|Omschrijving|
      |---|---|---|---|
      | ? | length | variant | De lengte van een string in bytes |
      | length | string | uint8[length] | De string zelf |

   + Array: de array bestaat uit een variable length integer, gevolgd door een reeks van elementen.

4. Fixed-point Number

   Data in NEO (zoals hoeveelheid of prijs) zijn 64bit fixed-point getallen met een precisie van 10<sup>-8</sup>, wat resulteert in een bereik van [-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>].

Data Type
-------

1. Blockchain

   De blockchain is een specifieke logische structuur, in serie verbonden met een eenwegs gelinkte lijst. Het wordt gebruikt om de data van het gehele netwerk op te slaan, zoals transacties en asets.

1. Block

   | Grootte | Veld | DataType | Omschrijving |
   |---|---|---|---|
   |4|Version|uint32|Versie van het block welke nu 0 is|
   |32|PrevBlock|uint256| Hashwaarde van het vorige blok|
   |32|MerkleRoot|uint256|Root-hash van een lijst van transacties|
   |4|Timestamp|uint32|Tijdsaanduiding|
   |4|Height|uint32|Blockhoogte|
   |8|Nonce|uint64|Willekeurig getal|
   |20|NextMiner|uint160|Contract-addres van de volgende miner|
   |1|-|uint8| Staat vast op 1 |
   |?|Script|script| Het gebruikte validatiescript voor het block|
   |?\*? |Transactions|tx[]|Lijst van transacties|

   Bij het berekenen van de hashwaarde van een block worden alleen de eerste zeven velden in het block berekend, in plaats van het gehele block. Dit zijn: version, PrevBlock, MerkleRoot, timestamp, height, nonce en NextMiner. Aangezien MerkleRoot al de hashwaarde van alle transacties bevat, zal aanpassing van een transactie de hashwaarde van het block veranderen.
   
   Datastructuur van de block head:

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |4|Version|uint32|Versie van het block welke nu 0 is|
   |32|PrevBlock|uint256|Hashwaarde van het vorige blok|
   |32|MerkleRoot|uint256|Root-hash van een lijst van transacties|
   |4|Timestamp|uint32|Tijdsaanduiding|
   |4|Height|uint32|Blockhoogte|
   |8|Nonce|uint64|Willekeurig getal|
   |20|NextMiner|uint160|Contract-addres van de volgende miner|
   |1|-|uint8|Staat vast op 1|
   |?|Script|script|Het gebruikte validatiescript voor het block|
   |1|-|uint8|Staat vast op 0|

   De tijdsaanduiding op elk block moet later zijn dan die van het block ervoor. Normaal gesproken is het verschil ongeveer 15 seconden. De tijdsaanduiding hoeft niet tot op de milliseconde te kloppen. De hoogte van de blockchain moet exact gelijk zijn als die van het block hiervoor plus een.
   
1. Transaction

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |1|Type|uint8|Type van de transactie|
   |1|Version|uint8|Trading version, momenteel 0|
   |?|-|-|Type-specifieke data|
   |?\*?|Attributes|tx_attr[]|Aanvullende transactie-eigenschappen|
   |34\*?|Inputs|tx_in[]|Input|
   |60\*?|Outputs|tx_out[]|Output|
   |?\*?|Scripts|script[]|Lijst van validatiescripts voor de transactie|

   Alle processen in het NEO-systeem worden opgeslagen als transactie. Er zijn verschillende typen transacties:

   |Waarde|Naam|System Fee|Omschrijving|
   |---|---|---|---|
   |0x00|MinerTransaction|0|Byte-fees toeschrijven|
   |0x01|IssueTransaction|500\|0|Een asset toeschrijven|
   |0x02|ClaimTransaction|0|GAS toe-eigenen|
   |0x20|EnrollmentTransaction|1000|Meedingen voor positie als validator|
   |0x40|RegisterTransaction|10000|Asset registreren|
   |0x80|ContractTransaction|0|Contract transactie|
   |0xd0|PublishTransaction|500 * n|(Niet functioneel) Speciale transacties voor Smart Contracts|
   |0xd1|InvocationTransaction|0|Speciale transacties voor het beroep doen op Smart Contracts|

   Elk type transactie heeft naast een publiek veld ook een eigen veld:

   + MinerTransaction

      |Grootte|Veld|DataType|Omschrijving|
      |---|---|---|---|
      |4|Nonce|uint32|Willekeurig getal|

      De eerste transactie in elk block moet een MinerTransaction zijn. Deze worden gebruikt om alle transactie-feest toe te schrijven aan de validator.
      
      Er wordt gebruik gemaakt van een willekeurig getal in de transactie om het botsen van hashwaardes te voorkomen.

   + IssueTransaction

      Er zijn geen speciale velden voor een issue transactie.
      
      Asset-beheerders kunnen de assets aanmaken die zijn geregistreerd in NEO's blockchain door middel van IsueTransaction, en ze vervolgens naar een adres sturen.
      
      Als de verstuurde asset NEO is, zal de transactie gratis worden uitgevoerd.
      
      Er wordt gebruik gemaakt van een willekeurig getal in de transactie om het botsen van hashwaardes te voorkomen.

   + ClaimTransaction

      |Grootte|Veld  |DataType| Omschrijving       |
      |-------|------|------- |--------------------|
      |34*?   |Claims|tx_in[] |NEO voor distributie|

   + EnrollmentTransaction

      |Grootte| Veld    |DataType| Omschrijving              |
      |-------|---------|--------|---------------------------|
      |33     |PublicKey|ec_point|public key van de validator|

      De transactie vertegenwoordigt een inschrijvingsformulier, welke aangeeft dat de sponsor van de transactie zich wil aanmelden als validator.
      
      Inschrijven gaat als volgt: creëer een EnrollmentTransaction-type transactie en stuur een storting naar het adres van de PublicKey.
      
      Om de registratie te annuleren, dient de storting te worden uitgegeven vanuit de PublicKey.

   + RegisterTransaction

      > [!Warning]
      Is gedeactiveerd en vervangen door Neo.Asset.Create voor Smart Contracts

      Bekijk het [Alternatieve .NET Smart Contract Framework](../sc/fw/dotnet/neo/Asset/Create.md)

      Bekijk de [Alternatieve Smart Contract API](../sc/api/neo.md)

   + ContractTransaction

      Er zijn geen speciale attributen voor een contract transactie. Dit is een veel voorkomend type transactie, aangezien het de mogelijkheid biedt om NEO van een wallet naar een andere wallet te sturen. De `inputs` en `outputs` transactie-velden zijn meestal belangrijk bij deze transacties (bijvoorbeeld, om bij te houden hoeveel NEO wordt uitgegeven en aan welk adres).

   + PublishTransaction

      > [!Warning]
      Is gedeactiveerd en vervangen door Neo.Contract.Create voor Smart Contracts

      Bekijk het [Alternatieve .NET Smart Contract Framework](../sc/fw/dotnet/neo/Contract/Create.md)

      Bekijk de [Alternatieve Smart Contract API](../sc/api/neo.md)

   + Invoking a Transaction

      | Grootte   | Veld     | Data Type    | Omschrijving                                        |
      | --------- | -------- | ------------ | --------------------------------------------------- |
      | -         | -        | -            | Openbare velden voor transacties                    |
      | ?         | Script   | uint8[]      | Opgeroepen door Smart Contracts                     |
      | 8         | Gas      | int64        | Vereiste kosten om het Smart Contract uit te voeren |
      | -         | -        | -            | Openbare velden voor transacties                    |

1. Transaction Attributes

   | Grootte  | Veld    | Data Type     | Omschrijving                                                     |
   |----------|---------|---------------|------------------------------------------------------------------|
   | 1        | Usage   | uint8         | Gebruik                                                          |
   |          | length  | uint8         | Lengte van de data (specifieke omstandigheden worden weggelaten) |
   | length   | Data    | uint8[length] | Externe data                                                     |

   Soms bevat een transactie data voor extern gebruik; deze data wordt geplaatst in de transaction attributes velden.

   Elke transaction attribute heeft een doel:

   |Waarde|Naam|Omschrijving|
   |---|---|---|
   |0x00|ContractHash| Hashwaarde van contract|
   |0x02-0x03|ECDH02-ECDH03|Public key voor ECDH key exchange|
   |0x20|Script|Aanvullende validatie van transacties|
   |0x30|Vote|Om te stemmen|
   |0x80|CertUrl|Url addres van een certificate|
   |0x81|DescriptionUrl|Url addres van een omschrijving|
   |0x90|Description|Korte omschrijving|
   |0xa1-0xaf|Hash1-Hash15| Om aangepaste hashwaardes op te slaan|
   |0xf0-0xff|Remark-Remark15|Opmerkingen|

   Voor ContractHash, ECDH series en Hash series is de data-lengte altijd 32 bytes en het lengte-veld weggelaten;

   Voor CertUrl, DescriptionUrl, Description en Remark series moet de data-lengte duidelijk worden vernoemd, waarbij de lengte niet groter mag zijn dan 255;

1. Input of Transaction

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |32|PrevHash|uint256|Vorige transactie's hash|
   |2|PrevIndex|uint16|Vorige transactie's index|

1. Output of Transaction

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |32|AssetId|uint256|Asset-ID|
   |8|Value|int64|Waarde|
   |20|ScriptHash|uint160|Addres van remittee|

   Elke transactie kan outputs hebben tot 65536.

1. Validation Script

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |?|StackScript|uint8[]|Stack script code|
   |?|RedeemScript|uint8[]|Contract script code|

   Stack script kunnen alleen worden gebruikt voor PUSH-acties, welke worden gebruikt om signatures aan de stack toe te voegen. De script interpreter zal de stack script code eerst uitvoeren, daarna de contract script code.

   In een transactie moet de hashwaarde van de contract script code consistent zijn met de transactie-output, wat onderdeel is van de validatie. Een latere sectie zal de uitvoering van het script in detail toelichten.

Network Message
-------

Alle netwerkberichten worden volgens deze structuur gezonden:

| Grootte  | Veld    | Data Type     | Omschrijving         |
|---|---|---|---|
|4|Magic|uint32|Protocol-ID|
|12|Command|char[12]|Command|
|4|length|uint32|Lengte van inhoud (Payload)|
|4|Checksum|uint32|Checksum|
|length|Payload|uint8[length]|Inhoud of message|

Defined Magic value:

|Waarde|Omschrijving|
|---|---|
|0x00746e41|Productie-modus|
|0x74746e41|Testmodus|

Command is in UTF8 code met als lengte 12 bytes; het extra deel is gevuld met 0.

Checksum is de eerste 4 bytes van de waarde van tweemaal de SHA256 hash van de Payload.

Afhankelijk van verschillende orders heeft de Payload een ander format, zie hieronder:

1. version

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |4|Version|uint32|Versie van protocol, momenteel 0|
   |8|Services|uint64|De verleende dienst door de node, momenteel 1|
   |4|Timestamp|uint32|Huidige tijd|
   |2|Port|uint16|Port waarop de server luistert (0 wanneer buiten gebruik)|
   |4|Nonce|uint32|Om onderscheid te maken tussen de node en openbare IP|
   |?|UserAgent|varstr|Client-ID|
   |4|StartHeight|uint32|Hoogte van de blockchain|
   |1|Relay|bool| Of ontvangen moet worden / doorgestuurd moet worden

   Als een node een verbindingsaanvraag ontvangt, meldt het meteen de versie. De communicatie gaat pas verder wanneer beide partijen de versie van elkaar hebben ontvangen.

1. verack

   Als een node het versiebericht ontvangt, reageert het meteen met een verack.
   
   Dit bericht heeft geen payload.

1. getaddr

   Maak een aanvraag naar een node voor een batch van nieuwe actieve nodes om het aantal connecties te vergroten.

   Dit bericht heeft geen payload.

1. addr

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |30\*?|AddressList|net_addr[]|Adres van andere node in het netwerk|

   Na het ontvangen van het getaddr bericht, reageert de node met een addr bericht en geeft de node informatie van andere bekende nodes op het netwerk.

1. getheaders

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |32\*?|HashStart|uint256[]|Hash van het laatste block die de node aanvraagt|
   |32|HashStop|uint256|Hash van het laatste block die de node aanvraagt|

   Vraag een node voor de header pakketen van maximaal 2000 blocks, welke HashStart tot HashStop bevatten. Om hierna de block-hash te krijgen, moet het getheaders-bericht opnieuw worden gestuurd. Dit bericht wordt meestal gebruikt om snel de blockchain zonder transacties te downloaden.

1. headers

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |?\*?|Headers|header[]|Head of the block|

   Na het ontvangen van het getheaders-bericht, stuurt de node een header-bericht als reactie en geeft hierbij informatie van andere bekende nodes op het netwerk.

1. getblocks

   | Grootte  | Veld    | Data Type     | Omschrijving         |
   |---|---|---|---|
   |32\*?|HashStart|uint256[]|Hash van het laatste block die de node aanvraagt|
   |32|HashStop|uint256|Hash van het laatste block die de node aanvraagt|

   Een aanvraag voor een node voor een inv-bericht die gaat van HashStart tot HashStop. De hoeveelheid blocks die starten van HashStart tot HashStop is maximaal 500. Als je meer block-hash-waardes dan dat wil ontvangen, dient het getblocks-bericht opnieuw te worden gestuurd.

1. inv

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |36\*?|Inventories|inv_vect[]|Data van inventarissen|

   De node kan de informatie van het object welke het bezit uitzenden door middel van dit bericht. Het bericht kan automatisch worden gestuurd, of om getblocks-berichten te beantwoorden.

   De object-informatie is ingesloten in de lijst:

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |4|Type|uint32|Type object|
   |32|Hash|uint256|Hash van object|

   Object types:

   |Waarde|Naam|Omschrijving|
   |---|---|---|
   |0x01|TX|Transactie|
   |0x02|Block|Block|
   |0xe0|Consensus|Consensus-data|

1. getdata

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |36\*?|Inventories|inv_vect[]|Data van inventarissen|

   Om een specifiek object van een node aan te vragen, wordt getdata meestal na het ontvangen van het inv-pakket gestuurd met het bekende element verwijderd.

1. block

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |?|Block|block|Block|

   Het sturen van een block naar een node, om te antwoorden op het getdata-bericht.

1. tx

   |Grootte|Veld|DataType|Omschrijving|
   |---|---|---|---|
   |?|Transaction|tx|Transactie|

   Het sturen van een transactie naar een node, om te antwoorden op een getdata-bericht.

   |Grootte|Veld|DataType|Omschrijving|
   |----|---------|--------- |----------------- |
   |32\*?|HashStart|uint256[]|De node is bekend als laatste block hash|
   |32|hashStop|uint256|Het laatste block aanvragen|
