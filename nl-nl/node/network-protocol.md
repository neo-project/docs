# Network Protocol

NEO maakt gebruik van een P2P netwerkstructuur, waarbij nodes met elkaar communiceren door TCP/IP protocol. In deze structuur zijn er twee soorten nodes: peer nodes en validating nodes (ook wel Bookkeepers geheten). Peer nodes kunnen transacties en blocks uitzenden, ontvangen en overzetten, terwijl validating nodes blocks kunnen aanmaken.

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
   |?|Script|script| Het gebruikte validatiescript voor de block|
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
   |?|Script|script|Het gebruikte validatiescript voor de block|
   |1|-|uint8|Staat vast op 0|

   De tijdsaanduiding op elk block moet later zijn dan die van het block ervoor. Normaal gesproken is het verschil ongeveer 15 seconden. De tijdsaanduiding hoeft niet tot op de milliseconde te kloppen. De hoogte van de blockchain moet exact gelijk zijn als die van de block hiervoor plus een.
   
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

   For ContractHash, ECDH series, Hash series, data length is fixed to 32 bytes and length field is omitted;

   For CertUrl, DescriptionUrl, Description, Remark series, the data length must be clearly defined, and the length should not exceed 255;

1. Input of Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32|PrevHash|uint256|Previous transaction's hash|
   |2|PrevIndex|uint16|Previous transaction's index|

1. Output of Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32|AssetId|uint256|Asset id|
   |8|Value|int64|Value|
   |20|ScriptHash|uint160|Address of remittee|

   Each transaction can have outputs up to 65536.

1. Validation Script

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|StackScript|uint8[]|Stack script code|
   |?|RedeemScript|uint8[]|Contract script code|

   Stack script can only be used for the PUSH operations, which is used to push data like signatures into the stack. The script interpreter will execute the stack script code first, and then execute the contract script code.

   In a transaction, the hash value of the contract script code must be consistent with the transaction output, which is part of the validation. The later section will describe the execution process of the script in detail.

Network Message
-------

All network messages are sent in this structure:

|Size|Field|DataType|Description|
|---|---|---|---|
|4|Magic|uint32|Protocol ID|
|12|Command|char[12]|Command|
|4|length|uint32|Length of payload|
|4|Checksum|uint32|Checksum|
|length|Payload|uint8[length]|Content of message|

Defined Magic value:

|Value|Description|
|---|---|
|0x00746e41|Production mode|
|0x74746e41|Test mode|

Command is utf8 code, of which the length is 12 bytes, the extra part is filled with 0.

Checksum is the first 4 bytes of the value that two times SHA256 hash of the Payload.

According to different orders Payload has different detailed format, see below:

1. version

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Version|uint32|Version of protocol, 0 for now|
   |8|Services|uint64|The service provided by the node is currently 1|
   |4|Timestamp|uint32|Current time|
   |2|Port|uint16|Port that the server is listening on, it's 0 if not used.|
   |4|Nonce|uint32|It's used to distinguish the node from public IP|
   |?|UserAgent|varstr|Client ID|
   |4|StartHeight|uint32|Height of block chain|
   |1|Relay|bool|Whether to receive and forward


   When a node receives a connection request, it declares its version immediately. There will be no other communication until both sides are getting versions of each other.

1. verack

   When a node receives the version message, it replies with a verack immediately.

   This message has no payload.

1. getaddr

   Make requests to a node for a batch of new active nodes in order to increase the number of connections.

   This message has no payload.

1. addr

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|Other nodes' address in network|

   After receiving the getaddr message, the node returns an addr message as response and provides information about the known nodes on the network.

1. getheaders

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hash of latest block that node requests|
   |32|HashStop|uint256|Hash of last block that node requests|

   Make requests to a node for at most 2000 blocks’ header packages that contain HashStart to HashStop. To get the block hash after that, you need to resend the getheaders message. This message is used to quickly download the blockchain which does not contain the transactions.

1. headers

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?*?|Headers|header[]|Head of the block|

   After receiving the getheaders message, the node returns a header message as response and provides information about the known nodes on the network.

1. getblocks

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hash of latest block that node requests|
   |32|HashStop|uint256|Hash of last block that node requests|

   Make requests to a node for inv message which starts from HashStart to HashStop. The number of blocks which starts from HashStart to HashStop is up to 500. If you want to get block hash more than that, you need to resend getblocks message.

1. inv

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Data of inventories|

   The node can broadcast the object information it owns by this message. The message can be sent automatically or can be used to answer getblocks messages.

   Object information is included in the list:

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Type|uint32|Type of object|
   |32|Hash|uint256|Hash of object|

   Object types:

   |Value|Name|Description|
   |---|---|---|
   |0x01|TX|Transaction|
   |0x02|Block|Block|
   |0xe0|Consensus|Consensus data|

1. getdata

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Data of inventories|

   To request a specified object from a node: It is usually sent after the inv packet is received and the known element removed.

1. block

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|Block|block|Block|

   Sending a block to a node, to respond to the getdata message.

1. tx

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|Transaction|tx|Transaction|

   Sending a transaction to a node, to respond to the getdata message.

   |Size|field|data type|description|
   |----|---------|--------- |----------------- |
   |32 *?|HashStart|uint256[]|Node is known as the latest block hash|
   |32|hashStop|uint256|Request the last block|
