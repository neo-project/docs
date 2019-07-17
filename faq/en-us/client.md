# Clients

## Why didn't I see any change in the account after I transferred assets to it using NEO-GUI?

Firstly check the transaction record in NEO-GUI to see if the transfer transaction has been confirmed. If confirmed, then check if your client has been synchronized up to the latest block height and rebuild the wallet index if the problem still exists.  

## Why doesn't the downloaded offline package work?

Read the instructions in [Synchronizing the blockchain faster](../../docs/en-us/node/syncblocks.md) and make sure the following:

- You have downloaded the proper package
- You have directly placed the downloaded file (chain.0.acc.zip or chain.xxx.acc.zip) under the root directory of NEO-CLI or NEO-GUI without modifying the file name
- You have installed the [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip) plugin.

## How do I know my client has been fully synchronized?

Use the blockchain browser to check the latest block height and then look at the wallet height in your client. If the two heights are the same, your client is fully synchronized. 

## How to make a watch-only wallet？

In NEO-CLI create a new address, then right-click to import the watch-only address and enter the address you want to monitor. Then you can see each transaction information in the transaction record. You need to rebuild the wallet index after importing the address.

## Is it possible to transfer assets to multiple addresses in one transaction?

Yes. Refer to [Transactions](../../docs/en-us/node/gui/transc.md).

## What are the hardware requirements for the computer running NEO node in the main net?

A dual-core CPU, 8G memory, and a solid state drive with a minimum of 100G or more are required. The hard disk needs to be expanded on demand to prevent the inode from overflowing.

## Is it possible to start NEO-CLI from background？

You can write some scripts, such as creating a Notepad file on Windows, typing `dotnet neo-cli.dll /rpc` and saving it as a .cmd file or using the screen command on linux.