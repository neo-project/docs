# About NEO SDK

You can use NEO SDK to develop various applications based on NEO, for example, wallet client, games, etc. With use of NEO SDK, your project can work in the existing environment without needing to move to NeoVM. For information about developing in NeoVM, refer to [Smart Contract](../../sc/gettingstarted/introduction.md).

This documentation is fully [open source](https://github.com/neo-project/docs). You can contribute to this project by any means, such as creating issues, writing articles and etc. Any contribution is welcome.

The NEO SDK version used in later topics is 2.9.0. It is easier to use NEO SDK to develop applications in Visual Studio 2017.

## Download

1. In Visual Studio 2017, create a new project
2. In Solution Explorer, right-click the project name and choose Manage NuGet Packages
3. Select the Browse tab and search for NEO, select Neo package in the list, and select Install

Alternatively, you can download [NuGet package](https://www.nuget.org/packages/Neo/2.7.1) and install it manually.

## Project Compositions

The complete NEO SDK consists of the following：

**NEO SDK Major Projects：**

NEO：https://github.com/neo-project/neo

NeoVM：https://github.com/neo-project/neo-vm

**NEO SDK Dependencies：**

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
