# Installing Neo-CLI

You can choose one of the following ways to install Neo-CLI:

- Install the official Neo-CLI released package
- or publish Neo-CLI source code from GitHub into an executable file. If you use macOS, this way is highly recommended.

This document will describe the two installation ways.

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

2. On Linux, install the LevelDB and SQLite3 dev packages. For example, on ubuntu 18.04 run the following:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   If using Windows, you can skip this step as those files are already included in the installation package.

## Publishing from Neo-CLI source code

You can download and compile the Neo-CLI source directly from Github.

> [!Note] 
>
> - The neo-cli master branch is only applicable to the neo-cli 3.x version which is under development
> - The NEO main net node version is neo-cli-2.X. To switch to this version, you should change to this branch: $ git checkout master-2.x

### Setting up Neo-CLI on Windows

#### Installing required files

1. On Windows 10 install [.NET Core](<https://www.microsoft.com/net/download/windows>) and [.NET Framework](https://www.microsoft.com/net/download/windows).
  
2. Git clone Neo-CLI source code from [Github](https://github.com/neo-project/neo-cli.git) or using the following command:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. Copy [NEO version of LevelDB](https://github.com/neo-project/leveldb) and place under the neo-cli folder.


#### Building the executable file

Run the following command in the command line:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
```

### Setting up Neo-CLI on Linux

#### Installing required files

1. On Linux (ubuntu 18.04) install [.NET Core Runtime](https://www.microsoft.com/net/download/linux).

2. Git clone Neo-CLI source code from [Github](https://github.com/neo-project/neo-cli.git) or using the following command:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. Run the following command to install levelDB:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

#### Building the executable file

Run the following command in the command line:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r linux-x64
```

### Setting up Neo-CLI on macOS

#### Installing required files

1. Git clone [Neo-CLI](https://github.com/neo-project/neo-cli.git) source code from Github or use the following commands:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```
4. Install [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/).

#### Setting up Visual Studio

1. Open the `neo-cli` folder and launch `neo-cli.sln` in Visual Studio
2. Right click on neo-cli's solution folder `neo-cli` and `Add` > `Add Existing Project...`
3. Navigate to the `neo` folder and choose `neo.csproj` (located inside the sub folder `neo`)
4. Right click on neo-cli's project `Dependencies` folder and choose `Edit References...`
5. Click the checkmark on `neo` and press `ok`
6. Click the `Project` menu bar and choose `Restore NuGet Packages`, once done choose `Update NuGet Packages`
7. Click the `Build` menu bar to `Rebuild All` just in case of errors

#### Building the executable file

Run the following in the command line:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

Navigate to the directory where the compiled files are stored:
`$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
**This path may be different depending on user configuration*

## What's next?

[Configuring and Starting Neo-CLI](config.md)