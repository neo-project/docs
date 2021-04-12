# 关于 RpcClient

`RpcClient` 是一个 C# 版本的依赖库，可用来开发各种基于 Neo 的应用，如钱包客户端，游戏等。 使用本项目可以方便地调用 Neo RPC 接口，构造交易以及调用合约等。

此文档是完全[开源](https://github.com/neo-project/docs)的，可通过任何方式参与此文档，如创建问题、编写文档等。

该文档适用于 Neo N3 版本。与 Visual Studio 2019 结合使用时，可以更方便地使用 Neo SDK 来开发软件。 

## 主要功能

- 内置的 RPC 调用方法

- 交易构建，序列化和反序列化

- 智能合约的脚本构造

- 简单易用的钱包相关功能：转账，余额查询和 GAS Claim 方法


## 引用方式

1. 在 Visual Studio 2019 中新建 .NET 项目。

   项目的.NET版本不能低于 Neo SDK 所使用的 .NET 版本。

2. 在项目中右键单击 `管理 NuGet 程序包`。

3. 在搜索框中搜索  `Neo.Network.RPC.RpcClient`，然后安装即可。

4. 在需要使用该模块的项目文件的头部添加如下代码：

   ```c#
   using Neo.Network.RPC;
   ```


> [!Note]
>
> 如果使用SDK构造要添加签名的交易，需要确保构造的RpcClient对象和其连接的区块链网络有相同的配置，否则 SDK 构造的交易在区块链中将无法验签通过，具体做法是：构造RpcClient对象时Load Neo-CLI 节点的 config.json，例如： RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json")) 。

## 异常处理

`RpcClient` 主要通过 RPC 请求与 Neo 节点进行交互，当 RPC 请求返回的消息中带有 Error 时系统就会抛出异常，所以最常见的异常类型是 `RpcException`， 主要包含下面几种：

- -100, "Unknown transaction/blockhash"
- -300, "Insufficient funds"
- -301, "The necessary fee is more than the Max_fee, this transaction is failed. Please increase your Max_fee value."
- -400, "Access denied"
- -500, Relay does not succeed, the detailed reasons contain "AlreadyExists, OutOfMemory, UnableToVerify, Invalid, Expired, InsufficientFunds, PolicyFail, Unknown"
- -32600, "Invalid Request"
- -32601, "Method not found"
- -32602, "Invalid params"
- -32700, "Parse error"

除此之外，可能会遇到 .NET 平台内置的其他异常，比如当传入的参数为空或格式有误时会引发 `ArgumentNullException` 和 `FormatException` 异常，所以使用 SDK 时需要进行合理的异常捕获与提示。

## 项目地址

`RpcClient`是 neo-modules 项目的功能子集，完整开源项目请参考：

Neo-modules：https://github.com/neo-project/neo-modules

欢迎在项目问题列表中提出使用中遇到的问题：

https://github.com/neo-project/neo-modules/issues



