# 准备工作

本文将以在 Neo 区块链上发布一个 NEP-5 资产为例，一步步带领开发者完成开发环境的搭建和配置，编写智能合约以及在私链上部署和调用合约。

Neo 有两个全节点客户端：Neo-GUI 和 Neo-CLI。本教程将使用 Neo-CLI 搭建私链发布智能合约。

## 系统环境

NEO-CLI 支持以下环境：

- Windows 10
- Ubuntu 16.04/18.04
- CentOS 7.4/7.6

## 下载客户端

### 准备工作

1. 下载 [neo-node](https://github.com/neo-project/neo-node) 项目，或通过 Git 命令克隆项目。

   ```
   $ git clone https://github.com/neo-project/neo-node.git
   ```

2. （可选）下载 [neo-modules](https://github.com/neo-project/neo-modules) 项目，或通过 Git 命令克隆项目。

   ```
   $ git clone https://github.com/neo-project/neo-modules.git
   ```

   该项目包含了一系列NEO核心库中使用的插件/模块，推荐开发者发布使用。

3. 下载对应版本的 [LevelDB](https://github.com/neo-ngd/leveldb/releases) 并解压备用。

4. 安装最新版的 [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/current/runtime)。

### 使用Visual Studio发布（仅Windows）

如果使用Windows系统且已安装Visual Studio 2019, 推荐此方法进行发布：

1. 在 Visual Studio 中打开项目文件neo-node.sln, 在解决方案栏中右键单击`neo-cli`，点击`发布`。

2. 继续打开项目文件neo-modules.sln，依次发布以下插件：

   - RpcServer：提供所有RPC 命令
   - ApplicationLogs：自动同步智能合约日志
   - LevelDBStore：把区块链数据存储到区块链中

   > [!Note]
   >
   > 如果选择了 RpcServer，需要下载 2.1.1 版本的 [Microsoft.AspNetCore.ResponseCompression](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCompression/2.1.1) 并解压，进入 `lib\netstandard2.0` 目录，复制 `Microsoft.AspNetCore.ResponseCompression.dll` 放到 RpcServer 的发布文件夹中。

3. 进入编译完的文件所在目录，将之前下载的 libleveldb.dll 拷贝到 neo-cli.exe 同级的文件夹中。

4. 新建 Plugins 文件夹，将发布的插件放入该文件夹中。

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

详细步骤以及 Linux、macOS 平台安装 Neo-CLI 请参考 [Neo-CLI 安装](../../node/cli/setup.md)。

## 继续阅读

[搭建本地网络](enviroment.md)