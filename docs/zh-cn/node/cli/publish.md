# 发布 NEO-CLI 源码 

你可以直接从 Github 下载 NEO-CLI 源码并进行发布。

## 在 Windows / Linux 系统中发布

### 安装文件

1. 根据系统选择以下文件进行安装： 
   - **Linux (ubuntu 17.10)**, 安装 [.NET Core Runtime](https://www.microsoft.com/net/download/linux)。
   - **Windows 7** / **Windows 10**，安装 [.NET Core](<https://www.microsoft.com/net/download/windows>) 和 [.NET Framework](https://www.microsoft.com/net/download/windows)。

2. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. 安装 levelDB:

   - 对于 Windows 系统，下载 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。
   - 对于 Linux 系统，运行以下命令：

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

### 发布可执行文件

在命令行界面运行以下命令：

**Linux**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r linux-x64
```

**Windows 7**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win7-x64
//进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝进来
```

**Windows 10**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
//进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝进来
```

## 在 macOS 系统中发布

### 安装文件

1. 从 [Github](https://github.com/neo-project/neo-cli.git) 下载源代码或通过以下命令下载：

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

2. 下载 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

3. 安装 [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/)。


### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
//进入编译完的文件所在目录，将之前下载的 libleveldb.dylib 拷贝进来
```

## 启动 NEO 节点

1. 进入编译完的文件所在目录：
   `$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
   **以上路径可能需要根据用户实际路径进行更改*
2. 要运行 NEO-CLI 输入命令 `$ dotnet neo-cli.dll`
   **建议将 `publish` 移到更易访问的目录*

