# CLI Command Reference

Open the command line, navigate to the directory where the program is located, and enter the following code to start the command line wallet (ie, the AntShares node).

`dotnet AntSharesDaemon.dll`

This tutorial will introduce all the commands in the command line wallet. You can manipulate your wallet with commands for creating a wallet, importing and exporting of private key, transferring, starting a consensus, and so on.

We will first explore the various commands listed in the command line. In the command line, enter `help` followed by a carriage return, and you will see a list of orders as shown.

![image](http://docs.antshares.org/images/2017-05-17_12-30-05.jpg)

The following is a description of all the commands, the order of the brackets ``<> ```is the parameter, square brackets`[] `is optional parameters, and the symbol` | `displays the fill parameters can be any of any type, the equal sign `=` indicates the default value of the optional parameter without input.`

## 1. Console Instructions

| Command      | Function Description      |
| ------- | --------- |
| version | shows the current software version |
| help    | help menu      |
| clear   | clear screen      |
| exit    | exit program      |

## 2. Wallet operation

Command | Function Description | Remarks |
| ---------------------------------------- | -------- ------------------------ | ------ |
Create wallet \ <path> | create wallet file |
Open wallet \ <path> | open wallet file
Rebuild wallet index | need to open wallet
List all the accounts in the wallet | need to open the wallet
| List asset | list all assets in the wallet | need to open the wallet
List key | List all public keys in your wallet | Need to open wallet
Create address [n = 1] | create address/batch create address | need to open wallet |
| Import key \ <wif \ | path> | import private key/bulk import of private keys | need to open wallet |
Export key \ [address] [path] | export private key | need to open wallet |
Send to the specified address transfer parameters are: asset ID, the other party address, transfer amount, fee | need to open the wallet |

The following commands is explained in detail:

👉 `rebuild index`

Rebuild the wallet index. Why is it necessary to rebuild the wallet index?

There is a field in the wallet that records the height of the current wallet sync block. For each new one, the wallet client synchronizes the blocks and updates the assets and transactions in the wallet. Assuming that the currently recorded block height is 100, then you execute the import key command to import the private key, and the wallet still calculates your asset from the block height of 100. If the imported address has some transactions when the block height is less than 100, the transactions and the corresponding assets will not be reflected in the purse, so the wallet index should be rebuilt, forcing the wallet to calculate your assets from the block height of 0.

The newly created wallet does not need to rebuild the wallet index, only the imported private key is required to rebuild the wallet index.

👉 `create address [n = 1]`

You can enter create address to create a new address, you can also enter create address 100 to create 100 new addresses in batches; Batch creation of the address will be automatically exported to the address.txt file.

👉 `export key [address] [path]`

You can specify which addresses to export the corresponding private keys to. You can also specify the export to the specified file. (For example, the following command is legal) The command also requires the verification of the wallet password.

Export key

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉 `import key <wif | path>`

When importing the private key, you can specify to import a private key, or import a file with a number of private keys. (The following order is legal)

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

If there is a specified file, the file is in the private key format. Refer to export key key.txt output.

👉 `send <id | alias> <address> <value> [fee = 0]`

For transfers, there are a total of four parameters. The first parameter is the asset ID, the second parameter is the payment address, the third parameter is the transfer amount, and the fourth parameter is the fee (This parameter can be left empty, the default is 0) The command needs to verify the wallet password. For example, in order to transfer 100 antshares to the address "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", I would need to enter the following command.

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

If you are not sure of the asset ID, please enter the list asset command to view all assets in the wallet.

## 3. View the node information

Command | Function Description |
| ---------- | ----------------------- |
Show state | Displays the current status of blockchain synchronization 
Show node | Displays the address and port of connected nodes |
Show pool | Display the transactions in the memory pool (These transactions are in the state of zero confirmation)
## 4. Advanced instructions

Command | Function Description |
| --------------- | ---- |
Start consensus | Begin consensus
Start the consensus on the premise that the wallet has a consensus authority, allows consensus authority to be obtained on the main net through voting. If a private chain is deployed, public key of the consensus can be set up in the `protocol.json`. Please refer to [Private chain](private-chain.md) for furher details.
