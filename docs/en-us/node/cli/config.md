# Configuring and Starting Neo-CLI 

After installation of Neo-CLI, this section we will walk you through the necessary configurations before running Neo-CLI and the steps to start Neo-CLI using commands. 

## Modifying configuration files

Neo-CLI accesses the configuration file `config.json`  during execution. You need to make necessary configurations in the file before starting Neo-CLI.

### Configuring a wallet

Before you can invoke the wallet related API, you must open the wallet. You can configure a wallet in the config.json file to enable Neo-CLI to open the wallet automatically when running. 

- `Path`: the wallet path
- `Password`: the wallet password
- `IsActive`: Set to `true` to allow Neo-CLI to open the wallet automatically.

Here is an example:

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
      "Path": "admint.json",
      "Password": "1",
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Magic": 6713213,
    "MillisecondsPerBlock": 15000,
    "MaxTraceableBlocks": 2102400,
    "ValidatorsCount": 7,
    "StandbyCommittee": [
      "02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e",
      "038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6",
      "03c9b1c89c6e2d4abd629a2db8b7d03aced518a56793bc90f4985ef7ed3f1b481a",
      "0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68",
      "025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10",
      "03e8ab5186e1deabcd10ec0e509ded4fffade6fddf534ac3e0506268bae3fd44a6",
      "020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40",
      "02f5f04a6036caedd68b5bd36e33105c0e9f43c0592e9f9f2188b1659be993bb5e",
      "0279ed5e9ed91547e332a4f27135eebff5daab6c978b57992d8ee0359ccb9f5e8b",
      "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
    ],
    "SeedList": [
      "seed1t.neo.org:21333",
      "seed2t.neo.org:21333",
      "seed3t.neo.org:21333",
      "seed4t.neo.org:21333",
      "seed5t.neo.org:21333"
    ]
  }
}
```

Where:

- `ConsoleOutput`: Whether to print log information on console. `true` means foreground and background printing, while `false` means background logging.
- `Active`: Whether to enable Log
- `Engine`: It defaults to LevelDBStore, which means the engine used by the blockchain to store data.
- `PluginURL`: The downloading URL of the plugin, which will be used when using the CLI install command.

### Connecting the node to network

To connect the node to test net, replace the content of `config.json` with the content of  `config.testnet.json`.

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
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/LevelDBStore.zip">LevelDBStore</a>
            </td>
            <td>Uses LevelDB to store the blockchain data</td>
            <td></td>    
            <td>Mandatory</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/RocksDBStore.zip">RocksDBStore</a>
            </td>
            <td>Uses RocksDBStore to store the blockchain data</td>
            <td></td>
            <td>An alternative to LevelDBStore</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/RpcServer.zip">RpcServer</a>
            </td>
            <td>Enables RPC for the node</td>
            <td><a href="../../reference/rpc/latest-version/api.html"> RPC API </a></td>
            <td>Mandatory</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>Synchronizes the smart contract log with the NativeContract log (Notify)</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>Recommended</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/RpcNep17Tracker.zip">RpcNep17Tracker</a>
            </td>
            <td>Enquiries NEP17 balance and transactions history of accounts through RPC</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep17balances.html">getnep17balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep17transfers.html">getnep17transfers</a></td>
            <td>Recommended</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>Exports Neo-CLI status data.</td>
            <td></td>
            <td>Optional</td>
        </tr>  
                <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/DBFTPlugin.zip">DBFTPlugin</a>
            </td>
            <td>dBFT consensus plugin</td>
            <td></td>
            <td>Mandatory when served as a consensus node</td>
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/OracleService.zip">OracleService</a>
            </td>
            <td>Oracle service plugin</td>
            <td></td>
            <td>Mandatory when served as an Oracle node</td>
        </tr>   
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/StateService.zip">StateService</a>
            </td>
            <td>StateRoot consensus service plugin</td>
            <td><a href="../../reference/rpc/latest-version/api/getstateroot.html">getstateroot</a><br>
                <a href="../../reference/rpc/latest-version/api/getproof.html">getproof</a><br>
                <a href="../../reference/rpc/latest-version/api/verifyproof.html">verifyproof</a><br>
                <a href="../../reference/rpc/latest-version/api/getstateheight.html">getstateheight</a>
            </td>
            <td>Mandatory when served as a StateRoot consensus node</td>
        </tr>   
    </tbody>
</table>


To install plugins, unzip plugin packages under the the Neo-CLI root directory, as shown below:

![](../../../zh-cn/assets/PluginsForExchange.png)

### Downloading plugins using command

It is easier to automatically install or uninstall the plugin using commands, for example:

```
neo> install StatesDumper
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview5/StatesDumper.zip
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
