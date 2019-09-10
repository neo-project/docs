# Client and Wallet

## Why can't I see any change in the account after I transfer assets to it using NEO-GUI?

Firstly check the transaction record in NEO-GUI to see if the transfer transaction has been confirmed. If confirmed, then check if your client has been synchronized up to the latest block height and rebuild the wallet index if the problem still exists.  

## How long does it take to synchronize my wallet?

- **NEO GUI wallet**: You can download the [offline package](https://sync.ngd.network/) of the blockchain data to speed up the sync process. The estimated synchronization time for each package can be found in that page. If you sync from height 0 (in other words: without any previous synchronization), it will take you several hours.
- **NEON wallet**: This is a light wallet and therefore does not require to download the entire blockchain. This makes synchronizing much faster.

## What is the difference between a light wallet like NEON, and the NEO GUI wallet?

The desktop client (NEO GUI) downloads the whole blockchain to your computer. Light wallets use an API to interact with the blockchain, thus requiring less storage space while still enabling you to make transactions on the blockchain.

## Why doesn't the downloaded offline package work?

Read the instructions in [Synchronizing the blockchain faster](../../docs/en-us/node/syncblocks.md) and make sure the following:

- You have downloaded the proper package
- You have directly placed the downloaded file (chain.0.acc.zip or chain.xxx.acc.zip) under the root directory of NEO-CLI or NEO-GUI without modifying the file name
- You have installed the [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip) plugin.

## How do I know my client has been fully synchronized?

You can check the height on a NEO blockchain explorer and compare it with your wallet. If the height of your wallet is the same as on the explorer, it means your wallet is fully synced; otherwise, it is not. 

## What size of storage space should I reserve for the wallet to be fully synchronized?

- **NEO GUI wallet**: at least 20 GB.
- **NEON wallet**: at least 250 MB.

## How to make a watch-only wallet？

In NEO-CLI create a new address, then right-click to import the watch-only address and enter the address you want to monitor. Then you can see each transaction information in the transaction record. You need to rebuild the wallet index after importing the address.

## Is it possible to transfer assets to multiple addresses in one transaction?

Yes. Refer to [Transactions](../../docs/en-us/node/gui/transc.md).

## What are the hardware requirements for the computer running NEO node in the main net?

A dual-core CPU, 8G memory, and a solid state drive with a minimum of 100G or more are required. The hard disk needs to be expanded on demand to prevent the inode from overflowing.

## Is it possible to start NEO-CLI from background？

You can write some scripts, such as creating a Notepad file on Windows, typing `dotnet neo-cli.dll /rpc` and saving it as a .cmd file or using the screen command on linux.

##I can't see my NEO in my wallet! Is it gone?

1. Most of the time,  whenever your NEO or GAS is not showing up in your wallet, the problem lies with the wallet. To make sure your NEO is safe, you can check your  balance on a NEO blockchain explorer, such as <https://neoscan.io/>.

2. Make sure your wallet is fully synchronized. If it is, and there is still no NEO in your wallet, then:

   - **NEO GUI wallet**: Re-index your wallet.

   - **Light wallet, e.g. NEON wallet**: Refresh your wallet.

##I have sent x amount of NEO/GAS to my wallet, but it has not arrived yet. Why?

1. Please confirm with the crypto currency exchange from which you made the transfer that the transaction was successful. If so:
2. Please check the status of your transaction/account on a blockchain explorer:

   - Once a transaction ID has been generated and the ID can be seen on the blockchain explorer, the transaction is successful and said amount has been transferred to your account. If the wallet does not display the correct balance, it is likely not fully synchronized. To check whether this is true, see preceding questions.
   - If you cannot find the transaction on the blockchain explorer, please contact the party sending said NEO/GAS, since the transaction was not completed.

## When I call the RPC method invoke, the result returned is not correct. Why?

It is an known issue. Please use the alternative method `invokefunction` instead. `invoke` will be deprecated in NEO3.
