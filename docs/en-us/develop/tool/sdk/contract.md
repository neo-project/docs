# Deploying and Invoking Contracts

In Neo N3 most of the functions are provided by contracts. ScriptHash is the unique identifier of the contract, and it is usually a necessary parameter for invoking contracts.

This document introduces the following SDK features:

- The construction method of contract deployment transaction
- Invoking methods in the contract under read-only mode
- `Nep17API` class that encapsulates the methods for invoking NEP17 contracts

## Contract deployment

`ContractClient` provides the method, `CreateDeployContractTxAsync`, to construct deployment transactions of the contract. The parameters are contract scripts, manifests, and account key pairs for payment of system and network fees, where contract scripts and manifests are available from the compilation. There must be sufficient GAS in the sender account.

Read the nef and manifest.json files of the contract:

```C#
// read nefFile & manifestFile
NefFile nefFile;
using (var stream = new BinaryReader(File.OpenRead(nefFilePath), Encoding.UTF8, false))
{
    nefFile = stream.ReadSerializable<NefFile>();
}

ContractManifest manifest = ContractManifest.Parse(File.ReadAllBytes(manifestFilePath));
```

Construct a contract deployment transaction:

```c#
// create the deploy contract transaction
Transaction transaction = await contractClient.CreateDeployContractTxAsync(nefFile.ToArray(), manifest, senderKeyPair);
```

After the transaction is constructed, you need to broadcast it on the blockchain:

```c#
// Broadcast the transaction over the Neo network
await client.SendRawTransactionAsync(transaction);
Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");
```

After the transaction is added to the blockchain you can get the transaction execution status to check if the contract is deployed successfully:

```c#
// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
await neoAPI.WaitTransactionAsync(transaction)
    .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
```

Here is the complete code:

```c#
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Manifest;
using Neo.Wallets;
using System;
using Neo.IO;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task Test()
        {
            // choose a neo node with rpc opened, here we use the localhost
            RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
            ContractClient contractClient = new ContractClient(client);

            string nefFilePath = "sc/Contract1.nef";
            string manifestFilePath = "sc/Contract1.manifest.json";

            // read nefFile & manifestFile
            NefFile nefFile;
            using (var stream = new BinaryReader(File.OpenRead(nefFilePath), Encoding.UTF8, false))
            {
                nefFile = stream.ReadSerializable<NefFile>();
            }

            ContractManifest manifest = ContractManifest.Parse(File.ReadAllBytes(manifestFilePath));

            // deploying contract needs sender to pay the system fee
            KeyPair senderKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");

            // create the deploy transaction
            Transaction transaction = await contractClient.CreateDeployContractTxAsync(nefFile.ToArray(), manifest, senderKey).ConfigureAwait(false);

            // Broadcast the transaction over the NEO network
            await client.SendRawTransactionAsync(transaction).ConfigureAwait(false);
            Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(transaction)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
        }
    }
}
```

## Contract invocation simulation

`ContractClient` provides the method `TestInvokeAsync` to simulate the contract invocation, which does not affect the data on the chain after execution. You can directly invoke the contract method that reads the data. For example, the following example invokes the name method in the NEO native contract.

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://127.0.0.1:10332");
ContractClient contractClient = new ContractClient(client);

// get the contract hash
UInt160 scriptHash = NativeContract.NEO.Hash;

// test invoking the method provided by the contract 
RpcInvokeResult invokeResult = await contractClient.TestInvokeAsync(scriptHash, "name").ConfigureAwait(false);
Console.WriteLine($"The name is {invokeResult.Stack.Single().GetString()}");
```

Or you can use `MakeScript` to construct the script you want to execute and then invoke the method `InvokeScriptAsync` in `RpcClient`to get the execution result.

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://127.0.0.1:10332");

// get the contract hash
UInt160 scriptHash = NativeContract.NEO.Hash;

byte[] script = scriptHash.MakeScript("name");
// call invoke script
RpcInvokeResult invokeResult = await client.InvokeScriptAsync(script).ConfigureAwait(false);
Console.WriteLine($"The name is {invokeResult.Stack.Single().GetString()}");
```

## Contract invocation (on-chain transactions)

Generally invoking a deployed contract on the blockchain contains the following steps:

1. Construct the script to invoke

    Take the `transfer` method of native contract Neo as an example:

    ```c#
    // construct the script, in this example, we will transfer 1024 NEO to receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1024);
    ```

2. Construct the transaction：

    ```c#
    // initialize the TransactionManagerFactory with rpc client and magic
    // fill the script and cosigners
    TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
        .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
    // add signature and sign transaction with the added signature
    Transaction tx = await txManager.AddSignature(sendKey).SignAsync().ConfigureAwait(false);
    ```
    
3. Broadcast the transaction on the blockchain:

    ```c#
    // broadcasts the transaction over the Neo network
    await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
    ```

4. Wait until the transaction is added to the blockchain and then get the transaction execution status to make sure the contract is invoked successfully:

    ```c#
    // print a message after the transaction is on chain
    WalletAPI neoAPI = new WalletAPI(client);
    await neoAPI.WaitTransactionAsync(tx)
        .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
    ```

For complete code refer to [Transaction Construction](transaction.md).

## NEP-17 Contracts

`Nep17API` encapsulates the method that generates transfer transactions. The above transaction process can be simplified to:

```c#
Nep17API nep17API = new Nep17API(client);
Transaction tx = await nep17API.CreateTransferTxAsync(scriptHash, sendKey, receiver, 1).ConfigureAwait(false);
```

Additionally, `Nep17API` also provides a set of simple methods to get data:

```c#
// get nep17 name
string name = await nep17API.NameAsync(NativeContract.NEO.Hash).ConfigureAwait(false);

// get nep17 symbol
string symbol = await nep17API.SymbolAsync(NativeContract.NEO.Hash).ConfigureAwait(false);

// get nep17 token decimals
byte decimals = await nep17API.DecimalsAsync(NativeContract.NEO.Hash).ConfigureAwait(false);

// get nep17 token total supply
BigInteger totalSupply = await nep17API.TotalSupplyAsync(NativeContract.NEO.Hash).ConfigureAwait(false);

// get the balance of nep17 token
UInt160 account = Utility.GetScriptHash("NXjtqYERuvSWGawjVux8UerNejvwdYg7eE");
BigInteger balance = await nep17API.BalanceOfAsync(NativeContract.NEO.Hash, account).ConfigureAwait(false);

// get token information
RpcNep17TokenInfo tokenInfo = await nep17API.GetTokenInfoAsync(NativeContract.NEO.Hash).ConfigureAwait(false);
```

