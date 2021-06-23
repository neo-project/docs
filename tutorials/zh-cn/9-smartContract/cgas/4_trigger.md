# 触发器

## Verification 触发器部分代码

这部分代码在 refund 第一步和 refund 第二步的时候执行，执行成功后交易确认，执行失败后交易不确认。

执行逻辑为：

获取当前交易的所有 inputs 和 outputs，分析 inputs 是否包已被标记为 refund，如果有则认为是用户在执行 refund 第二步的操作，如果没有则认为用户在执行refund 第一步的操作。

refund 第二步的逻辑很简单，只能标记为 refund 的人才可以把钱取走。

refund 第一步的逻辑也不复杂，进行交易后 CGAS 合约里的钱不会变少。

```c#
var tx = ExecutionEngine.ScriptContainer as Transaction;
var inputs = tx.GetInputs();
var outputs = tx.GetOutputs();
```

这段代码是获取智能合约调用的交易，从而获得交易输入和交易输出，为后续的判断做准备。

那么如何判断 inputs 是否包已被标记为 refund 呢？

```c#
foreach (var input in inputs)
{
    if (input.PrevIndex == 0)//If UTXO n is 0, it is possible to be a marker UTXO
    {
        StorageMap refund = Storage.CurrentContext.CreateMap(nameof(refund));
        var refundMan = refund.Get(input.PrevHash);
        //If the input that is marked for refund
        if (refundMan.Length > 0)
        {
            //Only one input and one output is allowed in refund
            if (inputs.Length != 1 || outputs.Length != 1)
                return false;
            return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
        }
    }
}
```

首先对所有交易输入进行遍历，在 refund 第一步操作的这里约定了用户进行 refund 的时候将第 0 号交易输出进行标记。所以这里对 UTXO 的 prevIndex 进行判断，如果是 0 则有可能是被标记的 UTXO，然后进行下一步判断。接下来是从存储区里读取 UTXO 的 prevHash，如果获取到值，则就是标记为 refund 的 UTXO。

问：既然从存储区里读取 prevHash 是最终的判断标准，为什么还要对 prevIndex 进行判断呢？

答：存储区操作会花费较多手续费，所以将判断分为两级，先进行手续费低的判断，再进行手续费高的判断。

### refund 第二步的代码

当从存储区中读取到后，用户就可以将这笔钱取走，但是不能将 CGAS 中其余的钱取走，所以这里对 inputs 和 outputs 的数量进行了限制，在 refund 操作中只允许一个 input 和一个 output。

```c#
if (inputs.Length != 1 || outputs.Length != 1)
    return false;
return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
```

最后一句的意思就是只允许这个 UTXO 的所有人，也就是将它标记为 refund 的人能把钱取走。但是只允许一个 input 和一个 output 的话有一个潜在的 Bug，就是如果打算支付手续费的话，只能通过减少 outputs 的金额来支付手续费，而无法通过添加 inputs 的方式来支付手续费，也就是说用户无法通过添加一个带 GAS 的 UTXO 来作为附加手续费。

如何改进呢？

```c#
var references = tx.GetReferences();
for (int i = 1; i < references.Length; i++)
{
    if (references[i].ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        return false;
}
return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
```

可能像上面的代码一样，检测 inputs 中只能有第一笔是从 CGAS 中取走的，其余的 UTXO 不能从 CGAS 取走。如上面的代码，这样就形成一个约定，要取走的 UTXO 只能作为第一个 inputs，如果用户附加的手续费作为第一个 inputs，要取走的 UTXO 作为第二个 inputs 就会失败。

当然也可以进行下面的改进：

```c#
var references = tx.GetReferences();
int count = 0;
for (int i = 1; i < references.Length; i++)
{
    if (references[i].ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        count++;
}
if(count > 1)
    return false;
return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
```

这样改后就解除了“要取走的 UTXO 只能作为第一个 inputs”这样的限制，但多加了些代码也会使手续费升高。总之需要在手续费和用户体验中找到一个平衡点。

只允许一个 input 和一个 output

### refund 第一步的代码

当所有的 inputs 中都没有检测到标记为 refund 的时候，就认为用户在执行 refund 第一步的操作。

和第二步不同的是，refund 第一步是一个 InvocationTransaction，执行分为两步，第一步是通过 Verification 触发器执行的，允许一笔从 CGAS 地址到 CGAS 地址的转账，要求转账后 CGAS 地址的金额不能少。而且在转账的时候不能使用被标记为 refund 的 UTXO。第二步是通过 Application 触发器执行的，这是在交易确认之后，才执行，这里先讲 Verification 触发器部分。

