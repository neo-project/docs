# NEP-5

NEP5 协议是 NEO 补充协议中的第5号协议。其目的是为 NEO 建立标准的 token 化智能合约通用交互机制。NEP5资产与 UTXO 不同，它没有采用 UTXO 模型，而是在合约存储区内记账，通过对存储区内不同账户 hash 所记录余额数值的变化，完成交易。

参照 NEP5 协议的要求，在编写 NEP5 资产智能合约时必须实现以下方法：

**totalSupply**    

```c#
public static BigInteger totalSupply()
```

Returns 部署在系统内该 token 的总数。 

**name**    

```c#
public static string name()
```

Returns token的名称. e.g. "MyToken"。

该方法每次被调用时必需返回一样的值。

**symbol**

```c#
public static string symbol()
```

Returns 合约所管理的token的短字符串符号 . e.g. "MYT"。

该符号需要应该比较短小 (建议3-8个字符),  没有空白字符或换行符 ，并限制为大写拉丁字母 (26个英文字符)。 

该方法每次被调用时必需返回一样的值。

**decimals**

```c#
public static byte decimals()
```

Returns token使用的小数位数 - e.g. 8，意味着把 token 数量除以 100,000,000 来获得它的表示值。

该方法每次被调用时必需返回一样的值。 

**balanceOf**

```c#
public static BigInteger balanceOf(byte[] account)
```

Returns 账户的token金额。

参数账户必需是一个 20 字节的地址。如果不是，该方法会抛出一个异常。

如果该账户是个未被使用的地址，该方法会返回0。

**transfer**

```c#
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```

从一个账户转移一定数量的 token 到另一个账户. 参数 from 和 to 必需是 20 字节的地址，否则，该方法会报错。

参数 amount 必需大于等于0，否则，该方法会报错。

如果账户没有足够的支付金额，该函数会返回 false。

如果方法执行成功，会触发转移事件，并返回 true，即使数量为 0 或者 from 和 to 是同一个地址。

函数会检查 from 的地址是否等于调用合约的 hash，如果是，则转移会被处理；否则，函数会调用 SYSCALL `Neo.Runtime.CheckWitness`来确认转移。

如果 to 地址是一个部署合约，函数会检查其 payable 标志位来决定是否把 token 转移到该合约。

如果转移没有被处理，函数会返回false。

**事件 transfer**

```c#
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

会在token被转移时触发，包括零值转移。

一个创建新 token 的 token 合约在创建 token 时会触发转移事件，并将from的地址设置为 null。

一个销毁 token 的 token 合约在销毁 token 时会触发转移事件，并将to的地址设置为 null。