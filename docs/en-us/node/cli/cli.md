# CLI Command Reference

Open the command line, navigate to the directory where NEO-CLI is located, and enter the following code to start the command line wallet (ie the NEO node).

`dotnet neo-cli.dll`

This tutorial will introduce all the commands in the command line wallet. You can manipulate your wallet with commands for creating a wallet, importing and exporting of private key, transferring, starting consensus, etc.

To view all the commands, enter `help` in the command line.

> [!Note]
>
> - Angular brackets `<>` indicate a parameter.
> - Square brackets `[]` is for optional parameters.
> - The pipe symbol `|` separates multiple parameters where any one of them can be used at your choice.
> - The equal sign `=` indicates the default value of the optional parameter without an input.

## Console Commands

| Command      | Function Description      |
| ------- | --------- |
| version | Shows the current software version |
| help    | Help menu      |
| clear   | Clear screen      |
| exit    | Exit program      |

## Contract Commands

| Command                 | Function Description |
| ----------------------- | -------------------- |
| deploy <avmFilePath>... | Deploy a contract    |
| invoke <scripthash>...  | Invoke a contract    |

### Command Description

👉 `deploy <avmFilePath> <paramTypes> <returnTypeHexString> <hasStorage (true|false)> <hasDynamicInvoke (true|false)> <isPayable (true|false) <contractName> <contractVersion> <contractAuthor> <contractEmail> <contractDescription>`

 To deploy a contract: 

```
neo> deploy Template.avm 0710 05 true false false aws 1.0.0 owen neo@neo.org hello 
Script hash: 0xee91a961c1464d43c4e80a44a447698973cb818b 
VM State: HALT
Gas Consumed: 500
Evaluation Stack: [{"type":"InteropInterface"}]

Signed and relayed transaction with hash=0x81dae9680b75befb450920bdc8693cba34c913aa421cd1226ed1620555c95f23
```

 👉 `invoke <scripthash> <command> [optionally quoted params separated by space]`

 To invoke a contract:

```
neo> invoke ee91a961c1464d43c4e80a44a447698973cb818b deploy
Invoking script with: '00c1066465706c6f79678b81cb73896947a4440ae8c4434d46c161a991ee'
VM State: HALT
Gas Consumed: 2.191
Evaluation Stack: [{"type":"Integer","value":"1"}]

relay tx(no|yes): yes
Signed and relayed transaction with hash=0x69edfe59bd1cfdb8fecc7eb5623bc44d785a4897cdbee78f9d276924d9ad3946
```

## Wallet Commands

Command | Function Description | Remarks |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | Create a wallet file |
| open wallet \<path> | Open a wallet file |
| close wallet | Close the current wallet |
| upgrade wallet \<path> | Upgrade old wallet files| |
| rebuild index |Rebuild the wallet index | Need to open wallet |
| list address | list all the accounts in the wallet | Need to open wallet |
| list asset | List all assets in the wallet | Need to open wallet |
| list key | List all public keys in your wallet | Need to open wallet |
| show utxo \[id\|alias] | List UTXO of the specified asset in the wallet | Need to open wallet |
| show gas | List all the GAS in your wallet | Need to open wallet |
| claim gas \[all] | Claim the available GAS in your wallet | Need to open wallet |
| create address [n = 1] | Create address / batch create address | Need to open wallet |
| import key \<wif\|path> | Import private key / bulk import of private keys | Need to open wallet |
| export key \[address] [path] | Export private key | Need to open wallet |
| send \<id\|alias> \<address> \<value> [fee=0]| Send to the specified address |Need to open wallet |
| import multisigaddress m pubkeys... | Create a multi-signature contract |Need to open wallet |
| sign \<jsonObjectToSign> | Sign the transaction. The parameter is the json string that records the transaction information | Need to open wallet |
| relay \<jsonObjectToSign> | Broadcast the transaction. The parameter is the json string that records the transaction information | Need to open wallet |

The following commands are explained in detail:

👉 `upgrade wallet <path>` 

This command is used to upgrade the old wallet files.

```
neo>upgrade wallet cli.db3
Wallet file upgrade complete. Old file has been auto-saved at: cli.old.db3
```

👉 `rebuild index`

This command is used to rebuild the wallet index, which forces the wallet to sync up transactions from the block height of 0. Rebuilding the wallet index is not for a newly created wallet but for the cases when you import a private key or the assets in your wallet is not displayed properly. 

Additionally, in the event that the transaction in your wallet is not confirmed for some reason, but the assets have already been deducted and this is not confirmed by the whole blockchain, you can remove the unconfirmed transaction to show the asset amount correctly by rebuilding the wallet index.

👉 `show utxo [id|alias]`

This command is used to list the UTXO of the specified assets, as shown below:

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

👉 `show gas` 

This command is used to list all the gas in your wallet. The result is as shown below:

```
unavailable: 133.024
  available: 10.123
```

Where `unavailable` represents the GAS that cannot be claimed and `available` represents the claimable GAS. 

