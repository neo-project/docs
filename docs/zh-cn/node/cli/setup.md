# 安装

你可以通过两种方式安装 Neo-CLI：

- 下载 neo-node 和 neo-modules 的源代码并发布成可执行文件。
- 下载 neo-node 和 neo-modules 的官方发布程序包进行安装（目前尚未发布）。

下文将具体介绍这两种方式。

## 配置要求

运行 Neo-CLI 的计算机需具备以下配置，以获得较佳体验：

|          | 最低配置                                             | 推荐配置                                             |
| -------- | ---------------------------------------------------- | ---------------------------------------------------- |
| 操作系统 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 |
| CPU      | 双核                                                 | 四核                                                 |
| 内存     | 8G                                                   | 16G                                                  |
| 硬盘     | 50G 固定硬盘                                         | 100G 固定硬盘                                        |

## 通过源码发布 Neo-CLI 

### 准备工作

下载 [neo-node](https://github.com/neo-project/neo-node) 项目，或通过 Git 命令克隆项目。

```
$ git clone https://github.com/neo-project/neo-node.git
```

下载 [neo-modules](https://github.com/neo-project/neo-modules) 项目，或通过 Git 命令克隆项目。

```
$ git clone https://github.com/neo-project/neo-modules.git
```

下载对应版本的 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

安装最新版的 [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/current/runtime)。

### 在 Windows 系统中发布（Visual Studio）

使用 Visual Studio 打开下载的两个项目文件，依次发布  neo-cli、LevelDBStore、RpcServer（可选，开发者推荐）、ApplicationLogs（可选，开发者推荐）

如果选择了 RpcServer，需要下载 2.1.1 版本的 [Microsoft.AspNetCore.ResponseCompression](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCompression/2.1.1) 并解压，进入 `lib\netstandard2.0` 目录，复制 `Microsoft.AspNetCore.ResponseCompression.dll` 放到 RpcServer 的发布文件夹中

进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝到 neo-cli.exe 同级的文件夹中。

新建 Plugins 文件夹，将发布的 LevelDBStore、RpcServer、ApplicationLogs 放入 Plugins 文件夹中。

完整的目录结构如下：

```
……
Plugins
	ApplicationLogs
	LevelDBStore
	RpcServer
	ApplicationLogs.dll
	LevelDBStore.dll
	Microsoft.AspNetCore.ResponseCompression.dll
	RpcServer.dll
……
libleveldb.dll
……
neo-cli.exe
……
```

### 在 Windows、Linux、macOS 系统中发布（命令行）

可以用 .NET Core CLI 来发布项目，[dotnet publish 命令参考](https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)。

发布 neo-cli

其中 `<RUNTIME_IDENTIFIER>` 为运行时标识符，应根据系统选择对应的 [RID 目录](https://docs.microsoft.com/zh-cn/dotnet/core/rid-catalog)，如 `win-x64`、 `linux-x64`、 `osx-x64` 等。

```
cd neo-node\neo-cli
dotnet restore
dotnet publish -c release -r <RUNTIME_IDENTIFIER>
```

发布 LevelDBStore

```
cd neo-modules\src\LevelDBStore
dotnet restore
dotnet publish -c release -r <RUNTIME_IDENTIFIER>
```

发布 RpcServer（可选，开发者推荐）

```
cd neo-modules\src\RpcServer
dotnet restore
dotnet publish -c release -r <RUNTIME_IDENTIFIER>
```

下载 2.1.1 版本的 [Microsoft.AspNetCore.ResponseCompression](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCompression/2.1.1) 并解压，进入 `lib\netstandard2.0` 目录，复制 `Microsoft.AspNetCore.ResponseCompression.dll` 放到 RpcServer 的发布文件夹中。

发布 ApplicationLogs（可选，开发者推荐）

```
cd neo-modules\src\ApplicationLogs
dotnet restore
dotnet publish -c release -r win10-x64
```

进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝到 neo-cli.exe 同级的文件夹中。

新建 Plugins 文件夹，将发布的 LevelDBStore、RpcServer、ApplicationLogs 放入 Plugins 文件夹中。

完整的目录结构如下：

```
……
Plugins
	ApplicationLogs
	LevelDBStore
	RpcServer
	ApplicationLogs.dll
	LevelDBStore.dll
	Microsoft.AspNetCore.ResponseCompression.dll
	RpcServer.dll
……
libleveldb.dll
……
neo-cli.exe
……
```

## 安装 Neo-CLI 程序包（暂不可用）

1. 在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-node/releases) 程序包并解压。

2. 在 GitHub 上下载需要的 [neo-modules](https://github.com/neo-project/neo-modules/releases) 程序包并解压。

3. 在 Neo-CLI 根目录中新建 Plugins 文件夹，将第二步下载的 LevelDBStore、RpcServer、ApplicationLogs 等模块放入 Plugins 文件夹中。

4. 如果选择了 RpcServer 模块，需要下载 2.1.1 版本的 [Microsoft.AspNetCore.ResponseCompression](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCompression/2.1.1) 并解压，进入 `lib\netstandard2.0` 目录，复制 `Microsoft.AspNetCore.ResponseCompression.dll` 放到 RpcServer 的发布文件夹中

5. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 18.04 上输入以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。  

## 阅读下节

[配置与启动 Neo-CLI](config.md)