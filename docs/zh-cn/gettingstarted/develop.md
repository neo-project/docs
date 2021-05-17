# 开发示例合约

我们已经搭建私链并启动节点连接私链，本节我们将继续带领开发者配置环境、编写，并编译一个 NEP17 合约。

本节内容适用于多平台，如 Windows，macOS, 和 Ubuntu。

## 下载开发工具

1. 下载并安装 [Visual Studio Code](https://code.visualstudio.com/Download)

2. 下载并安装 [.NET 5.0 SDK](https://dotnet.microsoft.com/download)

3. 打开系统命令行，执行命令查看是否成功安装 SDK。

   ```powershell
   dotnet --list-sdks
   ```

   如成功安装， 屏幕将显示 SDK 版本号。

## 安装合约模板

[Neo3.SmartContract.Templates](https://www.nuget.org/packages/Neo3.SmartContract.Templates/) 包含最新的合约编译器以及一个 hello contract 模板，推荐安装最新版：

```powershell
dotnet new -i Neo3.SmartContract.Templates
```

如果要开发 **NEO N3 RC1** 版本的合约，则需要引用与其兼容的版本 ***1.0.2***：

```powershell
dotnet new -i Neo3.SmartContract.Templates::1.0.2
```

## 创建合约项目

1. 新建一个名为 `Nep17` 的目录作为合约项目。

2. 通过命令行进入 `Nep17` 目录，并执行以下命令，使用合约模板生成代码文件

   ```powershell
   dotnet new neo3-contract
   ```
   
   此时 `Nep17` 目录下会自动创建以目录名命名的文件，Nep17.cs 和 Nep17.csproj 。
   
   如果要指定文件名，可使用参数 -n, 例如 `dotnet new neo3-contract -n tokenA`

## 编写 NEP17代码

1. 从 GitHub 上下载 [NEP17 示例](https://github.com/neo-project/examples/tree/master/csharp/NEP17) 中的所有 .cs 文件并放到  `Nep17` 目录下。

2. 删除原模板生成的文件 Nep17.cs。

3. 运行 VS Code，根据提示安装 C# extension。

   ![](assets\extension.png)

4. 打开 `Nep17` 目录中的 Nep17 模板文件，参考前文 [编写 NEP17 代码](#编写-nep17-代码)。

## 编译合约文件

编写完成后输入以下命令编译当前合约：

```powershell
dotnet build
```

![](assets\build.png)

合约项目下的 `bin\sc` 目录将生成对应的合约文件。

## 更多参考

关于合约编写的更多内容，可参考 [合约编写](../develop/write/basics.md)

要了解 Neo N3 合约编写的变动，请参考 [N3 合约变动](../develop/write/difference.md)

