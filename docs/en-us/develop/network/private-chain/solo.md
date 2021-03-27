# Build a private chain with one node

Neo-CLI supports generating blocks without consensus nodes, which means you can set up a private chain with one node. To simplify the process, you can directly down the project [Neo-Private-Net](https://github.com/chenzhitong/NEO-Private-Net) to run the private chain quickly.  

Alternatively, you can build a private chain with one node from scratch, which will be elaborated in the following sections.

## Prerequisites

1. Refer to [Installation of NEO-CLI](../../../node/cli/setup.md) to install Neo-CLI. (Make sure you install the DBFTPlugin)
2. Run Neo-CLI and enter the command `create wallet <path>` to create a wallet, e.g. `create wallet consensus.json`

3. Specify the wallet password and confirm.
4. Record the wallet pubkey. This will be used in later steps.

## Modifying the node configuration files

### Modifying config.json

In config.json under the Neo-cli directory, make the following configurations:

- In `UnlockWallet` specify the wallet path and wallet password.
- Set `IsActive` as true.
- Set `ConsoleOutput` and `Active` as true.
- Set `ValidatorsCount` as 1.
- In `StandbyCommittee`, enter the public key of the `consensus.json` wallet (Only one public key in `StandbyCommittee` represents the solo mode).

Here is an example：

```json
{
  "ApplicationConfiguration": {
    "Logger": {
      "Path": "Logs",
      "ConsoleOutput": true,
      "Active": true
    },
    "Storage": {
      "Engine": "LevelDBStore",
      "Path": "Data_LevelDB_{0}"
    },
    "P2P": {
      "Port": 21333,
      "WsPort": 21334
    },
    "UnlockWallet": {
      "Path": "consensus.json",
      "Password": "1",
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Magic": 5309138,
    "MillisecondsPerBlock": 15000,
    "MaxTraceableBlocks": 2102400,
    "ValidatorsCount": 1,
    "StandbyCommittee": [
      "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
    ],
    "SeedList": []
  }
}
```

In the config.json under the `Plugins\DBFTPlugin` directory make the following change:

- Set `AutoStart` as true

Here is an example:

```json
{
  "PluginConfiguration": {
    "RecoveryLogs": "ConsensusState",
    "IgnoreRecoveryLogs": false,
    "AutoStart": true,
    "Network": 827601742,
    "MaxBlockSize": 262144,
    "MaxBlockSystemFee": 900000000000
  }
}
```

## Starting the private chain

Run the command line and enter the Neo-CLI directory. Then enter  `neo-cli.exe` to start the private chain. The private chain is set up successfully when it goes as shown below:

![](../assets/solo.png)

The private chain is terminated if you close the window.

## Withdrawing NEO and GAS

### Using Neo-CLI to withdraw

In the genesis block of the Neo network, 100 million NEO and 30 million GAS are generated. When the private chain is set up, you can withdraw those NEO and GAS from a multi-party address with Neo-CLI, to facilitate your blockchain development and testing.

1. Copy another Neo-CLI directory as an external node.

2. Add the consensus node tcp address (localhost:21333) to the `seedlist` field in the external node config.json.

3. Modify the port in the external node config.json to avoid conflicting with other consensus node ports:

   ```json
   {
     "ApplicationConfiguration": {
       "Logger": {
         "Path": "Logs",
         "ConsoleOutput": false,
         "Active": false
       },
       "Storage": {
         "Engine": "LevelDBStore",
         "Path": "Data_LevelDB_{0}"
       },
       "P2P": {
         "Port": 23333,
         "WsPort": 23334
       },
       "UnlockWallet": {
         "Path": "",
         "Password": "",
         "IsActive": false
       },
       "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
     },
     "ProtocolConfiguration": {
       "Magic": 5309138,
       "MillisecondsPerBlock": 15000,
       "MaxTraceableBlocks": 2102400,
       "ValidatorsCount": 1,
       "StandbyCommittee": [
         "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
       ],
       "SeedList": [
       "localhost:21333"
       ]
     }
   }
   ```
   
4. Start the private chain and the external node

5. From the external node command line, enter `import multisigaddress m pubkeys` to create a multi-part signed address, where:

   `m` is 1 as the minimal signature number and `pubkeys` is the public key of `consensus.json`
   

   ```
   import multisigaddress 1 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
   ```
   
6. Enter `list asset`，then you should see 100 million NEO and 30 million GAS displayed.
