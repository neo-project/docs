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

#### Contract Commands

| Command           | Parameters                                                   | Description        |
| ----------------- | ------------------------------------------------------------ | ------------------ |
| [deploy](#deploy) | \<nefFilePath> [manifestFile]                                | Deploys a contract |
| [invoke](#invoke) | \<scripthash> \<command> [optionally quoted params separated by space] | Invokes a contract |

#### Wallet Commands

| Command                                           | Parameters                                     | Description                                                  |
| ------------------------------------------------- | ---------------------------------------------- | ------------------------------------------------------------ |
| [create wallet](#create-wallet)                   | \<path>                                        | Creates a wallet file.                                       |
| [open wallet](#open-wallet)                       | \<path>                                        | Opens a wallet file.                                         |
| close wallet                                      |                                                | Closes the current wallet.                                   |
| [upgrade wallet](#upgrade-wallet)                 | \<path>                                        | Upgrades old wallet files.                                   |
| [rebuild index](#rebuild-index)                   |                                                |                                                              |
| list address                                      |                                                | lists all the accounts in the wallet.<br>Need to open wallet. |
| list asset                                        |                                                | Lists all assets in the wallet.<br/>Need to open wallet.     |
| list key                                          |                                                | Lists all public keys in your wallet.<br/>Need to open wallet. |
| [show utxo](#show-utxo)                           | [id\|alias]                                    |                                                              |
| [show gas](#show-gas)                             |                                                | Lists all the GAS in your wallet.<br/>Need to open wallet.   |
| [claim gas](#claim-gas)                           | [all]                                          |                                                              |
| [create address](#create-address)                 | [n is a positive integer and defaults to 0]    | Creates address / batch create address<br/>Need to open wallet. |
| [import key](#import-key)                         | \<wif\|path>                                   | Imports a private key / bulk import of private keys.<br/>Need to open wallet. |
| [export key](#export-key)                         | \[address] [path]                              | Exports private keys.<br/>Need to open wallet.               |
| [send](#send)                                     | \<id\|alias> \<address> \<amount>\|all [fee=0] | Sends assets to the specified address.<br/>Need to open wallet. |
| [import multisigaddress](#import-multisigaddress) | \<m pubkeys>                                   | Creates a multi-signature contract.<br/>Need to open wallet. |
| [sign](#sign)                                     | \<jsonObjectToSign>                            | Signs the transaction. The parameter is the json string that records the transaction information.<br/>Need to open wallet. |

#### Node Commands

| Command         | Parameters          | Description                                                  |
| --------------- | ------------------- | ------------------------------------------------------------ |
| show state      |                     | Displays the current status of blockchain synchronization.   |
| show node       |                     | Displays the address and port of connected nodes             |
| show pool       | [verbose]           | Displays the transactions in the memory pool (These transactions are in the state of zero confirmation). |
| [relay](#relay) | \<jsonObjectToSign> | Broadcasts the transaction. The parameter is the json string that records the transaction information. |

#### Plugin Commands

| Command                             | Parameters       | Description                                                  |
| ----------------------------------- | ---------------- | ------------------------------------------------------------ |
| [plugins](#plugins)                 |                  | Lists loaded plugins                                         |
| [install](#install)                 | [Plugin name]    | Installs the specified plugin                                |
| [uninstall](#install)               | [Plugin name]    | Uninstalls the specified plugin                              |
| [export block[s]](#export-block-s-) | [path=chain.acc] | Exports the whole blockchain data. The exported data  can be used for offline synchronzation. |
| [export block[s]](#export-block-s-) | \<start> [count] | Exports a specified number of block data from the specified block height. The exported data can be used for offline synchronization |

#### Advanced Commands

| Command                      | Description      |
| ---------------------------- | ---------------- |
| [start consensus](#d320b143) | Starts consensus |

## Command Description

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

`invoke <scripthash> <command> [optionally quoted params separated by space]` 

##### Parameters

- `scripthash`：Contract hash to invoke.
- `command`：Method name in the contract, which can be followed by input parameters separated by space. 

##### Example

```
neo> invoke 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6 name
Invoking script with: '00c1046e616d6514c6e5db4c428dfa9546c92bd8ae30f69a7be25c1e68627d5b52'
VM State: HALT
Gas Consumed: 4320950
Evaluation Stack: [{"type":"ByteArray","value":"6e616d656f66746865746f6b656e"}]

relay tx(no|yes): no
```

```
neo> invoke 43cf98eddbe047e198a3e5d57006311442a0ca15 balanceOf 91b83e96f2a7c4fdf0c1688441ec61986c7cae26
Invoking script with: '1426ae7c6c9861ec418468c1f0fdc4a7f2963eb89151c10962616c616e63654f661415caa04214310670d5e5a398e147e0dbed98cf4368627d5b52'
VM State: HAULT
Gas Consumed: 2007390
Evaluation Stack: [{"type":"Integer","value":"0008af2f"}]

relay tx(no|yes): n
```

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

### upgrade wallet

Upgrades the old .db3 wallet file into the .json format.

##### Syntax

 `upgrade wallet <path>` 

##### Example

```
neo> upgrade wallet test.db3
Wallet file upgrade complete. New wallet file has been auto-saved at: test.json
```

### rebuild index

This command is used to rebuild the wallet index, which forces the wallet to sync up transactions from the block height of 0. Rebuilding the wallet index is not for a newly created wallet but for the cases when you import a private key or the assets in your wallet is not displayed properly. 

Additionally, in the event that the transaction in your wallet is not confirmed for some reason, but the assets have already been deducted and this is not confirmed by the whole blockchain, you can remove the unconfirmed transaction to show the asset amount correctly by rebuilding the wallet index.

### show utxo

Lists the UTXO of the specified assets.

##### Syntax

`show utxo [id|alias]`

##### Example

```
neo>show utxo neo
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:2
total: 1 UTXOs
neo>show utxo gas
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:1
total: 1 UTXOs
neo>show utxo 025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:0
total: 1 UTXOs
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

### claim gas

Claims available GAS in your wallet. The execution is carried out by a special Claim Transaction. The client will print the Claim Transaction ID after you enter the command. 

After executing  `claim gas`, you will find GAS has been increased in the result of `list asset`.

##### Syntax

`claim gas [all]` 

##### Parameters

`all`：Claims all the available GAS in the wallet. If not specified, GAS from the first 50 addresses in the wallet is claimed.

### create address

Creates a new address. One can also enter `create address 100` to create 100 new addresses in batches; Addresses are automatically exported to the address.txt file.

##### Syntax

`create address [n]` 

##### Parameters

`n`：Number of addresses to create. N is an integer and defaults to 1.

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

Imports a private key, or import a file with a number of private keys.

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

`send <id|alias> <address> <amount>|all [fee=0]`

##### Parameters

- `id|alias`：asset ID or asset abbreviations, e.g. neo，gas
- `address`：payment address
- `amount|all`：transfer amount
- `fee`：This parameter can be left empty, and the default is 0. Setting a fee improves the transaction priority.

##### Example

Transfers 100 NEO to the address  “AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e”：

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

This command is used to sign when withdrawing assets from a multi-signed address which requires multiple signatures.The translation can be broadcasted only after signing is completed.

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

### install

Installs plugins.

`install [Plugin name]` 

To install a plugin, enter the command as follows:

```
neo> install ImportBlocks
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/ImportBlocks.zip
Install successful, please restart neo-cli.
```

For information about all plugins refer to [Install Plug-ins](config.md).

### export block[s]

Exports the whole blockchain data or export the specified amount of block data from the specified block height.  The output can be used for offline synchronization. Before you can use this command you need to install the plugin ImportBlocks.

##### Syntax

`export block[s] [path=chain.acc]`

`export block[s] <start> [count]`

##### Parameters

`[path=chain.acc]`：Export the whole blockchain data.

`<start> [count]`：The height of the starting block  and the number of blocks to export data.

`dump storage <key>`

### start consensus

Start the consensus on the premise that the wallet has a consensus authority, allows consensus authority to be obtained on the main net through voting. If a private chain is deployed, public key of the consensus can be set up in the `protocol.json`. For more information refer to [Setting up Private Chain](../../network/private-chain/private-chain.md).




