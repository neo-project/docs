# Triggers

## The trigger part of Verification

This part of the code is executed in the first two steps of refund. If the execution is successful, the transaction is confirmed; otherwise it will not be confirmed.

The execution logic is:

Get all inputs and outputs of the current transaction, and analyze the inputs to determine whether input marked as refund is included. If so, it is considered that the the user is preforming the second step for refund, while if not, the user should be in the first step for refund.

The logic for the second refund step is simple. Only those marked as refund can take away the token.

The logic for the first step also is not complicated, and the amount in the CGAS contract will not be reduced after the transaction.

```c#
var tx = ExecutionEngine.ScriptContainer as Transaction;
var inputs = tx.GetInputs();
var outputs = tx.GetOutputs();
```

This code section is to get the transaction invoked by the smart contract, so as to get the transaction inputs and outputs, in preparation for subsequent judgment.

So how to determine whether there exists input marked as refund in the inputs?

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

First, we proceeded to traverse all the transaction inputs. In the first step of refund operation, it is stipulated that the transaction output with index 0 is marked when user preform refund. So here the prevIndex of UTXO is checked. If it is 0, it may be the marked UTXO, and then go the next step. The next step is to read the UTXO prevHash from the store, if the return is not empty, it's the UTXO marked as refund.

Q: Since the prevHash read from the store is the final criterion, what is the judge of prevIndex for?

A: the operation of storage area will cost more fees, so we take the two-level judgment. First, the low-fee judgment is performed, and then we conduct the high-fee judgment.

### **The code for the second step of refund**

The user should be able to withdraw the respectively amount of the token when value can be read from the storage area, but cannot withdraw the rest of the token in CGAS. Therefore, the number of inputs and outputs is limited here; only one input and one output are allowed in the refund operation.

```c#
if (inputs.Length != 1 || outputs.Length != 1)
    return false;
return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
```

The last line means that only the owner of the UTXO, who marks it as refund, is allowed to withdraw the token. However, if only one input and one output are allowed, there should be a potential Bug, that is, if you intend to pay the fee, you can only pay it by reducing the amount of outputs, but not by adding inputs. In other words, users cannot add a UTXO with GAS as an additional fee.

How to improve?

```c#
var references = tx.GetReferences();
for (int i = 1; i < references.Length; i++)
{
    if (references[i].ScriptHash.AsBigInteger() == currentHash.AsBigInteger())
        return false;
}
return outputs[0].ScriptHash.AsBigInteger() == refundMan.AsBigInteger();
```

Just like the above code, only the first UTXO in inputs can be taken from CGAS, and the rest cannot be withdrawn from CGAS. As with the code, it forms a convention that the UTXO to be taken must be used only as the first input. If the user’s additional fee is used as the first input, and the UTXO to be taken as the second input, then it will not perform successfully.

Of course, the following improvement is also feasible:


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

This removes the restriction that the UTXO to be taken must be used as the first input, but the additional code also cost more fees. It's all about finding a balance between fees and user experience.

Only one input and one output are allowed

### **Code for the first step of refund**

When no refund is detected in all inputs, the user is considered to be performing the first step of refund.

Unlike the second step, the first refund step is an InvocationTransaction which is divided into two steps. The first step is performed through Verification trigger, which allows a transfer from CGAS address to CGAS address. It requires that the amount of the CGAS address should not be less after the transfer. Moreover, we could not use UTXO marked as refund when transferring assets. The second step is performed through the Application trigger, which is executed after the transaction is confirmed. The Verification trigger section is included here.

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

The code logic should be simple. First, inputs should not include non-GAS assets, then inputs from the CGAS addresses are summed, and outputs transferred to the CGAS addresses are summed as well. Finally, compare whether the sum of inputs and outpus is equal.

Additional fees are allowed for the code in CGAS, but when it comes to CNEO, as it cannot contain non-NEO assets, it's not allowed to add fees. This is already a Bug, but it has little impact at present. How to improve?

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

The above code first removes the restriction that does not allow other assets to be included, and then determines whether the amount of specified assets from the contract address in the transaction inputs is equal to the amount of specified assets to the contract address in the transaction outputs. This prevents the loss of the assets specified in the contract.

In the judgment, it is necessary to judge not only the amount of assets, but also the type of assets; otherwise the following attacks may occur:

```
Transaction inputs                      Transaction outputs

CGAS  100 GAS                CGAS  100 Token1
User1 100 Token1             User1 100 GAS  
```

Where User1 is the user's address and Token1 is some other worthless global asset.

The security of smart contracts is no less than the security of financial softwares, which needs to be considered very comprehensively when writing to avoid vulnerability.

## The trigger part of Application

This part is very simple. It is the standard smart contract format, that is, executing different methods according to the type of the method.

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

Remarkably, the ExecutionEngine.CallingScriptHash method means to obtain the upper level of the contract invocation chain, which is the contract invoking CGAS. This method needs to be executed in the first place. If it is executed in the Transfer method, the obtained value may not be the scriptHash of the upper level of the invocation chain.

## The trigger part of VerificationR

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

This trigger has not been implemented yet, which is backward compatible with NEP-7. If the node supports NEP-7, it will verify when the transfer is received by CGAS. Return false if the transfer is refused, true otherwise. What can result in the transfer being refused? In case the user transfers some strange assets, as if the user mistakenly transfers other assets to the CGAS address, he cannot withdraw them, so this code is limited. However, NEP-7 is not currently supported on the main network, so it does not work for the time being.

## Next Step
Now let us move to function of [mint token and refund](5_minttokens_and_refund.md).

If you want to know how is UTXO model working in the CGAS, click [here](3_utxo_model.md).
