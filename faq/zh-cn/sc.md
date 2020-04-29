# 智能合约

## 为什么我发布C#智能合约编译器失败？

在发布C#智能合约编译器之前，请确认你进行了以下操作：

- 已安装最新 .net core 2.1版本；
- 使用 VS2017 发布时，选择目标为 win10-64;
- 使用 VS2019 发布时，修改目标为 win10-64，并选择 “独立” 部署模式

## 为什么我创建 NeoContract 项目后, 代码中有很多画红线的地方，提示找不到 Neo 命名空间，而且在项目的引用中有感叹号？

在 VS 中右击解决方案文件，点击 `还原 NuGet 程序 包` ，这时在 “输出” 面板会看到 “正在还原 NuGet 程序包...”。所有程序包已经还原成功后，如果代码仍然报错，并且右侧 “引用” 中仍有个感叹号，可以尝试双击感叹号。如果仍然无法解决问题，可以尝试下面的办法：

1. 在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 NeoContract 项目的根目录。
2. 打开 Power Shell 或命令提示符（CMD）。
3. 转到 NeoContract 项目的根目录，运行 `nuget restore` 即可。

## 为什么当我在 Windows 7 中发布 neon 设置好环境变量后，运行 neon 时提示缺少  api-ms-win-core-console-l2-1-0.dll 文件？

发布时的平台错了，neon 项目默认的发布平台为 win10-x64，所以发布到 Windows7 时才会提示缺少 dll 文件。这时，需要用文本编译器打开 neon.csproj 文件，将 `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` 更改为 `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>` 然后用 VS 重新发布该项目即可。或者可以直接用命令 `dotnet publish -r win7-x64 -c debug` 来发布。

详细 RID 可以参考 [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) 。

## 为什么我设置好环境变量后，在 CMD 中输入 neon 却提示找不到 neon？

这是因为修改环境变量后没有重新启动 CMD，CMD 读取的环境变量还是之前没有修改过的。解决办法：重启 CMD。

## 已经发布了 neon 并将 neon.exe 所在目录添加到了 path， 为什么编译 NeoContract 时卡在 Start NeoContract converter 这一步？

这是因为修改环境变量后没有重新启动 Visual Studio，Visual Studio 读取的环境变量还是之前没有修改过的，所以找不到 neon。

解决办法：重启 Visual Studio。如果仍未解决就重启系统。

## 我用旧版本的 neon 编译的智能合约，代码写的没有问题，为什么在测试网或主网上运行失败？

NEO 智能合约需要的 开发框架、编译器、NeoVM 版本要求一致。否则用旧版本的开发框架和编译器编译的代码有可能在新版 NeoVM 中运行出错。已发布到区块链上的智能合约不受此影响。

当你准备开始智能合约时，确保你的开发框架（如NeoContractPlugin）和编译器（如 neon）是最新版本。

## 为什么用 neoj 编译的时候出现错误提示：无法找到 org.neo.smartcontract.framework.jar?

你需要将 neo-devpack-java-master 打包成 jar 包并放入 neoj 的 \neoj\bin\Release\netcoreapp1.1\win10-x64\publish\

本节部分内容摘自文章：[NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7) 感谢 **cybourgeoisie** 的贡献。

## 我成功部署了合约，为什么调用失败了？

这是因为合约使用新的NEP-8 opcodes进行编译，不兼容旧的NEOVM opcodes。要解决这个问题，需要在兼容模式下编译合约：

1. 发布 C# 编译器 neon.exe 添加其路径到环境变量
2. 通过 Visual Studio 2019 编译并构建合约
3. 在兼容模式下编译合约，使用命令： `neon contract.dll --compatible`
4. 编译成功后使用新生成的合约文件部署合约