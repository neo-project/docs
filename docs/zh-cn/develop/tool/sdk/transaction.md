# 构造交易

`RpcClient` 封装了交易构造模块，通过该模块可以使用特定的参数和方法构造 Neo N3 中的交易，完成个性化的功能，本篇主要介绍这部分的使用方法。

> [!Note]
>
> 如果使用SDK构造要添加签名的交易，需要确保构造的RpcClient对象和其连接的区块链网络有相同的配置，否则 SDK 构造的交易在区块链中将无法验签通过，具体做法是：构造RpcClient对象时Load Neo-CLI 节点的 config.json，例如： RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json")) 。

## 交易构造步骤

1. 构造交易脚本，决定交易要执行什么样的功能，比如转账交易：

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to the receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1, "data");
    ```

2. 构造 `TransactionManagerFactory`，将`RpcClient`作为参数; 构造`TransactionManager`, 将`Script`和`Signers`作为参数。

    ```c#
    TransactionManager txManager = await new TransactionManagerFactory(client)
            .MakeTransactionAsync(script, signers).ConfigureAwait(false);
    ```

3. 添加签名（单签或者多签），将账户的 `KeyPair` 作为签名的参数；并且签名。

    - 单签
    
    ```c#
    // add signature for the transaction with sendKey
    txManager.AddSignature(sendKey);
    ```
    - 多签
    
    ```c#
    // add multi-signatures for the transaction with sendKey
    txManager.AddMultiSig(key1, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    txManager.AddMultiSig(key2, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
    ```
    - 多签合约

      多签的本质来源于多签合约，需要先构建多签合约才能获取多签地址，进行多签转账。下面的示例使用了3个账户构成多签，验签时需要至少2个账户签名
    
    ```c#
    // create a multi-signature contract, which needs at least 2 of 3 KeyPairs to sign
    Contract multiContract = Contract.CreateMultiSigContract(2, sendKey.PublicKey, key2.PublicKey, key3.PublicKey);
    // get the scripthash of the multi-signature contract
    UInt160 multiAccount = multiContract.Script.ToScriptHash();
    ```

5. 校验签名，并将 `Witness` 添加至交易体。

    如果签名数量不够或手续费不够会引发异常。

    ```c#
    // sign the transaction with the added signatures
    Transaction tx = await txManager.SignAsync().ConfigureAwait(false);
    ```
## 交易构造示例

### 构造 NEP17 转账交易

下面的示例实现了从sender账户转账1024个NEO到receiver账户的功能。构建不同交易时需要关注交易中脚本和所需签名的不同。

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
            RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] signers = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // get the scripthash of the account you want to transfer to
            UInt160 receiver = Utility.GetScriptHash("NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM", ProtocolSettings.Default);

            // construct the script, in this example, we will transfer 1024 NEO to receiver
            UInt160 scriptHash = NativeContract.NEO.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1024, "data");

            // initialize the TransactionManagerFactory with rpc client and magic
            // fill in the TransactionManager with the script and cosigners
            TransactionManager txManager = await new TransactionManagerFactory(client)
                .MakeTransactionAsync(script, signers).ConfigureAwait(false);
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

`WalletAPI` 封装了上面的过程，NEP17 转账可以简化为：

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
            RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");

            // get the scripthash of the account you want to transfer to
            UInt160 receiver = Utility.GetScriptHash("NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM", ProtocolSettings.Default);

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

### 构造交易向多签账户转账

下面的示例实现了向多签账户转账 10 个 GAS 的功能。多签账户的 scripthash 由多签合约脚本的 hash 得来。因为发送方为普通账户，添加签名的过程与上一个示例没有区别。

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
            RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // get the KeyPair of your accounts
            KeyPair key2 = Utility.GetKeyPair("L1bQBbZWnKbPkpHM3jXWD3E5NwK7nui2eWHYXVZPy3t8jSFF1Qj3");
            KeyPair key3 = Utility.GetKeyPair("KwrJfYyc7KWfZG5h97SYfcCQyW4jRw1njmHo48kZhZmuQWeTtUHM");

            // create multi-signatures contract, this contract needs at least 2 of 3 KeyPairs to sign
            Contract multiContract = Contract.CreateMultiSigContract(2, new ECPoint[] { sendKey.PublicKey, key2.PublicKey, key3.PublicKey });
            // get the scripthash of the multi-signature Contract
            UInt160 multiAccount = multiContract.Script.ToScriptHash();

            // construct the script, in this example, we will transfer 1024 GAS to multi-sign account
            // in contract parameter, the amount type is BigInteger, so we need to muliply the contract factor
            UInt160 scriptHash = NativeContract.GAS.Hash;
            byte[] script = scriptHash.MakeScript("transfer", sender, multiAccount, 1024 * NativeContract.GAS.Factor, "data");

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] signers = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = sender } };

            // initialize the TransactionManager with rpc client and magic
            // fill the script and signers
            TransactionManager txManager = await new TransactionManagerFactory(client)
                .MakeTransactionAsync(script, signers).ConfigureAwait(false);
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

### 构造交易从多签账户转账

下面的示例实现了从多签账户转出1024个GAS的功能。多签账户的scripthash由多签合约脚本的hash得来。因为需要从多签账户转账，添加签名时要根据多签合约要求的签名数量添加。

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
            RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));

            // get the KeyPair of your account
            KeyPair receiverKey = Utility.GetKeyPair("L53tg72Az8QhYUAyyqTQ3LaXMXBE3S9mJGGZVKHBryZxya7prwhZ");
            KeyPair key2 = Utility.GetKeyPair("L1bQBbZWnKbPkpHM3jXWD3E5NwK7nui2eWHYXVZPy3t8jSFF1Qj3");
            KeyPair key3 = Utility.GetKeyPair("KwrJfYyc7KWfZG5h97SYfcCQyW4jRw1njmHo48kZhZmuQWeTtUHM");

            // create multi-signature contract, this contract needs at least 2 of 3 KeyPairs to sign
            Contract multiContract = Contract.CreateMultiSigContract(2, new ECPoint[] { receiverKey.PublicKey, key2.PublicKey, key3.PublicKey });
            // get the scripthash of the multi-signature Contract
            UInt160 multiAccount = multiContract.Script.ToScriptHash();

            UInt160 receiver = Contract.CreateSignatureContract(receiverKey.PublicKey).ScriptHash;

            // construct the script, in this example, we will transfer 1024 GAS to multi-sign account
            // in contract parameter, the amount type is BigInteger, so we need to muliply the contract factor
            UInt160 scriptHash = NativeContract.GAS.Hash;
            byte[] script = scriptHash.MakeScript("transfer", multiAccount, receiver, 1024 * NativeContract.GAS.Factor, "data");

            // add Signers, which is a collection of scripthashs that need to be signed
            Signer[] signers = new[] { new Signer { Scopes = WitnessScope.CalledByEntry, Account = multiAccount } };

            // initialize the TransactionManager with rpc client and magic
            // fill the script and signers
            TransactionManager txManager = await new TransactionManagerFactory(client)
                .MakeTransactionAsync(script, signers).ConfigureAwait(false);
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

