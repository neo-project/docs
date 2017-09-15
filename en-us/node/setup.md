# Installation and deployment of NEO node 

The above article describes two clients for nodes in the NEO network. One is [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (the command line client - for developer use), and the other is [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (the graphical interface client - for the advanced user)

The deployment consensus node uses the `Neo-CLI`, a cross-platform program that runs in Windows, Linux and Docker.

|                                   | Neo-CLI |
| --------------------------------- | ----------------- |
| Windows 7 SP1 x64                 | ✅                 |
| Windows Server 2008 R2 SP1        | ✅                 |
| Red Hat Enterprise Linux 7 Server | ✅                 |
| Ubuntu 14.04, 16.04, 16.10        | ✅                 |
| Debian 8                          | ✅                 |
| Fedora 23, 24                     | ✅                 |
| CentOS 7.1 & Oracle Linux 7.1     | ✅                 |
| openSUSE 13.2, 42.1               | ✅                 |
| Docker                            | ✅                 |

> [!Note]
> At present, NEO nodes do not work properly under Mac OS. In the future there will be support for Mac OS, please wait for further updates.

## Run the environment

Running of an NEO node requires installation of [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), version 1.0.1 or above.

### Windows system installation method

In the Windows system, installation of . NET Core is very convenient, you can directly download and run.

### Linux system installation method

The following shows how .NET Core is installed in Red Hat Enterprise Linux 7 Server:

> [!Note]
> Other distributions of the Linux kernel installation method, please refer to [.NET Core installation tutorial](https://www.snetnet/core#linuxredhat)


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

After the installation is complete, you can run the following command to check whether the .NET Core environment was installed successfully.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

If you see the final output "Hello World!", The .Net Core installation is successful.


## Installation of NEO node

1. Download the [Neo-CLI](https://github.com/neo-project/neo-cli/releases) package on Github and unzip it.

> [!Note]
> If you try to download and compile the Neo-CLI source directly on Github, you will find that `dotnet neo-cli.dll` will run incorrectly after compiling, and you will need to copy libleveldb.dll and sqlite3.dll to the same directory as neo-cli.dll under. These two files can be downloaded in the first step of the package.

2. Open the command line, navigate to the program directory, enter the following code to start the NEO node.

```
dotnet neo-cli.dll
```

Neo-CLI provides a series of APIs for external access. If you want to start the node while opening the API, you can run the following code.
```
dotnet neo-cli.dll /rpc
```
3. If you want the external program to access the node API need to open the firewall port: 10331-10334, 20331-20334
