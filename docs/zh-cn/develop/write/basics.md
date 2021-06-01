# 合约开发基础

本文将介绍开发智能合约的一些基础知识。

我们来看一下这个基础的hello world合约：

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;

namespace Helloworld
{
    [ManifestExtra("Author", "Neo")]
    [ManifestExtra("Email", "dev@neo.org")]
    [ManifestExtra("Description", "This is a contract example")]
    public class Contract1 : SmartContract
    {
        //TODO: Replace it with your own address.
        [InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default;

        private static bool IsOwner() => Runtime.CheckWitness(Owner);

        // When this contract address is included in the transaction signature,
        // this method will be triggered as a VerificationTrigger to verify that the signature is correct.
        // For example, this method needs to be called when withdrawing token from the contract.
        public static bool Verify() => IsOwner();

        // TODO: Replace it with your methods.
        public static string MyMethod()
        {
            return Storage.Get(Storage.CurrentContext, "Hello");
        }

        public static void _deploy(object data, bool update)
        {
            if (update) return;

            // It will be executed during deploy
            Storage.Put(Storage.CurrentContext, "Hello", "World");
        }

        public static void Update(ByteString nefFile, string manifest)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Update(nefFile, manifest, null);
        }

        public static void Destroy()
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Destroy();
        }
    }
}
```

## 合约属性

在合约类中，使用 `static readonly` 或 `const` 定义的合约属性是常量属性且值不能更改。例如，如果想要定义合约的所属者或在以后的资产转账中使用的因数时，我们可以这样定义这些常量：

```csharp
// 代表该合约的所属者，表示为固定的地址。通常是合约的创建者
[InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
static readonly UInt160 Owner = default;

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

Neo提供了基于键值对的数据访问接口。可以使用键从智能合约中读取、删除数据或将数据记录写入到智能合约中。此外，智能合约可以检索并将它们的存储上下文发送给其他合约，从而委托其他合约管理它们的存储区域。在C#开发中，智能合约可以使用 `Storage` 类来读写持久性存储区。 `Storage` 类是一个静态类，不需要构造函数。 `Storage` 类的方法可以查看 [API 参考文档](../../reference/scapi/framework/services/Storage.md) 。

例如，如果你想将token的总供应量存储到存储区:

```c#
// 键是 totalSupply ，值是100000000
Storage.Put(Storage.CurrentContext, "totalSupply", 100000000);
```

这里 `CurrentContext` 返回当前存储上下文。获取存储上下文之后，对象可以作为参数传给其他合约(作为一种授权方式)，从而允许其他合约在当前合约的持久存储区上执行读/写操作。

对于基本类型的存储 `Storage` 类非常的有效，而对于结构化数据，你可以使用 `StorageMap` 来存储，这个类可以在智能合约存储中将整个容器存储在一个键中。

```c#
// 获取storageMap中的总供应量。这个键名称为“contract”的Map可以用来表示整个容器
StorageMap contract = new(Storage.CurrentContext, nameof(contract))
var value = contract.Get("totalSupply");
return value is null ? 0 : (BigInteger)value;;
```

## 数据类型

由于NeoVM和Dotnet IL之间的差异，当使用C#开发智能合约时并不能使用C#的全部特性。

由于NeoVM更紧凑，我们只能将有限的C# / dotnet特性编译到 NEF 文件中。

NeoVM提供了以下的基本类型:

- `Pointer`
- `Boolean`
- `Integer`
- `ByteString`
- `Buffer`
- `Array`
- `Struct`
- `Map`
- `InteropInterface`


C#的基本类型是:

- `Int8 int16 int32 int64 uint8 uint16 uint32 uint64`
- `float double`
- `Boolean`
- `Char String`

## 第一个智能合约

分析完之前那个基本的hello world合约后，我们来分析一下这个具有真实意义的智能合约。这里我们提供了一个非常简单的DNS系统，它是用C#编写的。DNS的主要功能是为用户存储域名。除了事件外，它包含了上面所说的所有概念。我们可以研究一下这个合约，学习如何开发一个基本的智能合约。源代码在这里:

```c#
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System.ComponentModel;

namespace Domain
{
    public class Contract1 : SmartContract
    {

        [DisplayName("query")]
        public static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        [DisplayName("register")]
        publilc static bool Register(string domain, byte[] owner)
        {
            // 检查合约的调用者是否是合约的所属者
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        [DisplayName("delete")]
        public static bool Delete(string domain)
        {
            // 待完成的其他代码
        }
    }
}
```

我们来逐步地看看这个合约。

### 合约特性

合约中可以声明特性：

```c#
[ManifestExtra("Author", "Neo")]
[ManifestExtra("Email", "dev@neo.org")]
[ManifestExtra("Description", "This is a contract example")]
[SupportedStandards("NEP-17")]
[ContractPermission("*", "onNEP17Payment")]
[ContractTrust("0x0a0b00ff00ff00ff00ff00ff00ff00ff00ff00a4")]
public class Contract1 : SmartContract
{
    public static bool Main(string operation, object[] args)
    {
        // 其他代码
    }
}
```

`ManifestExtra` 表示 Manifest 文件中的额外字段，可以添加 `Author`、 `Email`、 `Description` 等值；

`SupportedStandards` 表示合约符合的 NEP 标准，比如 `NEP-17` 是 Neo 上的代币标准。

`ContractPermission` 表示合约申请的权限，`ContractTrust` 表示合约信任哪些合约调用自己。参考 [权限相关字段](../deploy/invoke.html#权限相关字段)。

也可以添加其它字段，如：

```c#
[ManifestExtra("Name", "sample contract")]
[ManifestExtra("Version", "1.0.0")]
```

### 合约入口函数

理论上来说，智能合约可以有任意的入口函数，合约中 public static 类型的方法都可以用作入口函数被外部调用，例如:

```c#
using Neo.SmartContract;
using Neo.SmartContract.Framework;

namespace Neo.Compiler.MSIL.UnitTests.TestClasses
{
    class Contract_a : SmartContract.Framework.SmartContract
    {
        public static object First(string method, object[] args)
        {
            return 'a';
        }
        public static object Second(string method, object[] args)
        {
            return 'b';
        }
    }
}
```
编译器会在abi中标记`First`与`Second` 方法的offset，并在调用合约时赋给initialPosition参数来调整入口函数。在调用时，会根据abi中记录的offset，自行找到匹配的方法进入并执行。

### 触发器

智能合约触发器是触发智能合约执行逻辑的机制。在Neo智能合约中引入了三个触发器 `Verification` 触发器, `Application` 触发器 和 `System` 触发器，但在大部分的合约开发中, 不会直接涉及触发器判断, 仅需在合约中实现Verify方法, 提供签名验证逻辑。


#### Verification 触发器

当合约地址被包含在交易签名中时, 合约需要实现函数Verify，用来提供在验证签名时, 需要执行的具体逻辑。

```c#
public static bool Verify()
{
    return Runtime.CheckWitness(Owner);
}
```

### CheckWitness

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

与 `Register` 方法类似，`Delete` 方法首先检查域名所属者是否存在，如果存在，再判断调用合约的是否是该域名的所属者，如果是，则使用 `Storage.Delete` 方法来删除该键值对。

### 事件

在智能合约中，事件是区块链与应用程序前端(或后端)进行通信的一种方式，后者可以“监听”某些事件，并在事件发生时做一些操作。你可以使用这个机制来更新外部数据库、做一些分析或更新 UI。在某些特定的合约标准中，它定义了一些应该发布的事件。本节没有涉及到这方面的相关内容，但是它对于其他智能合约而言确实非常有用。例如，在 NEP-17 Token 标准中，事件 `转账` 应该在用户调用转账方法时触发。

```c#
//当对NEP-17资产进行转账时调用
[DisplayName("Transfer")]
public static event Action<byte[], byte[], BigInteger> OnTransfer;
```
Transfer 是事件名。

### Json序列化

在智能合约中, 新添加了Json正/反序列化功能, 可以用来处理类型的存储与发送. 合约示例如下:

```c#
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

namespace Neo.Compiler.MSIL.TestClasses
{
    public class Contract_Json : SmartContract.Framework.SmartContract
    {
        public static string Serialize(object obj)
        {
            return Json.Serialize(obj);
        }

        public static object Deserialize(string json)
        {
            return Json.Deserialize(json);
        }
    }
}
```

