# 合约编写对比 (Neo N3 vs. Neo Legacy)

本文档总结了 Neo N3 与 Neo Legacy在合约编写方面的主要差异， 以便于开发人员将智能合约从Neo Legacy 迁移到 Neo N3。由于 Neo N3 仍在不断更新中，本文仅列举了改动较大或影响较大的变更，并将持续更新。

## 开发环境

### .NET Core

在 Neo N3 中，.NET Core 版本从 3.0 升级为 6.0，需要更新 SDK。

### Visual Studio 扩展

在 Neo N3 中，Visual Studio 扩展更新，需卸载旧的 NeoContractPlugin 插件，编译、安装最新的 NeoContractPlugin。

新建的合约模板有重大更新，详见 <a href="#合约模板">合约模板</a>。

### 编译器

在Neo N3中，旧版的 neon（Neo.Compiler.MSIL） 已经废弃，需使用最新的 [nccs](https://www.nuget.org/packages/Neo.Compiler.CSharp/)（Neo.Compiler.CSharp）编译器，其主要变化如下：

* 新的 nccs 取消了对 Visual Basic 语言的支持
* 新的 nccs 编译时无需 IL 中间语言，直接将 C# 代码编译为智能合约
* 可直接编译解决方案、项目、C# 文件
* 支持更多 C# 功能
* 确定性编译。代码和编译器确定的情况下，编译后的合约即是确定的
* 将 abi 文件升级为 manifest 文件
* 将 nvm 文件升级为 nef 文件
* 编译目录从 bin/debug 修改为 bin/sc

## 合约模板

### 命名空间

Neo Legacy：

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
```
Neo N3：

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
```

### 合约特性

|               | Neo Legacy                                                   | Neo N3                                                       |
| ------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| 合约信息      | 在合约部署时需填写合约特性，如名称、作者、邮箱等             | 将合约特性添加到合约文件中，以 [C# 特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/attributes/) 的方式编写。例如：<br/>[ManifestExtra("Author", "Neo")]<br/>[ManifestExtra("Email", "dev@neo.org")]<br/>[ContractTrust("\*")]<br/>[ContractPermission("\*", "\*")]<br/>[SupportedStandards("NEP-17")]<br/>[ManifestExtra("Description", "This is a contract example")]<br/>public class Contract1 : SmartContract |
| 合约功能      | 部署合约时需要声明合约功能，如是否使用存储区、是否可以动态调用、是否可以接受 NEP-5 资产。 | 默认所有合约均可以使用存储区和动态调用，通过实现 OnNEP17Payment 方法以决定是否接受 NEP-17 资产，通过实现 OnNEP11Payment 方法以决定是否接受 NEP-11（NFT 标准）资产。 |
| 声明支持的NEP | 代码示例<br/>public static string[] SupportedStandards()<br/>{<br/>    string[] result = { "NEP-5", "NEP-7", "NEP-10" };<br/>    return result;<br/>} | 直接在合约类名上添加 `[SupportedStandards("NEP-17")]` 特性。 |

#### 静态变量的声明

Neo Legacy

```c#
private static readonly byte[] InitialOwnerScriptHash = "AJhZmdHxW44FWMiMxD5bTiF7UgHcp3g2Fr".ToScriptHash();
```

Neo N3

```c#
[InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
static readonly UInt160 Owner = default;
```

#### 方法和事件

|                | Neo Legacy                                                   | Neo N3                                                       |
| -------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| main           |                                                              | 已移除，开发者不再需要写冗余的 main 方法来进行合约方法的跳转 |
| Verify         | 在Main 方法中判断，例如：<br/>public static object Main(string method, object[] args)<br/>{<br/>    if (Runtime.Trigger == TriggerType.Verification)<br/>    {<br/>    	return IsOwner();<br/>    )<br/>} | 独立的方法：<br/> `public static bool Verify() => IsOwner();` |
| 方法名         | 为了让方法名符合智能合约的命名规则，会这么声明方法：<br/>[DisplayName("balanceOf")]<br/>public static BigInteger BalanceOf(byte[] account) | 自动将方法名首字母编译为小写，开发者不用再通过 DisplayName 的方式将方法名首字母改为小写，但 DisplayName 这种写法仍然可用。 |
| 部署           | 初始化变量会放到一个单独的方法中，部署后手动调用；           | 添加 `_deploy` 方法，部署后自动执行。                        |
| 升级和销毁     | 需要自行编写升级（Update）和销毁（Destroy）方法              | 合约模板中内置了升级和销毁方法                               |
| transfer事件名 | `transfer` ，事件名为全小写                                  | `Transfer`，首字母大写                                       |

### 权限管理

#### 用户签名

Neo Legacy 默认调用链中的所有合约均可使用用户签名；

Neo N3 新增签名作用域（WitnessScope）概念，默认只允入口合约才能使用用户签名，并允许用户修改。

#### 权限与信任

Neo Legacy 中有动态调用功能的合约均可互相调用，需开发者在代码中自行控制权限，但作用有限；

Neo N3：

- 增加了对合约调用权限的限制，需要先声明权限（Permission），再调用；
- 增加了合约组（Groups）和信任（Trusts）的概念，以便钱包提供更好的安全提示；

- 增加了调用标志（CallFlag）的概念，以限制被调用的合约的行为。


#### 安全方法

Neo N3 新增安全方法，在方法中添加 [Safe] 特性，就会以只读的方式执行合约。

## 合约框架

### 原生合约

Neo N3 新增了大量原生合约，将 Neo Legacy 中的大量互操作服务转移到了原生合约中，具体变化如下：

- 将 Blockchain 类升级为 Ledger 原生合约，如：`Blockchain.GetBlock()` 改为 `Ledger.GetBlock()`。

- 新增 ContractManagement 原生合约，来查询合约以及管理合约的升级和销毁。

- 将 Blockchain 类中的合约部分移入 ContractManagement 原生合约，如：`Blockchain.GetContract()` 改为 `ContractManagement .GetContract()`。

- 新增 CryptoLib 原生合约，将 Sha256、ripemd160、VerifyWithECDsa 等方法移到该合约中。

- 新增 StdLib 原生合约，将序列化、反序列化、数据转换等方法从 Helper 类中移到该合约中。

- 新增 NEO、GAS、Oracle、Policy、RoleManagement 原生合约。

- 将选举、投票、提取 GAS等功能从单独的特殊交易移到了 NEO 原生合约中。


### 其它类

- Runtime 类有大量更新，增加更多运行时状态。

- Transaction 类有大量更新，以适配 Neo N3 交易的数据结构。

- 新增 Crypto 类，将部分 SmartContract 类提供的方法移到 Crypto 类中。

- 移除 Account 类

- 移除 Asset 类

- 移除 Header 类

- 移除 InvocationTransaction 类

- 移除 TransactionAttribute 类

- 移除 TransactionInput 类

- 移除 TransactionOutput 类


### 存储区操作

|                | Neo Legacy                                           | Neo N3                                                       |
| -------------- | ---------------------------------------------------- | ------------------------------------------------------------ |
| StorageMap     | 不能作为静态变量，要写到每个方法中                   | 支持声明静态的 StorageMap                                    |
| 存储区查找     | 找不到对应的 key时，返回 byte[]                      | 找不到对应的 key时返回 null，需要开发者自行判断是否为空，否则可能出现空引用异常 |
| 存储区数字转换 | 通过 `ToBigInteger` 方法转换                         | 通过 `(BigInteger)` 强制转换                                 |
|                | `Storage.CurrentContext.CreateMap(string name)` 方法 | 改为 StorageMap 的构造方法                                   |

Neo Legacy ：

```c#
public static readonly string mapName = "asset";

public static void Put(byte[] key, BigInteger value) => Storage.CurrentContext.CreateMap(mapName).Put(key, value);

public static BigInteger Get(byte[] key) => Storage.CurrentContext.CreateMap(mapName).Get(key).ToBigInteger();
```

Neo N3：

```c#
public static readonly string mapName = "asset";

public static void Put(UInt160 key, BigInteger value) => assetMap.Put(key, value);

public static BigInteger Get(UInt160 key)
{
    var value = assetMap.Get(key);
    return value is null ? 0 : (BigInteger)value;
}
```

### TokenSale 操作

#### 合约编写

Neo Legacy：

由于 UTXO 资产和合约资产两种资产模型的关系，进行 Token Sale 比较复杂。一般要写 mintTokens 方法，获得调用合约的交易，再从交易输入中分析出发送者，从交易输出中分析出转账金额和资产名称，最后将合约资产转给发送者。

Neo N3：

实现 OnNEP17Payment 即可完成 TokenSale 操作，发送者、转账金额再也不用从交易中逐个分析再累加汇总，而是可以直接从参数中拿到。示例代码如下：

```c#
public static void OnNEP17Payment(UInt160 from, BigInteger amount, object data)
{
    if (Runtime.CallingScriptHash == NEO.Hash)
    {
        Mint(amount * TokensPerNEO);
    }
    else if (Runtime.CallingScriptHash == GAS.Hash)
    {
        if (from != null) Mint(amount * TokensPerGAS);
    }
}
```

#### 用户操作

Neo Legacy：

首先用户通过发起 InvocationTransaction，构造交易输入和交易输出，将 NEO/GAS 转给合约地址，并且调用合约地址的 mintTokens 方法完成 TokenSale 操作。

Neo N3 ：

用户只需将 NEO/GAS 打到合约地址，此操作会触发合约的 OnNEP17Payment 方法，就能完成 TokenSale 操作。

### 异常处理

Neo Legacy：

调用合约时，如合约执行遇到异常，异常的消息并不会输出。

Neo N3：

调用合约时，异常消息会输出到调用结果中。

### 静态调用

Neo Legacy ：

```c#
[Appcall("XXXXXXXXXX")]//ScriptHash
public static extern int AnotherContract(string arg);

public static void Main()
{
    AnotherContract("Hello");    
}
```

Neo N3 ：

```c#
[Contract("0102030405060708090A0102030405060708090A")]
public class Contract1
{
    public static extern void MyMethod();
}

public static void Call()
{
    Contract1.MyMethod();
}
```

### 动态调用

Neo Legacy：

```c#
delegate object Dyncall(string method, object[] args);
public static object Main(string operation, object[] args)
{
    var dyncall = (Dyncall)target.ToDelegate();
    var newArgs = new object[1];
    var method = (string)args[0];
    newArgs[0] = args[1];
    dyncall(method, newArgs);
}
```

Neo N3：

可以直接调用 `Contract.Call()` 完成合约的动态调用：

```c#
public static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
{
    Contract.Call(to, "onNEP17Payment", CallFlags.All, new object[] { from, amount, data });
}
```

