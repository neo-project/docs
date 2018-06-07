# Installation of NEO-CLI 

This section describes the procedure for installing the official NEO-CLI released package and starting the NEO node. Alternatively, you can directly publish NEO-CLI source from GitHub into an executable file. Especially when you use macOS, that is the only way to set up NEO-CLI. For more information refer to [Publishing from Source](publish.md).

## Installing the environment

Install one of the following depending on your system:  

- For **Windows 7** and **Windows 10**, install [.NET Core](https://www.microsoft.com/net/download/windows) and [.NET Framework](https://www.microsoft.com/net/download/windows).
- For  **Linux (ubuntu 17.10)**, install [.NET Core Runtime](https://www.microsoft.com/net/download/linux).

After the installation is complete, you can run the following command to check whether the .NET Core environment was installed successfully.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

If you see the final output "Hello World!", The .Net Core installation is successful.


## Installing the NEO-CLI package

1. Download the latest [Neo-CLI](https://github.com/neo-project/neo-cli/releases) package according to your operating system on Github and unzip it.

2. On Linux, install the LevelDB and SQLite3 dev packages. For example, on ubuntu 17.10 run the following:

```
sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On Windows, you can skip this step as those files are already included in the installation package.

## Starting the NEO node

Open the command line, navigate to the neo-cli directory, and enter the following command to start the NEO node:

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
dotnet neo-cli.dll
```

NEO-CLI provides a series of APIs for external access. If you want to start the node while opening the API, you can add the parameter `--rpc`, `/rpc`, or `-r`, for example:

```
dotnet neo-cli.dll --rpc
```
To log the smart contract information, e.g. the NEP-5 assets transactions, you can add `--log` or `-l`, for example:

```
dotnet neo-cli.dll --log 
```

If you want to only connect seed nodes in the configuration file, enter the following:

```
dotnet neo-cli.dll --nopeers 
```

If you want the external program to access the node API need to open the firewall port: 10331-10334, 20331-20334

> [!Important]
>
> If you open the API service and the wallet in NEO-CLI, you need to set up your firewall policy. For example, set a whitelist for the firewall to only allow access to these ports by whitelisted IP addresses. If completely opening the service to external network, others may be able to export the private key or transfer assets using API.

