# 智能合约

## 为什么我发布 neon 时提示无法还原 NuGet 包？即使我尝试使用 Visual Studio 2017 进行还原，仍然会出现同样的错误。

可根据以下步骤解决该问题：

1. 在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 neo-compiler 项目的根目录。
2. 打开 Power Shell 或命令提示符（CMD）。
3. 转到 neo-compiler 根目录，运行 `nuget restore` 。

## 为什么我发布 neon 项目出现如下错误提示：无法复制文件”obj\Release\netcoreapp1.0\win10-x64\neon.dll“，原因是找不到该文件？

这可能是 VS 2017 （如 15.4，15.5）的一个 Bug，此时需要手动将 `\obj\Release\netcoreapp1.0\neon.dll` 文件复制到 `\obj\Release\netcoreapp1.0\win10-x64\` 文件夹中，然后重新发布即可。

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