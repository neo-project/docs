# Installing Neo-CLI

You can choose one of the following ways to install Neo-CLI:

- Install the official Neo-CLI released package
- or publish Neo-CLI source code from GitHub into an executable file. If you use macOS, this way is highly recommended.

This document will describe both ways.

## Hardware requirements

The following table lists the minimum and recommended hardware requirements for the computer running Neo-CLI.

|           | Minimum                                              | Recommended                                          |
| --------- | ---------------------------------------------------- | ---------------------------------------------------- |
| System    | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 |
| CPU       | Dual core                                            | Quad core                                            |
| Memory    | 8G                                                   | 16G                                                  |
| Hard Disk | 50G SSD hard drive                                   | 100G SSD hard drive                                  |

## Installing Neo-CLI package

1. Download the latest [Neo-CLI](https://github.com/neo-project/neo-cli/releases) package according to your operating system on Github and unzip it.

2. On Linux, install the LevelDB and SQLite3 dev packages. 

  **Ubuntu:**

  ```
  sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
  ```

  **CentOS:**

  ```
  sudo wget http://dl.fedoraproject.org/pub/epel/epel-release-latest-7.noarch.rpm
  sudo yum -y install epel-release-latest-7.noarch.rpm
  sudo yum  -y install leveldb-devel libunwind-devel libsqlite3x-devel sqlite3*
  ```

  If you use RocksDB as the storage, modify config.json, as shown below：

  ```
  "Storage": {
     "Engine": "RocksDBStore"
   },
  ```

  and then enter the following command on ubuntu 18.04：

  ```
  sudo apt-get install librocksdb-dev
  ```

  If using Windows, you can skip this step as those files are already included in the installation package.

## Publishing from Neo-CLI source code

You can download and compile the Neo-CLI source directly from Github.

### Installing required files

1. Git clone Neo-CLI source code from [Github](https://github.com/neo-project/neo-node) or using the following command:

  ```
 $ git clone https://github.com/neo-project/neo-node.git
  ```

2. Download [LevelDB](https://github.com/neo-ngd/leveldb/releases) and unzip the package for later use.

3. Install the latest version of  [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/current/runtime)

### Publishing using Visual Studio (Windows)

If you has Visual Studio 2022 installed on your Windows system, this way is recommended:

1. In Visual Studio, open the project file neo-node.sln.
2. In the Solution panel, right click `neo-cli` and select `Publish`.
3. Go to the directory where the compiled files are outputted and copy the libleveldb.dll downloaded before to here.

### Publishing using command line (Windows/Linux/macOS)

You can also use .NET Core CLI to pubish the project. For more information refer to [dotnet publish](https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish).

1. Run the following command in the command line:
  
   ```
   cd neo-node\neo-cli
   dotnet restore
   dotnet publish -c release -r <RUNTIME_IDENTIFIER>
   ```
   Where `<RUNTIME_IDENTIFIER>` should be replaced by the related [system platform RID](https://docs.microsoft.com/zh-cn/dotnet/core/rid-catalog), e.g.  `win-x64`, `linux-x64`, or `osx-x64`.

2. Go to the directory where the compiled files are outputted and copy the libleveldb.dll downloaded before to here.

