# 安装 NEO-CLI

本文将介绍如何安装 NEO-CLI 的官方发布程序包以及启动 NEO 节点。你也可以选择直接从 GitHub 上下载 NEO-CLI 源代码并发布成可执行文件。如果使用 macOS，则只能通过后一种方式安装运行 NEO-CLI。相关信息请参考 [发布 NEO-CLI 源码](publish.md)。

## 配置要求

建议运行 NEO-CLI 的计算机配置固态硬盘，以免同步区块数据时速度太慢。

## 了解 neo-cli v2.9 插件新特性

从 neo-cli v2.9 开始，一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 neo-cli 时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 applicationlogs 等一系列繁琐的指令，为交易所部署提供了很大的方便。点击此处下载 [Plugins](https://github.com/neo-project/neo-plugins/releases)。

插件目前有 5 个，分别是：

1.[ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ApplicationLogs.zip)：在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为 LevelDB 的存储形式。（交易所必备）

2.[ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip)：同步离线包的插件，发布的版本中已经自带。（交易所必备）

3.[RpcDisabled](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/RpcDisabled.zip)：禁用一切 RPC 服务。（可选）

4.[SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/SimplePolicy.zip)：共识的简单策略规则。（搭建私链时必备）

5.[StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/StatesDumper.zip)：导出 neo-cli 状态数据。（可选）

## 安装 NEO-CLI

1. 在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

2. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 17.10 上输入以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 -dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。  

3. 从 GitHub 上下载 [Plugins](https://github.com/neo-project/neo-plugins/releases) 中的 [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ApplicationLogs.zip) 和 [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/SimplePolicy.zip) 以保证交易日志 API 和私链搭建功能的完整性。

4. 在 neo-cli 根目录新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中。

   ![plugins.png](../../../assets/plugins.png)


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
./neo-cli
```

或

   ```
dotnet neo-cli.dll
   ```

> [!Note]
>
> 如果使用 dotnet，需要先安装 .net core 环境。

如果想在启动节点的同时启动 API 服务，可以输入参数 `--rpc`  或 `/rpc` 或 `-r`

   ```
neo-cli.dll --rpc
   ```
仅连接配置文件中的种子节点，可以输入参数 `--nopeers`

   ```
neo-cli.dll --nopeers
   ```

如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 

> [!Important]
>
> 请注意，如果开通了 API 服务，并且在 NEO-CLI 中打开钱包的话，需要设置防火墙策略，例如设置防火墙的白名单，这些端口仅对白名单的 IP 地址开放。如果完全对外开放，其它人可能会通过 API 导出私钥或者进行转账。

## 快速同步区块数据

客户端运行时会自动同步区块数据，打开钱包时也会自动同步钱包数据，当同步完成后才可以正常使用客户端以及查看钱包内资产。由于区块链数据庞大，初次同步时等待时间通常很久，建议采用离线同步包进行同步，相关信息，请参见 [快速同步区块数据](../../network/syncblocks.md)。
