---
layout: post
lang: en
lang-ref: Give_an_ITO
---

# Give an ITO (Initial Token Offering)


>
> **Objective**:  Learn the general idea of NEP5
>
> **Main points**:
>
> 1. What is ITO (Initial Token Offering)
>
> 2. Implementation of MintToken function
>

## What is ITO (Initial Token Offering)

We already know what is a `NEP-5` token how to [implement](What_is_nep5.md) your NEP-5 token. The NEP-5 token is used as an asset which can used to transfer between users. However, only issue such a `NEP-5` token is not profitable for issuer because you have to link this asset to outside world manually. In NEO, there is a way for your to trade between `NEP-5` token  and global asset such as NEO.

ITO stands for Initial Token Offering. With this process, you can digitize or tokenize your asset and make it publicly available through the internet. This means you can start a business, company or project with any asset value. Via ITO, you generate digital coins or tokens which represent your asset. Consecutively, you can electronically transfer these coins or tokens.

The ITO standard in NEO is based on the NEP-5 which we implemented before. In addition to those methods and properties already defined in the NEP-5, in the ITO, there are several new emthods and property should add in.

## Timestamp
It is worth noting that every ITO has limited amount of time and number of tokens. Therefore, in the ITO contract, we should define the start time of ITO and the finish time of ITO. Besides this period, the ITO can not be invoked successfully.
```csharp
//start time of ito. Which is Monday, August 14, 2017 4:00:00 PM
private const int ico_start_time = 1502726400;
//end time of ito. Which is : Monday, August 28, 2017 4:00:00 PM
private const int ico_end_time = 1503936000;
```

Inside the contract , we add a `CurrentSwapRate` rate function. The function judge if the current block time is inside the predefined ITO period. In side the function, it get the block time from the `Blockchain.GetHeader` and the `BlockChain.GetHeight` API. Those API can query the information of the block and header directly. More API can be found [here](https://docs.neo.org/en-us/sc/reference/api/neo.html).

```csharp
// The function CurrentSwapRate() returns the current exchange rate
// between ico tokens and neo during the token swap period
private static ulong CurrentSwapRate()
{
    // factor is detemined by the decimal, which is a constant. The raate means 1 NEO => 1000 NEP5
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
> In this code snippet of `CurrentSwapRate`, only the basic rate is retured, however, in the real life ITO, due to the different time period, the program can return different swap rate.

## MintToken

The `MintToken` method is the most important method in the ITO contract (which also has more things to learn). Think of the idea that project is published and offer its tokens as a share of that project. What customer can to is donate NEO on the hand to that project and get it's `NEP-5token` as a share of that project. This process we call it `MintToken`



Now let us implement the `MintToken` function. Firstly, in the `MintToken` method, we have to fetch the `Transaction` object first, which is the script container for this smart contract.

```csharp
Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
```

Next, we have to get the `references` of this transaction. Here, a reference stands for the corresponding output for the inputs of the transaction. After get the references，we’re verifying that the output that is sent to the contract address (this.address) is NEO. After confirm this, we can get the corresponding `sender` address through the `ScriptHash` of this `TransactionOutput` object. We can learn more about `reference`,`inputs` and `outputs` in the [UTXO](UTXO.md).

```csharp
TransactionOutput reference = tx.GetReferences()[0];
// check whether asset is neo
if (reference.AssetId != neo_asset_id) return false;
byte[] sender = reference.ScriptHash;
```

Now we have to collect the total amount of NEO from the outputs of the transactionOutput.  The `outputs` here is every output of the current transaction. In this kind of `MintToken` method of ITO contract, usually we only aaccpt one global asset such as `NEO`. Therefore, in the for loop that checks for only NEO assets, sum the amount by `output.Value` .

```csharp
TransactionOutput[] outputs = tx.GetOutputs();
byte[] receiver = ExecutionEngine.ExecutingScriptHash;
ulong value = 0;
// get the total amount of Neo
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

if the swap_rate is equal to 0, it means the ITO has been finished or the ITO amount has exceed the total supply of token. That will lead to the failure of the crowdfunding and trigger the `Refund` event.

```csharp
// crowdfunding failure
if (swap_rate == 0){
    Refund(sender, value);
    return false;
}
```

After successfully handle statements all above, the mint process can be finished. First get the token which exchanged by the global asset. After that, update the balance and the totoalSupply respectively. Finally, fire the Transferred event and returne true.

```csharp           
// crowdfunding success
ulong token = value * swap_rate / 100000000;
BigInteger balance = Storage.Get(Storage.CurrentContext, sender).AsBigInteger();
Storage.Put(Storage.CurrentContext, sender, token + balance);
BigInteger totalSupply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
Storage.Put(Storage.CurrentContext, "totalSupply", token + totalSupply);
Transferred(null, sender, token);
return true;
```


## Next Step
Now you have successfully make your first ITO and familiar with the most ideas of smart contract, the next one will be more difficult contract [which is CGAS](cgas/1_what_is_cgas.md).

If you want to know how to implement the NEP5, click [here](Implementation_of_NEP5.md).

