# Test network

The TestNet is an environment where the user can develop, commission and test programs. Testing programs on the testnet incurs the network fee of testnet GAS (not real GAS!!). Testnet NEO and GAS can be applied free of charge, on the official website, detailed instruction are below.

All the blockchain of the test network are independent of the main network. If you develop a simple smart contract or try to register assets, the use of testnet should suffice. After the testing is complete, the development can be moved to the NEO mainnet online operation.

## TestNet characteristics

1. Asset registration, asset distribution, contract execution, etc. (Does not consume real money)
2. Globalized deployment in the Internet environment.
3. Test of network blocks; Transactions and other information can be easily viewed in the blockchain browser.
4. Smart contract deployment in the test environment, where anyone in the world can employ it.
5. Test network can not be used as commercial application of an actual landing environment.

## Client Downloads

The test network client is the same as the primary network client. By modifying the client's configuration file, the client can be switched between the primary and test networks.

Reference: [Introduction of NEO node](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Official website](https://www.neo.org/download) or [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Source code | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Method of switching to test network

1. Copy the contents of the program directory under the `protocol.testnet.json` into ` protocol.json` as shown.

![image](/assets/testnet_1.png)

2. Copy the contents of the program (GUI) directory `config.testnet.json` into the `config.json` as shown in Figure

![image](/assets/testnet_2_v2.png)

## Method of getting TEST GAS and TEST NEO
If you are a developer, you can ask for NEO and GAS on the TestNet. You will need 500 Test GAS to deploy a contract to the TestNet.  

- Fill in the request form (https://www.neo.org/Testnet/Create) specifying your PUBLIC key and EMAIL.
- A day or so later you will receive an email with an Contract Address and a second PUBLIC KEY. 
- Create/Add a multi-sig address in your wallet.
- Select the new address and transfer the assets from the multi-part signed address to your own address.

### STEP 1 - Look up your PUBLIC key
In NEO the address and PUBLIC key are different.  
The PUBLIC KEY is shown when you view the PRIVATE KEY. (Never share your PRIVATE key.)

  ![image](/assets/neo_gas_0.jpg)

### STEP 2 - Fill in the request
Complete the form here: https://www.neo.org/Testnet/Create specifying your EMAIL and PUBLIC key.
After a day or so you will be sent an email containing a "Multi-party signed address" and the PUBLIC key of the sender. See Advanced Features, Multi-party signed address.

### STEP 3 - Create a multi-party signed address
To access the assets, in your neo-gui you will create a "Multi-party signed address" in your wallet using 
- The "Multi-party signed address" (from the email) 
- The PUBLIC KEY of the sender (from the email)
- Your PUBLIC KEY (from STEP 1 above) 

1. From NEO-GUI, right-click on the account area and select `Create Contract Address` -> `Multi-Signature`.

  ![image](/assets/neo_gas_1.jpg)

2. In the public key list, enter the public keys used for signing. (PUB Key of sender and your PUB key) 
3. Specify the minimal number of signatures to be  `1`.
4. Click `confirm`.

The contract address specified in the email is created and displayed in the account page.

![image](/assets/neo_gas_2.jpg)

You will see the quantity of NEO and/or GAS shown beside the Contact address.


### STEP 4 - Transfer the assets to another account

1. Select the `Contact address` by clicking on it.

2. From NEO-GUI menu, select `Transaction` -> `Transfer`

![image](/assets/neo_gas_3.png)

3. Select the Asset and the amount to send and the account you want to transfer the asset to. 

## Alternatives to the TestNet
Testing your Smart Contract on the TestNet is a good idea before publishing it on the LIVE network but earlier in your development cycle you should consider using other methods to test your Smart Contacts such as:
- Using Neo.VM if developing in C# with Visual Studio
- Running you own PRIVATE Testnet
