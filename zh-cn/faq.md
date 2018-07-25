# 常见问题

## 一般问题

**有哪些推荐使用的区块链浏览器？**

推荐使用以下浏览器：

- https://neotracker.io/

- https://neoscan.io/
- https://scan.nel.group

**如何获取 NEP-5 资产的 TXID?**

目前建议使用区块链浏览器 https://scan.nel.group 查看 NEP-5 资产的 TXID。

1. 进入浏览器后，点击页面上方导航栏中的 Assets。 
2. 在 Assets 列表中选择 NEP-5。
3. 在列表中点击要查看的资产，可进入详情页面查看到该资产的 TXID。

**从一个最小签名数为 3 的多方签名合约中提取资产， 为什么签名时显示钱包中没有对象的私钥？**

搭建私链后，在四个钱包中都需要进行相同的操作：添加多方签名地址和重建钱包索引。

## 智能合约

**为什么我发布 neon 时提示 NuGet 错误？**

当我尝试发布 neon 时, 遇到错误提示无法还原 NuGet 包。即使我尝试使用 Visual Studio 2017 进行还原，仍然会出现同样的错误。

如何解决：

1. 你可以在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 neo-compiler 项目的根目录
2. 打开 Power Shell 或命令提示符（CMD）
3. 转到 neo-compiler 根目录，运行 `nuget restore` 。

**为什么无法复制 neon.dll？**

在 VS 2017 的某些版本中（如 15.4，15.5），发布 neon 项目会出现如下错误：

无法复制文件”obj\Release\netcoreapp1.0\win10-x64\neon.dll“，原因是找不到该文件

如何解决：

这可能是 VS 2017 的一个 Bug，此时需要手动将 `\obj\Release\netcoreapp1.0\neon.dll` 文件复制到 `\obj\Release\netcoreapp1.0\win10-x64\` 文件夹中，然后重新发布即可。

**为什么我无法在新建的 NeoContract 项目里找到 Neo 命名空间？**

创建 NeoContract 项目后, 我发现代码中有很多画红线的地方，提示找不到 Neo 命名空间，而且在项目的引用中有感叹号。

如何解决：

在 VS 中右击解决方案文件，点击 `还原 NuGet 程序 包` ，这时在 “输出” 面板会看到 “正在还原 NuGet 程序包...”。所有程序包已经还原成功后，如果代码仍然报错，并且右侧 “引用” 中仍有个感叹号，可以尝试双击感叹号。

如果仍然无法解决问题，可以尝试下面的终极办法：

1. 在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 NeoContract 项目的根目录。
2. 打开 Power Shell 或命令提示符（CMD）。
3. 转到 NeoContract 项目的根目录，运行 `nuget restore` 即可。

**为什么运行 neon 时提示缺少 api-ms-win-core-console-l2-1-0.dll 文件？**

当我在 Windows 7 中发布 neon 设置好环境变量后，运行 neon，提示缺少  api-ms-win-core-console-l2-1-0.dll 文件。

如何解决：

发布时的平台错了，neon 项目默认的发布平台为 win10-x64，所以发布到 Windows7 时才会提示缺少 dll 文件。这时，需要用文本编译器打开 neon.csproj 文件，将 `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` 更改为 `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>` 然后用 VS 重新发布该项目即可。或者可以直接用命令 `dotnet publish -r win7-x64 -c debug` 来发布。

详细 RID 可以参考 [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) 。

**为什么我设置好环境变量后，运行 CMD 提示找不到 neon？**

当你先打开了 CMD，然后设置环境变量，这时你运行 CMD，输入 neon 会提示找不到 neon。

如何解决：

这是因为你修改环境变量后没有重新启动 CMD。CMD 读取的环境变量还是之前没有修改过的，自然找不到 neon。解决办法：重启 CMD。

**为什么编译 NeoContract 时卡在 Start NeoContract converter 这一步？**

当我已经发布了 neon，并将 neon.exe 所在目录添加到 path 之后 ，编译 NeoContract 项目时卡在了 Start NeoContract converter 这一步。

如何解决：

这是因为修改环境变量后没有重新启动 Visual Studio，Visual Studio 读取的环境变量还是之前没有修改过的，所以找不到 neon。

解决办法很简单：重启 Visual Studio。还不行？那么重启系统。

**我用旧版本的 neon 编译的智能合约，代码写的没有问题，为什么在测试网或主网上运行失败？**

NEO 智能合约需要的 开发框架、编译器、NeoVM 版本要求一致。否则用旧版本的开发框架和编译器编译的代码有可能在新版 NeoVM 中运行出错。已发布到区块链上的智能合约不受此影响。

如何解决：

当你准备开始智能合约时，确保你的开发框架（如NeoContractPlugin）和编译器（如 neon）是最新版本。

**为什么用 neoj 编译的时候出现错误提示：无法找到 org.neo.smartcontract.framework.jar?**

你需要将 neo-devpack-java-master 打包成 jar 包并放入 neoj 的 \neoj\bin\Release\netcoreapp1.1\win10-x64\publish\

本文部分内容摘自文章：[NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7) 感谢 **cybourgeoisie** 的贡献。
