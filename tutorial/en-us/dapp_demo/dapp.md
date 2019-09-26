serialisation# Building a Dapp based on NEO


<div align="center">  
<img src="dapp.png" alt="NEO-Tutorial" height="500">
<p>Dapp Demo : NEO house</p>
</div>


In this tutorial we are going to build your first Dapp on the NEO, which is an online NEO game shop. This tutorial is for general developers who has basic knowledge of web development and understanding the usage of javascript. And before this tutorial, it is better to learn the [NEO smart contract development](https://github.com/neo-ngd/NEO-Tutorial/blob/master/9-smartContract/Smart_Contract_basics.md) first.

## Smart contract

The main purpose of this demo is to writing the smart contract and using the javascript to handle the front-end logic for its usage.

First of all, we need to write the smart contract part. The general idea of this NEO game shop is each item  in the shop has an ID, and the shop offer a kind of coupon which we can exchange from the store and then buy these items. Therefore, we can use the most part of [ITO](https://neo-ngd.github.io/NEO-Tutorial/en/9-smartContract/Give_an_ITO.html#give-an-ito-initial-token-offering) contract, to let players exchange the coupon within the store, and then use the coupon to buy the Item.


### Constant properties

First of all, here are some constant property for this smart contract. Here we first define a `NEP-5` similar asset *NEO GAME DIAMOND*, which is used to buy items in the shop. The Neo game diamond has such a list of properties:

```csharp

private const ulong factor = 100000000; //decided by Decimals()
private const ulong initValue = 100000000 * factor;

......

[DisplayName("name")]
public static string Name() => "NEO GAME DIAMOND"; //name of the token

[DisplayName("symbol")]
public static string Symbol() => "NGD"; //symbol of the token

......


[DisplayName("totalSupply")]
public static BigInteger TotalSupply()
{
    StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
    return contract.Get("totalSupply").AsBigInteger();
}

```

### exchange_token(Mint Token)

This is similar function as mint token in the [ITO](https://neo-ngd.github.io/NEO-Tutorial/en/9-smartContract/Give_an_ITO.html#give-an-ito-initial-token-offering). What end user can do is to send `NEO` to the smart contract and take NEP-5 to his balance.

```csharp

[DisplayName("exchange_token")]
public static object exchange_token()
{
    Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
    TransactionOutput reference = tx.GetReferences()[0];
    if (reference.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;

    byte[] sender = reference.ScriptHash;
    byte[] receiver = ExecutionEngine.ExecutingScriptHash;
    ulong value = 0;
    TransactionOutput[] outputs = tx.GetOutputs();

    // get the total amount of Neo
    foreach (TransactionOutput output in outputs)
    {
        if (output.ScriptHash == receiver)
        {
            value += (ulong)output.Value;
        }
    }

    ulong exchanged_amount = value * 10;
    StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
    BigInteger balance = asset.Get(sender).AsBigInteger();
    asset.Put(Owner, balance + exchanged_amount);
    return true;
}

```

The code above is the whole exchange_token function. First of all, it has to extract the transaction  of current smart contract invocation and get the UTXO that points to this smart contract, and check if it is sending NEO.

```csharp

Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
TransactionOutput reference = tx.GetReferences()[0];
if (reference.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;

```

Next step is to calculate how much `NEO` the user wants to exchange the NEP5 token. To get it, just get all the outpus and to check if the outputs script is the smart contract address. For more detail about transaction, inputs and outputs, see this [UTXO](https://github.com/neo-ngd/NEO-Tutorial/blob/master/en/9-smartContract/UTXO.md).

```csharp
// get the total amount of Neo
foreach (TransactionOutput output in outputs)
{
    if (output.ScriptHash == receiver)
    {
        value += (ulong)output.Value;
    }
}
```
Finally, we know the amount of NEO and then change the NEP-5 asset balance of the sender.

```csharp

ulong exchanged_amount = value * 10;
StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
BigInteger balance = asset.Get(sender).AsBigInteger();
asset.Put(Owner, balance + exchanged_amount);

```


### Buy Items

To buy items from the store, first thing is to decrease the number of Diamond from user. This is exactly same as invoke transfer function in the normal NEP-5 Token.

```csharp

StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
var fromAmount = asset.Get(from).AsBigInteger();
if (fromAmount < amount)
    return false;
//Reduce payer balances
if (fromAmount == amount)
    asset.Delete(from);
else
    asset.Put(from, fromAmount - amount);
//Increase the payee balance
var toAmount = asset.Get(Owner).AsBigInteger();
asset.Put(Owner, toAmount + amount);

```
Now, after taking the Diamond, the item should be stored for user. In this Demo, each Item is just a random string as a Id and stored in the storage under each user account. In real life case, it can use Non-fungible token instead.
In addition, here we just store the string Id in storage using `neo` word as a splitter and concat items in to one long string. Then in the front end, we can use javascript to slice it. However, this is just for demo purpose and in production. This should be replaced by using deserialisation and serialisation.


```csharp

StorageMap item = Storage.CurrentContext.CreateMap(nameof(item));
byte[] my_item = item.Get(from);
if (my_item.Length == 0)
{
    item.Put(from, to);
}
else
{
    item.Put(from, my_item.Concat(slider).Concat(to));

}

```

### Check Items
To check the items, it is just read from the storage.

```csharp

StorageMap item = Storage.CurrentContext.CreateMap(nameof(item));
String my_item= item.Get(from).AsString();
return my_item;

```

Now we finish the smart contract part. Let us move to the front-end side.


## Front end


### Usage of neon-js

The [neon-js](https://cityofzion.io/neon-js/) JS SDK for NEO BlockChain. It make developer easy to call RPC methods of NEO and also provide some encapsulated function to call smart contract and sending assets. It includes the wallet functions and transaction functions.

To use neon-js in the browser, the simplest way is to include the source file in the html

```html
<script src="https://unpkg.com/@cityofzion/neon-js"></script>
```

### Login

First of all, each user has to provide their private key in the hexstring format or WIF format to Login, to create account

```js
let loginAccount = new Neon.wallet.Account(privateKey);
```

**important!** This is only for demo usage and do not use it in the real product. It is not safe to use the privateKey in such way directly. The better way to use the privateKey to send the transaction and provide signature is to delegate such security problem to wallet applications, such as desktop wallet or browser extension.


### Get balances

There is 2 kinds of asset we used in this demo Dapp. First one is `NEO` token and the second one is called `Diamond` which is a NEP-5 Token.


To check the `NEO` balance, just need to query the `neo-scan` api which is embedded in the neon-js sdk. Just call the `getBalance` method and the result include the unspent NEO token of this specific address.

```js
var privateNetNeoscan = new Neon.api.neoscan.instance("PrivateNet");
privateNetNeoscan.getBalance(loginAccount.address).then(res => {
    console.log(res);
    updateGasDisplay(res);
});
```

```js
function updateGasDisplay(balance) {
    if (balance.assets['NEO'] === undefined) {
        globalNEODisplayEle.innerText = '0';
        return ;
    }
    const unSpentUtxos = balance.assets['NEO'].unspent;
    let NEOAmount = 0;
    unSpentUtxos.forEach(unspent => {
        NEOAmount += unspent.value.toNumber();
    });
    globalNEODisplayEle.innerText =  NEOAmount;
}
```

To check the balance of the Diamond, we must call the `balanceOf` of the smart contract. To invoke the readonly method in the smart contract such as `balanceOf` or `name`, we just use the rpc query method to query the smart contract method. To call a readonly method in the smart contract, we have to provide two parameter, first is the contract address which is the scriptHash of the contract, the other one is the method name you want to call. Because function like `balanceOf` they need another parameter which is the address of the account you want to check.
After fill these parameter, we can call the rpc query method and get the result immediately and re-render the front-end.

```js
function invokeScriptReadOnly(method, callback) {
    const methodParam = Neon.default.create.contractParam("String", method);
    const addressParam = Neon.sc.ContractParam.byteArray(
      loginAccount.address,
      "address"
    );
    Neon.rpc.Query.invoke(
        CONTRACT_SCRIPTHASH,
        methodParam,
        Neon.sc.ContractParam.array(addressParam)
    ).execute("http://seed6.ngd.network:20332").then(res => callback(res));
}
```

### Exchange Diamond (Mint Token)

The initial balance of Diamond for a new user is 0. In order to get the diamond, the only way to do is to exchange it with NEO in your account. The method we have to call is the `exchange_token` function in the smart contract. The  method we use in the neon-js is `Neon.default.doInvoke`. Here we construct some elements this method will use. First one is intent, which is the transaction of UTXO asset (NEO token). It means we want to transfer some NEO to contract address (The address format of UTXO). Then here is the script part which needs to call the smart contract. It contains scripthash of smart contract, operation name and arguments of that method.


```js
  const intent = Neon.api.makeIntent({NEO:neoAmount}, CONTRACT_ADDRESS);
  const props = {
      scriptHash: CONTRACT_SCRIPTHASH,
      operation: "exchange_token",
      args: []
  };
  const script = Neon.default.create.script(props);

```

Next we put all the things into an object which we call with the `Neon.default.doInvoke` function. Here I call the object `config`. It includes the api method, the account which you create in the beginning, the intent that includes the UTXO asset transfer and the script which call the function in the smart contract.


```js
  const config = {
      api: testNetNeoScan,
      account: loginAccount,
      intents: intent,
      script: script
  };
```

Finally, we execute the `Neon.default.doInvoke(config)` and get the result back.


```js

Neon.default.doInvoke(config).then(res => {
      someCallback(res)
    }
}).catch(err => {
    console.log(err);
});

```

### Get items and buy new item

To check the item from the smart contract, it is as easy as get the balance. The only function we have to call is invokeScriptReadOnly, which is similar to call the balanceOf function. The only difference is the function name changed to the `checkItem`.

```js
invokeScriptReadOnly('checkItem', checkItemCallback);
```

To buy the new item, we have to use the doInvoke API of neon-js again.  It is similar to call the `exchange_token` function above. Here we use the nep-5 token only and do not need UTXO token. Therefore, we do not need the intent content and the only element we have to construct is the script and put it into a `config` object.


```js
const param_address = Neon.sc.ContractParam.byteArray(
      loginAccount.address,
      "address"
    );
const param_itemName = Neon.default.create.contractParam("String", ItemName);
const param_price = Neon.default.create.contractParam("Integer", price*1e8);

const props = {
    scriptHash: CONTRACT_SCRIPTHASH,
    operation: "buyItem",
    args: [param_address, param_itemName, param_price]
};
const script = Neon.default.create.script(props);
const config = {
    api: testNetNeoScan,
    account: loginAccount,
    script: script
};
```

Then, we execute the `Neon.default.doInvoke(config)` and get the result back.


```js

Neon.default.doInvoke(config).then(res => {
      someCallback(res)
    }
}).catch(err => {
    console.log(err);
});

```

## Deploy

In order to run this Dapp, we use [neo-local](https://github.com/CityOfZion/neo-local) which enables user to fire up a personal NEO blockchain which you can use to run tests, execute commands, and inspect state while controlling how the chain operates. In neo-local, it fires up a private chain with four nodes and also run a neo-python for user. We can use neo-gui to deploy the contract or neo-python to deploy the contract, which leads to same outcome.

In neo-local, it will fire up a blockchain explorer `neo-scan` whose default url is `localhost:4000`. We can view all the blocks and transactions on it. In the javascript, we have to setup the neo-scan url:

```js
const NEO_SCAN_URL = "https://localhost:4000/api/main_net";
```

After deploy the smart contract on the neo-local, get the scripHash of your smart contract, and put it into corresponding place in the javascript file of your dapp. Then you just open the html file and get everything work!
