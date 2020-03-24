# 在CGAS中使用UTXO

正如在[UTXO基础知识](../UTXO.md)中所解释的，NEO系统中使用的全局资产是基于模型UTXO的，NEO中使用的交易可以划分为交易输入和交易输出两种。 

在CGAS中，UTXO以多种方式使用。第一种用法是`MintToken`方法，可以用来获取全局资产。

这里，我们首先获取当前交易的引用。

```csharp
var references = tx.GetReferences();
```

`tx.GetRenferences`方法实际上是用于获取其他交易的`输出`结果，用于构建当前交易的输入。因此，这里的每个引用都包含一个表示资产类型的AssetId以及一个ScriptHash，其中ScriptHash表示对应输出的接收者。

在mintToken方法中，`引用`用于跟踪用户地址以及发送到CGAS合约的资产类型。为了获得发送到当前CGAS合约的全局资产的数量，我们需要调用api的 txt.getoutput()方法来获取当前交易的`输出`。在当前交易的每个输出中，将scriptionHash与CGAS scriptHash和AssetId进行比较，然后对每个输出的值求和。

```csharp
//兑换数量
var outputs = tx.GetOutputs();
ulong value = 0;
foreach (var output in outputs)
{
    if (output.ScriptHash == ExecutionEngine.ExecutingScriptHash &&
        output.AssetId.AsBigInteger() == AssetId.AsBigInteger())
    {
        alue += (ulong)output.Value;
    }
}
```

CGAS合约在退款操作中会使用另一个UTXO。这里我们只简单地提及了退款操作中使用到的UTXO的相关信息，退款操作的细则可以点击[此处](5_minttokens_and_refund.md)查看。在退款操作的验证触发器中，它将使用`输入`来检查标记的UTXO。在NEO的UTXO模型中，输入结构更像是一个指针，指向它前一个交易的输出。它有两个字段，`PrevHash`表示交易的散列值，`PrevIndex`表示相应输出的索引位置。

```csharp
foreach (var input in inputs)
	{
	    if (input.PrevIndex == 0)//如果UTXO n是0，表明这可能是一个标记UTXO
	    {
	        StorageMap refund = Storage.CurrentContext.CreateMap(nameof(refund));
	        var refundMan = refund.Get(input.PrevHash); //0.1
	        //如果输入标记为退款操作
	        if (refundMan.Length > 0)
	        {
	            //退款中只能有一个输入和一个输出
	            if (inputs.Length != 1 || outputs.Length != 1)
	                return false;
	            return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
	        }
	    }
	}
```

## 阅读下节

下节我们将介绍 [CGAS中的触发器](4_trigger.md)。

如果要返回上节了解全局资产与NEP5资产的区别，点击[这里](2_global_asset_and_nep5.md)。