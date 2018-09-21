# Installation of NEO-CLI 

This section describes the procedure for installing the official NEO-CLI released package and starting the NEO node. Alternatively, you can directly publish NEO-CLI source from GitHub into an executable file. Especially when you use macOS, that is the only way to set up NEO-CLI. For more information refer to [Publishing from Source](publish.md).

## Hardware Requirment

A solid state disk with the computer running the NEO-CLI client  is recommended to avoid waiting too long when synchorizing blocks.


## Installing the NEO-CLI package

1. Download the latest [Neo-CLI](https://github.com/neo-project/neo-cli/releases) package according to your operating system on Github and unzip it.

2. On Linux, install the LevelDB and SQLite3 dev packages. For example, on ubuntu 17.10 run the following:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   On Windows, you can skip this step as those files are already included in the installation package.

## Starting the NEO node

Open the command line, navigate to the NEO-CLI directory, and enter the following command to start the NEO node:

On **Windows 10**:

```
dotnet neo-cli.dll
```

or 

```
neo-cli.exe
```

On **Linux (ubuntu 17.10)**:

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

NEO-CLI provides a series of APIs for external access. If you want to start the node while opening the API, you can add the parameter `--rpc`, `/rpc`, or `-r`, for example:

```
neo-cli.dll --rpc
```
If you want to only connect seed nodes in the configuration file, enter the following:

```
neo-cli.dll --nopeers 
```

If you want the external program to access the node API need to open the firewall port: 10331-10334, 20331-20334

> [!Important]
>
> If you open the API service and the wallet in NEO-CLI, you need to set up your firewall policy. For example, set a whitelist for the firewall to only allow access to these ports by whitelisted IP addresses. If completely opening the service to external network, others may be able to export the private key or transfer assets using API.

## Synchronizing blockchain data

The client must be fully synchronized before use. In order to speed up network synchronization you can download an offline package of the blockchain data up to a certain block height.  This means the client will only need to sync the additional blocks from the NEO network rather than the entire blockchain. For more information,  see  [Synchronizing the blockchain faster](../../network/syncblocks.md).