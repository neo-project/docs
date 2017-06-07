---
typora-root-url: ..\..
---

# 如何用C#编写小蚁智能合约

目前小蚁智能合约推荐使用 C# 语言来开发（此外还支持 Java、Kotlin、Go、C/C++、Python、JavaScript 等编程语言）

此部分包含简短的教程，可指导你配置小蚁智能合约的 C# 开发环境，并使你了解如何创建智能合约项目，以及如何编译。 

   > [!Note]
   > 目前小蚁的所有项目已经升级到了 Visual Studio 2017 版本，如果用你想使用 Visual Studio 2015 创建智能合约可以参考 [如何用C#编写小蚁智能合约 for VS2015](getting-started-2015.md)

## 开发工具

### 1. Visual Studio 2017

如果你的计算机中已经安装过 Visual Studio 2017，并且在安装时勾选了 `.NET Core 跨平台开发` 可跳过本小节。

下载及安装方法：

[Visual Studio 下载地址](https://www.visualstudio.com/products/visual-studio-community-vs)

安装过程很简单，直接按照提示一步一步操作即可，需要注意的是在安装时需要勾选 `.NET Core 跨平台开发` ，安装大概需要十几分钟或几十分钟。

![](~/images/2017-06-02_18-18-13.jpg) 

### 2.AntShares.SmartContract 插件

安装方法：

打开 Visual Studio 2017，打开 `工具`， `扩展和更新` ，在左侧点击 `联机` ，搜索 AntShares，安装 AntShares.SmartContract 插件（该过程需要联网）

![](~/images/2017-06-02_18-28-37.jpg)

### 3. AntShares.Compiler.MSIL

安装和配置方法：

在 Github 上下载 [AntShares.VM](https://github.com/AntShares/AntShares.VM) 项目，用 Visual Studio 2017 打开该解决方案，发布其中的 AntShares.Compiler.MSIL 项目，如图

![](~/images/2017-06-02_18-21-53.jpg)

![](~/images/2017-06-02_18-37-44.jpg)

发布成功后，会在 bin\Release\PublishOutput 目录下生成 AntShares.Compiler.MSIL.exe 文件

然后需要添加 path，让任何位置都能访问这个 exe 程序

添加 path 方法：

按 Windows + S 键，输入“环境变量”，选择“编辑账户的环境变量”回车

![](~/images/2017-06-07_12-07-03.png)


然后选择 Path, 点击 `编辑` 

![](~/images/2017-06-07_11-35-28.png)

在弹出来的窗口中点击”新建“输入 AntShares.Compiler.MSIL.exe 所在的目录，点击 `确定` ，`确定` 

![](~/images/2017-06-07_11-29-16.png)

添加完 path 后，运行 CMD 或者 PowerShell 测试一下，输入 antshares.compiler.msil 后，没有报错，输出如图所示的版本号的提示信息即表示环境变量配置成功

![](~/images/2017-06-07_11-48-23.png)

## 创建项目

以上四步安装配置成功后，即可在 Visual Studio 2017 中创建小蚁智能合约项目，如图

![](~/images/2017-06-07_11-51-20.png)

创建项目好后，会自动生成一个 c# 文件，默认的类继承于 FunctionCode，如图 

![](~/images/2017-06-07_11-55-41.png)

## 编译项目

一切准备就绪，为项目添加入口方法 Main

```c#
public class Contract1 : FunctionCode
{
    public static void Main() //注意Main方法要大写
    {
        
    }
}
```

然后编译成功，你会在 `bin/Debug` 目录下看到生成的 `SmartContract1.avm` 文件，该文件即是生成的小蚁智能合约文件。

![](~/images/2017-05-11_13-21-21.jpg)

现在，你已经完成了小蚁智能合约开发环境的配置，智能合约编写方法请参考 [小蚁智能合约教程](tutorial.md)

