# 开发示例合约

我们已经搭建私链并启动节点连接私链，下文将以使用 windows 10 和 C# 为例，带领开发者配置环境、编写、编译以及在私链上部署和调用 Neo 智能合约。

在本节我们将完成以下任务：

1. 安装合约开发环境
2. 创建一个 NEP-5 合约项目
3. 编译合约

## 安装开发环境

### 安装 Visual Studio 2019

下载 [Visual Studio 2019](https://www.visualstudio.com/products/visual-studio-community-vs) 并安装，注意安装时需要勾选 `.NET Core 跨平台开发` 和 `Visual Studio 扩展开发`。

安装 [.NET Framework 4.6.2 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net462-developer-pack-offline-installer) 以便接下来正确加载项目。

### 安装 NeoContractPlugin 插件

拉取 [neo-devpack-dotnet](https://github.com/neo-project/neo-devpack-dotnet) 项目并打开

编译 `Installer` 项目

打开在 bin/Debug 目录下打开刚刚编译的 `Neo.SmartContract.Installer.vsix` 文件

安装  `Neo.SmartContract.Installer.vsix` 扩展

重启 Visual Studio 

### 配置编译器

打开 [neo-devpack-dotnet](https://github.com/neo-project/neo-devpack-dotnet) 项目

发布 `Neo.Compiler.MSIL` 项目，记下发布目录

打开发布目录，如 \bin\Release\netcoreapp3.1\publish，启动 PowerShell，输入命令 `./neon.exe` 确保 neon 可以正常启动

将发布目录添加到环境变量 PATH 中

在任意位置启动 PowerShell，输入命令 `neon.exe` 确保环境变量已正确配置

### 配置智能合约框架

打开 [neo-devpack-dotnet](https://github.com/neo-project/neo-devpack-dotnet) 项目

编译 `Neo.SmartContract.Framework` 项目

找到编译后的 `Neo.SmartContract.Framework.dll` 以便下一步使用

## 创建 Neo 合约项目

启动 Visual Studio 2019，新建 NeoContract 项目

在项目上右键，打开 `管理 NuGet 程序包`

卸载 `Neo.SmartContract.Framework` 的 NuGet 引用

将上一步编译的 `Neo.SmartContract.Framework.dll` 文件放入 NeoContract 项目中

为 NeoContract 项目添加 `Neo.SmartContract.Framework.dll` 引用

至此，我们的 Neo3 智能合约项目就创建完成，接下来开始编写代码。

## 编辑 NEP-5 代码

项目创建完之后，我们已经得到了一份智能合约的代码模板。

示例代码比较简单，功能是向存储区存入 "Hello" "World" 的键值对。

很多开发者比较关心的是如何在 Neo 公链上发布自己的合约资产，现在我们就先在私链上一步步实现。

这里是 [Neo3 的 NEP5 示例](https://github.com/chenzhitong/Neo3-Smart-Contract-Examples/tree/master/NEP5) 可供参考

Neo3 的 NEP-5 合约相对于 Neo2 来说有以下几个地方的改动：

1、在智能合约类上方添加自定义特性（模板中已包含）

```c#
[Features(ContractFeatures.HasStorage)]
public class NEP5 : SmartContract
……
```

2、将所有的 `ToBigInteger()` 方法，改为 `TryToBigInteger()`

并添加该扩展方法的实现，[参考](https://github.com/chenzhitong/Neo3-Smart-Contract-Examples/blob/master/NEP5/Helper.cs)

```c#
public static class Helper
{
    public static BigInteger TryToBigInteger(this byte[] value)
    {
        return value?.ToBigInteger() ?? 0;
    }
}
```

3、添加 Deploy 方法以供第一次分发资产（可选）[参考](https://github.com/chenzhitong/Neo3-Smart-Contract-Examples/blob/master/NEP5/Contract1.cs)

```c#
public static object Main(string method, object[] args)
{
	……
	if (method == "deploy") return Deploy();
	……
}
```

```c#
[DisplayName("deploy")]
public static bool Deploy()
{
    if (TotalSupply() != 0) return false;
    StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
    contract.Put("totalSupply", TotalSupplyValue);
    StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
    asset.Put(Owner, TotalSupplyValue);
    Transferred(null, Owner, TotalSupplyValue);
    return true;
}
```

## 编译合约文件

点击菜单栏上的 `生成` -> `生成解决方案`（快捷键 Ctrl + Shift + B）开始编译程序。

编译成功后你会在该项目的 `bin/Debug` 目录下看到生成的 `NEP5.nef` 文件，它相当于 Neo2 中的 .avm 文件，是 Neo 智能合约的执行文件。

`NEP5.manifest.json` 是智能合约的描述文档，文档中对合约的 功能、ScriptHash、入口、方法、参数、返回值等进行了描述。

## 继续阅读

[部署与调用合约](deploy.md)

