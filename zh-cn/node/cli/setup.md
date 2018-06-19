# 安装 NEO-CLI

本文将介绍如何安装 NEO-CLI 的官方发布程序包以及启动 NEO 节点。你也可以选择直接从GitHub上下载 NEO-CLI 源代码并发布成可执行文件。如果使用macOS，则只能通过后一种方式安装运行 NEO-CLI。相关信息请参考 [发布 NEO-CLI 源码](publish.md)。

## 安装运行环境

根据所使用的系统选择对应的环境进行安装：

- 对于 **Windows 7** and **Windows 10**，安装 [.NET Core](https://www.microsoft.com/net/download/windows) 和 [.NET Framework](https://www.microsoft.com/net/download/windows).
- 对于 **Linux (ubuntu 17.10)**，安装 [.NET Core Runtime](https://www.microsoft.com/net/download/linux).

安装完成后，可以运行以下命令来检测 .NET Core 环境是否安装成功 。

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

如果你看到最后输出 “Hello World!” 说明 .Net Core 安装成功。


## 安装 NEO-CLI

1. 在 Github 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

2. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 17.10 上输入以下命令：

   ```c#
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。

## 启动 NEO 节点

打开命令行，定位到 NEO-CLI 所在目录，输入以下命令启动 NEO 节点 。

**Windows 10**:

```
dotnet neo-cli.dll
```

或

```
neo-cli.exe
```

**Linux (ubuntu 17.10)**:

   ```
dotnet neo-cli.dll
   ```

如果想在启动节点的同时启动 API 服务，可以输入参数 `--rpc`  或 `/rpc` 或 `-r`

   ```
dotnet neo-cli.dll --rpc
   ```
记录智能合约日志，如 NEP-5 资产的交易信息等，可以输入参数 `--log`  或 `-l` 

   ```
dotnet neo-cli.dll --log
   ```

仅连接配置文件中的种子节点，可以输入参数 `--nopeers`

   ```
dotnet neo-cli.dll --nopeers
   ```

如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 

> [!Important]
>
> 请注意，如果开通了 API 服务，并且在 NEO-CLI 中打开钱包的话，需要设置防火墙策略，例如设置防火墙的白名单，这些端口仅对白名单的 IP 地址开放。如果完全对外开放，其它人可能会通过 API 导出私钥或者进行转账。

## 快速同步区块数据

客户端运行时会自动同步区块数据，打开钱包时也会自动同步钱包数据，当同步完成后才可以正常使用客户端以及查看钱包内资产。由于区块链数据庞大，初次同步时等待时间通常很久，建议采用离线同步包进行同步，相关信息，请参见 [快速同步区块数据](../../network/syncblocks.md)。