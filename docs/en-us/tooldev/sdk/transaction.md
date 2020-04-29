# Transaction Construction

Neo RPC SDK encapsulates the transaction construction module, which allows you to construct transactions in Neo3 with specific parameters and methods to personalize your functions. This document introduces the relevant methods.

## Transaction construction process

1. Construct a transaction script to determine what functions the transaction will perform, such as a transfer transaction:

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to the receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1);
    ```

2. Initialize `TransactionManager` with `RpcClient ` and `ScriptHash ` of the sending account.

    ```c#
    // initialize the TransactionManager with rpc client and the sender scripthash
    TransactionManager txManager = new TransactionManager(client, sender);
    ```

3. Invoke `MakeTransaction` and pass in transaction script, attributes, and cosigners.

  ```c#
    // fill the script, attributes and cosigners
    txManager.MakeTransaction(script, null, cosigners);
  ```

4. Add signature (single or multiple signatures) and use `KeyPair` of the account as the parameter.

    - single signature
    
    ```c#
    // add signature for the transaction with sendKey
    txManager.AddSignature(sendKey);
    ```
    - multiple signatures
    
    ```c#
    // add multi-signatures for the transaction with sendKey
    txManager.AddMultiSig(receiverKey, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    txManager.AddMultiSig(key2, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    ```
    - multi-signature contract

      The nature of multi-signature comes from multi-signature contracts. You need to construct a multi-signature contract before you can obtain the multi-signature address and transfer assets. The following example uses 3 accounts to create a multi-signature contract which requires at least 2 account signatures for signing.
    
    ```c#
    // create a multi-signature contract
    Contract multiContract = Contract.CreateMultiSigContract(2, sendKey.PublicKey, key2.PublicKey, key3.PublicKey);
    // get the scripthash of the multi-signature contract
    UInt160 multiAccount = multiContract.Script.ToScriptHash();
    ```

5. Verify signatures and add `Witness` to the transaction body.

    If there are not enough signatures or fees an exception will be thrown.

    ```c#
    // sign the transaction with the added signatures
    txManager.Sign();
    Transaction tx = txManager.Tx;
    ```

## Transaction Construction Examples

### Constructing an NEP5 transfer transaction

The following example implements a function that transfers 1 NEO from the sender account to the receiver account. You need to pay attention to the difference between the script and the signature in a transaction for constructing different transactions.

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;
using Utility = Neo.Network.RPC.Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // add Cosigners, which is a collection of scripthashs that need to be signed
            Cosigner[] cosigners = new[] { new Cosigner { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // get the scripthash of the account you want to transfer to
            UInt160 receiver = Utility.GetScriptHash("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ");

            // construct the script, in this example, we will transfer 1 NEO to receiver
            UInt160 scriptHash = NativeContract.NEO.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1);

            // initialize the TransactionManager with rpc client and sender scripthash
            Transaction tx = new TransactionManager(client, sender)
                // fill the script, attributes and cosigners
                .MakeTransaction(script, null, cosigners)
                // add signature for the transaction with sendKey
                .AddSignature(sendKey)
                // sign transaction with the added signature
                .Sign()
                .Tx;

            // broadcasts the transaction over the Neo network.
            client.SendRawTransaction(tx);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            neoAPI.WaitTransaction(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));

            Console.ReadKey();
        }
    }
}


```

`WalletAPI` encapsulates the above process, so you can simplify the NEP5 transfer as follows:

```c#
WalletAPI walletAPI = new WalletAPI(client);
Transaction tx = walletAPI.Transfer(NativeContract.NEO.Hash, sendKey, receiver, 1);
```

### Constructing a transaction to transfer to multi-signature account

The following example implements a function that transfers 10 GAS to a multi-signature account. The scripthash of a multi-signature account is obtained from the scripthash of the multi-signature contract. As the sender is a normal account, the process of adding a signature is the same as last example.

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;
using Utility = Neo.Network.RPC.Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // get the KeyPair of your accounts
            KeyPair key2 = Utility.GetKeyPair("L2ynA5aq6KPJjpisXb8pGXnRvgDqYVkgC2Rw85GM51B9W33YcdiZ");
            KeyPair key3 = Utility.GetKeyPair("L3TbPZ3Gtqh3TTk2CWn44m9iiuUhBGZWoDJQuvVw5Zbx5NAjPbdb");

            // create multi-signatures contract
            Contract multiContract = Contract.CreateMultiSigContract(2, sendKey.PublicKey, key2.PublicKey, key3.PublicKey);
            // get the scripthash of the multi-signature Contract
            UInt160 multiAccount = multiContract.Script.ToScriptHash();

            // construct the script, in this example, we will transfer 10 GAS to multi-sign account
            // in contract parameter, the amount type is BigInteger, so we need to muliply the contract factor
            UInt160 scriptHash = NativeContract.GAS.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, multiAccount, 10 * NativeContract.GAS.Factor);

            // add Cosigners, this is a collection of scripthashs which need to be signed
            Cosigner[] cosigners = new[] { new Cosigner { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // initialize the TransactionManager with rpc client and sender scripthash
            Transaction tx = new TransactionManager(client, sender)
                // fill the script, attributes and cosigners
                .MakeTransaction(script, null, cosigners)
                // add signature for the transaction with sendKey
                .AddSignature(sendKey)
                // sign transaction with the added signature
                .Sign()
                .Tx;

            // broadcasts transaction over the NEO network.
            client.SendRawTransaction(tx);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            neoAPI.WaitTransaction(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));

            Console.ReadKey();
        }
    }
}

