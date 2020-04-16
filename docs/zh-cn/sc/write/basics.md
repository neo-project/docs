# 合约开发基础

本文将介绍开发智能合约的一些基础知识。

我们来看一下这个基础的hello world合约：

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;

namespace Helloworld
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        private const string test_str = "Hello World";
        public static String Main(string operation, object[] args)
        {
            Storage.Put("Hello", "World");
            return test_str;
        }
    }
}
```

## 合约结构

每个智能合约都继承了Neo框架中的 `SmartContract` 基类，并实现了一些基本的方法。

命名空间 `NEO` 是Neo区块链所提供的API，它提供了访问区块链数据和操作持久存储的方法。这些API分为两类:

1. 区块链分类账本。合约可以通过interops层访问整个区块链上的所有数据，包括完整的区块和交易数据，以及它们的所有字段。
2. 持久化存储。部署在Neo上的每个应用程序合约都有一个只能由合约自身访问的存储空间。所提供的这些方法可以用来访问合约中的数据。

## 合约属性

在合约类中，使用 `static readonly` 或 `const` 定义的合约属性是常量属性且值不能更改。例如，如果想要定义合约的所属者或在以后的资产转账中使用的因数时，我们可以这样定义这些常量:

```csharp
// 代表该合约的所属者，表示为固定的地址。通常是合约的创建者
public static readonly byte[] Owner = "ATrzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr".ToScriptHash();

// 一个常量
private const ulong factor = 100000000;
```

在合约属性中定义的这些属性通常是一些常量，可以在智能合约方法的内部使用，当智能合约在任意实例上运行时，这些属性的值都保持不变。

此外，开发人员可以在合约中定义静态方法并返回一个常量，该常量可以将方法暴露在合约之外，让终端用户在查询智能合约时可以通过调用该方法来获取这个固定常量。例如，创建自己的token时，你需要定义一个名称，这样每个使用你的合约的人都可以调用这个方法来检查这个名称。

```csharp
public static string Name() => "name of the token";
```

## 存储属性

在开发智能合约时，必须将应用程序的数据存储在区块链上。当创建一个智能合约或者交易使用这个合约时，合约的代码需要读写它的存储空间。存储在智能合约存储区中的所有数据在智能合约的调用期间会自动持久化。区块链中的全节点会存储链上每一个智能合约的状态。

Neo提供了基于键值对的数据访问接口。可以使用键从智能合约中读取、删除数据或将数据记录写入到智能合约中。此外，智能合约可以检索并将它们的存储上下文发送给其他合约，从而委托其他合约管理它们的存储区域。在C#开发中，智能合约可以使用 `Storage` 类来读写持久性存储区。 `Storage` 类是一个静态类，不需要构造函数。 `Storage` 类的方法可以查看 [API 参考文档](../../reference/scapi/fw/dotnet/neo/Storage.md) 。

例如，如果你想将token的总供应量存储到存储区:

```c#
// 键是 totalSupply ，值是100000000
Storage.Put(Storage.CurrentContext, "totalSupply", 100000000);
```

这里 `CurrentContext` 返回当前存储上下文。获取存储上下文之后，对象可以作为参数传给其他合约(作为一种授权方式)，从而允许其他合约在当前合约的持久存储区上执行读/写操作。

对于基本类型的存储 `Storage` 类非常的有效，而对于结构化数据，你可以使用 `StorageMap` 来存储，这个类可以在智能合约存储中将整个容器存储在一个键中。

```c#
// 获取storageMap中的总供应量。这个键名称为“contract”的Map可以用来表示整个容器
StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
return contract.Get("totalSupply").AsBigInteger();
```

## 数据类型

由于NeoVM和Dotnet IL之间的差异，当使用C#开发智能合约时并不能使用C#的全部特性。

由于NeoVM更紧凑，我们只能将有限的C# / dotnet特性编译到AVM文件中。

NeoVM提供了以下的基本类型:

- `ByteArray`
- `Integer`
- `Boolean`
- `Array`
- `Struct`
- `Map`
- `Interface`

AVM代码可直接生成的基本类型只有:

- `ByteArray`（ByteArray 可用来表示Integer和 Boolean两种基本类型）
- `Array`
- `Struct`
- `Map`

C#的基本类型是:

- `Int8 int16 int32 int64 uint8 uint16 uint32 uint64`
- `float double`
- `Boolean`
- `Char String`

## 第一个智能合约

分析完之前那个基本的hello world合约后，我们来分析一下这个具有真实意义的智能合约。这里我们提供了一个非常简单的DNS系统，它是用C#编写的。DNS的主要功能是为用户存储域名。除了事件外，它包含了上面所说的所有概念。我们可以研究一下这个合约，学习如何开发一个基本的智能合约。源代码在这里:

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.ComponentModel;

namespace Domain
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        public static object Main(string method, params object[] args)
        {
            return method switch
            {
                "query" => Query((string)args[0]),
                "register" => Register((string)args[0], (byte[])args[1]),
                "delete" => Delete((string)args[0]),
                _ => false,
            };
        }

        [DisplayName("query")]
        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        [DisplayName("register")]
        private static bool Register(string domain, byte[] owner)
        {
            // 检查合约的调用者是否是合约的所属者
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        [DisplayName("delete")]
        private static bool Delete(string domain)
        {
            // 待完成的其他代码
        }
    }
}
```

我们来逐步地看看这个合约。

## 合约特性

```c#
[Features(ContractFeatures.HasStorage)]
```

在合约的类的上方可以写合约特性，这一句的意思是合约可以访问存储区。

## Main 方法

