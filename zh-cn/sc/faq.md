# 常见问题

## 发布 neon 时提示 NuGet 错误

### 问题

当您尝试发布 neon 时, 可能会遇到一个错误，告诉您无法还原 NuGet 包。但是，即使你尝试使用 Visual Studio 2017 进行还原，仍然会出现同样的错误，从而卡在这里，无法进行下一步。

### 解决方案

你可以在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 neo-compiler 项目的根目录。然后打开 Power Shell 或命令提示符（CMD），转到 neo-compiler 根目录，运行 `nuget restore` 即可。



## 新建的 NeoContract 项目找不到 Neo 命名空间

### 问题

当您创建了 NeoContract 项目后, 会发现代码中有很多画红线的地方，提示找不到 Neo 命名空间，而且在项目的引用中有感叹号。

### 解决方案

解决方法也很简单，在 VS 中右击解决方案文件，点击 `还原 NuGet 程序 包` ，这时在 “输出” 面板会看到 “正在还原 NuGet 程序包...”。所有程序包已经还原成功后，如果代码仍然报错，并且右侧 “引用” 中仍有个感叹号，可以尝试双击感叹号。

如果仍然无法解决问题，可以尝试下面的终极办法：在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 NeoContract 项目的根目录。然后打开 Power Shell 或命令提示符（CMD），转到 NeoContract 项目的根目录，运行 `nuget restore` 即可。



## 无法复制 neon.dll

### 问题

在 VS 2017 的某些版本中（如 15.4，15.5），发布 neon 项目会出现如下错误：

无法复制文件”obj\Release\netcoreapp1.0\win10-x64\neon.dll“，原因是找不到该文件

### 解决方案

这可能是 VS 2017 的一个 Bug，此时需要手动将 `\obj\Release\netcoreapp1.0\neon.dll` 文件复制到 `\obj\Release\netcoreapp1.0\win10-x64\` 文件夹中，然后重新发布即可发布成功。



### 缺少 api-ms-win-core-console-l2-1-0.dll 文件

### 问题：

在 Windows7 中运行 CMD 或者 PowerShell ，输入 neon 后，提示缺少  api-ms-win-core-console-l2-1-0.dll 文件。虽然可以在 [这里](https://cn.dll-files.com/api-ms-win-core-console-l2-1-0.dll.html) 下载该文件放到 neon.exe 所在目录中解决，但这种方法非常粗暴而且有安全隐患，所以不推荐。

### 解决方案：

发布时的平台错了，neon 项目默认的发布平台为 win10-x64，所以发布到 Windows7 时才会提示缺少 dll 文件。这时，需要用文本编译器打开 neon.csproj 文件，将 \<RuntimeIdentifiers>win10-x64\</RuntimeIdentifiers> 更改为 \<RuntimeIdentifiers>win7-64\</RuntimeIdentifiers> 然后用 VS 重新发布该项目即可。或者可以直接用命令 `dotnet publish -r win7-x64 -c debug` 来发布。

详细 RID 可以参考 [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)



## 设置好环境变量后，运行 CMD 提示找不到 neon

### 问题

当你先打开了 CMD，然后设置环境变量，这时你运行 CMD，输入 neon 会提示找不到 neon。

### 解决方案

这是因为你修改环境变量后没有重新启动 CMD。CMD 读取的环境变量还是之前没有修改过的，自然找不到 neon。解决办法：重启 CMD。



## 编译 NeoContract 时卡在 Start NeoContract converter 这一步

### 问题

当你已经发布了 neon，已经将 neon.exe 所在目录添加到 path 之后 ，编译 NeoContract 项目时卡在了 Start NeoContract converter 这一步。

### 解决方案

这是因为你修改环境变量后没有重新启动 Visual Studio。Visual Studio 读取的环境变量还是之前没有修改过的，自然找不到 neon，所以卡在了 Start NeoContract converter 这一步。

解决办法很简单：重启 Visual Studio。还不行？那么重启系统。



## 用旧版本的 neon 编译的智能合约，在测试网或主网运行失败

### 问题

我用旧版本的 neon 编译的智能合约，代码写的没有问题，可是在现在的测试网或主网上运行失败。

### 解决方案

NEO 智能合约需要的 开发框架、编译器、NeoVM 版本要求一致。否则用旧版本的开发框架和编译器编译的代码有可能在新版 NeoVM 中运行出错。已发布到区块链上的智能合约不受此影响。所以当你准备开始智能合约时，要确保你的开发框架（如NeoContractPlugin）和编译器（如 neon）是最新版本的。



本文部分内容摘自 **cybourgeoisie** 的文章：[NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7) 感谢 **cybourgeoisie** 的贡献。
