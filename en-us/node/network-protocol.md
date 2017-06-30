Antshares adopts a P2P network structure, in which nodes can communicate with each other through TCP/IP protocol. In this structure, there are two different types of nodes: peer node and validating node (referred to as Bookkeepers in the Antshares Whitepaper). Peer node can broadcast, receive and transfer transactions or blocks, while validating node can create blocks.


The network protocol of Antshares is roughly similar to bitcoin’s, however, data structure such as blocks or transactions is quite different.

Convention
----

1. Byte Order

    All integer types of Antshares are Little Endian except for IP address and port number, these 2 are Big Endian.

1. Hash

   Two different hash functions are used in Antshares: SHA256 and RIPEMD160. SHA256 is used to generate a long hash value, and RIPEMD160 is used to generate a short hash value. In general, we get an object's hash value by using hash function twice. For example, we use SHA256 twice when we want to generate block's or transaction's hash value. When generating a contract address, we will use SHA256 function first and then use RIPEMD160.

   In addition, the block will also use a hash structure called Merkle Tree. It computes the hash of each transaction and combines one another then hash again, repeats this process until there is only one root hash (Merkle Root).

1. Variable Length Type

   + variant：variable length integer, can be encoded to save space according to the value typed.

      |Value|Length|Format|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + varstr：variable length string, consisting of variable length integer followed by strings. String encoded by UTF8.

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |?|length|variant|The length of a string in bytes|
      |length|string|uint8[length]|string itself|

   + array：The array consists of a variable length integer followed by a sequence of elements.

1. Fixed-point Number

   Data in Antshares such as amount or price are 64 bit fixed-point number and the precision of decimal part is 10<sup>-8</sup>，range：[-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>)

Data Type
-------

1. Block Chain

   Block chain is a kind of logical structure, which is connected in series with a one-way linked list. It is used to store the data of the whole network, such as transactions or assets.

1. Block

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Version|uint32|version of the block which is 0 for now|
   |32|PrevBlock|uint256|hash value of the previous block|
   |32|MerkleRoot|uint256|root hash of a transaction list|
   |4|Timestamp|uint32|time stamp|
   |4|Height|uint32|height of block|
   |8|Nonce|uint64|random number|
   |20|NextMiner|uint160|contract address of next miner|
   |1|-|uint8|It's fixed to 1|
   |?|Script|script|Script used to validate the block|
   |?*?|Transactions|tx[]|transactions list|

   When calculating the hash value of the block, instead of calculating the entire block, only first seven fields in the block head will be calculated, which are version, PrevBlock, MerkleRoot, timestamp, and height, the nonce, NextMiner. Since MerkleRoot already contains the hash value of all transactions, the modification of transaction will influence the hash value of the block.

   Data structure of block head:

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Version|uint32|version of the block which is 0 for now|
   |32|PrevBlock|uint256|hash value of the previous block|
   |32|MerkleRoot|uint256|root hash of a transaction list|
   |4|Timestamp|uint32|time stamp|
   |4|Height|uint32|height of block|
   |8|Nonce|uint64|random number|
   |20|NextMiner|uint160|contract address of next miner|
   |1|-|uint8|It's fixed to 1|
   |?|Script|script|Script used to validate the block|
   |1|-|uint8|It's fixed to 0|

   The time stamp of each block must be later than previous block's time stamp. Generally the difference of two block's time stamp is about 15 seconds and imprecision is allowed. The height of the block must be exactly equal to the height of the previous block plus 1.

1. Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |1|Type|uint8|type of transaction|
   |?|-|-|Data specific to transaction types|
   |?*?|Attributes|tx_attr[]|Additional features that the transaction has|
   |34*?|Inputs|tx_in[]|input|
   |60*?|Outputs|tx_out[]|output|
   |?*?|Scripts|script[]|List of scripts used to validate the transaction|

   All processes in Antshares system are recorded in transactions. There are several types of transactions:

   |Value|Name|System Fee|Description|
   |---|---|---|---|
   |0x00|MinerTransaction|0|assign byte fees|
   |0x01|IssueTransaction|500\|0|inssuance of asset|
   |0x02|ClaimTransaction|0|assign ant coins|
   |0x20|EnrollmentTransaction|1000|enrollment for validator|
   |0x24|VotingTransaction|10|vote for validator|
   |0x40|RegisterTransaction|10000|assets register|
   |0x80|ContractTransaction|0|contract transaction|
   |0xb0|AgencyTransaction|0|agency transaction|

   Each type of transaction, in addition to the public field, also has its own exclusive field. The following will describe these exclusive fields in detail.

   + MinerTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |4|Nonce|uint32|random number|
      |-|-|-|public filed of transaction|

      The first transaction in each block must be MinerTransaction. It is used to reward all transaction fees of the current block to the validator.

      Random number in the transaction is used to avoid hash collision.

   + IssueTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |4|Nonce|uint32|random number|
      |-|-|-|public filed of transaction|

      Asset managers can create the assets that have been registered in Antshares' block chain through IssueTransaction, and sent them to any address.

      In particular, if the assets which being issued are AntShares, then the transaction will be sent free.

      Random number in the transaction is used to avoid hash collision.

   + ClaimTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |34*?|Claims|tx_in[]|ant shares for distribution|
      |-|-|-|public filed of transaction|

   + EnrollmentTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |33|PublicKey|ec_point|public key of validator|
      |-|-|-|public filed of transaction|

      The transaction represents an enrollment form, which indicates that the sponsor of the transaction would like to sign up as a validator.

      The way to sign up is: to construct an EnrollmentTransaction type of transaction, and send a deposit to the address of the PublicKey.

      The way to cancel the registration is: spend the deposit on the address of the PublicKey.

   + VotingTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |32*?|Enrollments|uint256[]|List of the hash values on the enrollment form|
      |-|-|-|public filed of transaction|

      This transaction represents a vote, which indicates that the sponsor wants to vote on one or more of the registered validator candidates. It can be voted to 1024 candidates at maximum and one people at minmum. The weight of the vote is equal to the number of AntShares in this transaction.

   + RegisterTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |1|AssetType|uint8|asset type|
      |?|Name|varstr|asset name|
      |8|Amount|int64|amount|
      |33|Issuer|ec_point|public key of issuer|
      |20|Admin|uint160|hash value of issuer's contract|
      |-|-|-|public filed of transaction|

      If you want to create a new asset in the blockchain of Antshares, you need to register the asset.

      Following are some types of asset that you may choose:

      |Value|Name|Description|
      |---|---|---|
      |0x00|AntShare|ant share|
      |0x01|AntCoin|ant coin|
      |0x10|Share|equity/share|
      |0x20|Currency|currency|
      |0x40|Token|custom asset|

      Each type of asset has its own specific limits.

      AntShares and AntCoins are the system's built-in assets, so they cannot be created except for creating them in Genesis block (i.e., the block whose height is 0).

      When creating the equity-like assets, total amount should be limited and transactions need to be signed by both the sender and the receiver.

      When creating the currencies assets, total amount cannot be limited.

      Custom assets have no limits.

      About the total amount, there are two models: limited mode and unlimited mode. When the amount is a positive number, the asset is the limited type; when the amount is equal to the -10<sup>-8</sup>, the asset is the unlimited type.

   + ContractTransaction

      There is nothing special in the contract transaction.

   + AgencyTransaction

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |-|-|-|public filed of transaction|
      |32|AssetId|uint256|asset id|
      |32|ValueAssetId|uint256|value asset id|
      |20|Agent|uint160|agent's contract address|
      |?*?|Orders|order[]|order list|
      |1|-|uint8|It's fixed to 1|
      |36|SplitOrder|split_order|orders that partially executed|
      |-|-|-|public filed of transaction|

      ValueAssetId in the agency transaction must be the currency asset, and cannot be the same as AssetId.

      Buying list and selling list should have at least one order each.

      Transactions cannot contain orders that are not traded, and only can contain one order which is partially executed.

      If there is an order that partially executed then the price of this order must be the worst, which means that it's the lowest price for buying orders and highest price for selling orders.

      For buying order, it can be executed at the price that is lower than the price specified by client. For selling order, it can be executed at the price that is higher than the price specified by client.

      Amount is accurate ot 10<sup>-4</sup>，price is accurate to10<sup>-4</sup>.

      Order's Data Structure：

      |Size|Field|DataType|Description|
      |---|---|---|---|
      |32|AssetId|uint256|asset id|
      |32|ValueAssetId|uint256|value asset id|
      |20|Agent|uint160|agent's contract address|
      |8|Amount|int64|amount|
      |8|Price|int64|price|
      |20|Client|uint160|client's contract address|
      |34*?|Inputs|tx_in[]|inputs|
      |?*?|Scripts|script[]|script list which is used to validate this order|

      If an order is transferred along with the transaction, since it already contains information such as assets, currency, agents and so on, it can be compressed into the following format:


      |Size|Field|DataType|Description|
      |---|---|---|---|
      |8|Amount|int64|amount|
      |8|Price|int64|price|
      |20|Client|uint160|client's contract address|
      |34*?|Inputs|tx_in[]|inputs|
      |?*?|Scripts|script[]|script list which is used to validate this order|

      Data structure of order that being partially executed is like:
      
      |Size|Field|DataType|Description|
      |---|---|---|---|
      |8|Amount|int64|amount|
      |8|Price|int64|price|
      |20|Client|uint160|client's contract address|

      For all kinds of orders, if the amount is positive, it means buying, if the amount is negative, it means selling.

