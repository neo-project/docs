# CLI Command Reference

Open the command line, navigate to the directory where Neo-CLI is located, and enter the following code to start the command line wallet (i.e. the Neo node).

`dotnet neo-cli.dll`

This section will introduce all the commands in the command line wallet. You can manipulate your wallet with commands for creating a wallet, importing and exporting of private key, transferring, starting consensus, etc.

## Overview

The following tables list all the commands. You can also enter `help` in the command line to view them all.

All the commands described in this document conform with these conventions:

- `<>` indicate a parameter.
- `[]` is for optional parameters.
- `|` separates multiple parameters where any one of them can be used at your choice.
- `=` indicates the default value of the optional parameter without an input.

#### Console Commands

| Command      | Description      |
| ------- | --------- |
| version | Shows the current software version |
| help [plugin-name] | Help menu, which can also show plugin related commands. |
| clear   | Clear screen      |
| exit    | Exit program      |

#### Wallet Commands

| Command                                           | Parameters                             | Description                                                  |
| ------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [create wallet](#create-wallet)                   | \<path>                                | Creates a wallet file.                                       |
| [open wallet](#open-wallet)                       | \<path>                                | Opens a wallet file.                                         |
| close wallet                                      |                                        | Closes the current wallet.                                   |
| [upgrade wallet](#upgrade-wallet)                 | \<path>                                | Upgrades old wallet files.                                   |

The commands listed in the table below requires you to open the wallet before invoking.

| Command                                           | Parameters                             | Description                                                  |
| ------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [change password](#change-password)               | \<path>                                | Changes the wallet password                                  |
| list address                                      |                                        | lists all the accounts in the wallet.                        |
| list asset                                        |                                        | Lists all assets in the wallet.                              |
| list key                                          |                                        | Lists all public keys in your wallet.                        |
| [show gas](#show-gas)                             |                                        | Lists all the GAS in your wallet.                            |
| [create address](#create-address)                 | [n=1]                                  | Creates address / batch create address                       |
| [import key](#import-key)                         | \<wif\|path>                           | Imports a private key / bulk import of private keys.         |
| [export key](#export-key)                         | \[path] [address script hash]          | Exports private keys.                                        |
| [import multisigaddress](#import-multisigaddress) | \<m> \<pubkey1 pubkey2 ...>            | Creates a multi-signature contract.                          |
| [send](#send)                                     | \<id\|alias> \<address> \<amount>\|all | Sends assets to the specified address.                       |
| [sign](#sign)                                     | \<jsonObjectToSign>                    | Signs the transaction. The parameter is the json string that records the transaction information. |

#### Contract Commands

| Command           | Parameters                                                   | Description        |
| ----------------- | ------------------------------------------------------------ | ------------------ |
| [deploy](#deploy) | \<nefFilePath> [manifestFile]                                | Deploys a contract |
| [invoke](#invoke) | \<scripthash> \<command> \[optionally quoted params separated by space\] \[witness address separated by space\] | Invokes a contract |


#### Node Commands

| Command         | Parameters          | Description                                                  |
| --------------- | ------------------- | ------------------------------------------------------------ |
| show state      |                     | Displays the current status of blockchain synchronization.   |
| show pool       | [verbose]           | Displays the transactions in the memory pool (These transactions are in the state of zero confirmation). |

####Network Commands

| Command         | Parameters          | Description                                                  |
| --------------- | ------------------- | ------------------------------------------------------------ |
| [relay](#relay) | \<jsonObjectToSign> | Broadcasts the transaction. The parameter is the json string that records the transaction information. |
| [broadcast addr](#broadcast-addr) |  \<payload IP address> \<port>   | Broadcasts the IP address of the node |
| [broadcast block](#broadcast-block) |  \<block hash \| block height>  | Broadcasts a block |
| [broadcast getblocks](#broadcast-getblocks) |  \<block hash>  | Broadcasts the getblocks request |
| [broadcast getdata](#broadcast-getdata) |  \<inventory type> \<payload>  | Broadcasts the getdata request |
| [broadcast getheaders](#broadcast-getheaders) |  \<block hash>  | Broadcasts the getheaders request |
| [broadcast inv](#broadcast-inv) |  \<inventory type> \<payload>  | Broadcasts the inventory data |
| [broadcast transaction](#broadcast-transaction) |  \<transaction hash>  | Broadcasts a transaction |

#### Plugin Commands

| Command                       | Parameters    | Description                              |
| ----------------------------- | ------------- | ---------------------------------------- |
| [plugins](#plugins)           |               | Lists loaded plugins                     |
| [install](#install)           | [Plugin name] | Installs the specified plugin            |
| [uninstall](#install)         | [Plugin name] | Uninstalls the specified plugin          |
| [dump storage](#dump-storage) | \<key>        | Exports all or the specified state data. |

#### Advanced Commands

| Command                         | Parameters                             | Description                                                  |
| ------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [export blocks](#export-blocks) | \<start> \[block count] \[export path] | Exports the blockchain data from the specified block height. The exported data  can be used for offline synchronzation. |
| [start consensus](#d320b143)    |                                        | Starts consensus                                             |

## Command Description

### create wallet

Creates a wallet file in the .db3 or .json format. A wallet password is required to be specified during the process. 

##### Syntax

 `create wallet <path>` 

##### Example

```
neo> create wallet test.json
password: *
password: *
address: ATGBeteuYJsHwUVt6xMdxZMV9Y7BkV51yn
pubkey: 0399e96a2970c83e26ad66de36a4bad0512a62defd447e3e26723fac73d4072ba1
```

The wallet file is generated under the neo-cli root directory. If you want to set other path, you need to create the folder in advance.

### open wallet

Opens the wallet file at the specified path. The wallet password is required to be entered when opening the wallet.

##### Syntax

 `open wallet <path>` 

##### Example

```
neo> open wallet test.json
password: *
```

### change password

Changes the wallet password.

##### Syntax

 `change password` 

##### Example

```
neo> change password
password: ***
New password: ***
Re-Enter Password: ***
Password changed successfully
```

### upgrade wallet

Upgrades the old .db3 wallet file into the .json format.

##### Syntax

 `upgrade wallet <path>` 

##### Example

```
neo> upgrade wallet test.db3
Wallet file upgrade complete. New wallet file has been auto-saved at: test.json
```

### show gas

lists all the unclaimed GAS in the current wallet.

##### Syntax

`show gas` 

##### Example

```
neo> show gas
unclaimed gas: 0
```

> [!NOTE]
>
> This command does not show the GAS that has been claimed. Use `list asset` instead.

On Neo3, The GAS in an account is claimed automatically every time when the number of Neo in the account changes.  

### create address

Creates a new address. One can also enter `create address 100` to create 100 new addresses in batches; Addresses are automatically exported to the address.txt file.

##### Syntax

`create address [n]` 

##### Parameters

`n`：Number of addresses to create. n is an integer and defaults to 1.

##### Example

```
neo> create address 3
The file 'address.txt' already exists, do you want to overwrite it? (yes|no): yes
[3/3]
export addresses to address.txt
```

### export key

Exports private key of the address to the specified file. The command also requires the verification of the wallet password.

##### Syntax

 `export key [address] [path]`

##### Parameters

- `address`：Address to export private key.
- `path`：Path to the file used to store the private key.

##### Example

Exports the key to the console:

```
neo> export key
password: ********
L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
L3raEwVsJHzovTXfgVG1HWxzmH4Zm3vMia8byszhVrvbJ38YnsXv
KywrMAnBWRXUAb4Aq76ZoCCqDvGNL9nidjVwWwDr3DbMPwg1RPBL
KwhNLC9rULxJmevqwYbQzJhYNvaCDPyAUAm7EkHrW5kQwLYfxTFG
```

```
neo> export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9
password: ********
L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
```

Exports the key to the specified file:

```
neo> export key key1.txt
password: ********

```

```
neo> export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9 key2.txt
password: ********

```

### import key

Imports a private key, or  a file with a number of private keys.

##### Syntax

 `import key <wif|path>`

##### Parameters

`wif|path`：The key to import or the file path.

##### Example

```
neo> import key L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
address: AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9
 pubkey: 03768c9fc17a01854084b836d3f0ae4122902b4b59b6c11e855a3f3bf8ea6b205f
```

```
neo> import key key1.txt
```

If there is a specified file, the file is in the private key format. Refer to export key key.txt output.

### import multisigaddress

Creates a multi-party signed address. 

##### Syntax

`import multisigaddress m pubkeys...`

##### Parameters

- `m`：m is the minimal number of signatures. For example, creating a multi-party signed address with two public keys, m can be 1 or 2.
- `pubkeys`：Public keys of multiple parties involved.

##### Example

```
neo> import multisigaddress 1 022b386a0ac6fa5abad4bfabc7dff3c016654fa97176811cb64f4831284a7399ca 0288a99d33b6f7f1b19d3be7a7935d2c076fec52d9591336af03e43eec8ca1b16b
Multisig. Addr.: AYpc268sh4tff7CTj5W4tztt1qheVTUa6P
```

### send

Transfers the asset to the specified address. The command requires the verification of the wallet password.

##### Syntax

`send <id|alias> <address> <amount>|all `

##### Parameters

- `id|alias`：asset ID or asset abbreviations, e.g. neo，gas
- `address`：payment address
- `amount|all`：transfer amount

##### Example

Transfer 100 Neo to the address  “AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e”：

```
neo> send a1760976db5fcdfab2a9930e8f6ce875b2d18225 AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0x8f831d8de723093316c05749a053a226514bc06338b2bceb50db690610e0b92f
```

If you are not sure of the asset ID, you can enter `list asset` to view all assets in the wallet.

In above example, we can also replace the asset ID with asset abbreviation, as shown below:

```
neo> send gas AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0xae0675797c2d738dcadb21cec3f1809ff453ac291046a05ac679cbd95b79c856
```

When withdrawing assets from a multi-signed address, multiple signatures are required. A json string is returned requiring signatures, as shown below:

```
neo> send gas ARfyrX28D2H2wP6KR6xxaUbvqvkv5SbMNe 2
password: ********
SignatureContext:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature"},{"type":"Signature"}],"signatures":{"032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff00":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}}}}
```

### sign

This command is used to sign when withdrawing assets from a multi-signed address which requires multiple signatures. The translation can be broadcasted only after signing is completed.

##### Syntax

`sign <jsonObjectToSign>` 

##### Parameters

`jsonObjectToSign`：The json string that records the transaction information. 

##### Example

```
neo> sign {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature"},{"type":"Signature"}],"signatures":{"032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff00":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}}}}
Signed Output:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature","value":"794f87a810bd30b15f90ddc1898e2e592c1a3fae4b14e34d8a411305e7913d44ab56e388125ef597be46a8958b2ed8c5e298076c2d69ab3337c944f5356c462b"},{"type":"Signature","value":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}]}}}
```

### deploy

Deploys a contract on the blockchain.

##### Syntax

`deploy <nefFilePath> [manifestFile]` 

##### Parameters

- `nefFilePath`：Path to the executable file (.nef) of NeoVM.
- `manifestFile`：Path to the file manifest.json, which records each interface information and configuration content of the contract.

##### Example

```
neo> deploy Template.nef Template.manifest.json  
Script hash: 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6
Gas Consumed: 100000000

Signed and relayed transaction with hash=0xab6dd63ea36a7c95580b241f34ba756e62c767813be5d53e02a983f4e561d284
```

### invoke

Invokes a contract. 

##### Syntax

`invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]` 

##### Parameters

- `scripthash`: Contract hash to invoke.

- `command`: Method name in the contract, which can be followed by input parameters separated by space. 

- `contractParameters`: Parameters to invoke. You need to pass in JSON-formatted string. For ByteArray type, encode it with Base64 in advance. 

  For example, the address `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` can be converted to the hexadecimal big-endian script hash  `0xe4b0b6fa65a399d7233827502b178ece1912cdd4` or the Base64-encoded script hash `1M0SGc6OFytQJzgj15mjZfq2sOQ=`. The JSON-formatted parameters are:

  ```
  [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
  [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
  ```

- `witnessAddress` : An array of co-signed addresses and only supports standard accounts (single address). After filling in Neo-CLI will append signatures of all addresses in the array to the invocation transaction.

##### Example 1

Input:

```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 name
```
Output:

```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"TXlUb2tlbg=="}]

relay tx(no|yes):
```

- `VM State`：there are two states:
  -  `HALT` : the virtual machine executes successfully.
  -  `FAULT` : the virtual machine exits during execution due to an exception. 
- `Gas Consumed`：the system fees consumed for smart contract invocation.
- `Evaluation Stack`：shows the result of contract execution, where the value is encoded with Base64.

Input:

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
```

Output:

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

Output:

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
```

or

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"d4cd1219ce8e172b50273823d799a365fab6b0e4"}]
```

Output:

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

> [!Note]
>
> After entering the invoke command, the node invokes the `main` method of the contract rather than directly invokes the `operation` method, and passes `operation` and `contractParameters` as arguments. If `operation` and `contractParameters` are not processed in the `main` method, the expected result will not be returned.

### relay

After signing completed, this command can be used to broadcast the transaction information.  

##### Syntax

`relay <jsonObjectToSign>` 

##### Parameters

`jsonObjectToSign`：The json string that records the transaction information.

##### Example

```
neo> relay {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature","value":"794f87a810bd30b15f90ddc1898e2e592c1a3fae4b14e34d8a411305e7913d44ab56e388125ef597be46a8958b2ed8c5e298076c2d69ab3337c944f5356c462b"},{"type":"Signature","value":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}]}}}
Data relay success, the hash is shown as follows:
0xdcf144d9ed2d64482fb5caafa719cf6706e9afd607ab043e8bfcb9018795e4d1
```

### broadcast addr

Broadcasts the IP address of a block.

##### Syntax

`broadcast addr <IPAddress> <port>`

##### Example

```
neo> broadcast addr 127.0.0.1 10332
neo> 
```

### broadcast block

Broadcasts a block.

##### Syntax

`broadcast block <block-hash> `

`broadcast block <block-height> `

##### Example

```
neo> broadcast block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast block 537
neo> 
```

### broadcast getblocks

Broadcasts the getblocks request.

##### Syntax

`broadcast getblocks <block-hash> `

##### Example

```
neo> broadcast getblocks 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getheaders

Broadcasts the getheaders request.

##### Syntax

`broadcast getheaders <block-hash> `

##### Example

```
neo> broadcast getheaders 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getdata

Broadcasts the getdata request.

##### Syntax

`broadcast getdata <inventory type> <payload> `

##### Example

```
neo> broadcast getdata Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast getdata TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
neo> broadcast getdata Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
```

### broadcast inv

Broadcasts inventory data。

##### Syntax

`broadcast inv <inventory type> <payload> `

##### Example

```
neo> broadcast inv Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast inv TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
neo> broadcast inv Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
```

### broadcast transaction

Broadcasts a transaction.

##### Syntax

`broadcast transaction <transaction hash> `

##### Example

```
neo> broadcast transaction 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### plugins

Shows all the loaded plugins.

##### Syntax

`plugins`

##### Example

```
neo> plugins
Loaded plugins:
        ApplicationLogs
        LevelDBStore
        RpcServer
        RpcNep5Tracker
        StatesDumper
        SystemLog
```

### install

Installs plugins.

`install [Plugin name]` 

To install a plugin, enter the command as follows:

```
neo> install RpcServer
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v3.0.0-preview2-00/RpcServer.zip
Install successful, please restart neo-cli.
```

For information about all plugins refer to [Install Plug-ins](config.md).

### dump storage

Exports all or the specified state data.

##### Syntax

`dump storage <key>`

### export blocks

Exports the block data from the specified block height. The output can be used for offline synchronization. 

##### Syntax

`export blocks <index>`

##### Parameters

`<index> `：The height of the starting block from which the data is exported.

### start consensus

Starts the consensus on the premise that the wallet has a consensus authority, allows consensus authority to be obtained on the main net through voting. If a private chain is deployed, public key of the consensus can be set up in the `protocol.json`. For more information refer to [Setting up Private Chain](../../network/private-chain/private-chain2.md)。

> [!NOTE]
>
> If you wan to view the consensus log, install the plugin [SystemLog](https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2/SystemLog.zip) first.




