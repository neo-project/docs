# Frequently Asked Questions (FAQ)

## The basics

**What is NEO？**

NEO is a distributed network which utilizes blockchain technology and digital identity to digitize assets and automate the management of digital assets using smart contracts. NEO network has two tokens, NEO representing the right to manage NEO blockchain and GAS representing the right to use the NEO Blockchain. 

**What developer communities does NEO have?**

NEO has a large number of worldwide developer communities that have been contributing to NEO development for a long time. Following are some representative communities:

- **CoZ**，the earliest developer community in NEO ecosystem: https://github.com/CityOfZion
- **NEL**，the first Chinese developer community in NEO ecosystem: https://github.com/NewEconoLab
- **NeoResearch**，the South American developer community：https://github.com/NeoResearch
- **NSPCC**，the St. Petersburg developer community, russia：https://www.nspcc.ru/en/
- **KeyMakers**，the Japanese developer community：https://github.com/keymakers

**What is GAS？How to acquire GAS？**

GAS represents the right to use the Neo Blockchain. NEO network charges GAS for the new assets issuance as well as for smart contract running and storage. In the genesis block GAS is 0 and it is generated as new blocks generate. Once NEO is acquired, GAS is generated in the system following the algorithms. GAS has two status, available and unavailable. Once NEO is spent (i.e. transferred out) from the account, the relevant GAS turns to available. NEO holders can initiate a claim transaction at any time to claim available GAS to the NEO address.

**Can I transfer GAS to my own account to make it claimable?** 

Yes. You can do that even if there is just one address in your wallet.

**What consensus algorithms does NEO use？**

NEO utilizes a delegated Byzantine Fault Tolerance (dBFT) algorithm which provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. 

There are two types of nodes in this mechanism, the ordinary node and the consensus node. Ordinary nodes vote for consensus nodes based on the proportion of NEO they own. When a consensus needs to be passed, a speaker is randomly selected to decide the proposal, and then other consensus nodes vote according to the dBFT algorithm. If more than 2/3 of nodes agree to the proposal, the consensus is reached; otherwise, the speaker is re-elected and the voting process is repeated.  

**How to become a NEO consensus node？Is there any incentives？**

NEO consensus nodes are elected by NEO holders. For more information see https://neo-ngd.github.io/reference/How-To-Become-NEO-Consensus-Node.html

**What browsers are available for NEO blockchain?**

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

**What is the difference between ordinary assets and NEP-5 assets?**

NEO has two asset types. One is global assets which manages assets using the UTXO model. The other is NEP-5 assets which manages assets using the BALANCE model. Both NEO and GAS are UTXO assets that can be traded directly. NEP-5 is a contract asset that is traded by invoking the smart contract. You can use NEO-GUI to register and issue a new UTXO asset. To issue a new NEP-5 asset you need to write a smart contract.

**How to view NEP-5 assets in NEO-CLI？**

In NEO-CLI you can just list UTXO assets using `list asset`. To view NEP-5 assets invoke the API `getbalance`.

**What is the difference between NEP-5 and NEP-6？**

NEP-5 is a token standard that specifies the token issuance in NEO smart contract. NEP-6 is a wallet standard that specifies the wallet format, the definition of parameters in it, the creation rules of wallet address and so on. NEP-6 is applicable to several current NEO client versions including 2.7.6. The NEO client supports wallets in two formats,  sqlite wallet (in .db3) and NEP-6 wallet (in .json). Considering the processing speed, the sqlite wallet is strongly recommended for exchanges. 

## Clients

**Why didn't I see any change in the account after I transferred assets to it using NEO-GUI?**

Firstly check the transaction record in NEO-GUI to see if the transfer transaction has been confirmed. If confirmed, then check if your client has been synchronized up to the latest block height and rebuild the wallet index if the problem still exists.  

**Why doesn't the downloaded offline package work?**

Read the instructions in [Synchronizing the blockchain faster](network/syncblocks.md) and make sure the following:

- You have downloaded the proper package
- You have directly placed the downloaded file (chain.0.acc.zip or chain.xxx.acc.zip) under the root directory of NEO-CLI or NEO-GUI without modifying the file name
- You have installed the [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip) plugin.

**How do I know my client has been fully synchronized? **

Use the blockchain browser to check the latest block height and then look at the wallet height in your client. If the two heights are the same, your client is fully synchronized. 

**How to make a watch-only wallet？**

In NEO-CLI create a new address, then right-click to import the watch-only address and enter the address you want to monitor. Then you can see each transaction information in the transaction record. You need to rebuild the wallet index after importing the address.

**Is it possible to transfer assets to multiple addresses in one transaction?**

Yes. Refer to [Transactions](node/gui/transc.md).

**What are the hardware requirements for the computer running NEO node in the main net?**

A dual-core CPU, 8G memory, and a solid state drive with a minimum of 100G or more are required. The hard disk needs to be expanded on demand to prevent the inode from overflowing.

