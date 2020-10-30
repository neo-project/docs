# Deploying and Invoking Contracts

In Neo3 most of the functions are provided by contracts. ScriptHash is the unique identifier of the contract, and it is usually a necessary parameter for invoking contracts.

This document introduces the following SDK features:

- The construction method of contract deployment transaction
- Invoking methods in the contract under read-only mode
- `Nep5API` class that encapsulates the methods for invoking NEP5 contracts

## Contract deployment

`ContractClient` provides the method, `CreateDeployContractTx`, to construct deployment transactions of the contract. The parameters are contract scripts, manifests, and account key pairs for payment of system and network fees, where contract scripts and manifests are available from the compilation. There must be sufficient GAS in the sender account.

```c#
// create the deploy contract transaction
Transaction transaction = contractClient.CreateDeployContractTx(script, manifest, senderKey);
```

After the transaction is constructed, you need to broadcast it on the blockchain:

```c#
// Broadcast the transaction over the Neo network
client.SendRawTransaction(transaction);
Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");
```

After the transaction is added to the blockchain you can get the transaction execution status to check if the contract is deployed successfully:

```c#
// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
neoAPI.WaitTransaction(transaction)
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

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
            ContractClient contractClient = new ContractClient(client);

            // contract script, it should be from compiled file, we use empty byte[] in this example
            byte[] script = new byte[1];

            // we use default ContractManifest in this example
            ContractManifest manifest = ContractManifest.CreateDefault(script.ToScriptHash());

            // deploying contract needs sender to pay the system fee
            KeyPair senderKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");

            // create the deploy transaction
            Transaction transaction = contractClient.CreateDeployContractTx(script, manifest, senderKey);

            // Broadcast the transaction over the Neo network
            client.SendRawTransaction(transaction);
            Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            neoAPI.WaitTransaction(transaction)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));

            Console.ReadKey();
        }
    }
}
```

## Contract invocation simulation

`ContractClient` provides the method `TestInvoke` to simulate the contract invocation, which does not affect the data on the chain after execution. You can directly invoke the contract method that reads the data. For example, the following example invokes the name method in the NEO native contract.

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
ContractClient contractClient = new ContractClient(client);

// get the contract hash
UInt160 scriptHash = NativeContract.NEO.Hash;

// test invoking the method provided by the contract 
string name = contractClient.TestInvoke(scriptHash, "name")
    .Stack.Single().ToStackItem().GetString();
```

Or you can use `MakeScript` to construct the script you want to execute and then invoke `InvokeScript` to get the execution result.

```c#
// construct the script you want to run in test mode
byte[] script = scriptHash.MakeScript("name");
// call invoke script
name =  client.InvokeScript(script).Stack.Single().ToStackItem().GetString();
```

## Contract invocation (on-chain transactions)

Generally invoking a deployed contract on the blockchain contains the following steps:

1. Construct the script to invoke

    Take the `transfer` method of native contract Neo as an example:

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1);
    ```

2. Construct the transaction：

    ```c#
    // initialize the TransactionManager with rpc client and sender scripthash
    Transaction tx = new TransactionManager(client, sender)
        // fill the script, attributes and cosigners
        .MakeTransaction(script, null, cosigners)
        // add signature for the transaction with sendKey
        .AddSignature(sendKey)
        // sign transaction with the added signature
        .Sign()
        .Tx;
    ```

3. Broadcast the transaction on the blockchain:

    ```c#
    // broadcasts the transaction over the Neo network
    client.SendRawTransaction(tx);
    ```

4. Wait until the transaction is added to the blockchain and then get the transaction execution status to make sure the contract is invoked successfully:

    ```c#
    // print a message after the transaction is on chain
    WalletAPI neoAPI = new WalletAPI(client);
    neoAPI.WaitTransaction(tx)
        .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
    ```

For complete code refer to [Transaction Construction](transaction.md).

## NEP-5 Contracts

`Nep5API` encapsulates the method that generates transfer transactions. The above transaction process can be simplified to:

```c#
Nep5API nep5API = new Nep5API(client);
Transaction tx = nep5API.CreateTransferTx(scriptHash, sendKey, receiver, 1);
```

Additionally, `Nep5API` also provides a set of simple methods to get data:

```c#
// get nep5 name
string name = nep5API.Name(scriptHash);

// get nep5 symbol
string symbol = nep5API.Symbol(scriptHash);

// get nep5 token decimals
uint decimals = nep5API.Decimals(scriptHash);

// get nep5 token total supply
BigInteger totalSupply = nep5API.TotalSupply(scriptHash);
```

