# Configuring and Starting Neo-CLI 

After installation of Neo-CLI, this section we will walk you through the necessary configurations before running Neo-CLI and the steps to start Neo-CLI using commands. 

## Modifying configuration files

Neo-CLI accesses two configuration files during execution: `config.json` and `protocol.json`. You need to make necessary configurations in these files before starting Neo-CLI.

### Configuring a wallet

Before you can invoke the wallet related API, you need to configure a wallet in the config.json file to enable Neo-CLI to open the wallet automatically when running. 

- `Path`: the wallet path
- `Password`: the wallet password
- `IsActive`: Set to `true` to allow Neo-CLI to open the wallet automatically.

Here is an example:

```json
  {
  "ApplicationConfiguration": {
    "Logger": {
      "Path": "Logs_{0}",
      "ConsoleOutput": true,
      "Active": true
    },
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 20333,
      "WsPort": 20334
    },
    "UnlockWallet": {
      "Path": "wallet.json",
      "Password": "11111111",
      "StartConsensus": false,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

Where:

- `ConsoleOutput`: Whether to print log information on console. `true` means foreground and background printing, while `false` means background logging.
- `Active`: Whether to enable Log
- `Engine`: It defaults to LevelDBStore, which means the engine used by the blockchain to store data.
- `PluginURL`: The downloading URL of the plugin, which will be used when using the CLI install command.

### Connecting the node to network

To connect the node to test net, replace the content of configuration files  `config.json` and `protocol.json` with the content of  `config.testnet.json` and `protocol.testnet.json` respectively.

To connect the node to your private net, refer to [Setting up Private Chain](../../develop/network/private-chain/solo.md).

## Installing plugins

Some additional functionalities are individually encapsulated in plug-ins for the purpose of improving node security, stability, and flexibility. The user can select the desired extension functionality instead of invoking it with additional parameters every time starting neo-cli, thus avoiding many human errors and some tedious instructions such as opening a wallet and calling APIs. 

You can choose one of the following ways to install plugins:

- Download the plugin package from GitHub
- Use the CLI command to install automatically

### Downloading plugins from GitHub

Download the plugins you need from the following table.

<table class="table table-hover">
    <thead>
        <tr>
            <th style="width: 25%;">Plugin</th>
            <th style="width: 35%;">Description</th>
            <th style="width: 20%;">API Included</th>
            <th style="width: 20%;"></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/LevelDBStore.zip">LevelDBStore</a>
            </td>
            <td>Uses LevelDB to store the blockchain data</td>
            <td></td>    
            <td>Mandatory</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/RocksDBStore.zip">RocksDBStore</a>
            </td>
            <td>Uses RocksDBStore to store the blockchain data</td>
            <td></td>
            <td>An alternative to LevelDBStore</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/RpcServer.zip">RpcServer</a>
            </td>
            <td>Enables RPC for the node</td>
            <td><a href="../../reference/rpc/latest-version/api.html"> RPC API </a></td>
            <td>Mandatory</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>Synchronizes the smart contract log with the NativeContract log (Notify)</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>Recommended</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/RpcNep17Tracker.zip">RpcNep17Tracker</a>
            </td>
            <td>Enquiries NEP17 balance and transactions history of accounts through RPC</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep17balances.html">getnep17balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep17transfers.html">getnep17transfers</a></td>
            <td>Recommended</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>Exports Neo-CLI status data.</td>
            <td></td>
            <td>Optional</td>
        </tr>  
    </tbody>
</table>



To install plugins, unzip plugin packages under the the Neo-CLI root directory, as shown below:

![](../../../zh-cn/assets/PluginsForExchange.png)

### Downloading plugins using command

It is easier to automatically install or uninstall the plugin using commands, for example:

```
neo> install StatesDumper
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview4/StatesDumper.zip
Install successful, please restart neo-cli.
```

```
neo> uninstall StatesDumper
Uninstall successful, please restart neo-cli.
```

After installation, restart Neo-CLI for the plugin to take effect.

## Starting the NEO node

Open the command line, navigate to the Neo-CLI directory, and enter the following command to start the Neo node:

On **Windows 10**:

```
dotnet neo-cli.dll
```

or 

```
neo-cli.exe
```

On **Linux (ubuntu 16.04/18.04)**:

```
./neo-cli
```

or

```
dotnet neo-cli.dll
```

> [!Note]
>
> If you  use dotnet install .net core in advance.

If you want the external program to access the node API need to open the firewall port: 10331-10334, 20331-20334

> [!WARNING]
>
> If you open the API service and the wallet in Neo-CLI, you need to set up your firewall policy. For example, set a whitelist for the firewall to only allow access to these ports by whitelisted IP addresses. If completely opening the service to external network, others may be able to export the private key or transfer assets using API.
