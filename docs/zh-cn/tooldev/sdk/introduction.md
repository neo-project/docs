# 关于 Neo RPC SDK

> [!Note]
>
> 本文档中使用的 Neo 版本为 3.0 及以上。

`NEO RPC SDK` 是一个 C# 版本的依赖库，可用来开发各种基于 Neo 的应用，如钱包客户端，游戏等。 使用本项目可以方便地调用 Neo RPC 接口，构造交易以及调用合约等。

此文档是完全[开源](https://github.com/neo-project/docs)的，可通过任何方式参与此文档，如创建问题、编写文档等。

该文档适用于 NEO3 版本。与 Visual Studio 2019 结合使用时，可以更方便地使用 NEO SDK 来开发软件。 

## 主要功能

- 内置的 RPC 调用方法

- 交易构建，序列化和反序列化

- 智能合约的脚本构造

- 简单易用的钱包相关功能：转账，余额查询和 GAS Claim 方法


## 引用方式

1. 在 Visual Studio 2019 中新建 .NET 项目。

   项目的.NET版本不能低于 NEO SDK 所使用的 .NET 版本。

2. 在项目中右键单击 `管理 NuGet 程序包`。

3. 在搜索框中搜索  `NEO`，然后安装即可。

4. 在需要使用该模块的项目文件的头部添加如下代码：

   ```c#
   using Neo.Network.RPC;
   ```

## 异常处理

`NEO RPC SDK` 主要通过 RPC 请求与 Neo 节点进行交互，当 RPC 请求返回的消息中带有 Error 时系统就会抛出异常，所以最常见的异常类型是 `RpcException`， 主要包含下面几种：

- -501, "Block or transaction already exists and cannot be sent repeatedly."
- -502, "The memory pool is full and no more transactions can be sent."
- -503, "The block cannot be validated."
- -504, "Block or transaction validation failed."
- -505, "One of the Policy filters failed."
- -500, "Unknown error."

除此之外，可能会遇到 .NET 平台内置的其他异常，比如当传入的参数为空或格式有误时会引发 `ArgumentNullException` 和 `FormatException` 异常，所以使用 SDK 时需要进行合理的异常捕获与提示。

## 项目地址

`NEO RPC SDK`是 NEO3 项目的功能子集，完整开源项目请参考：

NEO：https://github.com/neo-project/neo

欢迎在项目问题列表中提出使用中遇到的问题：

https://github.com/neo-project/neo/issues

## 阅读下节

[RPC 调用方法](rpc.md)

