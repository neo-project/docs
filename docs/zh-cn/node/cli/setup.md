# 安装

你可以通过两种方式安装 NEO-CLI：

- 直接下载 NEO-CLI 的官方发布程序包进行安装。
- 或者下载 NEO-CLI 的源代码并发布成可执行文件，如果使用 macOS，则推荐此方式。

下文将具体介绍这两种方式。

## 配置要求

运行 NEO-CLI 的计算机需具备以下配置，以获得较佳体验：

|          | 最低配置                                                  | 推荐配置                                                  |
| -------- | --------------------------------------------------------- | --------------------------------------------------------- |
| 操作系统 | Windows 10<br/>Linux: Ubuntu16.04/18.04 或 CentOS 7.4/7.6 | Windows 10<br/>Linux: Ubuntu16.04/18.04 或 CentOS 7.4/7.6 |
| CPU      | 双核                                                      | 四核                                                      |
| 内存     | 8G                                                        | 16G                                                       |
| 硬盘     | 50G 固定硬盘                                              | 100G 固定硬盘                                             |

## 安装 NEO-CLI 程序包

1. 在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

2. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 18.04 上输入以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。  

## 通过源码发布 NEO-CLI 

你也可以直接从 Github 下载 NEO-CLI 源码并进行发布。

> [!Note] 
>
> - neo-cli master 分支仅针对开发中的 neo-cli 3.x 版本
> - NEO 主网节点版本为 neo-cli-2.X, 如果想切换到此版本，请切换到分支: $ git checkout master-2.x

### 在 Windows 系统中发布

#### 安装文件

1. 在 Windows 10 系统中，安装 [.NET Core](https://www.microsoft.com/net/download/windows) 和 [.NET Framework](https://www.microsoft.com/net/download/windows)。

2. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. 复制 [LevelDB](https://github.com/neo-project/leveldb) 并放置到 neo-cli 文件夹下。

#### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
```

### 在 Linux 系统中发布

#### 安装文件

1. 在 Linux (ubuntu 18.04) 系统中，安装 [.NET Core Runtime](https://www.microsoft.com/net/download/linux)。

2. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. 运行以下命令，安装 levelDB:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

#### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r linux-x64
```

### 在 macOS 系统中发布

#### 安装文件

1. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

2. 使用 `rocksdb` 命令下载 NEO 依赖库：

   ```
   $ git clone -b rocksdb-proxy https://github.com/ixje/neo.git
   ```

3. 使用 Homebrew 安装 `rocksdb`：

   ```
   $ brew install rocksdb
   ```

4. 安装 [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/)。

#### 编译准备工作

1. 打开 `neo-cli` 文件夹，在 Visual Studio 中运行 `neo-cli.sln` 。
2. 右键单击 NEO-CLI 解决方案文件夹 `neo-cli (master)` ，点击 `Add` > `Add Existing Project...`
3. 导航到 `neo` 文件夹并选择  `neo.csproj` 。
4. 右键单击 NEO-CLI 项目依赖库文件夹并选择 `Edit References...`
5. 选取 `neo` 并点击 `ok`
6. 单击 菜单中的 `Restore NuGet Packages` 和 `Update NuGet Packages`
7. 单击  `Build` 重新编译以免出错。

#### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

进入编译完的文件所在目录：
`$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
**以上路径可能需要根据用户实际路径进行更改*

## 阅读下节

[配置与启动 NEO-CLI](config.md)