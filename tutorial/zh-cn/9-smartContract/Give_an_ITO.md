---
layout: post
lang: cn
lang-ref: Give_an_ITO
---

# 发起ITO（首次通证发行）


>
> **目的**:  了解NEP5的基本概念
>
> **要点**:
>
> 1. 什么是ITO（首次通证发行）
>
> 2. MintToken函数的实现
>

## 什么是ITO（首次通证发行）

我们已经知道什么是 `NEP-5` 通证以及如何实现NEP-5通证。 NEP-5通证可用于在用户之间进行转账的资产。但是，仅仅发行此类 `NEP-5` 通证对资产发行人而言并不能盈利，因为你必须手动将此类资产与外部世界进行链接。在NEO中，允许你在 `NEP-5` 通证和NEO等全局资产之间进行交易。

ITO代表首次通证发行。通过这个过程，你可以对资产进行数字化或通证化，并通过互联网公开发布。这意味着你可以通过任何资产的价值创建业务、公司或项目。通过ITO，你可以生成代表你的资产的数字代币或通证。你可以不断地以电子方式转移这些代币或者通证。

NEO中的ITO标准是基于我们之前实现的NEP-5标准的。除了已经在NEP-5中定义的那些方法和属性之外，ITO中还应该添加一些新的方法和属性。

## 时间戳
值得注意的是，每个ITO的有效时间和通证数量都是有限制的。因此，在ITO合约中，我们应该定义ITO的开始时间和ITO的完成时间。在这段时间之外，ITO不能被成功调用。

```csharp
//ito的开始时间。即2017年8月14日星期一下午4:00:00
private const int ico_start_time = 1502726400;
//ito的结束时间。即2017年8月28日星期一下午4:00:00
private const int ico_end_time = 1503936000;
```

在合约中，我们添加了 `CurrentSwapRate` 汇率函数。该函数判断当前区块时间是否在预定义的ITO时段内。在函数内部，它通过调用 `Blockchain.GetHeader` 和 `BlockChain.GetHeight ` API获取区块时间。这些API可以直接查询区块和区块头的信息。更多API信息可以点击[此处](https://docs.neo.org/en-us/sc/reference/api/neo.html)查看。

```csharp
// 函数CurrentSwapRate（）返回在通证兑换期间，ico通证和neo之间的当前汇率
private static ulong CurrentSwapRate()
{
    // factor是一个浮点型常量。 rate表示1 NEO => 1000 NEP5
    const ulong basic_rate = 1000 * factor;
    const int ico_duration = ico_end_time - ico_start_time;
    BigInteger total_supply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
    if (total_supply >= total_amount) return 0;
    uint now = Blockchain.GetHeader(Blockchain.GetHeight()).Timestamp;
    int time = (int)now - ico_start_time;
    if (time < 0){
        return 0;
    } else if (time > ico_duration){
        return 0;
    } else{
        return basic_rate;
    }
}
```
> [!Note]
>
> 在这个 `CurrentSwapRate` 	的代码片段中，只返回了基本汇率，但是，在真实的ITO中，由于时间周期不同，程序可以返回不同的兑换汇率。

## MintToken

`MintToken` 方法是ITO合约中最重要的方法（要学习的内容还有很多）。考虑一下这种情况，项目已经发布并将其通证作为该项目的一部分对外提供。客户可以将手头上的NEO捐赠给该项目，同时将获得该项目的部分 `NEP-5` 通证。这个过程我们称之为 `MintToken`。

现在让我们实现 `MintToken` 函数。首先，在 `MintToken` 方法中，我们必须首先获取 `交易` 对象，这是该智能合约的脚本容器。

```csharp
Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
```

接下来，我们必须获取该交易的 `引用` 。这里，引用代表该交易输入的相应输出。获取引用后，我们将验证发送到合约地址（this.address）的输出是否为NEO。确认后，我们可以通过此 `TransactionOutput` 对象的 `ScriptHash` 获取相应的 `发送者` 地址。我们可以在[UTXO](UTXO.md)中了解有关 `引用` 、 `输入` 和` 输出`的更多信息。

```csharp
TransactionOutput reference = tx.GetReferences()[0];
// 检查资产是否是neo
if (reference.AssetId != neo_asset_id) return false;
byte[] sender = reference.ScriptHash;
```

现在我们必须从transactionOutput的输出中获取NEO的总数。这里的 `输出` 是当前交易的每个输出。在ITO合约的这种类型的 `MintToken` 方法中，通常我们只接受一个全局资产如 `NEO` 。因此，在仅检查NEO资产的for循环中，对 `output.Value` 的值求和。

```csharp
TransactionOutput[] outputs = tx.GetOutputs();
byte[] receiver = ExecutionEngine.ExecutingScriptHash;
ulong value = 0;
// 获取转入智能合约地址的Neo总量
foreach (TransactionOutput output in outputs){
    if (output.ScriptHash == receiver){
       if (output.AssetId != neo_asset_id) {
          return false;
        }
        value += (ulong)output.Value;
    }
}
```
如果swap_rate等于0，则表示ITO已经完成，或者ITO数量超过了该通证的总供应量。这会导致众筹的失败，并触发 `Refund` 事件。

```csharp
//众筹失败
if (swap_rate == 0){
    Refund(sender, value);
    return false;
}
```
成功处理以上语句后，就可以完成锻造流程了。首先获得由全局资产交换得到的通证。之后，分别更新余额和总供应量。最后，触发转账事件并返回true。

```csharp           
// 众筹成功
ulong token = value * swap_rate / 100000000;
BigInteger balance = Storage.Get(Storage.CurrentContext, sender).AsBigInteger();
Storage.Put(Storage.CurrentContext, sender, token + balance);
BigInteger totalSupply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
Storage.Put(Storage.CurrentContext, "totalSupply", token + totalSupply);
Transferred(null, sender, token);
return true;
```


## 阅读下节
现在你已经成功地完成了你的第一个ITO，同时也熟悉了智能合约的大部分内容，下一部分内容涉及到更为复杂的合约，[即CGAS](cgas/1_what_is_cgas.md)。

要返回上节查看如何实现NEP5合约，点击[这里](Implementation_of_NEP5.md)。

