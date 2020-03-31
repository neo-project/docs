# Build a private chain with one node

Neo-CLI supports generating blocks without consensus nodes, which means you can set up a private chain with one node. To simplify the process, you can directly down the project [Neo-Private-Net](https://github.com/chenzhitong/NEO-Private-Net) to run the private chain quickly.  

Alternatively, you can build a private chain with one node from scratch, which will be elaborated in the following sections.

## Prerequisites

1. Refer to [Installation of NEO-CLI](../../node/cli/setup.md) to install Neo-CLI.

2. Run Neo-CLI and enter the command `create wallet <path>` to create a wallet, e.g. `create wallet 1.json`:

   ![](../../../zh-cn/network/assets/create-wallet.png)

3. Record the wallet pubkey that appears. This will be used in later steps.

## Modifying the node configuration files

### Modifying config.json

In config.json under the Neo-cli directory, make the following configurations:

- In "UnlockWallet" specify the wallet path and wallet password.
- Set  `StartConsensus` and `IsActive` as true.

Here is an example：

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

### Modifying protocol.json

1. Open protocol.json under the Neo-cli directory
2. In StandbyValidators enter the public key of the wallet 1.json created before (It is single node mode when there is only one public key included in StandbyValidators).

Here is an example：

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

Run the command line and enter the Neo-CLI directory. Then enter  `neo-cli.exe` to start the private chain. The private chain is set up successfully when it goes as shown below:

![img](../../../zh-cn/network/assets/solo.png)

> [!Note]
>
> If the plugin SystemLog is installed, the consensus log is printed. Here we didn't install the plugin for the convenience of entering commands.
>
> Using `show state` you can check the block height.

The private chain is terminated if you close the window.

## Withdrawing NEO and GAS

In the genesis block of the Neo network, 100 million NEO and 30 million GAS are generated. When the private chain is set up, you can withdraw those NEO and GAS from a multi-party address with Neo-CLI, to facilitate your blockchain development and testing.

### Withdrawing NEO/GAS using Neo-CLI

1. From Neo-CLI command line enter  `open wallet a.json` to open the wallet.

2. Enter the command `import multisigaddress m pubkeys` to create a multi-part signed address, where:

   `m` is 1 as the minimal signature number and `pubkeys` is the public key of a.json

   ```
   import multisigaddress 1 03ac765294075da6f7927c96bfe3d3f64ae3680c5eb50f82f55170a9f1bea59dad
   ```

3. Enter `list asset`，then you should see 100 million NEO and 30 million GAS displayed.

