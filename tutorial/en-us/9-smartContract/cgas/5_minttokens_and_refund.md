# MintTokens and Refund

## Part of the code for MintTokens

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

These first few lines are to get the user who initiates MintTokens, namely the investor. But investors are not allowed to be CGAS, otherwise it’s possible to use this vulnerability to attack.

```c#
if (GetTxInfo(tx.Hash) != null)
    return false;
```

The next line is also to prevent hackers, and works with the end code of MintTokens.

```c#
SetTxInfo(null, sender, value);
```

Normally an Invocation transaction will execute the Main method once, and so does a invocation through the NEO-GUI. But if a hacker manually constructs a transaction to execute the Main method multiple times and each time invoke MintTokens, it will lead to multiple token-mint operations for a single investment. Such attack can be avoided in this way. After a MintTokens method is executed, the transaction ID is written in the storage area. Every time the MintTokens is executed, return false if the transaction ID is found in the storage area, indicating it an invalid MintTokens operation.

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

The following code is to calculate the amount of GAS transferred to the CGAS contract. All transaction outputs are traversed here. If the transferred address is a CGAS address and the transferred asset is GAS, then the corresponding amount is counted.

Once getting the total amount of GAS transferred by the user to the CGAS contract, we need to perform the next two operations:

1. Modify the total amount of CGAS

   ```c#
   StorageMap contract =        Storage.CurrentContext.CreateMap(nameof(contract));
   var totalSupply = contract.Get("totalSupply").AsBigInteger();
   totalSupply += value;
   contract.Put("totalSupply", totalSupply);
   ```

2. Distribute CGAS to the user according to the exchange proportion

   ```c#
   StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
   var amount = asset.Get(sender).AsBigInteger();
   asset.Put(sender, amount + value);
   ```

Finally, transfer event is triggered to notify the client to make a transfer to the user out of nowhere, that is, to distribute the asset.

```c#
Transferred(null, sender, value);
```

There are three parameters in Transferred method, namely sender, receiver, and transferred amount. In MintTokens, the sender is null, and in the first step of the refund, the receiver is null.

Additional fees are allowed for users in MintTokens. The code only checks the GAS part of the transaction outputs transferred to the CGAS contract. The GAS included in the user’s transaction inputs and the changed GAS is not counted.

## Part of the code for Refund

Recall the introduction in the method description: Users exchange CGAS to GAS in two steps. The first step is to initiate an InvocationTransaction, which contains a GAS transferred from the CGAS address to the CGAS address (the transfer amount is the amount of GAS the user want to refund), and invoke the refund method (parameter is the refunder's Script Hash). When the contract invocation is successful, the CGAS equal to the refunded amount will be automatically ruined, and the output with index 0 of the transaction will be marked as belonging to the user. In the second step, the user creates a transaction that takes the UTXO marked in the first step as the transaction input and own address as output, thus taking the GAS from the CGAS address.

So which step does this part of the refund method correspond to?

Obviously, the refund is invoked in the Application trigger in the Main method, so only InvocationTransaction can trigger the method. The corresponding step is to execute refund method after the success of the transaction in the first step.

In the code, there are two sections of code that jointly complete the first step of the Refund, one is the code for Verification trigger mentioned above, and the other is the code for refund method.

This code is executed after the InvocationTransaction has been successfully verified.

```c#
if (from.Length != 20)
    throw new InvalidOperationException("The parameter from SHOULD be 20-byte addresses.");
```

The first is to verify the parameters, which is in line with the NEP-5 specification. The transfer is proceeding from CGAS address to CGAS address, and no user address is involved. So in order to get the user's address, it is required to take it as a parameter in the input.

```c#
var tx = ExecutionEngine.ScriptContainer as Transaction;
var preRefund = tx.GetOutputs()[0];
if (preRefund.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;
```

Then the invalidity of the Refund asset is verified.

```c#
if (preRefund.ScriptHash.AsBigInteger() != ExecutionEngine.ExecutingScriptHash.AsBigInteger()) return false;
```

Next, we are going to mark the transaction output with index 0 as refund, so first we need to verify whether the transaction output refers to the CGAS address rather than the other address.

```c#
StorageMap refund = Storage.CurrentContext.CreateMap(nameof(refund));
if (refund.Get(tx.Hash).Length > 0) return false;
……
refund.Put(tx.Hash, from);
```

This step is preventive programming to prevent the same UTXO from being refunded multiple times, which will lead to the loss of user’s assets.

```c#
if (!Runtime.CheckWitness(from)) return false;
```

The final step is to verify the signature, which is a common means for permission verification. If the hacker wants to refund other people's assets, parameter from will be filled as others’ address. At this point, the verification will fail.

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

Once the verification of the identity, it’s ready to operate the user’s assets. It is about to reduce the user's assets. In order to avoid negative numbers, we first compare the refund amount with the user’s balance, and then modify the user assets.

If the user's assets are reduced, then the total amount of CGAS will also be reduced, so the totalSupply should be modified as follows:

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

Finally, the transaction ID is recorded to facilitate query and trigger Transferred event for the convenience of blockchain explorer and client processing. Then record the refunder of the UTXO to prepare for the second step of the refund.

## Next Step
Now let us move to the [signature and verification](6_signature_and_verification.md)

To learn the function of trigger, click [here](4_trigger.md)
