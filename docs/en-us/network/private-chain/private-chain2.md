# Build a private chain on local host

In this document we will introduce a simple way to build a private chain on a windows system computer.

## Installing Neo node

Install Neo-CLI and make four copies of the node folder with the name of node1, node2, node3, and node4, successively.

For more information refer to [Installation of Neo-CLI](../../node/cli/setup.md). 

## Creating wallet files

From Neo-CLI or Neo-GUI create four wallets, 1.json, 2.json, 3.json, and 4.json, and place each in the folder of four nodes. 

## Modifying config.json

Make the following configurations in config.json of each node:

- Specify the ports so that each port is not duplicated and is not occupied by other applications.
- In "UnlockWallet" specify the wallet path and wallet password.
- Set `StartConsensus` and `IsActive` as `true`.


You can refer to the following example：

**node1/config.json**

```json
{
  "ApplicationConfiguration": {
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "UnlockWallet": {
      "Path": "1.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

**node2/config.json**

```json
{
  "ApplicationConfiguration": {
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 20333,
      "WsPort": 20334
    },
    "UnlockWallet": {
      "Path": "2.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

**node3/config.json**

```json
{
  "ApplicationConfiguration": {
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 30333,
      "WsPort": 30334
    },
    "UnlockWallet": {
      "Path": "3.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

**node4/config.json**

```json
{
  "ApplicationConfiguration": {
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 40333,
      "WsPort": 40334
    },
    "UnlockWallet": {
      "Path": "4.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

> [!Note]
>
> If the plugin RpcServer is installed, you also need to modify the port numbers in the plugin config.json file to make them different from each other and from the ports in config.json of the node.

## Modifying protocol.json

Configure the following parameters in each node protocol.json. Ensure the configuration in each file is consistent.

- Magic : The private chain ID, which can be any integer in the range of [0 - 4294967295].

- StandbyValidators: The public key of the alternate consensus node. Enter the public keys of four wallets.

- SeedList: The IP address and port number of the seed node. Specify the IP address as `localhost` and the ports as four P2P ports configured before in config.json.


You can refer to the following example：

```json
{
  "ProtocolConfiguration": {
    "Magic": 5195086,
    "MillisecondsPerBlock": 15000,
    "StandbyValidators": [
      "03ac765294075da6f7927c96bfe3d3f64ae3680c5eb50f82f55170a9f1bea59dad",
      "023e3da62b3bc314017e2b6ac11ebc2b66270f74b41dc680c77be1cf90c724882e",
      "03f4c4132e592f448607d135b3ea98ebb5aeb86f4e786ad23f62cbe8b5e3c38fd0",
      "024debe4763ebb14b3ede443409c2a8bcd7a823feab211623b34551321d37de8b2"
    ],
    "SeedList": [
      "localhost:10333",
      "localhost:20333",
      "localhost:30333",
      "localhost:40333"
    ]
  }
}
```

## Creating a shortcut to start

Create a notepad file for ease of starting the private chain. In the file, enter `dotnet neo-cli.dll /rpc`  , rename it as 1Run.cmd, and then place it under the folder of each node.

At this point the private chain has been set up. All the files  we modified are as follows:

```
├─node1
│      1.json
│      1Run.cmd
│      config.json
│      protocol.json
│
├─node2
│      1Run.cmd
│      2.json
│      config.json
│      protocol.json
│
├─node3
│      1Run.cmd
│      3.json
│      config.json
│      protocol.json
│
└─node4
        1Run.cmd
        4.json
        config.json
        protocol.json
```

## Starting the private chain

Enter each node directory and double-click `1Run.cmd`. From one client input the command  `show state`, when the screen shows 3 nodes connected and block height is increasing as shown below, the private chain is set up successfully.

![](../../../zh-cn/assets/privatechain_demo.png)

The private chain is terminated if you close all the windows. 

## Withdrawing NEO and GAS

In the genesis block of the NEO network, 100 million NEO and 30 million GAS are generated. When the private chain is set up, you can withdraw those NEO and GAS from a multi-party address with Neo-CLI for internal development and testing.

### Creating multi-party signature addresses

1. Start your private chain.

2. Open one wallet and create a multi-signature address using the command `import multisigaddress m pubkeys`:

   - `m`: the minimal number of signatures needed to complete the transaction. 
   - `pubkeys`: the public keys in StandbyValidators in all consensus node wallets.

   For example:
   
   ```
   import multisigaddress 3 03ac765294075da6f7927c96bfe3d3f64ae3680c5eb50f82f55170a9f1bea59dad 023e3da62b3bc314017e2b6ac11ebc2b66270f74b41dc680c77be1cf90c724882e 03f4c4132e592f448607d135b3ea98ebb5aeb86f4e786ad23f62cbe8b5e3c38fd0 024debe4763ebb14b3ede443409c2a8bcd7a823feab211623b34551321d37de8b2
   ```
   
3. Repeat the last step to create multi-signature addresses in other 3 wallets.

4. Enter the command `list asset` and you can see 100 million NEO and 30 million GAS displayed.

   ![image](../../assets/privatechain_28.png)

> [!Note]
>
> You must create the multi-party signature address in each wallet so that the transfer transaction can be signed successfully.

### Transferring NEO to a normal address

Here we want to send NEO from the contract address to the normal address.

1. Open the wallet 1.json and input the command `send <id|alias> <address> <value>` with the normal address of the wallet desired

2. Copy the SignatureContext and close the wallet.

   ![image](../../assets/privatechain_29.png)

3. Open another wallet (2.json) listed on the multi-signature

4. Use the command `sign <jsonObjectToSign>` with the object copied in step 2

5. Copy the object in Signed Output and close the wallet.

   ![image](../../assets/privatechain_30.png)

6. Repeat the previous steps in the third wallet 3.json. Then you can use `relay <jsonObjectToSign>` and your wallet is ready.

   ![image](../../assets/privatechain_31.png)

7. Use `list asset` to check the wallet balance:

   ![image](../../assets/privatechain_32.png)

Similarly, you can refer to the preceding steps to withdraw GAS from the multi-party signature address.
