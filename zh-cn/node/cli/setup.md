# NEO-CLI 的安装部署

上文介绍了 NEO 的全节点有两个客户端，一个是 [NEO-CLI](https://github.com/neo-project/neo-cli/releases)（为开发者提供的命令行客户端），一个是 [NEO-GUI](https://github.com/neo-project/neo-gui/releases)（为高级用户提供的图形界面的客户端）

部署共识节点所用的是 `NEO-CLI` ，这是一个跨平台的程序，可以在 Windows、Linux 和 Docker 中运行

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
> 目前 NEO 节点在 Mac OS 下不能正常运行，之后会加入对 Mac OS 的支持，敬请期待。

## 安装运行环境

运行 NEO 节点需要安装 [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime)，需要安装 2.0 或以上版本。

### Windows 系统下的安装方法

在 Windows 系统下安装  .NET Core 非常方便，直接下载运行即可。
> [!Note]
> Windows可能还需要安装Microsoft Visual C++ 2015 Redistributable Update 3（https://www.microsoft.com/en-us/download/details.aspx?id=53840) ，否则后面无法启动Neo-CLI。

### Linux 系统下的安装方法

下面演示的是 .NET Core 在 Red Hat Enterprise Linux 7 Server 中的安装方法：

> [!Note]
> 其它发行版的 Linux 下的 .NET Core 安装方法可以参考 [.NET Core 安装教程](https://www.microsoft.com/net/core#linuxredhat)


```
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

安装完成后，可以运行以下命令来检测 .NET Core 环境是否安装成功 。

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

如果你看到最后输出 “Hello World!” 说明 .Net Core 安装成功。


## 安装 NEO-CLI

1. 在 Github 上下载 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

   > [!Note]
   > 如果你试图直接在 Github 上下载并编译 Neo-CLI 源码，你会发现编译后运行 `dotnet neo-cli.dll` 会报错，因为源码中并不包含 libleveldb.dll 和  sqlite3.dll 这两个第三方的动态连接库。如果你是 Windows 系统，可以在上述的程序包中找到这两个文件，复制到程序根目录中即可正常运行，如果是 Linux 系统，可以通过下面的系统命令安装 libleveldb 和 sqlite3。

2. 安装 LevelDB 和 SQLite3 开发包。

   对于Linux 系统，需要手动安装 LevelDB 和 SQLite3 例如，在 Ubuntu 上输入以下命令完成安装：

   ```c#
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

   其它 Linux 操作系统安装  LevelDB 和 SQLite3 的命令可能有所不同，这里就不一一列举了。

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，无需单独安装，可跳过该步骤。

## NEO 节点的启动

打开命令行，定位到程序所在目录，输入下面代码即可启动 NEO 节点 。

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
