# 铸币与退款

## MintTokens 部分代码

```c#
var tx = ExecutionEngine.ScriptContainer as Transaction;
byte[] sender = null;
var inputs = tx.GetReferences();
foreach (var input in inputs)
{
    if (input.AssetId.AsBigInteger() == AssetId.AsBigInteger())
        sender = sender ?? input.ScriptHash;
    if (input.ScriptHash.AsBigInteger() == ExecutionEngine.ExecutingScriptHash.AsBigInteger())
        return false;
}
```

这几行代码的作用是获取发起 MintTokens 的人，也就是投资者。但要求投资者不能是 CGAS 本身，否则就可以利用此漏洞进行攻击。

```c#
if (GetTxInfo(tx.Hash) != null)
    return false;
```

接下来这句也是防止黑客攻击的，和 MintTokens 结尾这一段代码配合使用。

```c#
SetTxInfo(null, sender, value);
```

因为正常来讲一笔 Invocation 交易会执行一遍 Main 方法，从 NEO-GUI 里调用的也是这样，但如果黑客手动构造了一笔交易，让其执行多次 Main 方法，然后都调用了 MintTokens，就会导致一笔投资，进行多次铸币操作。通过这样的方法可以避免这类攻击。在一次 MintTokens 方法执行结束后， 将交易 ID 写在存储区里，每次执行 MintTokens 的时候，如果发现存储区里有该交易 ID，则返回 False，将其认为非法的 MintTokens 操作。

```c#
var outputs = tx.GetOutputs();
ulong value = 0;
foreach (var output in outputs)
{
    if (output.ScriptHash == ExecutionEngine.ExecutingScriptHash &&
        output.AssetId.AsBigInteger() == AssetId.AsBigInteger())
    {
        value += (ulong)output.Value;
    }
}
```

接下来的代码是进行计算用户向 CGAS 合约转账了多少 GAS，这里对所有交易输出进行了遍历，如果转的地址是 CGAS 地址，并且转的资产是 GAS，则进行统计。

获取了用户总共向 CGAS 合约转了多少 GAS 之后，就要做两件事:

1. 修改 CGAS 的总量


   ```c#
   StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
   var totalSupply = contract.Get("totalSupply").AsBigInteger(); 
   totalSupply += value;
   contract.Put("totalSupply", totalSupply);
   ```

2. 给用户分按兑换比例发 CGAS


   ```c#
   StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
   var amount = asset.Get(sender).AsBigInteger();
   asset.Put(sender, amount + value);
   ```

最后触发转账的事件，通知客户端无中生有地给一个用户进行了转账，也就是分发资产。

```c#
Transferred(null, sender, value);
```

Transferred 的参数有 3 个，分别是 转账人、收款人、转账金额。在 MintTokens 中，转账人为 null，在 refund 第一步，收款人为 null。

用户如果想在 MintTokens 的时候附加一些手续费，也是可以的，代码中只检测转给 CGAS 合约的交易输出中的 GAS 部分，用户交易输入中包含的 GAS，以及找零的 GAS 程序是不进行统计的。

## Refund 部分代码

回顾一下方法说明中的介绍：用户将 CGAS 提取，变成 GAS 总共分两步。第一步，发起一笔 InvocationTransaction 其中包含一笔从 CGAS 地址到 CGAS 地址的 GAS 转账（转账金额为用户想退回的 GAS 的数量），并调用 refund 方法（参数为退回者的 Script Hash）。合约调用成功后，将自动销毁与退回数量相等的 CGAS，并把该交易的第 0 号 output 标记为所属于该用户。第二步，用户构造一个交易将第一步标记过的 UTXO 作为交易输入，交易输出为用户自己的地址，从而将 GAS 从 CGAS 地址中取走。

那么 refund 方法这一部分的代码对应上面的哪一步呢？

显然，refund 是在 Main 方法中的 Application 触发器中调用的，所以只有 InvocationTransaction 才可能触发该方法。对应的就是第一步中的交易成功后，执行 refund 方法这一步。

在代码中，有两段代码共同配合完成 Refund 的第一步的操作，一段就是上文所说的 Verification 触发器部分代码，第二段就是 refund 方法这一部分的代码。

这段代码是在 InvocationTransaction 验证成功后，才执行的。

```c#
if (from.Length != 20)
    throw new InvalidOperationException("The parameter from SHOULD be 20-byte addresses.");
```

首先是对参数进行验证，这符合 NEP-5 规范。在转账的过程一直是从 CGAS 合约地址转到 CGAS 合约地址，不存在用户的地址，所以为了获得用户的地址，需要把用户的地址作为参数传进来。

```c#
var tx = ExecutionEngine.ScriptContainer as Transaction;
var preRefund = tx.GetOutputs()[0];
if (preRefund.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;
```

然后验证了 Refund 的资产是否符合要求。

```c#
if (preRefund.ScriptHash.AsBigInteger() != ExecutionEngine.ExecutingScriptHash.AsBigInteger()) return false;
```

接下来我们打算把 index 为 0 的交易输出标记为 refund，所以先验证一下这个交易输出是否转到的是 CGAS 地址，而不是其它的地址。

```c#
StorageMap refund = Storage.CurrentContext.CreateMap(nameof(refund));
if (refund.Get(tx.Hash).Length > 0) return false; 
……
refund.Put(tx.Hash, from);
```

这一步是预防性编程，防止同一个 UTXO 被多次 refund，如果发生会让用户损失资产。

```c#
if (!Runtime.CheckWitness(from)) return false;
```

最后一步验证就是验证签名，这是进行权限验证的常用手段，如果黑客想 refund 其它人的资产，我把 from 填写为其它人的地址，到这一步验证签名就会失败。

```c#
StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
var fromAmount = asset.Get(from).AsBigInteger(); 
var preRefundValue = preRefund.Value;
if (fromAmount < preRefundValue)
    return false;
else if (fromAmount == preRefundValue)
    asset.Delete(from); 
else
    asset.Put(from, fromAmount - preRefundValue); 
```

验证好身份之后，就要对用户资产进行操作了。这里做的事情就是将用户的资产减少，为了避免产生负数，先对 refund 的金额和用户的余额进行了比较。然后修改用户资产。

有用户的资产减少了，那么 CGAS 的总量也会减少，所以还要对 totalSupply 进行修改，代码如下：

```c#
StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
var totalSupply = contract.Get("totalSupply").AsBigInteger(); 
totalSupply -= preRefundValue;
contract.Put("totalSupply", totalSupply);
```

```c#
SetTxInfo(from, null, preRefundValue);
Transferred(from, null, preRefundValue);
Refunded(tx.Hash, from);
```

最后记录下交易 ID，方便查询，触发 Transferrd 事件，方便区块链浏览器和客户端处理。然后记下这个 UTXO 是谁退回的，为 refund 第二步做准备。

## 阅读下节

下节我们将介绍 [签名与验证](6_signature_and_verification.md)。

如果要返回上节了解触发器，点击[这里](4_trigger.md)。