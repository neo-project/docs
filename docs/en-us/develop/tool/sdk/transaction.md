# Transaction Construction

`RpcClient` encapsulates the transaction construction module, which allows you to construct transactions in Neo N3 with specific parameters and methods to personalize your functions. This document introduces the relevant methods.

> [!Note]
>
> If you use SDK to construct a transaction that requires a signature, you need to ensure that the RpcClient obeject and the network it is connected to are configured the same way, or the transaction constructed by the SDK will not be validated in the blockchain. To do so, load Neo-CLI config.json when constructing the RpcClient object, for example:
>
> RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"))

## Transaction construction process

1. Construct a transaction script to determine what functions the transaction will perform, such as a transfer transaction:

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to the receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1，"data");
    ```

2. Construct `TransactionManagerFactory` with the parameter `RpcClient `; Construct `TransactionManager` with the parameters `Script` and`Signers`:

    ```c#
    TransactionManager txManager = await new TransactionManagerFactory(client)
            .MakeTransactionAsync(script, signers).ConfigureAwait(false);
    ```

3. Add signature (single or multiple signatures) and use `KeyPair` of the account as the parameter.

    - single signature

    ```c#
    // add signature for the transaction with sendKey
    txManager.AddSignature(sendKey);
    ```
    - multiple signatures
    
    ```c#
    // add multi-signatures for the transaction with sendKey
    txManager.AddMultiSig(key1, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    txManager.AddMultiSig(key2, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    ```
    - multi-signature contract
    
      The nature of multi-signature comes from multi-signature contracts. You need to construct a multi-signature contract before you can obtain the multi-signature address and transfer assets. The following example uses 3 accounts to create a multi-signature contract which requires at least 2 account signatures for signing.

    ```c#
    // create a multi-signature contract, which needs at least 2 of 3 KeyPairs to sign
    Contract multiContract = Contract.CreateMultiSigContract(2, sendKey.PublicKey, key2.PublicKey, key3.PublicKey);
    // get the scripthash of the multi-signature contract
    UInt160 multiAccount = multiContract.Script.ToScriptHash();
    ```
    
5. Verify signatures and add `Witness` to the transaction body.

    If there are not enough signatures or fees an exception will be thrown.

    ```c#
    // sign the transaction with the added signatures
    Transaction tx = await txManager.SignAsync().ConfigureAwait(false);
    ```

## Transaction Construction Examples

### Constructing an NEP17 transfer transaction

The following example implements a function that transfers 1024 NEO from the sender account to the receiver account. You need to pay attention to the difference between the script and the signature in a transaction for constructing different transactions.

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNep17Transfer().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task TestNep17Transfer()
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://127.0.0.1:10332");
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // get the scripthash of the account you want to transfer to
            UInt160 receiver = Utility.GetScriptHash("NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM");

            // construct the script, in this example, we will transfer 1024 NEO to receiver
            UInt160 scriptHash = NativeContract.NEO.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1024);

            // initialize the TransactionManagerFactory with rpc client and magic
            // fill in the TransactionManager with the script and cosigners
            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            // add signature and sign transaction with the added signature
            Transaction tx = await txManager.AddSignature(sendKey).SignAsync().ConfigureAwait(false);

            // broadcasts the transaction over the Neo network.
            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```

`WalletAPI` encapsulates the above process, so you can simplify the NEP17 transfer as follows:

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNep17Transfer().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task TestNep17Transfer()
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://127.0.0.1:10332");
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");

            // get the scripthash of the account you want to transfer to
            UInt160 receiver = Utility.GetScriptHash("NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM");

            // use WalletAPI to create and send the transfer transaction
            WalletAPI walletAPI = new WalletAPI(client);
            Transaction tx = await walletAPI.TransferAsync(NativeContract.NEO.Hash, sendKey, receiver, 1024).ConfigureAwait(false);

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
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
            TestToMultiTransfer().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task TestToMultiTransfer()
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://127.0.0.1:10332");
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // get the KeyPair of your accounts
            KeyPair key2 = Utility.GetKeyPair("L1bQBbZWnKbPkpHM3jXWD3E5NwK7nui2eWHYXVZPy3t8jSFF1Qj3");
            KeyPair key3 = Utility.GetKeyPair("KwrJfYyc7KWfZG5h97SYfcCQyW4jRw1njmHo48kZhZmuQWeTtUHM");

            // create multi-signatures contract, this contract needs at least 2 of 3 KeyPairs to sign
            Contract multiContract = Contract.CreateMultiSigContract(2, sendKey.PublicKey, key2.PublicKey, key3.PublicKey);
            // get the scripthash of the multi-signature Contract
            UInt160 multiAccount = multiContract.Script.ToScriptHash();

            // construct the script, in this example, we will transfer 1024 GAS to multi-sign account
            // in contract parameter, the amount type is BigInteger, so we need to muliply the contract factor
            UInt160 scriptHash = NativeContract.GAS.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, multiAccount, 1024 * NativeContract.GAS.Factor);

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // initialize the TransactionManager with rpc client and magic
            // fill the script and cosigners
            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            // add signature and sign transaction with the added signature
            Transaction tx = await txManager.AddSignature(sendKey).SignAsync().ConfigureAwait(false);

            // broadcasts the transaction over the Neo network.
            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```

### Constructing a transaction to transfer from multi-signature account

The following example implements a function that transfers 1024 GAS from a multi-signature account. The scripthash of the multi-signature account is obtained from the scripthash of the multi-signature contract. To transfer assets from a multi-signature account, you need to add signatures required by the multi-signature contract.

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
            TestFromMultiTransfer().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task TestFromMultiTransfer()
        {
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://127.0.0.1:10332");

            // get the KeyPair of your account
            KeyPair receiverKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            KeyPair key2 = Utility.GetKeyPair("L1bQBbZWnKbPkpHM3jXWD3E5NwK7nui2eWHYXVZPy3t8jSFF1Qj3");
            KeyPair key3 = Utility.GetKeyPair("KwrJfYyc7KWfZG5h97SYfcCQyW4jRw1njmHo48kZhZmuQWeTtUHM");

            // create multi-signature contract, this contract needs at least 2 of 3 KeyPairs to sign
            Contract multiContract = Contract.CreateMultiSigContract(2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
            // get the scripthash of the multi-signature Contract
            UInt160 multiAccount = multiContract.Script.ToScriptHash();

            UInt160 receiver = Contract.CreateSignatureContract(receiverKey.PublicKey).ScriptHash;

            // construct the script, in this example, we will transfer 1024 GAS to multi-sign account
            // in contract parameter, the amount type is BigInteger, so we need to muliply the contract factor
            UInt160 scriptHash = NativeContract.GAS.Hash;
            byte[] script = scriptHash.MakeScript("transfer", multiAccount, receiver, 1024 * NativeContract.GAS.Factor);

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = multiAccount } };

            // initialize the TransactionManager with rpc client and magic
            // fill the script and cosigners
            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            // add signature and sign transaction with the added signature
            Transaction tx = await txManager.AddMultiSig(new KeyPair[]{receiverKey, key2}, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey)
                .SignAsync().ConfigureAwait(false);

            // broadcasts the transaction over the Neo network.
            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            // print a message after the transaction is on chain
            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```

