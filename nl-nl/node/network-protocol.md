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
   |?*?|Transactions|tx[]|Lijst van transacties|

   When calculating the hash value of the block, instead of calculating the entire block, only first seven fields in the block head will be calculated, which are version, PrevBlock, MerkleRoot, timestamp, and height, the nonce, NextMiner. Since MerkleRoot already contains the hash value of all transactions, the modification of transaction will influence the hash value of the block.

   Data structure of block head:

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Version|uint32|Version of the block which is 0 for now|
   |32|PrevBlock|uint256|Hash value of the previous block|
   |32|MerkleRoot|uint256|Root hash of a transaction list|
   |4|Timestamp|uint32|Time-stamp|
   |4|Height|uint32|Height of block|
   |8|Nonce|uint64|Random number|
   |20|NextMiner|uint160|Contract address of next miner|
   |1|-|uint8|It's fixed to 1|
   |?|Script|script|Script used to validate the block|
   |1|-|uint8|It's fixed to 0|

   The time-stamp of each block must be later than previous block's time stamp. Generally the difference of two block's time stamp is about 15 seconds and imprecision is allowed. The height of the block must be exactly equal to the height of the previous block plus 1.

1. Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |1|Type|uint8|Type of transaction|
   |1|Version|uint8|Trading version, currently 0|
   |?|-|-|Data specific to transaction types|
   |?*?|Attributes|tx_attr[]|Additional features that the transaction has|
   |34*?|Inputs|tx_in[]|Input|
   |60*?|Outputs|tx_out[]|Output|
   |?*?|Scripts|script[]|List of scripts used to validate the transaction|

   All processes in NEO system are recorded as transactions. There are several types of transactions:

   |Value|Name|System Fee|Description|
   |---|---|---|---|
   |0x00|MinerTransaction|0|Assign byte fees|
   |0x01|IssueTransaction|500\|0|Inssuance of asset|
   |0x02|ClaimTransaction|0|Assign GAS|
   |0x20|EnrollmentTransaction|1000|Enrollment for validator|
   |0x40|RegisterTransaction|10000|Assets register|
   |0x80|ContractTransaction|0|Contract transaction|
   |0xd0|PublishTransaction|500 * n|(Not usable) Special Transactions for Smart Contracts|
   |0xd1|InvocationTransaction|0|Special transactions for calling Smart Contracts|

   Each type of transaction, in addition to the public field, also has its own exclusive field. The following will describe these exclusive fields in detail.

   + MinerTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |4|Nonce|uint32|random number|

      The first transaction in each block must be MinerTransaction. It is used to reward all transaction fees of the current block to the validator.

      Random number in the transaction is used to avoid hash collision.

   + IssueTransaction

      There are no special fields for an issue transaction.

      Asset managers can create the assets that have been registered in NEO's block chain through IssueTransaction, and sent them to any address.

      In particular, if the assets which being issued are NEO, then the transaction will be sent free.

      Random number in the transaction is used to avoid hash collision.

   + ClaimTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |34*?|Claims|tx_in[]|NEO for distribution|

   + EnrollmentTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |33|PublicKey|ec_point|public key of validator|

      The transaction represents an enrollment form, which indicates that the sponsor of the transaction would like to sign up as a validator.

      The way to sign up is: To construct an EnrollmentTransaction type of transaction, and send a deposit to the address of the PublicKey.

      The way to cancel the registration is: Spend the deposit on the address of the PublicKey.

   + RegisterTransaction

      > [!Warning]
      Has been deactived and replaced by Neo.Asset.Create for the smart contract.

      View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/neo/Asset/Create.md)

      View [Alternative Smart Contract API](../sc/api/neo.md)

   + ContractTransaction

      There are no special attributes for a contract transaction. This is a very common kind of transaction as it allows one wallet to send NEO to another. The `inputs` and `outputs` transaction fields will usually be important for this transaction (for example, to govern how much NEO will be sent, and to what address).

   + PublishTransaction

      > [!Warning]
      Has been deactivated and replaced by Neo.Contract.Create for the smart contract.

      View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/neo/Contract/Create.md)

      View [Alternative Smart Contract API](../sc/api/neo.md)

   + Invoking a Transaction

      | Size   | Field     | Data Type    | Description              |
      | ---- | ------ | ------- | --------------- |
      | -    | -      | -       | Public fields for transactions         |
      | ?    | Script | uint8[] | Invoked by smart contract     |
      | 8    | Gas    | int64   | Costs required to run the smart contract |
      | -    | -      | -       | Publics fields for transactions         |

1. Transaction Attributes

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |1|Usage|uint8|Usage|
   |0\|1|length|uint8|Length of data(Specific circumstances will be omitted)|
   |length|Data|uint8[length]|External data|

   Sometimes the transaction will contain some data for external use, these data will be placed in the transaction attributes field.

   Each transaction attribute has different usages:

   |Value|Name|Description|
   |---|---|---|
   |0x00|ContractHash|Hash value of contract|
   |0x02-0x03|ECDH02-ECDH03|Public key for ECDH key exchange|
   |0x20|Script|Additional validation of transactions|
   |0x30|Vote|For voting
   |0x80|CertUrl|Url address of certificate|
   |0x81|DescriptionUrl|Url address of description|
   |0x90|Description|Brief description|
   |0xa1-0xaf|Hash1-Hash15|Used to store custom hash values|
   |0xf0-0xff|Remark-Remark15|Remarks|

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
