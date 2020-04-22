# 安装

你可以通过两种方式安装 Neo-CLI：

- 下载 Neo-CLI 官方发布程序包进行安装。
- 下载 Neo-CLI 的源代码并发布成可执行文件。

下文将具体介绍这两种方式。

## 配置要求

运行 Neo-CLI 的计算机需具备以下配置，以获得较佳体验：

|          | 最低配置                                             | 推荐配置                                             |
| -------- | ---------------------------------------------------- | ---------------------------------------------------- |
| 操作系统 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 |
| CPU      | 双核                                                 | 四核                                                 |
| 内存     | 8G                                                   | 16G                                                  |
| 硬盘     | 50G 固定硬盘                                         | 100G 固定硬盘                                        |

## 安装 Neo-CLI 程序包

1. 在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-node/releases) 程序包并解压。

2. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 18.04 上输入以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。  


## 通过源码发布 Neo-CLI

### 准备工作

1. 下载 [neo-node](https://github.com/neo-project/neo-node) 项目，或通过 Git 命令克隆项目。

   ```
   $ git clone https://github.com/neo-project/neo-node.git
   ```

3. 下载对应版本的 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

4. 安装最新版的 [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/current/runtime)。

### 使用Visual Studio发布（仅Windows）

如果使用 Windows 系统且已安装 Visual Studio 2019, 推荐此方法进行发布：

1. 在 Visual Studio 中打开项目文件 neo-node.sln, 在解决方案栏中右键单击 `neo-cli`，点击`发布`。

2. 进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝到 neo-cli.exe 同级的文件夹中。

### 使用命令行发布（Windows/Linux/macOS）

也可以用 .NET Core CLI 来发布项目，详情可参考 [dotnet publish 命令参考](https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)。

1. 发布 neo-cli：

   ```
   cd neo-node\neo-cli
   dotnet restore
   dotnet publish -c release -r <RUNTIME_IDENTIFIER>
   ```
   其中 `<RUNTIME_IDENTIFIER>` 为运行时标识符，应根据系统选择对应的 [RID 目录](https://docs.microsoft.com/zh-cn/dotnet/core/rid-catalog)，如 `win-x64`、 `linux-x64`、 `osx-x64` 等。
   
5. 进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝到 neo-cli.exe 同级的文件夹中。


## 阅读下节

[配置与启动 Neo-CLI](config.md)