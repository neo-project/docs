# NEO SDK

You can use NEO SDK to develop various applications based on NEO, for example, wallet client, games, and etc. With use of NEO SDK, your project can work in the existing environment without needing to move to NeoVM. For information about developing in NeoVM, refer to [Smart Contract](../../sc/introduction.md). 

This document is applicable to NEO 2.7.1. It is more easier to use NEO SDK to develop applications in conjunction with Visual Studio 2017.

## Download

1. In Visual Studio 2017, create a new project.
2. Right-click the project name and select Manage NuGet program package.
3. Search NEO and install the Neo package.

Alternatively, you can download [NuGet package](https://www.nuget.org/packages/Neo/2.7.1) and install manually.

## Project Compositions

The complete NEO SDK consists of the following：

**NEO SDK Major Projects：**

NEO：https://github.com/neo-project/neo

NeoVM：https://github.com/neo-project/neo-vm

**NEO SDK Dependencies：**

.NETFramework 4.7

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 

​	Replicon.Cryptography.SCrypt (>= 1.1.6.13) 

.NETStandard 2.0

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 