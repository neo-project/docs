---
typora-root-url: ..\..
---

# 如何用 C# 编写 NEO 智能合约

目前 NEO 智能合约推荐使用 C# 语言来开发（此外还支持 Java、Kotlin、Go、C/C++、Python、JavaScript 等编程语言）

此部分包含简短的教程，可指导你配置 NEO 智能合约的 C# 开发环境，并使你了解如何创建智能合约项目，以及如何编译。

   > [!Note]
   > 目前 NEO 的所有项目已经升级到了 Visual Studio 2017 版本，如果你电脑中安装的是 Visual Studio 2015，请升级。

## 开发工具

### 1. Visual Studio 2017

如果你的计算机中已经安装过 Visual Studio 2017，并且在安装时勾选了 `.NET Core 跨平台开发 ` 可跳过本小节。

下载及安装方法：

[Visual Studio 下载地址](https://www.visualstudio.com/products/visual-studio-community-vs)

安装过程很简单，直接按照提示一步一步操作即可，需要注意的是在安装时需要勾选 `.NET Core 跨平台开发 ` ，安装大概需要十几分钟或几十分钟。

![](assets/install_core_cross_platform_development_toolset.jpg)

### 2. NeoContractPlugin 插件

安装方法：

打开 Visual Studio 2017，打开 ` 工具 `， ` 扩展和更新 ` ，在左侧点击 ` 联机 ` ，搜索 Neo，安装 NeoContractPlugin 插件（该过程需要联网）

![](assets/download_and_install_smart_contract_plugin.jpg)

### 3. neo-compiler

安装和配置方法：

在 Github 上下载 [neo-compiler](https://github.com/neo-project/neo-compiler) 项目，用 Visual Studio 2017 打开该解决方案，发布其中的 neon 项目，如图

![](assets/publish_neo_compiler_msil_project.jpg)

![](assets/publish_and_profile_settings.jpg)

发布成功后，会在 bin\Release\PublishOutput 目录下生成 neon.exe 文件

然后需要添加 path，让任何位置都能访问这个 exe 程序

添加 path 方法：

按 Windows + S 键，输入“环境变量”，选择“编辑账户的环境变量”回车

![](assets/2017-06-07_12-07-03.png)


然后选择 Path, 点击 ` 编辑 `

![](assets/2017-06-07_11-35-28.png)

在弹出来的窗口中点击”新建“输入 neon.exe 所在的目录，点击 ` 确定 ` ，` 确定 `

![](assets/2017-06-07_11-29-16.png)

添加完 path 后，运行 CMD 或者 PowerShell 测试一下，输入 neon.exe 后，没有报错，输出如图所示的版本号的提示信息即表示环境变量配置成功

![](assets/powershell_enviornment_variabled_updated_correctly.png)

## 创建项目

以上四步安装配置成功后，即可在 Visual Studio 2017 中创建 NEO 智能合约项目，如图

![](assets/new_smart_contract_project.png)

创建项目好后，会自动生成一个 c# 文件，默认的类继承于 FunctionCode，如图

![](/assets/smart_contract_function_code.png)

## 编译项目

一切准备就绪，为项目添加入口方法 Main

```c#
public class Contract1 : FunctionCode
{
    public static void Main() // 注意 Main 方法要大写
    {

    }
}
```

然后编译成功，你会在 `bin/Debug` 目录下看到生成的 `SmartContract1.avm` 文件，该文件即是生成的 NEO 智能合约文件。

![](assets/compile_smart_contract.jpg)

现在，你已经完成了 NEO 智能合约开发环境的配置，智能合约编写方法请参考 [NEO 智能合约教程](tutorial.md)