```

### Constructing a transaction to transfer from multi-signature account

The following example implements a function that transfers 1 GAS from a multi-signature account. The scripthash of the multi-signature account is obtained from the scripthash of the multi-signature contract. To transfer assets from a multi-signature account, you need to add signatures required by the multi-signature contract.

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;
using Utility = Neo.Network.RPC.Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

            // get the KeyPair of your account
            KeyPair receiverKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
            KeyPair key2 = Utility.GetKeyPair("L2ynA5aq6KPJjpisXb8pGXnRvgDqYVkgC2Rw85GM51B9W33YcdiZ");
            KeyPair key3 = Utility.GetKeyPair("L3TbPZ3Gtqh3TTk2CWn44m9iiuUhBGZWoDJQuvVw5Zbx5NAjPbdb");

            // create multi-signature contract, this contract needs at least 2 of 3 KeyPairs to sign
            Contract multiContract = Contract.CreateMultiSigContract(2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);

            // construct the script, in this example, we will transfer 10 GAS to receiver
            UInt160 scriptHash = NativeContract.GAS.Hash;
            UInt160 multiAccount = multiContract.Script.ToScriptHash();
            UInt160 receiver = Contract.CreateSignatureContract(receiverKey.PublicKey).ScriptHash;
            byte[] script = scriptHash.MakeScript("transfer", multiAccount, receiver, 10 * NativeContract.GAS.Factor);

            // add Cosigners, this is a collection of scripthashs which need to be signed
            Cosigner[] cosigners = new[] { new Cosigner { Scopes = WitnessScope.CalledByEntry, Account = multiAccount } };

            // initialize the TransactionManager with rpc client and sender scripthash
            Transaction tx = new TransactionManager(client, multiAccount)
                // fill the script, attributes and cosigners
                .MakeTransaction(script, null, cosigners)
                // add multi-signature for the transaction with sendKey
                .AddMultiSig(receiverKey, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey)
                .AddMultiSig(key2, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey)
                // sign the transaction with the added signature
                .Sign()
                .Tx;

            // broadcast the transaction over the NEO network.
            client.SendRawTransaction(tx);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            neoAPI.WaitTransaction(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction is on block {(await p).BlockHash}"));

            Console.ReadKey();
        }
    }
}

```

## What's next?

[Contract Deployment and Invocation](contract.md)