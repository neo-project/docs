# 在多平台（Windows,Mac,Ubuntu）使用 C# 编写合约

## 准备工作
1. 安装 [Visual Studio Code](https://code.visualstudio.com/Download)
2. 安装 [.NET 5.0 SDK](https://dotnet.microsoft.com/download)


## 安装合约模板
[Neo3.SmartContract.Templates](https://www.nuget.org/packages/Neo3.SmartContract.Templates/) 包含最新的合约编译器以及模板，推荐安装最新版。

```
dotnet new --install Neo3.SmartContract.Templates
```

如果希望开发的**NEO3 RC1**版本的合约，则需要引用与其兼容的版本***1.0.2***.

```
dotnet new --install Neo3.SmartContract.Templates::1.0.2
```

## 使用合约模板

开发一个名为“HelloContract”的合约：
1. 新建一个名为“HelloContract”的目录
2. 通过命令行进入“HelloContact”目录，并输入命令：
```
dotnet new neo3-contract -n HelloContract
```

>此时“HelloContract”目录下应该已经自动创建了“HelloContract.cs”、“HelloContract.csproj”两个文件。


3. 输入以下命令编译当前合约：
```
dotnet build
```
4. 使用VS Code打开“HelloContract”目录，编写合约代码即可。
