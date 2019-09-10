

## 什么是非同质通证?

非同质通证（NFT）可以被看作是一个财产契约——每个财产都是唯一的，并且携带一些不可更改的信息(例如，财产的物理地址)，不过其他信息，例如财产的所有者，是可以更改的。NFT智能合约有助于追踪真实世界中物品的所有权，在网络游戏中也是如此，它允许用户拥有特有的角色或限量供应的道具，这些道具可以在用户之间转移，而无需获得游戏所有者的许可。

NEO智能经济的NFT提案标准目前正在开发中。这是使用C#写的一个例子，展示了如何编写这样一个智能合约。在NEP-5 (可替换的) 通证功能之间有一些重叠，以便API的编写能更容易的进行适配调整。


### 方法

#### name

```csharp
public static string name()
```

返回通证的名称。例如， <code>"MyNFT"</code>。

每次调用此方法时，它都必须返回相同的值。

#### symbol

```csharp
public static string symbol()
```

返回此合约中管理的通证的短字符串符号。例如，<code>"MNFT"</code>。这个符号应该是简短的 (推荐是3-8个字符)，没有空格字符或换行符，并且应该限于大写的拉丁字母(即英语中使用的26个字母)。

每次调用此方法时，它都必须返回相同的值。 

#### totalSupply

```csharp
public static BigInteger totalSupply()
```

返回系统中部署的通证的供应总量。

#### decimals

```csharp
public static byte decimals()
```

返回通证使用的小数位数——例如，<code>8</code>，表示将通证数量除以<code>100,000,000</code>，从而得到它的用户表示。

如果这个合约中管理的通证是不可分割的，函数应该返回 <code>0</code>。

如果函数返回非零值，则必须实现此标准中的所有''OPTIONAL''方法。

每次调用此方法时，它都必须返回相同的值。

#### tokens

```csharp
public static enumerator tokens()
```

返回此合约中已经发行的所有通证的 <code>枚举值</code>。

#### transfer

```csharp
public static bool transfer(byte[] to, byte[] tokenid)
```

将id为 <code>tokenid</code>的通证转到地址<code>to</code>。

参数 <code>tokenid</code>应该是一个有效的NFT。如果无效，这个方法应该<code>抛出</code>异常。

参数<code>to</code> 应该是一个20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

如果要转账的通证有多个所有者，函数应该返回<code>false</code>。

如果方法执行成功，它必须触发<code>转账</code> 事件，并且必须返回 <code>true</code>，即使通证是被发送给合约所有者本人。

函数应该检查所有者的地址是否等于合约调用者的散列值。如果是，则应处理转账;如果不是，函数应该使用SYSCALL <code>Neo.Runtime.CheckWitness</code> 来对转账操作进行验证。

如果 <code>to</code> 地址是已经部署的合约，函数应该检查该合约的 <code>payable</code> 标志，从而决定是否应该将通证转账到该合约。

如果没有处理转账事件，函数应该返回 <code>false</code>。 

```csharp
public static bool transfer(byte[] from, byte[] to, BigInteger amount, byte[] tokenid)
```

''OPTIONAL'': 如果<code>decimals() > 0</code>，则必须实现此方法。

将具有id <code>tokenid</code> 的通证相应的<code>数量</code>从一个地址<code>from</code>转到另一个地址<code>to</code>。

参数<code>tokenid</code>应该是一个有效的NFT。如果不是，这个方法应该<code>抛出</code>异常。

参数 <code>from</code> 和 <code>to</code> 应该是20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

参数 <code>amount</code> 应该大于或等于 <code>0</code>，并且应该小于或等于<code>pow(10, decimals())</code>。如果不是，这个方法应该<code>抛出</code>异常。

如果<code>from</code>账户余额没有足够的通证来消费，函数应该返回<code>false</code>。

如果方法执行成功，它必须触发<code>转账</code>事件，并且必须返回 <code>true</code>，即使<code>数量</code>为<code>0</code>，或者通证被发送给合约所有者本人。

函数应该检查<code>from</code> 地址是否等于合约调用者的散列值。如果是，则应处理转账;如果不是，函数应该使用SYSCALL  <code>Neo.Runtime.CheckWitness</code> 来对转账操作进行验证。

如果<code>to</code>地址是已经部署的合约，函数应该检查该合约的<code>payable</code> 标志，从而决定是否应该将通证转到该合约。

如果没有处理转账操作，函数应该返回<code>false</code>。

#### ownerOf

```csharp
public static enumerator ownerOf(byte[] tokenid)
```

返回一个<code>枚举值</code>，该枚举值包含拥有指定通证的所有共同所有者。

参数<code>tokenid</code>应该是一个有效的NFT。如果不是，这个方法应该<code>抛出</code>异常。

#### tokenURI

```csharp
public static string tokenURI(byte[] tokenid)
```

返回给定资产的不同的统一资源标识符(URI)。通证的URI数据提供了一个引用，以获取关于特定通证或通证数据的更多信息。

参数<code>tokenid</code>应该是一个有效的NFT。如果不是，这个方法应该<code>抛出</code>异常。

#### balanceOf

```csharp
public static BigInteger balanceOf(byte[] owner, byte[] tokenid)
```

返回指定所有者账户的指定通证的余额。

参数<code>tokenid</code>应该是一个有效的NFT。如果不是，这个方法应该<code>抛出</code>异常。

参数<code>owner</code> 应该是一个20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

如果<code>owner</code> 是未使用的地址，或者不是指定通证的所有者，则此方法应该返回<code>0</code>。

#### tokensOfOwner

```csharp
public static enumerator tokensOfOwner(byte[] owner)
```
返回一个<code>枚举值</code>，该枚举值包含指定地址所拥有的所有通证。

参数<code>owner</code> 应该是一个20字节长的地址。如果不是，这个方法应该<code>抛出</code>异常。

### 事件


#### transfer

```csharp
public static event transfer(byte[] from, byte[] to, BigInteger amount, byte[] tokenid)
```

必须在通证转账(包括零值转账)时触发。

创建新通证的合约应该在通证创建时触发<code>转账</code>事件，其中地址<code>from</code>设置为<code>null</code>。