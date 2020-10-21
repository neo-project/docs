# 安装

你可以通过两种方式安装 Neo-CLI：

- 直接下载 Neo-CLI 的官方发布程序包进行安装。
- 或者下载 Neo-CLI 的源代码并发布成可执行文件，如果使用 macOS，则推荐此方式。

下文将具体介绍这两种方式。

## 配置要求

运行 Neo-CLI 的计算机需具备以下配置，以获得较佳体验：

|          | 最低配置                                             | 推荐配置                                             | 最佳配置                                               |
| -------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| 操作系统 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 | Windows 10<br/>Ubuntu 16.04/18.04<br/>CentOS 7.4/7.6 |
| CPU      | 双核                                                 | 四核                                                 | 八核                                                  |
| 内存     | 8G                                                   | 16G                                                  | 32G                                                  |
| 硬盘     | 200G 固态硬盘                                         | 300G 固态硬盘                                        | 500G 固态硬盘                                         |

## 安装 Neo-CLI 程序包

1. 在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。

2. 对于 Linux 系统，需要安装 LevelDB 和 SQLite3 开发包。例如，在 ubuntu 18.04 上输入以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev libunwind8-dev
   ```

   对于 Windows 系统，[Neo-CLI](https://github.com/neo-project/neo-cli/releases) 的安装包中已经包含了 LevelDB，可跳过该步骤。  

## 通过源码发布 Neo-CLI 

你也可以直接从 Github 下载 Neo-CLI 源码并进行发布。

### 在 Windows 系统中发布

#### 安装文件

1. 在 Windows 10 系统中，安装 [.NET Core](https://www.microsoft.com/net/download/windows) 和 [.NET Framework](https://www.microsoft.com/net/download/windows)。

2. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-node/tree/master-2.x
   ```

3. 下载 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

#### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
//进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝进来
```

### 在 Linux 系统中发布

#### 安装文件

1. 在 Linux (ubuntu 18.04) 系统中，安装 [.NET Core Runtime](https://www.microsoft.com/net/download/linux)。

2. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-node/tree/master-2.x
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
   $ git clone https://github.com/neo-project/neo-node/tree/master-2.x
   ```

2. 下载 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

3. 安装 [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/)。

#### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
//进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝进来
```