**Is it possible to start NEO-CLI from background？**

You can write some scripts, such as creating a Notepad file on Windows, typing `dotnet neo-cli.dll /rpc` and saving it as a .cmd file or using the screen command on linux.

## Development

**How to apply for test tokens?**

Go to https://neo.org/testcoin/apply and fill out the application form. If the application is accepted, you will be notified in three to five workdays.

**How to build a private chain?**

To build a private chain, you have the following options：

- Use a virtual machine to build a private chain on a cloud server. See [here](network/private-chain/private-chain.md).
- Quickly build a private chain on one Windows serve. See [here](network/private-chain/private-chain2.md).
- Quickly build a private chain with neo-local. See [here](network/local-chain.md).

You can also refer to the [community tutorial](http://docs.neo.org/communitydoc.html) to learn more options.

**Which languages can I use to develop smart contracts?**

NEO supports a variety of mainstream programming languages and can be developed using C#, Python, Go, JS, and Jave. Currently in the NEO ecosystem, the infrastructure for C# and Python is extremely well-developed and various compilers are provided for developers.

**How can I obtain the NEP-5 assets TXID?**

Currently we recommend you use the blockchain browser https://scan.nel.group to view the NEP-5 assets TXID.

1. In the browser, click Assets in the top navigation bar. 
2. In the Assets drop-down list, select NEP-5.
3. Click the desired asset to view its TXID in the details page that appears.

**Why is it prompted that there is no object's private key in the wallet when withdrawing assets from a multi-party signature contract?**

After the private chain is set up, you need to make the same configurations in all (n/2+1) wallets (n is the node number), that is, add the multi-party signed addresses and then rebuild the wallet index. 

## Smart contract

**Why is it prompted the NuGet package cannot be restored when I try to publish neon? Even if I use Visual Studio 2017, the problem still occurs.**

To solve it:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root  of the neo-compiler project. 
2. Run Power Shell or command line (CMD) 
3. Go to the neo-compiler root and run `nuget restore` .

**Why can't neon.dll be copied when publishing a neon project?**

This may caused by a VS 2017 bug. In some versions of VS 2017 (e.g.15.4, 15.5), the following error may occur:  

Cannot copy "obj\Release\netcoreapp1.0\win10-x64\neon.dll" because the file could not be found.

To solve it, you can manually copy the file `\obj\Release\netcoreapp1.0\neon.dll` to the directory `\obj\Release\netcoreapp1.0\win10-x64\` and then republish.

**Why can't NEO namespace be found in the new-created NeoContract project?**

After creating the NeoContract project, there are many red underlines in the code indicating that the NEO namespace is not found, and there is an exclamation mark in the project reference.

To solve this problem, right-click on the solution file in Visual Studio and click `restore NuGet package`. After all the packages are restored successfully, if the issue still exists and there is still an exclamation mark in References in the right panel, try double-clicking the exclamation mark to solve the issue.

If you still cannot solve the issue, try this way:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root of the NeoContract project. 
2. Run Power Shell or command line (CMD) 
3. Go to the NeoContract root and run `nuget restore`.

**After publishing neon in Windows 7 and setting the environment variable, why is it prompted that api-ms-win-core-console-l2-1-0.dll is missing when I am running neon?**

This is caused by the publishing system configuration. As the default publishing system for the neon project is win 10-x64, when you publish neon in Windows 7 the missing .dll file is prompted. 

To solve this problem, edit the neon.csproj file and change  `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` to `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>`. Then republish the project in Visual Studio or using the command `dotnet publish -r win7-x64 -c debug`.

For more information about RID refer to [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) .

Although you can download the file and copy it to the neon.exe directory, this method is not recommended due to potential security issues.

**Why can't neon be found in CMD after I set the environment variable?**

This is because you did not restart CMD after you changed the environment variable. The CMD still read the parameters changed before. To solve this, restart the CMD.

**After publishing neon and adding neon.exe directory to path, why does compiling NeoContract hang at the step "Start NeoContract converter"?**

This is because you did not restart Visual Studio after modifying the environment variable. The Visual Studio still read the environment variable changed before. 

To solve this problem, restart Visual Studio. If not solved, restart your system.

**Why does smart contract complied with the old version of neon fail to run on the test net or main net?**

NEO smart contracts require development framework, compiler, and NEOVM versions are consistent. The code compiled with the old framework and compiler may not be able to work in the new version of NEOVM. It does not affect the smart contracts already published on the blockchain. So before you start developing smart contracts, make sure you use the latest version of framework (e.g. NeoContractPlugin) and compiler (e.g. neon).

Some parts of this article is excerpted from [NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7). Thanks for **cybourgeoisie**'s contribution.

If you are still having trouble or you do not find a relevant issue, you can open an issue or pull request on [GitHub NEO Doc project](https://github.com/neo-project/docs).