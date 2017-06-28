# Build a private chain with an ant node

In a previous tutorial, you learned how to setup and deply a node on Windows and Linux. This tutorial will teach you how to build a private chain or alliance chain, and the steps needed to extract AntShares and AntCoins from these private chains. 

The deployment of an AntShares private chain requires at least four servers to reach a consensus, where each server corresponds to a consensus node and a dedicated AntShares wallet.

## 1, Configuration of the virtual machine

The deployment of an AntShares private chain requires at least four servers to reach a consensus, where each server corresponds to a consensus node. For demonstration purposes, I have created four Windows virtual machines on Azure, the size is Standard DS1 v2 (1 core, 3.5 GB RAM). You will be able to deploy private chains on a LAN or virtual machine.

![image](http://docs.antshares.org/images/2017-05-17_15-18-43.jpg)

After creating, to open 10331-10334 port, the specific method for the system in the `firewall` `advanced setting` `inbound rules`, to establish new rules, and then add port 10331-10334.

> [!Note]
> If you create a virtual machine on a cloud server, log in to the virtual machine's administrative background, set up a network security group.
>
> Azure setup method is: `network interface` `network security group` `inbound security rules` `add` add port 10331-10334.

Once the virtual machine has been created, save the IP addresses of the four virtual machines for later use.

## 2, Installation of the AntShares node

The installation process of the AntShares node has been described in details above. Please refer to these installation instructions (setup.md).

## 3,Create a wallet

First, we have created four wallet files, namely wallet1.db3 - wallet4.db3. This step can be executed in both the PC version of the wallet and the command line wallet, where the following figure is a screenshot of the the command line client.

![image](http://docs.antshares.org/images/2017-05-17_11-17-30.jpg)

Once a wallet has been created and its corresponding public key saved, (ie. saved to a txt file), directly copy the public key or use the `list key` command in [CLI Command](cli.md) to view the public key and then copy it.

Afterwards, copy the four wallets to the four virtual machine node directory.

## 4, Modify the node's configuration file

Open the node's configuration file `protocol.json`.

First modify the `Magic` value. Magic is used to identify the source network of the message, and specifying a different Magic ensures that different network information in the AntShares block are not sent to other networks, during transmission.

> [!Note]
> The type of Magic is uint, so note that the value you fill in is in the range [0 - 4294967295].

Modify the `StandbyValidators`, and fill in the 4 public keys recorded in step 3, here.

Finally modify the `SeedList`, fill in the IP address recorded in the first step, and the port number remains unchanged. For example, I modified the following configuration.

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
    ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
    ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```

SystemFee is the system fee, the current fee is as follows (in units of ANC):

Registration for book-keepers - 1000, Distribution of Assets - 500 Smart Contracts 500, Register Assets - 10000

You can set the system fee for your private chain here.

Finally, modify the modified protocol.json to the 4-node client directory, replacing the previous protocol.json file.

Then in the four virtual machines, enter the following commands to start the node, open the wallet, open the consensus. Please do not remember the command [CLI Command Reference](cli.md).

Start node:

`Dotnet AntSharesDaemon.dll`

Open wallet:

`Open wallet wallet1.db3`

Note: Not all nodes here have to open wallet1, each node should open its own corresponding wallet file.

`Start consensus`

If the above operation is successful, then the four nodes will begin a consensus process, as shown

![image](http://docs.antshares.org/images/2017-05-17_14-58-10.jpg)

4 nodes that are turned off can still achieve consensus, as shown:

![image](http://docs.antshares.org/images/2017-05-17_14-57-51.jpg)



## 5, Extracting AntShares and AntCoins

Install the PC version of the client (AntSharesCore-GUI), modify the configuration file protocol.json to connect to the private chain.

Open the wallet. If the lower left corner of the connection number is non-zero, and has been synchronized to the same block, it means that the client has been successfully connected to the private chain.

Open the wallet wallet1.db3 in the PC client, add the multi-party signature address, enter the four public keys in protocol.json, set the minimum number of signatures to 3 (the number of consensus nodes/2 + 1), as shown.

![image](http://docs.antshares.org/images/2017-05-17_15-08-39.jpg)

Click OK. In order to rebuild the wallet index, click on the 'wallet' in the menu bar, and then you will see the contract address has 100 million AntShares shares.

![image](http://docs.antshares.org/images/2017-05-17_15-10-14.jpg)

> [!Note]
> All 4 wallets have to perform the operation of adding multi-party signature address, and rebuilding of the wallet index.

Here we want to send the ant shares from the contract address to the normal address. To do so, open any of the four wallet, click `transaction`, `transfer` and enter the recipient address, in order to transfer 100 million AntShares to this recipient address.

Then, the system will prompt "transaction structure is completed, but there is not enough signature". Copy down the code, open the second wallet, click `transaction`, `transfer`, and paste the code that you have just copied. Click `sign`, and copy the code down, open the third wallet, click on the `transaction`, `transfer` and paste the code that you have just copied. Click `sign`. At this time, you will notice a pop-up window that displays a `broadcast' button, which means the signing process for the transaction is completed (the minimum number of signatures required for the contract has been achieved) The transaction can now be broadcasted, click on the `broadcast'. Once the transfer transcation begins broadcasting, it will take about 15 seconds for successful remittance to the account.

![image](http://docs.antshares.org/images/2017-05-17_15-12-50.jpg)

The operation to extract the AntShares coin is also similar, click `advanced`, `claim ant-coin`, `claim` as shown. (Remember all the wallets X, you will need it later)

![image](http://docs.antshares.org/images/2017-05-17_15-13-29.jpg)

The next operation is similar to the transfer of the AntShares. Copy down the code that has insufficient signatures, open the second wallet, click `transaction`, `transfer`, and paste the code that you have just copied. Click `sign`, and copy the code down, open the third wallet, click on the `transaction`, `transfer` and paste the code that you have just copied. Click `sign` and `broadcast' to broadcast the transaction of claiming AntCoins. Once the claim transaction begins broadcasting, it will take about 15 seconds for successful remittance to the account.
After the successful extraction, the AntCoins will enter the first standard address of the wallet (ie, the top X wallet) of the exchange where you initiate the extraction of the AntShares coins, as shown.

![image](http://docs.antshares.org/images/2017-05-17_15-15-45.jpg)
