# Build a private chain with one node

NEO-CLI 2.10.2 and the later clients support generating blocks without consensus nodes, which means you can set up a private chain with one node. 

You can directly download the project [NEO-Private-Net](https://github.com/chenzhitong/NEO-Private-Net) to run a private chain quickly. Note that this project assumes you use Windows 10 and has [.NetFramework 4.7.1](https://www.microsoft.com/net/download/dotnet-framework-runtime) installed. 

You can also build a private chain with one node by yourself, which will be elaborated in the following sections.

## Installing NEO node

Refer to [Installation of NEO-CLI](../../node/cli/setup.md) to install NEO-CLI.

## Installing plug-in (Optional)

Install the plug-in [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/) which is used to output the log of generated blocks . Place the unzipped plugin under the Plugins folder of NEO-CLI.

You can also install other plugins with reference to the following list:

```
─Plugins
    │  ApplicationLogs.dll
    │  RpcSecurity.dll
    │  RpcWallet.dll
    │  SimplePolicy.dll
    │
    ├─ApplicationLogs
    │      config.json
    │
    ├─RpcSecurity
    │      config.json
    │
    ├─RpcWallet
    │      config.json
    │
    └─SimplePolicy
            config.json
```

## Creating a wallet file

From NEO-CLI or NEO-GUI create a wallet a.json and place it in the node folder. 

## Modifying config.json

Make the following configurations in config.json of the node:

- Specify the ports so that each port is not duplicated and is not occupied by other applications.
- In "UnlockWallet" specify the wallet path and wallet password.
- Set  `StartConsensus` and `IsActive` as true.

You can refer to the following example：

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "Index": "Index_{0}"
    },
    "P2P": {
      "Port": 10003,
      "WsPort": 10004
    },
    "RPC": {
      "BindAddress": "127.0.0.1",
      "Port": 10002,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "a.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-plugins/releases/download/v{1}/{0}.zip"
  }
}
```

## Modifying protocol.json

Configure the following parameters in NEO-CLI protocol.json. If you configure other nodes later ensure the configuration in each file is consistent.

- Magic: The private chain ID, which can be any integer in the range of [0 - 4294967295].
- StandbyValidators ：The public key of the alternate consensus node. Enter the public key of the wallet a.json (It is single node mode when there is only one public key included in StandbyValidators).
- SeedList: The IP address and port number of the seed node. Specify the IP address as `localhost` and the ports as the P2P port configured in config.json.

You can refer to the following example：

```json
{
  "ProtocolConfiguration": {
    "Magic": 1840412,
    "AddressVersion": 23,
    "SecondsPerBlock": 5,
    "LowPriorityThreshold": 0.001,
    "StandbyValidators": [
      "03d08d6f766b54e35745bc99d643c939ec6f3d37004f2a59006be0e53610f0be25"
    ],
    "SeedList": [
      "127.0.0.1:10003"
    ],
    "SystemFee": {
      "EnrollmentTransaction": 1000,
      "IssueTransaction": 500,
      "PublishTransaction": 500,
      "RegisterTransaction": 10000
    }
  }
}
```

## Starting the private chain

Run the command line and enter the NEO-CLI directory. Then enter  `neo-cli.exe` to start the private chain. The private chain is set up successfully when it goes as shown below:

![](../../../zh-cn/network/assets/solo.png)

The private chain is terminated if you close the window.

## Withdrawing NEO and GAS

In the genesis block of the Neo network, 100 million NEOs are generated. Additionally, GAS is generated with the generation of new blocks. When the private chain is set up, you can withdraw those NEO and GAS from a multi-party address with Neo-CLI or Neo-GUI, to facilitate your blockchain development and testing.

### Withdrawing NEO/GAS using Neo-CLI

1. From Neo-CLI command line enter  `open wallet a.json` to open the wallet.

2. Enter the command `import multisigaddress m pubkeys` to create a multi-part signed address, where:

   `m` is 1 as the minimal signature number and `pubkeys` is the public key of a.json

3. Enter `list asset`，then you should see 100 million NEO shares showing up.

4. Use the command `send <id|alias> <address> <value>` to transfer NEO to the normal address desired.

   Since this multi-signature address only requires one signature, operations for transferring assets from a contract address are as same as the normal address.

### Installing and configuring Neo-GUI

1. Download [Neo-GUI](https://github.com/neo-project/neo-gui/releases) from Github and extract the file.

2. Replace the protocol.json in the Neo-GUI folder with the one configured before.

3. Configure the file config.json to make sure the Neo-GUI port is not conflict with the one of Neo-CLI; otherwise, Neo-GUI cannot work as Neo-CLI is running.

   ```json
   {
     "ApplicationConfiguration": {
       "Paths": {
         "Chain": "Chain_{0}",
         "Index": "Index_{0}",
         "CertCache": "Certs"
       },
       "P2P": {
         "Port": 60001,
         "WsPort": 60002
       },
       "Urls": {
         "AddressUrl": "https://neoscan.io/address/{0}",
         "AssetUrl": "https://neoscan.io/api/main_net/v1/get_asset/{0}",
         "TransactionUrl": "https://neoscan.io/transaction/{0}"
       }
     }
   }
   ```

Start Neo-GUI and open a.json, if you see the connection number in the lower left corner is not 0 and the client has been downloading the blocks, the client has been successfully connected to the private chain.

### Transferring NEO/GAS

1. In NEO-GUI, right-click on the blank area of account page, click `Create Contract Address` -> `Multi-Signature`.
2. Enter the public key and set the minimum number of signatures to 1. Click `Confirm`. 
3. Click `Wallet` -> `Rebuild wallet index`.

Now you should see the contract address has 100 million NEO shares. Since this multi-signature address only requires one signature, operations for transferring assets from a contract address are as same as the normal address.

