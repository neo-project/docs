# 开发示例合约

我们已经搭建私链并启动节点连接私链，本节我们将继续带领开发者配置环境、编写，并编译一个 NEP17 合约。

本节内容适用于多平台，如 Windows，macOS, 和 Ubuntu。

## 下载开发工具

1. 下载并安装 [Visual Studio Code](https://code.visualstudio.com/Download)

2. 下载并安装 [.NET 6.0 SDK](https://dotnet.microsoft.com/download)

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

## 创建合约项

1. 新建一个名为 `Nep17` 的目录作为合约项目。

2. 通过命令行进入 `Nep17` 目录，并执行以下命令，使用合约模板生成代码文件

   ```powershell
   dotnet new neo3-contract
   ```
   
   此时 `Nep17` 目录下会自动创建以目录名命名的文件，Nep17.cs 和 Nep17.csproj 。
   
   如果要指定文件名，可使用参数 -n, 例如 `dotnet new neo3-contract -n tokenA`

## 编写 NEP17代码

很多开发者比较关心如何在 Neo 公链上发布自己的合约资产，下面我们就在私链上一步步实现。

1. 从 GitHub 上下载 [NEP17 示例](https://github.com/neo-project/examples/tree/master/csharp/NEP17) 中的所有 .cs 文件并放到  `Nep17` 目录下。

2. 删除原模板生成的文件 Nep17.cs。

3. 运行 VS Code，根据提示安装 C# extension。

   ![](assets\extension.png)

4. 打开 `Nep17` 目录中的 Nep17 模板文件，参考前文 [编写 NEP17 代码](#编写-nep17-代码)。

相对于 Neo Legacy 来说， Neo N3 的 NEP17 合约模板有以下改动：

- 在智能合约类上方添加了自定义特性：

  ```
  [DisplayName("Token Name")] 
  [ManifestExtra("Author", "Neo")] 
  [ManifestExtra("Email", "dev@neo.org")] 
  [ManifestExtra("Description", "This is a NEP17 example")] 
  [SupportedStandards("NEP-17")] 
  [ContractPermission("*", "onNEP17Payment")] 
  public class NEP17 : SmartContract 
  …… 
  ```

- 将 Transfer 事件改为首字母大写

- 移除了 Name 方法

- 添加了 _deploy 方法，合约部署后会立即执行

- 添加了 Update、Destroy 方法

- 所有 Crowdsale 方法都在 NEP17.Crowdsale.cs 文件中，开发者可以根据需要选择是否使用该文件

- 在 Transfer 方法中调用接收方的 onNEP17Payment 方法

- 实现 onNEP17Payment 以便在收到 NEP17 资产时自动执行智能合约

- 智能合约开发框架有了较大的改动。详情请参考 [智能合约 API](https://docs.neo.org/docs/zh-cn/reference/scapi/interop.html)。

更多信息，请参考 [NEP-17](https://docs.neo.org/docs/zh-cn/develop/write/nep17.html) 。

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