1. Transaction Feature

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |1|Usage|uint8|usage|
   |0\|1|length|uint8|length of data(Specific circumstances will be omitted)|
   |length|Data|uint8[length]|external data|

   Sometimes the transaction will contain some data for external use, these data will be placed in the transaction feature field.

   Each transaction feature has different usages:

   |Value|Name|Description|
   |---|---|---|
   |0x00|ContractHash|hash value of contract|
   |0x02-0x03|ECDH02-ECDH03|public key for ECDH key exchange|
   |0x20|Script|additional validation of transactions|
   |0x80|CertUrl|url address of certificate|
   |0x81|DescriptionUrl|url address of description|
   |0x90|Description|brief description|
   |0xa1-0xaf|Hash1-Hash15|used to store custom hash values|
   |0xf0-0xff|Remark-Remark15|remarks|

   For ContractHash, ECDH series, Hash series, data length is fixed to 32 bytes and length field is omitted;

   For CertUrl, DescriptionUrl, Description, Remark series, the data length must be clearly defined, and the length should not exceed 255;

1. Input of Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32|PrevHash|uint256|previous transaction's hash|
   |2|PrevIndex|uint16|previous transaction's index|

1. Output of Transaction

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32|AssetId|uint256|asset id|
   |8|Value|int64|value|
   |20|ScriptHash|uint160|address of remittee|

   Each transaction could have outputs up to 65536. 

1. Validation Script

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|StackScript|uint8[]|stack script code|
   |?|RedeemScript|uint8[]|contract script code|

   Stack script can only be used for the PUSH operations, which is used to push data like signatures into the stack. The script interpreter will execute the stack script code first, and then execute the contract script code.

   In a transaction, the hash value of the contract script code must be consistent with the transaction output, which is part of the validation. The later section will describe the execution process of the script in detail.

Network Message
-------

All network messages are sent in this structure:

|Size|Field|DataType|Description|
|---|---|---|---|
|4|Magic|uint32|protocol id|
|12|Command|char[12]|command|
|4|length|uint32|length of payload|
|4|Checksum|uint32|checksum|
|length|Payload|uint8[length]|content of message|

Defined Magic value:

|Value|Description|
|---|---|
|0x00746e41|production mode|
|0x74746e41|test mode|

Command is utf8 code, of which the length is 12 bytes, the extra part is filled with 0.

Checksum is the first 4 bytes of the value that two times SHA256 hash of the Payload.

According to different orders Payload has different detailed format, see below:

1. version

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Version|uint32|version of protocol, 0 for now|
   |8|Services|uint64|The service provided by the node is currently 1|
   |4|Timestamp|uint32|current time|
   |2|Port|uint16|port that the server is listening on, it's 0 if not used.|
   |4|Nonce|uint32|it's used to distinguish the node from public IP|
   |?|UserAgent|varstr|client ID|
   |4|StartHeight|uint32|height of block chain|

   When a node receives a connection request, it declares its version immediately. There will be no other communication until both sides are getting versions of each other.

1. verack

   When a node receives the version message, it replies to a verack as a response immediately.

   This message has no payload.

1. getaddr

   Make requests to a node for a batch of new active nodes in order to increase the number of connections.

   This message has no payload.

1. addr

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|other nodes' address in network|

   After receiving the getaddr message, the node returns an addr message as response and provides information about the known nodes on the network.

1. getheaders

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|hash of latest block that node requests|
   |32|HashStop|uint256|hash of last block that node requests|

   Make requests to a node for at most 2000 blocks’ header packages that contain HashStart to HashStop. To get the block hash after that, you need to resend the getheaders message. This message is used to quickly download the blockchain which does not contain the transactions.

1. headers

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?*?|Headers|header[]|head of the block|

   After receiving the getheaders message, the node returns a header message as response and provides information about the known nodes on the network.

1. getblocks

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|hash of latest block that node requests|
   |32|HashStop|uint256|hash of last block that node requests|

   Make requests to a node for inv message which starts from HashStart to HashStop. The number of blocks which starts from HashStart to HashStop is up to 500. If you want to get block hash more than that you need to resend getblocks message.

1. inv

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|data of inventories|

   The node can broadcast the object information it owns by this message. The message can be sent automatically or can be used to answer getbloks messages.

   Object information is included in the list:

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |4|Type|uint32|type of object|
   |32|Hash|uint256|hash of object|

   Object types:

   |Value|Name|Description|
   |---|---|---|
   |0x01|TX|transaction|
   |0x02|Block|block|
   |0xe0|Consensus|consensus data|

1. getdata

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|data of inventories|

   To request a specified object from a node: It is usually sent after the inv packet is received and the known element removed.

1. block

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|Block|block|block|

   Sending a block to a node to respond the getdata message.

1. tx

   |Size|Field|DataType|Description|
   |---|---|---|---|
   |?|Transaction|tx|transaction|

   Sending a transaction to a node to respond getdata message.
