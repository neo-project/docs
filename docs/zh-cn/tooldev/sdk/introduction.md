# 关于NEO SDK

可使用NEO SDK来开发各种基于NEO的应用，如钱包客户端，游戏等。 引用NEO SDK后，您的项目仍可在原有的环境中运行，而非在NeoVM中运行，如果想开发在 NeoVM中运行的程序，请参考[NEO 智能合约](../../sc/gettingstarted/introduction.md)。 

此文档是完全[开源](https://github.com/neo-project/docs)的。可通过任何方式参与此文档，如创建问题、编写文档等。

该文档适用于NEO 2.9.0版本。与Visual Studio 2017结合使用时，可以更方便地使用NEO SDK来开发软件。 

## 下载：

1. 在Visual Studio 2017中新建.NET项目（项目的.NET版本不能低于NEO SDK所使用的.NET版本）
2. 在项目中右键“管理 NuGet 程序包”
3. 在搜索框中搜索"NEO"，然后安装即可

此外，你也可以在[这里](https://www.nuget.org/packages/Neo/2.7.1)下载NuGet安装包来手动安装。

## 项目构成

完整的NEO SDK主要由两个项目以及众多依赖项构成：

**NEO SDK主要项目：**

NEO：https://github.com/neo-project/neo

NeoVM：https://github.com/neo-project/neo-vm

**NEO SDK依赖项：**

.NETFramework 4.7

- Akka (>= 1.3.8)

- Microsoft.AspNetCore.Server.Kestrel (>= 2.1.1)

- Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.1.1)

- Microsoft.AspNetCore.ResponseCompression (>= 2.1.1)

- Microsoft.AspNetCore.WebSockets (>= 2.1.1)

- Microsoft.EntityFrameworkCore.Sqlite (>= 2.1.1)

- Microsoft.Extensions.Configuration.Json (>= 2.1.1)

- System.Text.Encodings.Web (>= 4.5.0)

- Replicon.Cryptography.SCrypt (>= 1.1.6.13)

.NETStandard 2.0

- Akka (>= 1.3.8)

- Microsoft.AspNetCore.ResponseCompression (>= 2.1.1)

- Microsoft.AspNetCore.Server.Kestrel (>= 2.1.1)

- Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.1.1)

- Microsoft.AspNetCore.WebSockets (>= 2.1.1)

- Microsoft.EntityFrameworkCore.Sqlite (>= 2.1.1)

- Microsoft.Extensions.Configuration.Json (>= 2.1.1)

- System.Text.Encodings.Web (>= 4.5.0)
