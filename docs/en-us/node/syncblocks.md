# Synchronizing the blockchain faster

The client must be fully synchronized before use. In order to speed up network synchronization you can download an offline package of the blockchain data up to a certain block height. This means the client will only need to sync the additional blocks from the Neo network rather than the entire blockchain.

## Step 1 - Download the offline package

1. Close the Neo client and go to [offline synchronized package](https://sync.ngd.network/) downloading page.

2. From the offline package downloading page, click **N3 Mainnet** or **N3 Testnet** according to your network and then download one of the following packages (no need to unzip the package):

   - **Full offline package**: contains the most complete blockchain data. It is applicable to the client running for the first time. The download file is chain.0.acc.zip.
   - **Increment offline package**: contains data in the range from starting height to ending height of the package. It is applicable to the client which has been synchronized up to the block height within the increment offline package coverage. The download file is chain.xxx.acc.zip, where xxx is the package starting height, e.g. chain.378997.acc.zip.

   ![](../../zh-cn/node/assets/sync_01.png)

## Step 2 - Place the offline package

> [!Warning]
>
> You must not change the default offline package file name (chain.acc.zip or chain.xxx.acc.zip) , otherwise it will not work for synchronization.

For Neo-CLI:

Place the downloaded package (chain.0.acc.zip or chain.xxx.acc.zip) under the Neo-CLI root folder, as shown below:

![](../../zh-cn/node/assets/sync_02.png)

For Neo-GUI:

Place the downloaded package (chain.0.acc.zip or chain.xxx.acc.zip) under the Neo-GUI\resources\build-neo-node folder, as shown below:

![](../../zh-cn/node/assets/sync_05.png)

## Step 3 - Check the client synchronization status

Run the client again and check the blocks downloading status：

- For Neo-CLI，enter `open wallet <path>` to open a wallet, and then enter `show state` to check the blocks downloading status. When you see the connected nodes is 0 and the synchronizing speed is greatly accelerated, that means the offline package is working. When the connected nodes appear, it indicates the synchronization is completed.

  ![](../../zh-cn/node/assets/sync_03.png)

  ![](../../zh-cn/node/assets/sync_04.png)

- For Neo-GUI, you can see the client is now synchronized faster. 

  ![](assets/sync_06.png)

> [!Note]
>
> - The client cannot be reached during the process when it is synchronizing with the offline package, thus the connected nodes is 0 and you cannot invoke APIs from the client until it has completed synchronization.
> - You can also use the Neo-CLI command `export blocks`, to export the entire blockchain data to a package or export the specified number of block data from the specified block height . For more information, see [CLI Command Line](cli/cli.md).