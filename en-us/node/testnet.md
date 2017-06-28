# Test network

The TestNet is designed to be developed, commissioned and tested by the user. Testing the system on the testnet incurs the network fee of testnet AntCoins (not real AntCoins)! Testnet AntShares and AntCoins can be applied for free of charge, on the official website.

All the block data of the test network is independent of the main network. If you develop a simple smart contract or try to register assets, the use of testnet should suffice. After the testing is complete, the development can be moved to the AntShares's mainnet online operation.

## Test the characteristics of the network

1. Asset registration, asset distribution, contract execution, etc. will not consume real money.
2. Globalized, deployed in the Internet environment.
3. Test the network block, transactions and other information can be easily viewed in the blockchain browser.
4. Smart contract deployed in the test environment, anyone around the world can employ it.
5. Test network can not be used as a commercial application of the actual landing environment.

## Client Downloads

The test network client is the same as the primary network client. By modifying the client's configuration file, the client can be switched between the primary and test networks.

Reference: [introduction of AntShares node](introduction.md).

|      | AntSharesCore-GUI                        | AntSharesCore-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [official website](https://www.antshares.org/download) or [Github](https://github.com/antshares/antsharescore/releases) | [Github](https://github.com/AntShares/antsharescore/releases) |
Source code | [Github](https://github.com/antshares/antsharescore) | [Github](https://github.com/antshares/antsharescore) |

## Method of switching to test network

1, Copy the contents of the program directory under the `protocal.testnet.json` into ` protocol.json`, as shown.

![image](http://docs.antshares.org/images/2017-06-08_14-16-35.png)

2, Copy the contents of the program (GUI) directory `AntSharesUI.exe.testnet.config` into the `AntSharesUI.exe.config`, as shown in Figure

![image](http://docs.antshares.org/images/2017-06-08_14-16-12.png)

Note: If the node is run on CLI, the contents of `config.testnet.json` need to be copied to` config.json`.
