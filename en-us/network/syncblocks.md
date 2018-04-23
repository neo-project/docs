# Synchronizing the blockchain faster

The client must be fully synchronized before use. In order to speed up network synchronization you can download an offline package of the blockchain data up to a certain block height.  This means the client will only need to sync the additional blocks from the NEO network rather than the entire blockchain. 

Suppose you are using windows, you need to do the following:

1. Download the package located at [Client Downloads](https://neo.org/download) according to your network and client: chain.acc.zip for main net or chain.acc.test.zip for test net.

2. Close the NEO client and copy chain.acc.zip to the folder where the client executive program (neo-gui.exe or neo-cli.exe) is located. 

   > [!Note]
   >
   > For the test net package chain.acc.test.zip, you need to rename the file to chain.acc.zip before placement.

3. Run the client and check the blocks downloading status.

   - For NEO-GUI，You can see the client is now synchronized up to a certain point and the client will now continue synchronizing the rest of the blockchain. The data beside "Height" corresponds to wallet height/synchronized blockchain height/blockchain header height. 

   ![](../../assets/gui_1.png)

   - For NEO-CLI，enter  `open wallet <path>` to open a wallet, and then enter  `show state` to check the blocks downloading status. You can see the client is downloading the block data at a very quick speed. When the three values after "Height" get to the same, it indicates the synchronization is almost completed.

     ![](../../assets/cli_sync.png)

You can also use the NEO-CLI command `export blocks`, to export the synchronized block data to a package. For more information,  see CLI Command Line.