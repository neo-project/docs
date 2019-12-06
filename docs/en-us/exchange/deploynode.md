# Deploying Neo Nodes on Server

## Install Neo client

1. Install [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime) on the server, 2.0 and the later version.
2. From GitHub, download the [Neo-CLI](https://github.com/neo-project/neo-cli/releases) program and enable the Neo node.

## Install plugins

Since Neo-CLI 2.9.0 some additional functionalities are individually encapsulated in plug-ins for the purpose of improving node security, stability, and flexibility. For more information, refer to [Installing plugins](../../node/cli/config.md).

Go to [here](https://github.com/neo-project/neo-plugins/releases/) to download plugins. Exchanges need to install the following plugins to get the complete functionality of transaction log API and automatic synchronization with the offline package:

- ApplicationLogs (Mandatory)
- ImportBlocks (Mandatory)
- RpcWallet (Mandatory)
- CoreMetrics (Recommended)
- RpcSecurity (Recommended)
- RpcNep5Tracker (Recommended)

Copy the unzipped plugins into the Neo-CLI root directory, as shown below. 

![PluginsForExchange.png](../../assets/PluginsForExchange.png)

You can also install plugins using CLI commands：

```
install ImportBlocks
install ApplicationLogs
install RpcWallet
install CoreMetrics
install RpcNep5Tracker 
install RpcSecurity 
```

> [!Note]
>
> - A set of wallet-related RPC API are embedded the plugin RpcWallet. Ensure you have installed the plugin before you invoke these APIs.
> - You must install the plugins ApplicationLogs and RpcNep5Tracker before synchronizing the Neo client, otherwise the log in the blocks synchronized before will be lost.

## Modifying configuration files

Before running Neo-CLI, you need to make necessary configurations in the Neo-CLI configuration files. For more information, refer to [Configuring and Starting Neo-CLI](../node/cli/config.md).

> [!caution]
>
> Be cautious to enable automatic opening of wallet. Before you do that, make sure your firewall is open and safe as Password specified in the file is in clear text.
