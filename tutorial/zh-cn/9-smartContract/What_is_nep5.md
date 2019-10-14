---
layout: post
lang: cn
lang-ref: What_is_nep5
---

# NEP-5合约

>
> **目的**:  学习NEP5的基本概念
>
> **要点:**:
>
> 1. 什么是NEP (NEO加强提案)
>
> 2. NEP5的细节
>

## 什么是NEP?
NEP代表NEO增强提案。NEP是一种设计文档，用于向NEO社区提供信息，或者描述NEO/流程/环境的新特性。NEP应该提供该特性的简明的技术规范和基本原理。NEP作者负责在社区内建立共识并记录不同意见。在这个 [github存储库]( https://github.com/neo-project/proposals) 中已经有超过10个NEPS。

对于NEO实现者而言，NEPs是跟踪其实现进度的一种简便的方法。理想情况下，每个实现维护者都会列出他们已经实现的NEPs。这将为终端用户提供一种便捷的方法，来了解给定实现或库的当前状态。

如果有人有兴趣提出一个新的NEP，那么可以先查看一下 [NEP-1]( https://github.com/neo-project/proposals/blob/master/nep-1.mediawiki)，然后克隆存储库并将你所提出的NEP添加到存储库中。这里有一个模板NEP。然后向这个存储库提交一个Pull-Request请求。

## NEP-5介绍

NEP-5标准是一个通证标准，它表示一个通证化的智能合约。该标准可以规范在NEO区块链上发行的通证。提供一个规范的与通证进行交互的方法，可以使生态系统无需去维护一些基本操作的定义，而这些操作是使用了通证的智能合约所必需的。

在NEP-5标准中，提供了一些方法同时可以触发一个事件。


### 方法

#### totalSupply

```csharp
public static BigInteger totalSupply()
```

返回系统中部署的通证的供应总量。

#### name

```csharp
public static string name()
```

返回通证的名称。例如，<code>"MyToken"</code>。

每次调用此方法时，它都必须返回相同的值。

#### symbol

```csharp
public static string symbol()
```

返回此合约中管理的通证的短字符串符号。例如，<code>"MYT"</code>。这个符号应该是简短的 (推荐是3-8个字符)，没有空格字符或换行符，并且应该限于大写的拉丁字母(即英语中使用的26个字母)。

每次调用此方法时，它都必须返回相同的值。

#### decimals

```csharp
public static byte decimals()
```


返回通证使用的小数位数——例如，<code>8</code>，表示将通证数量除以<code>100,000,000</code>，从而得到它的用户表示。

每次调用此方法时，它都必须返回相同的值。

#### balanceOf

```csharp
public static BigInteger balanceOf(byte[] account)
```

返回<code>账户</code>的通证余额。

参数 <code>account</code>  应该是20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

如果<code>账户</code> 是未使用的地址，则此方法必须返回<code>0</code>。

#### transfer
```csharp
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```

从<code>from</code>账户转数量为<code>amount</code>的通证至<code>to</code>账户。

参数 <code>from</code> 和 <code>to</code> 应该是20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

参数 <code>amount</code> 应该大于或等于 <code>0</code>。如果不是，这个方法应该<code>抛出</code>异常。

如果<code>from</code>账户余额没有足够的通证来消费，函数必须返回<code>false</code>。

如果方法执行成功，它必须触发<code>转账</code>事件，并且必须返回 <code>true</code>，即使<code>数量</code>为<code>0</code>，或者<code>from</code>和<code>to</code>是相同的地址。

函数应该检查<code>from</code> 地址是否等于合约调用者的散列值。如果是，则应处理转账;如果不是，函数应该使用SYSCALL  <code>Neo.Runtime.CheckWitness</code> 来对转账操作进行验证。

如果<code>to</code>地址是已经部署的合约，函数应该检查该合约的<code>payable</code> 标志，从而决定是否应该将通证转到该合约。

如果没有处理转账操作，函数应该返回<code>false</code>。

### 事件
#### transfer
```csharp
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

必须在通证转账(包括零值转账)时触发。

创建新通证的合约必须在通证创建时触发<code>转账</code>事件，其中地址<code>from</code>设置为<code>null</code>。

销毁通证的合约必须在通证销毁时触发<code>转账</code>事件，其中地址<code>to</code>设置为<code>null</code>。

## 阅读下节
现在让我们[实现一个NEP-5通证](Implementation_of_NEP5.md)。

如果要返回上节查看智能合约基础知识，点击[这里](Smart_Contract_basics.md)。

