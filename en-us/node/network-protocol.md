# Network protocol

In the network structure, AntShares use point to point network structure, using TCP protocol for communication.

There are two kinds of node types in the network, namely, ordinary nodes and consensus nodes. Ordinary nodes can broadcast, receive and forward transactions, blocks, etc. Consensus nodes can create blocks. Refer to [this text](setup.md) for installation and deployment of nodes.

The agreement protocol of AntShares is very similar to Bitocin protocol, but they differ in terms of the data structure of the block, transaction and so on.

Agreement

### Byte order

All integer types in AntShares system are encoded using Little Endian, and only the IP address and port number are encoded using Big Endian.

### Hashing

Two different hash functions are used in the AntShares system: SHA256 and RIPEMD160. The former is used to generate longer hash values, while the latter is used to generate shorter hash values. Usually, generating the hash value of an object, will require the use two hash functions. For example, to generate a block or transaction hash, the SHA256 hash value has to be calcaluated twice. While generating a contract address, the first calculation be to calculate the script SHA256 hash, which is then followed by the calculation of the script RIPEMD160 hash.

In addition, the block will also use a hash tree (Merkle Tree) structure. The transcation hash of every action is combined and used in the calculation of another hash, where the above process is repeated until only one Root remains (Merkle Root).

### Variable type

Varint: Variable length integer, can be encoded according to the value of the expression to save space.

| Value | length | format |
| ------------- | ---- | ------------- |
| <0xfd | 1 | uint8 |
| <= 0xffff | 3 | 0xfd + uint16 |
| <= 0xffffffff | 5 | 0xfe + uint32 |
| 0xffffffff | 9 | 0xff + uint64 |

Varstr: Variable-length string consisting of a variable-length followed string. The string is encoded with UTF8.

| Size | field | data type | description |
| ------ | ------ | ------------- | ------------- |
| | Length | varint | The length of the string, in bytes
| Length | string | uint8 [length] | The string itself |

Array: An array of elements that consists of a variable length, followed by an element sequence.

### Fixed constants

The amount of money, price and other data in the AntShares system, the unified use of 64-bit fixed-point, the decimal precision of up to 10 <sup> -8 </ sup>, can be expressed in the range: [- 2 <sup> 63 </10 <sup> 8 </ sup>, +2 <sup> 63 </ sup>/10 <sup> 8 </ sup>]

Data structure
-------

### Blockchain

A blockchain is a logical structure that connects blocks in the form of unidirectional lists for storing transactions, assets, and so on.

### blocks

| Size | field | data type | description |
| - | ------------- | ------- | --------------------- |
| 4 | Version | uint32 | Block version, currently 0 |
| 32 | PrevBlock | uint256 | The hash value of the previous block |
| 32 | MerkleRoot | uint256 | The root of the transaction list
| 4 | Timestamp | uint32 | timestamp
| 4 | Index | uint32 | Block Height (Block Index) = Block Number - 1 |
ConsensusData | uint64 | Consensus Data (Consensus Node Generates Pseudorandom Number) |
| 20 | NextConsensus | uint160 | The hash value of the accounting contract for the next block
| 1 | - | uint8 | fixed to 1 |
Script | script | script used to verify the block
Transactions | tx[] | Transaction List |

When calculating the hash of the block, the entire block is not counted, but only the first seven fields of the header are used: Version, PrevBlock, MerkleRoot, Timestamp, Height, Nonce, NextMiner. Since MerkleRoot already contains the hash value for all transactions, any modification to the transaction also changes the hash value of the block.

The data structure of the block header is as follows:

| Size | field | data type | description |
| - | ------------- | ------- | --------------------- |
| 4 | Version | uint32 | block version, currently 0 |
| 32 | PrevBlock | uint256 | The hash value of the previous block |
| 32 | MerkleRoot | uint256 | The root of the transaction list
| 4 | Timestamp | uint32 | timestamp
| 4 | Index | uint32 | Block Height (Block Index) = Block Number - 1 |
ConsensusData | uint64 | Consensus Data (Consensus Node Generates Pseudorandom Number) |
| 20 | NextConsensus | uint160 | The hash value of the accounting contract for the next block
| 1 | - | uint8 | fixed to 1 |
Script | script | script used to verify the block
| 1 | - | uint8 | fixed to 0 |

The timestamp of each block must be later than the timestamp of the previous block. Generally, the timestamps of the two blocks differ by about 15 seconds, but there are exceptions to this rule. The height of the block must be equivalent to the height of the previous block, plus one.

### trade

| Size | field | data type | description |
| - | ---------- | --------- | ------------ |
| 1 | Type | uint8 | Transaction Type |
| 1 | Version | uint8 | Trading version, currently 0 |
| | | - | - | Data specific to transaction type
Attributes | tx_attr[] | Extra attributes of the transaction
| 34 *? | Inputs | tx_in[] | Input |
| 60 *? | Outputs | tx_out[] | Output |
Scripts | script[] | Scripts used to validate the transaction