> [!Note]
>
> - This command does not show the GAS that has been claimed. Use `list asset` instead.
> - GAS has two status, available and unavailable. Once NEO is spent (i.e. transferred out) from the account, the relevant GAS turns to available. Therefore you can transfer GAS to your own account to make them available.
>

👉 `claim gas[all]` 

This command is used to claim available GAS in your wallet. The execution is carried out by a special  Claim Transaction. The client will print the Claim Transaction ID after you enter the command. 

If no parameter is appended, GAS from the first 50 addresses in the wallet is claimed. If `all` is specified, all the GAS in the wallet is claimed.

After executing  `claim gas`, you will find GAS has been increased in the result of `list asset`.

👉 `create address [n = 1]`

This command is used to create a new address. One can also enter 'create address 100' to create 100 new addresses in batches; Batch creation of the address will be automatically exported to the address.txt file.

👉 `export key [address] [path]`

You can specify which addresses to export the corresponding private keys to. You can also specify the export to the specified file. (See below for examples). The command also requires the verification of the wallet password.

Export key

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉 `import key <wif | path>`

When importing the private key, you can specify to import a private key, or import a file with a number of private keys. (The following commands are legal)

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

If there is a specified file, the file is in the private key format. Refer to export key key.txt output.

👉 `send <id | alias> <address> <value> [fee = 0]`

For transfers, there are a total of four parameters. The first parameter is the asset ID, the second parameter is the payment address, the third parameter is the transfer amount, and the fourth parameter is the fee. (This parameter can be left empty, and the default is 0) The command needs to verify the wallet password. For example, in order to transfer 100 NEO to the address "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", one would need to enter the following command.

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

If you are not sure of the asset ID, please enter the list asset command to view all assets in the wallet.

👉 `import multisigaddress m pubkeys...`

The command is used to create a multi-party signed address. m is the minimal number of signatures. For example, creating a multi-party signed address with two public keys, m can be 1 or 2, and the parameter followed are the two parties public keys.

For example:

```
import multisigaddress 1 037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630d 03b34a4be80db4a38f62bb41d63f9b1cb664e5e0416c1ac39db605a8e30ef270cc
```

👉 `sign <jsonObjectToSign>` 

This command is used to sign when withdrawing assets from a multi-signed address which requires multiple signatures. The parameter is the json string that records the transaction information. The translation can be broadcasted only after signing is completed.

👉 `relay <jsonObjectToSign>` 

After signing completed, this command can be used to broadcast the transaction information.  The parameter is the json string that records the transaction information. 

## Plugin Commands

| Command                 | Function Description           |
| ----------------------- | ------------------------------ |
| plugins                 | List loaded plugins            |
| install [Plugin name]   | Install the specified plugin   |
| uninstall [Plugin name] | Uninstall the specified plugin |

👉 `plugins`

This command is used to list all the loaded plugins.

```
neo> plugins
Loaded plugins:
RpcSystemAssetTrackerPlugin
RpcNep5Tracker
RpcSecurity
StatesDumper
CoreMetrics
ImportBlocks
RpcWallet
ApplicationLogs
SimplePolicyPlugin
```

👉 `install [Plugin name]`

Following are examples for Installing a plugin. The uninstallation operation is similar.

```
neo>install ImportBlocks
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ImportBlocks.zip
Install successful, please restart neo-cli.
```

```
neo>install ApplicationLogs
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ApplicationLogs.zip
Install successful, please restart neo-cli.
```

For information about all plugins refer to  [Install Plug-ins](setup.md).

## View the node information

Command | Function Description |
| ---------- | ----------------------- |
show state | Displays the current status of blockchain synchronization
show node | Displays the address and port of connected nodes |
show pool | Display the transactions in the memory pool (These transactions are in the state of zero confirmation)
export blocks [path=chain.acc] | Exports the whole blockchain data. The exported data  can be used for offline synchronzation. |
export blocks \<start> [count] | Exports a specified number of block data from the specified block height. The exported data can be used for offline synchronization.

## Advanced Commands

Command | Function Description |
| --------------- | ---- |
| broadcast addr <ip> <port> | Relay an `addr` message |
| broadcast block <hash\|height> | Relay a `block` message |
| broadcast tx \<hash> | Relay a `tx` message |
| broadcast getdata \<inventory type> \<hash> | Relay a `getdata` message |
| broadcast inv \<inventory type> \<hash> | Relay an `inv` message |
| broadcast getblocks \<start hash> | Relay a `getblocks` message |
| broadcast getheaders \<start hash> | Relay a `getheaders` message |
| invoke \<script hash> \<command> [param 1] [param n] | Invoke a command on a smart contract |
| change view \<view number> | Set view of consensus to specific value |
Start consensus | Begin consensus 
Start the consensus on the premise that the wallet has a consensus authority, allows consensus authority to be obtained on the main net through voting. If a private chain is deployed, public key of the consensus can be set up in the `protocol.json`. Please refer to [Private chain](../../network/private-chain/solo.md) for further details.
