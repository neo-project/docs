# UTXO usage in the CGAS

As explained in the [UTXO basics](../UTXO.md), the global asset used in the NEO system is UTXO based and the transaction used in the NEO is divided into transaction input and transaction output.

In the CGAS, the UTXO is used in several way. The first usage is in the `MintToken` method, which is to receive the global asset here.

Here we first get the references for the current transaction.
```csharp
var references = tx.GetReferences();
```

The `tx.GetRenferences` method is actually get the `outputs` of other transaction that construct the inputs of current transaction. Therefore, each reference here contains an AssetId which indicate the type of asset, and an ScriptHash which indicates the receiver of that output.

In the mintToken method, the `Reference` is used to track the user's address and the type of the asset that send to the CGAS contract. In order to get the amount of the global asset that send to current CGAS contract, we have to use the `Outputs` of current transaction trough the api tx.GetOutputs(). In each output of current transaction, compare the scriptHash with the CGAS scriptHash and the AssetId, and then sum the value of each output.

```csharp
//Amount of exchange
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

The other UTXO used in the CGAS contract is in the refund step. Here we only indicates the knowledge of UTXO in the refund, the detailed principle of refund will be explained in [here](5_minttokens_and_refund.md). In the refund step, in the verification trigger, it will check the marker UTXO using the `inputs`. In the UTXO model of NEO, the input structure is more like a pointer which points to the output of previous transaction which it comes from. It has two fields, the `PrevHash` which indicates the transaction hash and the `PrevIndex` which indicates the corresponding output's position.

```csharp
foreach (var input in inputs)
	{
	    if (input.PrevIndex == 0)//If UTXO n is 0, it is possible to be a marker UTXO
	    {
	        StorageMap refund = Storage.CurrentContext.CreateMap(nameof(refund));
	        var refundMan = refund.Get(input.PrevHash); //0.1
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

## Next Step
In order to learn how the trigger is working in CGAS, we move to [here](4_trigger.md)

If you want to know what is difference between global asset and NEP5, click [here](2_global_asset_and_nep5.md).
