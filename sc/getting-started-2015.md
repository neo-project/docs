# 如何用C#编写小蚁智能合约 for VS2015

目前小蚁智能合约推荐使用 C# 语言来开发（此外还支持 Java、Kotlin、Go、C/C++、Python、JavaScript 等编程语言）

此部分包含简短的教程，可指导你配置小蚁智能合约的 C# 开发环境，并使你了解如何创建智能合约项目，以及如何编译。 

## 开发工具

### 1. Visual Studio 2015

下载及安装方法：

如果你的计算机中已经安装过 Visual Studio 2015（任意版本），可跳过本小节。

目前 Visual Studio 2015 已经从官网首页下架，不过可以这样下载。

打开 [Visual Studio 旧版本下载页面](https://www.visualstudio.com/zh-hans/vs/older-downloads/) 点击 `立即免费加入`

   ![](~/images/2017-05-10_13-46-45.jpg)

使用自己的微软账号登录后，进入 Visual Studio Dev Essentials 后在导航菜单点击 `下载`

   ![](~/images/2017-05-10_13-47-10.jpg)

在搜索框中输入 Visual Studio Community 2015 with Update 3，然后在搜索结果中选择好版本、语言等，点击右侧的 `下载` 按钮
   ![](~/images/2017-05-10_13-45-48.jpg)

安装方法与普通软件基本相同，安装过程中无须选择额外功能，仅安装 VS2015 核心部分即可

   ![](~/images/2017-05-10_9-48-54.jpg)

### 2. NET Core tools Preview 2 for Visual Studio 2015

下载及安装方法：

打开 [.Net Core 下载页面](https://www.microsoft.com/net/download/core)

下载并安装 NET Core tools Preview 2 for Visual Studio 2015

   ![](~/images/2017-05-10_15-38-46.jpg)

### 3. AntShares.SmartContract 插件

安装方法：

打开 Visual Studio 2015，打开 `工具`， `扩展和更新` ，在左侧点击 `联机` ，搜索 AntShares，安装 AntShares.SmartContract 插件（该过程需要联网）

   ![](~/images/2017-05-10_15-50-48.jpg)

### 4. AntShares.Compiler.MSIL

安装和配置方法：

在 Github 上下载 [AntShares.VM](https://github.com/AntShares/AntShares.VM) 项目，用 Visual Studio 2015 打开该解决方案，编译其中的 AntShares.Compiler.MSIL 项目，如图

   ![](~/images/2017-05-10_18-22-39.jpg)

编译成功后，会在 bin\Debug\netcoreapp1.0\win10-x64 目录下生成 AntShares.Compiler.MSIL.exe 文件
   > [!Note]
   > 如果你的计算机是32位操作系统的，需要将 project.json 文件中的 win10-x64 更改为 win10-x86

然后需要添加path，让任何位置都能访问这个 exe 程序

添加 path 方法：

打开 `计算机属性` （或者依次打开控制面板，系统和安全，系统），打开 `高级系统设置` ，选择 `高级` 选项卡，点击 `环境变量` 按钮，如图

   ![](~/images/2017-05-10_18-37-05.jpg)


然后选择 Path, 点击 `编辑` 

   ![](~/images/2017-05-10_18-46-05.jpg)

在弹出来的窗口中点击”新建“输入 AntShares.Compiler.MSIL.exe 所在的目录，点击 `确定` ，`确定` 

   ![](~/images/2017-05-10_18-48-11.jpg)

添加完 path 后，运行 cmd 测试一下，输入 antshares.compiler.msil 后，没有报错，输出如图所示即表示环境变量配置成功

   ![](~/images/2017-05-10_18-52-10.jpg)

## 创建项目

以上四步安装配置成功后，即可在 Visual Studio 2015 中创建小蚁智能合约项目，如图

![](~/images/2017-05-10_16-08-48.jpg)

创建项目好后，会自动生成一个 c# 文件，默认的类继承于 FunctionCode，如图 

![](~/images/2017-05-10_16-25-09.jpg)

- 注：如果出现了如下图所示的现象，是因为项目中的 AntShares.SmartContract.Framework 没有成功还原，可以通过以下方式还原 NuGet 包（该过程无需联网）

![](~/images/2017-05-10_16-27-40.jpg)

​	在解决方案资源管理器中，选择解决方案，右键，单击 `还原 NuGet 包` 

![](~/images/2017-05-10_16-28-39.jpg)

​	然后打开项目的引用，点击 `AntShares.SmartContract.Framework`  即可。少数情况下仍然无法还原 Nuget 包怎么办？请重启 Visual Studio 2015 或者直接尝试生成解决方案。

![](~/images/2017-05-10_16-31-55.jpg)

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

   > [!Note]
   > 如果你生成后，没有输出上图的结果，没关系，你也可以直接输入命令将 dll 编译成 avm 文件
   >
   > 打开命令提示符，定位到Debug目录下，输入下面高亮部分（SmartContract1.dll 是上一步所生成的 dll 的名称）。
   >
   > C:\……\bin\Debug> `antshares.compiler.msil SmartContract1.dll`
   >
   > AntShars.Compiler.MSIL console app  v1.6.4.2
   >
   > 找到函数入口点:System.Void SmartContract1.Contract1::Main()
   >
   > convert succ
   >
   > write:SmartContract1.avm
   >
   > SUCC
   >
   > C:\……\bin\Debug>

现在，你已经完成了小蚁智能合约开发环境的配置，智能合约编写方法请参考 [小蚁智能合约教程](tutorial.md)

