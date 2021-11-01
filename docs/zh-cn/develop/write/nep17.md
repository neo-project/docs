# NEP-17

NEP17 协议是 Neo 补充协议中的第17号协议，替代了原先的NEP5协议。其目的是为 Neo 建立标准的 token 化智能合约通用交互机制。NEP17资产是在合约存储区内记账，通过对存储区内不同账户 hash 记录余额数值的变化，完成交易。

参照 NEP17 协议的要求，在编写 NEP17 资产智能合约时必须实现以下方法：

**totalSupply**    

```c#
public static BigInteger totalSupply()
```

返回部署在系统内该 token 的总数。 

**symbol**

```c#
public static string symbol()
```

返回合约所管理的token的短字符串符号 . e.g. `"MYT"`。

该符号必须是一个有效的ASCII字符串，不能有空白字符或换行符，应该限制为简短的（建议为3-8个字符长）大写拉丁字母 (即26个英文字符)。 

该方法每次被调用时必须返回一样的值。

**decimals**

```c#
public static byte decimals()
```

返回token使用的小数位数 - e.g. `8`，意味着把 token 数量除以 `100,000,000` 来获得它的表示值。

该方法每次被调用时必须返回一样的值。 

**balanceOf**

```c#
public static BigInteger balanceOf(byte[] account)
```

返回`account`的token余额。

参数`account`必须是一个 20 字节的地址。如果不是，该方法应该`抛出异常`。

如果`account`是个未被使用的地址，该方法必须返回`0`。

**transfer**

```c#
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```
从账户`from`转移数量为`amount`的token到地址`to`。

参数 `from` 和 `to` 必须是 20 字节长的地址。否则，该方法应该`抛出异常`。

参数 `amount` 必须大于或等于`0`。否则，该方法应该`抛出异常`。

如果账户`from`的余额不足以支付费用，该函数必须返回 `false`。

如果方法执行成功，必须触发`Transfer`事件，并且必须返回 `true`，即使`amount`为 0 或者 `from` 和 `to` 是同一个地址。

函数应该检查当前调用该方法的合约哈希是否等于地址`from`。如果是，则应该对转账操作进行处理；否则，函数应该调用 SYSCALL `Neo.Runtime.CheckWitness`来验证转账操作。

如果转账操作没有执行成功，该函数必须返回`false`。

如果 `to` 是一个已部署合约的地址哈希，函数必须在触发`Transfer`事件后调用合约`to`的`onNEP17Payment`方法。如果合约`to`不想接收这笔转账，则必须调用操作码`ABORT`。

**事件 Transfer**

```c#
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

在token转账完成后必须触发该事件，包括`amount`为0以及`from`和`to`为同一地址的情况。

一个创建新 token 的 token 合约在创建 token 时必须触发`Transfer`事件，并将地址`from`设置为 `null`。

一个销毁 token 的 token 合约在销毁 token 时必须触发`Transfer`事件，并将地址`to`设置为 `null`。

NEP17 合约方法如下，完整的合约代码可参考 [GitHub 源码](https://github.com/neo-project/examples/tree/master/csharp/NEP17)。

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace Template.NEP17.CSharp
{
    public partial class NEP17 : SmartContract
    {
        public static BigInteger TotalSupply() => TotalSupplyStorage.Get();

        public static BigInteger BalanceOf(UInt160 account)
        {
            if (!ValidateAddress(account)) throw new Exception("The parameters account SHOULD be a 20-byte non-zero address.");
            return AssetStorage.Get(account);
        }

        public static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
        {
            if (!ValidateAddress(from) || !ValidateAddress(to)) throw new Exception("The parameters from and to SHOULD be 20-byte non-zero addresses.");
            if (amount <= 0) throw new Exception("The parameter amount MUST be greater than 0.");
            if (!Runtime.CheckWitness(from) && !from.Equals(ExecutionEngine.CallingScriptHash)) throw new Exception("No authorization.");
            if (AssetStorage.Get(from) < amount) throw new Exception("Insufficient balance.");
            if (from == to) return true;

            AssetStorage.Reduce(from, amount);
            AssetStorage.Increase(to, amount);

            OnTransfer(from, to, amount);

            // Validate payable
            if (IsDeployed(to)) Contract.Call(to, "onNEP17Payment", new object[] { from, amount, data });
            return true;
        }
    }
}
```

## NEP-17 变化

本节总结了NEP-17相对于NEP-5协议发生的改动。

### onNEP17Payment

- Transfer 方法需判断收款方是否是部署的合约，如果是，则调用它的 `onNEP17Payment` 方法。

- 原生合约的 FungibleToken（NeoToken、GasToken） 在转账时会调用 `onNEP17Tokens` 方法。NonfungibleToken 在转账时会调用 `onNEP11Tokens` 方法。

- TokenSale 合约需要实现 `onNEP17Payment` 方法，以接收资产，并修改 Manifest 文件以信任接收的资产合约对其调用。


### name 方法

移除了 name 方法，将 name 方法放到了 manifest 中，在写合约时要添加 `[DisplayName("Token Name")]`。

```c#
[DisplayName("Token Name")]
[ManifestExtra("Author", "Neo")]
[ManifestExtra("Email", "dev@neo.org")]
[ManifestExtra("Description", "This is a NEP17 example")]
[SupportedStandards("NEP-17")]
public partial class NEP17 : SmartContract
{
    [DisplayName("Transfer")]
    public static event Action<UInt160, UInt160, BigInteger> OnTransfer;

    public static string Symbol() => "TokenSymbol";

    public static ulong Decimals() => 8;
    
    //……
}
```

### Transfer 事件

transfer 事件变更为 Transfer 事件 （首字母大写）。

### IsPayable

在 Neo Legacy 中部署合约时需要勾选 IsPayable 表示能否接收 NEP-17 资产。

在 Neo N3 中移除了 payable 检查，相应逻辑将放到 `onNEP17Payment` 方法中。

合约能否接收资产从固定不变的常量改为合约内的代码逻辑。