All transactions in the AntShares system are recorded in transaction units. There are several types of transactions:

| Value | name | system cost | description |
| ---- | --------------------- | -------- | ---------------------- |
| 0x00 | MinerTransaction | 0 | Transactions for allocating byte fees |
| 0x01 | IssueTransaction | 500 \ | 0 | Transactions for Distributing Assets
| 0x02 | ClaimTransaction | 0 | Transactions for the distribution of AntShares coins
| 0x20 | EnrollmentTransaction | 1000 | (Not usable) Special transaction for registration as a consensus candidate |
| 0x40 | RegisterTransaction | 10000 \ | 0 | (Not usable) Transactions for asset registration
| 0x80 | ContractTransaction | 0 | Contract transaction, which is the most commonly used transaction type
| 0xd0 | PublishTransaction | 500 * n | (Not usuable) Special Transactions for Smart Contracts |
| 0xd1 | InvocationTransaction | 0 | Special transcations for calling smart contracts |

Each type of transaction has its own unique field in addition to the public field of the transaction. The exclusive fields for different types of transactions are described in detail below.

** MinerTransaction **

| Size | field | data type | description |
| ---- | ----- | ------ | ------- |
| | | | | | | Public fields for transactions
4 | Nonce | uint32 | Random number |
| | | | | | | Public fields for transactions

The first transaction for each block must be MinerTransaction. It is used to reward the book-keeper nodes with all the transaction fees in the current block.

The random number in the transaction is used to prevent hash conflicts.

** IssueTransaction **

There are no special fields for the asset issue transaction.

The asset manager can create an asset that has been registered in an asset chain and send it to any address through an asset issue transaction.

In particular, if the issue of assets is AntShares, then the deal will be free to send.

** ClaimTransaction **

| Size | field | data type | description |
| ---- | ------ | ------- | -------- |
| | | | | | | Public fields for transactions
34 * | | Claims | tx_in[] | For the distribution of AntShares shares
| | | | | | | Public fields for transactions

** EnrollmentTransaction **

> [!Warning]
Has been deactivated and replaced by the AntShares.Blockchain.RegisterValidator of the smart contract.

View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/AntShares/Blockchain/RegisterValidator.md)

View [Alternative Smart Contract API](../sc/api/AntShares.md)

** RegisterTransaction **

> [!Warning]
Has been deactived and replaced by AntShares.Blockchain.CreateAsset for the smart contract.

View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/AntShares/Blockchain/CreateAsset.md)

View [Alternative Smart Contract API](../sc/api/AntShares.md)

** ContractTransaction **

There is no special field for a contract transaction.

** PublishTransaction **

> [!Warning]
Has been deactivated and replaced by AntShares.Blockchain.CreateContract for the smart contract.

View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/AntShares/Blockchain/CreateContract.md)

View [Alternative Smart Contract API](../sc/api/AntShares.md)

** Invoking a Transaction **


| Size   | Field     | Data Type    | Description              |
| ---- | ------ | ------- | --------------- |
| -    | -      | -       | Public fields for transactions         |
| ?    | Script | uint8[] | Invoked by smart contract     |
| 8    | Gas    | int64   | Costs required to run the smart contract |
| -    | -      | -       | Publics fields for transactions         |


### Trading characteristics

| Size | field | data type | description |
| ------ | ------ | ------------- | -------------- |
| 1 | Usage | uint8 | Use |
| 0 | | 1 | length | uint8 | data length (Omitted in certain cases)
| Length | Data | uint8 [length] | Application-specific external data |

Occasionally, the transaction will need to contain some data for external use. This data will be placed in the transaction characteristics of the field.

Each transaction feature can have different uses:

| Value | name | description |
| --------- | --------------- | --------------- |
| 0x00 | ContractHash | Hash value of external contract
| 0x02-0x03 | ECDH02-ECDH03 | Public key for ECDH key exchange |
| 0x20 | Script | For additional verification of the transaction
| 0x30 | Vote | For voting
| 0x80 | CertUrl | Certificate Address |
| 0x81 | DescriptionUrl | External presentation information address |
| 0x90 | Description | Short introductory information |
| 0xa1-0xaf | Hash1-Hash15 | Used to store custom hash values ​​|
| 0xf0-0xff | Remark-Remark15 | Remarks |

For ContractHash, ECDH series, Vote, Hash, the data length is fixed to 32 bytes,and the length field is omitted;

For Script, you must explicitly give the data length, and the length can not exceed 65535;

For CertUrl, DescriptionUrl, Description, Remark, you must specify the length of the data, and the length can not exceed 255.

### Transaction input

| Size | field | data type | description |
| ---- | --------- | ------- | --------- |
| 32 | PrevHash | uint256 | Reference to the hash value of the transaction |
| 2 | PrevIndex | uint16 | Index that references the transaction output

### Transaction output