```c#
var currentHash = ExecutionEngine.ExecutingScriptHash;

BigInteger inputAmount = 0;
foreach (var refe in tx.GetReferences())
{
    if (refe.AssetId.AsBigInteger() != AssetId.AsBigInteger())
        return false;
    if (refe.ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        inputAmount += refe.Value;
}

BigInteger outputAmount = 0;
foreach (var output in outputs)
{
    if (output.ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        outputAmount += output.Value;
}

return outputAmount == inputAmount;
```

代码逻辑也很简单，首先不允许 inputs 中包含非 GAS 资产，然后对来自 CGAS 地址的 inputs 进行求和，再对转到 CGAS 地址的 outputs 进行求和，比较输入总和和输出总和是否相等。

这段代码在 CGAS 中是可以附加手续费的，但是到 CNEO 的话，由于限制了不能包含非 NEO 资产，所以无法附加手续费，这是已经的 Bug，但目前影响不大。如何改进呢？

```c#
BigInteger inputAmount = 0;
foreach (var refe in tx.GetReferences())
{
    if (refe.AssetId.AsBigInteger() == AssetId.AsBigInteger() && refe.ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        inputAmount += refe.Value;
}

BigInteger outputAmount = 0;
foreach (var output in outputs)
{
    if (output.AssetId.AsBigInteger() == AssetId.AsBigInteger() && output.ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        outputAmount += output.Value;
}
return outputAmount == inputAmount;
```

如上面的代码，首先去掉了不允许包含其它资产的限制，然后进行判断：交易输入中的来自合约地址的指定的资产的数量和交易输出中的转到合约地址的指定的资产的数量相等。这样就可以避免合约中指定资产的流失。

在判断中不仅要判断资产数量，还要判断资产种类，否则就有可能发生以下的攻击：

```
交易输入                      交易输出

CGAS  100 GAS                CGAS  100 Token1
User1 100 Token1             User1 100 GAS  
```

其中 User1 是用户的地址，Token1 是其它某个不值钱的全局资产。

智能合约的安全性不亚于金融软件的安全性，在编写时需要考虑得很全面，才能避免出现漏洞。

## Application 触发器部分代码

这块就很简单了，就是标准的智能合约的格式，通过 method 的不同来执行不同的方法。

```c#
if (Runtime.Trigger == TriggerType.Application)
{
    var callscript = ExecutionEngine.CallingScriptHash;

    if (method == "balanceOf") return BalanceOf((byte[])args[0]);

    if (method == "decimals") return Decimals();

    if (method == "getRefundTarget") return GetRefundTarget((byte[])args[0]);

    if (method == "getTxInfo") return GetTxInfo((byte[])args[0]);

    if (method == "mintTokens") return MintTokens();

    if (method == "name") return Name();

    if (method == "refund") return Refund((byte[])args[0]);

    if (method == "symbol") return Symbol();

    if (method == "supportedStandards") return SupportedStandards();

    if (method == "totalSupply") return TotalSupply();

    if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2], callscript);
}
```

需要注意的是，ExecutionEngine.CallingScriptHash 该方法的意思是获取合约调用链的上一级，也就是调用 CGAS 的合约，该方法需要在一开始执行，如果是在 Transfer 方法里面执行，获取的值可能不是调用链上一级的 ScriptHash。

## VerificationR 触发器部分代码

```c#
if (Runtime.Trigger == TriggerType.VerificationR) //Backward compatibility, refusing to accept other assets
{
    var currentHash = ExecutionEngine.ExecutingScriptHash;
    var tx = ExecutionEngine.ScriptContainer as Transaction;
    foreach (var output in tx.GetOutputs())
    {
        if (output.ScriptHash == currentHash && output.AssetId.AsBigInteger() != AssetId.AsBigInteger())
            return false;
    }
    return true;
}
```

这个触发器目前还没有实现，是对 NEP-7 的向后兼容，如果节点支持 NEP-7，它在 CGAS 收到转账的时候会进行验证，返回 false 代表拒绝接收这笔转账，返回 true 代表接收这笔转账。在什么情况下拒绝接受转账呢？就是用户转了一些奇奇怪怪的资产，因为用户如果误转了其它资产到 CGAS 地址，他是无法将其取出的，所以这段代码就是加以限制。但目前主网上还不支持 NEP-7，所以暂时不起作用。

## 阅读下节

下节我们将介绍 [铸币与退款](5_minttokens_and_refund.md)。

如果要返回上节了解CGAS中的UTXO模型，点击[这里](3_utxo_model.md)。