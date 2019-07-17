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

   - 对于 Windows 系统，复制 [LevelDB](https://github.com/neo-project/leveldb) 并放置到 neo-cli 文件夹下。
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
```

**Windows 10**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
```

## 在 macOS 系统中发布

### 安装文件

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

### 编译准备工作

1. 打开 `neo-cli` 文件夹，在 Visual Studio 中运行 `neo-cli.sln` 。
2. 右键单击 NEO-CLI 解决方案文件夹 `neo-cli (master)` ，点击 `Add` > `Add Existing Project...`
3. 导航到 `neo` 文件夹并选择  `neo.csproj` 。
4. 右键单击 NEO-CLI 项目依赖库文件夹并选择 `Edit References...`
5. 选取 `neo` 并点击 `ok`
6. 单击 菜单中的 `Restore NuGet Packages` 和 `Update NuGet Packages`
7. 单击  `Build` 重新编译以免出错。

### 发布可执行文件

在命令行中运行以下命令：

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

## 启动 NEO 节点

1. 进入编译完的文件所在目录：
   `$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
   **以上路径可能需要根据用户实际路径进行更改*
2. 要运行 NEO-CLI 输入命令 `$ dotnet neo-cli.dll`
   **建议将 `publish` 移到更易访问的目录*

