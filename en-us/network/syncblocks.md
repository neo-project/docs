# Synchronizing the blockchain faster

The client must be fully synchronized before use. In order to speed up network synchronization you can download an offline package. NEO official website provides two types of offline package:

- Full offline package: contains all blockchain data since 0 block height in the format of chain.acc  or chain.0.acc. It is applicable to the client running for the first time as well as the client which hasn't been synchronized up to the data range provided by increment offline packages.
- Increment offline package: contains the data in a block height range to speed up synchronization of the client to the end height of the incremental package. It is applicable to the client which has been synchronized up to the block height within the increment offline packages coverage. The incremental package format is chain.xxx.acc, where xxx is the incremental package starting height. For example, chain.2600000. acc is the package exported from the height of 2.6 million blocks.

Suppose you are using windows, you need to do the following:

1. Close the NEO client and click [Download offline synchronized package](http://sync.ngd.network/) from the [Client Downloads](https://neo.org/download) page.

2. Download the full offline package or increment offline package according to your network, and then place the zip package (chain.acc.zip or chain.xxx.acc.zip) under the folder where the client executive program (neo-gui.exe or neo-cli.exe) is located. 

   > [!Note]
   >
   > - You must neither change the default offline package file name  (chain.acc.zip or chain.xxx.acc.zip) nor unzip the package , otherwise it will not work for synchronization.
   >
   > - For NEO-CLI clients earlier than 2.9.0, the client cannot be reached as it is synchronizing with the offline package, thus the connected nodes is 0 and you cannot invoke APIs from the client until it has completed synchronization.

3. Run the client and check the blocks downloading status.

   - For NEO-GUI，You can see the client is now synchronized up to a certain point and the client will now continue synchronizing the rest of the blockchain. The data beside "Height" corresponds to wallet height/synchronized blockchain height/blockchain header height. 

   ![](../../assets/gui_1.png)

   - For NEO-CLI，enter  `open wallet <path>` to open a wallet, and then enter  `show state` to check the blocks downloading status. When you see the connected nodes is 0 and the synchronizing speed is greatly accelerated, that means the offline package is working. When the three values after "Height" get to the same, it indicates the synchronization is almost completed.

     ![](../../assets/cli_sync.png)

You can also use the NEO-CLI command `export blocks`, to export the entire blockchain data to a package or export the specified number of block data from the specified block height . For more information,  see [CLI Command Line](../node/cli/cli.md).