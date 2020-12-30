# NEP-17

NEP17 协议是 Neo 补充协议中的第17号协议，替代了原先的NEP17协议。其目的是为 Neo 建立标准的 token 化智能合约通用交互机制。NEP17资产是在合约存储区内记账，通过对存储区内不同账户 hash 记录余额数值的变化，完成交易。

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

如果 `to` 是一个已部署合约的地址哈希，函数必须在触发`Transfer`事件后调用合约`to`的`onPayment`方法。如果合约`to`不想接收这笔转账，则必须调用操作码`ABORT`。

**事件 Transfer**

```c#
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

在token转账完成后必须触发该事件，包括`amount`为0以及`from`和`to`为同一地址的情况。

一个创建新 token 的 token 合约在创建 token 时必须触发`Transfer`事件，并将地址`from`设置为 `null`。

一个销毁 token 的 token 合约在销毁 token 时必须触发`Transfer`事件，并将地址`to`设置为 `null`。

完整的 NEP-5 合约如下，也可参考 [GitHub 源码](https://github.com/neo-ngd/Neo3-Smart-Contract-Examples/blob/master/NEP17/Contract1.cs)

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NEP17
{
    [Features(ContractFeatures.HasStorage)]
    public class NEP17 : SmartContract
    {
        [DisplayName("Transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        private static readonly BigInteger TotalSupplyValue = 10000000000000000;

        private static readonly byte[] Owner = "NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9".ToScriptHash(); //Owner Address

        private static readonly StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));

        private static readonly StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return Runtime.CheckWitness(Owner);
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                var callscript = ExecutionEngine.CallingScriptHash;

                if (method == "deploy") return Deploy();

                if (method == "balanceOf") return BalanceOf((byte[])args[0]);

                if (method == "decimals") return Decimals();

                if (method == "name") return Name();

                if (method == "symbol") return Symbol();

                if (method == "supportedStandards") return SupportedStandards();

                if (method == "totalSupply") return TotalSupply();

                if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2], callscript);
            }
            return false;
        }

        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            
            contract.Put("totalSupply", TotalSupplyValue);
            
            asset.Put(Owner, TotalSupplyValue);
            Transferred(null, Owner, TotalSupplyValue);
            return true;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] account)
        {
            if (account.Length != 20)
                throw new InvalidOperationException("The parameter account SHOULD be 20-byte non-zero addresses.");
            return asset.Get(account).TryToBigInteger();
        }

        [DisplayName("decimals")]
        public static byte Decimals() => 8;

        private static void onPayment(BigInteger amount)
        {
            SmartContract.Abort();
        }

        [DisplayName("name")]
        public static string Name() => "MyToken"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "MYT"; //symbol of the token

        [DisplayName("supportedStandards")]
        public static string[] SupportedStandards() => new string[] { "NEP-5", "NEP-7", "NEP-10" };

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            return contract.Get("totalSupply").TryToBigInteger();
        }

#if DEBUG
        [DisplayName("transfer")] //Only for ABI file
        public static bool Transfer(byte[] from, byte[] to, BigInteger amount) => true;
#endif
        //Methods of actual execution
        private static bool Transfer(byte[] from, byte[] to, BigInteger amount, byte[] callscript)
        {
            //Check parameters
            if (from.Length != 20 || to.Length != 20)
                throw new InvalidOperationException("The parameters from and to SHOULD be 20-byte addresses.");
            if (amount <= 0)
                throw new InvalidOperationException("The parameter amount MUST be greater than 0.");
            if (!Runtime.CheckWitness(from) && from.TryToBigInteger() != callscript.TryToBigInteger())
                return false;
            var fromAmount = asset.Get(from).TryToBigInteger();
            if (fromAmount < amount)
                return false;
            if (from == to)
                return true;

            //Reduce payer balances
            if (fromAmount == amount)
                asset.Delete(from);
            else
                asset.Put(from, fromAmount - amount);

            //Increase the payee balance
            var toAmount = asset.Get(to).TryToBigInteger();
            asset.Put(to, toAmount + amount);

            Transferred(from, to, amount);

            // Validate payable
            if (Blockchain.GetContract(to) != null) Contract.Call(to, "onPayment", new object[] { amount });
            return true;
        }
    }

    public static class Helper
    {
        public static BigInteger TryToBigInteger(this byte[] value)
        {
            return value?.ToBigInteger() ?? 0;
        }
    }
}
```