| Size | field | data type | description |
| ---- | ---------- | ------- | ---- |
| 32 | AssetId | uint256 | Asset Number |
8 | Value | int64 | Amount |
| 20 | ScriptHash | uint160 | Payment address |

Each transaction can only contain up to 65536 outputs.

### Verify the script

| Size | field | data type | description |
| ---- | ------------ | ------- | ------ |
| StackScript | uint8[] | Stack script code |
RedeemScript | uint8[] | Contract script code |

The stack script can only contain push operations instructions that are used to pass parameters (such as signatures) to contract scripts. The script interpreter will execute the stack script code first, and then, execute the contract script code.

In a transaction, the hash value of the contract script code must be consistent with the transaction output, which is part of the verification process. The process of script execution will be described in detail later.

Network message
-------

All network messages are sent through the following message structure:

| Size | field | data type | description |
| ------ | -------- | ------------- | ----------- |
| 4 | Magic | uint32 | Protocol identification number |
| 12 | Command | char [12] | Command |
| 4 | length | uint32 | Payload length |
4 | Checksum | uint32 | Checksum |
| Length | Payload | uint8 [length] | Message content |

Defined Magic value:

| Value | description |
| ---------- | ---- |
| 0x00746e41 | Official Website |
| 0x74746e41 | Test Network |

Command using utf8 encoding, length of 12 bytes, and fill the extra part using 0.

Checksum is the first 4 bytes of the Payload, which has undergone two SHA256 hash.

Payload varies depending on the order of the different formats, see below.

### Version

| Size | field | data type | description |
| - | ----------- | ------ | --------------- |
| 4 | Version | uint32 | Protocol version, currently 0 |
| 8 | Services | uint64 | The services provided by the node are currently 1 |
4 | Timestamp | uint32 | Current time |
| 2 | Port | uint16 | The port that is listening, or 0, if it is not listening
| 4 | Nonce | uint32 | Nodes for distinguishing the same public network
UserAgent | varstr | Client ID
| 4 | StartHeight | uint32 | Block Chain Height |
| 1 | Relay | bool | Whether to receive and forward

When a node receives a connection request, it immediately declares its version. There will be no other communication before both parties are aware of each other's version.

### Verack

Once the node receives the version message, it immediately responds to a verack as a reply.

There is no payload for this message.

## Getaddr

Requests a new list of active nodes, in order to increase the number of its own connections.

There is no payload for this message.

### Addr

| Size | field | data type | description |
| - | ----------- | ---------- | ---------- |
| 30 *? | AddressList | net_addr[] | Addresses of other nodes on the network |

After the node receives the getaddr message, it returns an addr message as a reply to provide information about the known node on the network.

### Getheaders

| Size | field | data type | description |
| ---- | --------- | --------- | ----------------- |
| 32 *? | HashStart | uint256[] | Node is known as the latest block hash
| 32 | HashStop | uint256 | Request the last block of the hash |

Requests a header package containing up to 2000 blocks with the number HashStart to HashStop to a node. To get the resulting block hash, you need to resend the getheaders message. This message is used to quickly download blockchain that does not contain related transactions.

### Headers

| Size | field | data type | description |
| ---- | ------- | -------- | ---- |
Headers | header[] | Block header |

After the node receives the getheaders message, it returns a headers message as the response, providing the requested block header.

### Getblocks

| Size | field | data type | description |
| ---- | --------- | --------- | ----------------- |
| 32 *? | HashStart | uint256[] | Node is known as the latest block hash
| 32 | HashStop | uint256 | Request the last block of the hash |

Requests a inv message containing a number from the HashStart to the HashStop block list to a node. If HashStart to HashStop block more than 500, then cut off at 500. To get the following block hash, you need to resend the getblocks message.

### Inv

| Size | field | data type | description |
| ---- | ------ | --------- | ---- |
| 1 | Type | uint8 | Listing Type |
| 32 *? | Hashes | uint256[] | list |

The node can broadcast the object information it owns, using this message. This message can be sent automatically, or it can be used to answer getblocks messages.

The list types are the following:

| Value | name | description |
| ---- | --------- | ---- |
| 0x01 | TX | Trading |
| 0x02 | Block | Block
| 0xe0 | Consensus | consensus data |

### Getdata

| Size | field | data type | description |
| ---- | ------ | --------- | ---- |
| 1 | Type | uint8 | Listing Type |
| 32 *? | Hashes | uint256[] | list |

Requests a specified object to a node, which usually sends an inv packet and filters out the known element.

### Block

| Size | field | data type | description |
| ---- | ----- | ----- | ---- |
Block | block | block |

Send a block to a node that responds to the getdata message of the requested data.

### Tx

| Size | field | data type | description |
| ---- | ----------- | ---- | ---- |
| ? | Transactions | tx | Transactions |

Send a transaction to a node to respond to the getdata message of the requested data.

| Size | field | data type | description |
| ---- | --------- | --------- | ----------------- |
| 32 *? | HashStart | uint256[] | node is known as the latest block hash |
| 32 | hashStop | uint256 | request the last block |
