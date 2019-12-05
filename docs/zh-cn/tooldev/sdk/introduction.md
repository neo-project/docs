# 关于NEO RPC SDK

> 注：本文档中使用的 NEO 版本为 3.0 及以上。

`NEO RPC SDK`是一个C#版本的依赖库，可用来开发各种基于NEO的应用，如钱包客户端，游戏等。 使用本项目可以方便得调用NEO RPC接口，构造交易以及调用合约等。

此文档是完全[开源](https://github.com/neo-project/docs)的。可通过任何方式参与此文档，如创建问题、编写文档等。

该文档适用于NEO 3版本。与Visual Studio 2019结合使用时，可以更方便地使用NEO SDK来开发软件。 

## 主要功能

- 内置的RPC调用方法

- 交易构建，序列化和反序列化

- 智能合约的脚本构造

- 简单易用的钱包相关功能：转账，余额查询和GAS Claim方法


## 引用方式：

1. 在Visual Studio 2019中新建.NET项目（项目的.NET版本不能低于NEO SDK所使用的.NET版本）
2. 在项目中右键“管理 NuGet 程序包”
3. 在搜索框中搜索"NEO"，然后安装即可
4. 在需要使用该模块的项目文件的头部添加如下代码：

```c#
using Neo.Network.RPC;
```

## 异常处理：

`NEO RPC SDK`主要通过RPC请求与NEO节点进行交互，当RPC请求返回的消息中带有Error时系统就会抛出异常，所以最常见的异常类型是`RpcException`， 主要包含下面几种：

- -501, "Block or transaction already exists and cannot be sent repeatedly."
- -502, "The memory pool is full and no more transactions can be sent."
- -503, "The block cannot be validated."
- -504, "Block or transaction validation failed."
- -505, "One of the Policy filters failed."
- -500, "Unknown error."

除此之外，可能会遇到.NET平台内置的其他异常，比如当传入的参数为空或格式有误时会引发`ArgumentNullException`和`FormatException`异常。所以使用SDK时需要进行合理的异常捕获与提示。

## 项目地址

`NEO RPC SDK`是NEO3项目的功能子集，完整开源项目请参考：

NEO：https://github.com/neo-project/neo

欢迎在项目问题列表中提出使用中遇到的问题：

https://github.com/neo-project/neo/issues