理论上来说，智能合约可以有任意的入口函数，但是我们建议使用main函数作为智能合约的入口点，从而能够能更容易地进行方法调用。在main函数中，用户可以根据不同的入口点调用其他的函数。通常在main方法中，开发人员必须处理 `触发器` 逻辑。

### 触发器

智能合约触发器是触发智能合约执行逻辑的机制。在Neo智能合约中引入了两个触发器 `Verification` 触发器和 `Application` 触发器。

### Verification 触发器

Verification触发器作为验证函数来调用合约，该函数可以接受多个参数，并且返回一个有效的布尔值，从而表明交易或区块的有效性。

当将资产从账户A转移到账户B时，会触发Verification合约。所有接收到交易的节点(包括普通节点和异常的共识节点) 会对账户A的合约进行验证。如果返回值为true，则表示转账交易已经成功。如果返回false，则表示转账失败。

因此，Verification触发器可以用来判断是否需要将交易转发到网络的其余部分。如果返回 `false` ，则意味着交易不会记录在区块链中，并且交易失败。

```c#
public static bool Main(byte[] signature)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*condition A*/)
                return true;
            else
                return false;
    }  
}
```

### Application 触发器

Application触发器作为验证函数来调用合约, 该函数可以接受多个参数、更改区块链状态并返回任何类型的值。

与由转账交易触发的 Verification 触发器不同，Application触发器是由特殊交易`InvocationTransaction` 触发的。如果应用程序(Web/App)调用一个智能合约，就会构造一个 `InvocationTransaction` ，然后在procaAn应用程序触发器中进行签名和广播，将合约作为验证函数调用。在 `InvocationTransaction` 交易被确认后，共识节点就会执行智能合约。公共节点在转发交易时不会执行智能合约。

由于应用程序合约是在 `InvocationTransaction` 被确认后执行的，所以无论应用程序合约的执行是否成功，该交易都将记录在区块链中。

InvocationTransaction 的成功与否和智能合约执行的成功或失败没有必然联系。

通常在智能合约中， verification 触发器和 application 触发器都是可以捕获到的，开发人员必须对这些触发器进行处理。

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*Condition A*/)
                return true;
            else
                return false;
    }  
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
    }  
}

// 有一个智能合约的入口点，并从Main方法中重定向
public static bool FunctionA(params object[] args)
{
    // 其他代码  
}
```

在我们的 `DNS智能合约` 中，第一个方法是 `Main` 方法，它是智能合约的主要入口点。Main 方法将第一个参数解析为操作参数，剩下的为其他参数。

```c#
public static object Main(string method, params object[] args)
{
    return method switch
    {
        "query" => Query((string)args[0]),
        "register" => Register((string)args[0], (byte[])args[1]),
        "transfer" => Transfer((string)args[0], (byte[])args[1]),
        "delete" => Delete((string)args[0]),
        _ => false,
    };
}
```

在 Main 方法中，我们首先使用触发器来判断用户是否使用 `invocationTransaction` 来调用智能合约，这个交易表示用户在调用智能合约程序。这里，由于它是一个没有资产转账的普通类型的智能合约，因此只考虑Application触发器。在判断语句中，方法将根据操作类型重定向至其他函数。

现在我们可以看看每个具体的函数中执行了什么操作。第一个是 Query 方法，它用来查询域名地址的所属者。这里我们使用 `Storage.Get` 方法，第一个参数是 context，这里我们传入 CurrentContext。第二个参数是存储的键值对的键。这里我们使用域名作为参数。

```c#
private static byte[] Query(string domain)
{
    return Storage.Get(Storage.CurrentContext, domain);
}
```

## CheckWitness

在许多情况下(如果不是所有情况)，你可能希望对调用合约代码的地址进行验证。

`Runtime.CheckWitness` 方法接受一个参数，该参数表示你想要验证的调用合约代码的地址。更准确地来说，它验证调用合约的交易/区块是否已验证了所需的脚本散列。

通常，这个方法用于检查指定的地址是否是合约调用者，然后可以使用该地址进行存储更改或一些其他操作。

在我们的 `DNS智能合约` 中，`Register` 方法首先检查调用合约的人是否是域名的所属者。这里我们使用 `Runtime.CheckWitness` 方法。然后我们首先试着去获取域名的所属者，看看该域名是否已经存在于存储区。如果没有，我们可以使用 `Storage.Put` 方法来存储域名-> 所属者的键值对。

```c#
private static bool Register(string domain, byte[] owner)
{
    if (!Runtime.CheckWitness(owner)) return false;
    byte[] value = Storage.Get(Storage.CurrentContext, domain);
    if (value != null) return false;
    Storage.Put(Storage.CurrentContext, domain, owner);
    return true;
}
```

与 `Register` 方法类似，`Delete` 方法首先检查域名所属者是否存在，如果存在，再判断调用合约的是否是该域名的所属者，如果是，则使用 `Storage.Delete` 方法来删除该键值对。关于这个方法，本节最后留有一个问题。

## 事件

在智能合约中，事件是区块链与应用程序前端(或后端)进行通信的一种方式，后者可以“监听”某些事件，并在事件发生时做一些操作。你可以使用这个机制来更新外部数据库、做一些分析或更新 UI。在某些特定的合约标准中，它定义了一些应该发布的事件。本节没有涉及到这方面的相关内容，但是它对于其他智能合约而言确实非常有用。例如，在 NEP-5Token 标准中，事件 `转账` 应该在用户调用转账方法时触发。

```c#
//当对NEP-5资产进行转账时调用
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

## Assignment

在上面的 `DNS` 智能合约中，有一个 `delete` 方法。其基本思想是首先检查域名所属者，如果存在并且与合约的调用者相同，则使用 `Storage.Delete` 方法来删除相应的键值对。请实现这个功能。
