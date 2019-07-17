# Installing the NEO-GUI Client

> [!Note]
>
> Unless otherwise stated,  this article introduces the NEO-GUI running on the test net. For more information, refer to [Test Network](../../network/testnet.md).

## Downloading the client

Download [NEO-GUI](https://neo.org/download) and extract the files to a location of your choice, then double-click neo-gui.exe to run the client. If there are any problems with the process and the client cannot be used normally, please keep the error.log file located in the same directory as NEO-GUI, then contact our technical staff to assist you in solving the problem.

> [!Note]
>
> The NEO-GUI client is compatible with the following versions of Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
>
> You must install [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework) on your windows system.

## Installing plugin

You need to install the [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ImportBlocks.zip) plugin to enable NEO-GUI to synchronize with the offline package.

1. Download [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ImportBlocks.zip) and unzip it.
2. Create a new Plugins folder (The first letter is capitalized) under the NEO-GUI root directory and copy the unzipped plugin into it. 

## Synchronizing blockchain data

The client must be fully synchronized before use. In order to speed up network synchronization you can download an offline package of the blockchain data up to a certain block height.  This means the client will only need to sync the additional blocks from the NEO network rather than the entire blockchain. For more information,  see [Synchronizing the blockchain faster](../syncblocks.md).
