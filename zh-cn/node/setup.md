# NEO 节点的安装部署

上文介绍了 NEO 的全节点有两个客户端，一个是 [Neo-CLI](https://github.com/neo-project/neo-cli/releases)（为开发者提供的命令行客户端），一个是 [Neo-GUI](https://github.com/neo-project/neo-gui/releases)（为高级用户提供的图形界面的客户端）

部署共识节点所用的是 `Neo-CLI` ，这是一个跨平台的程序，可以在 Windows、Linux 和 Docker 中运行

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

## 运行环境

运行 NEO 节点需要安装 [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime)，需要安装 1.0.1 或以上版本

### Windows 系统下的安装方法

在 Windows 系统下安装  .NET Core 非常方便，直接下载运行即可。
> [!Note]
> Windows可能还需要安装Microsoft Visual C++ 2015 Redistributable Update 3（https://www.microsoft.com/zh-cn/download/confirmation.aspx?id=53587），否则后面无法启动Neo-CLI。

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


## NEO 节点的安装

1、在 Github 上下载 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

> [!Note]
> 如果你试图直接在 Github 上下载并编译 Neo-CLI 源码，你会发现编译后运行 `dotnet neo-cli.dll` 会报错，这时你需要将 libleveldb.dll 和  sqlite3.dll 复制到 neo-cli.dll 同一目录下。这两个文件可以在第一步的程序包中下载。

2、打开命令行，定位到程序所在目录，输入下面代码即可启动 NEO 节点 。

``` 
dotnet neo-cli.dll
```

Neo-CLI 提供了一系列供外部访问的 API，如果想启动节点的同时开启 API 的话，可以运行下面的代码。
```
dotnet neo-cli.dll /rpc
```
3、如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 
