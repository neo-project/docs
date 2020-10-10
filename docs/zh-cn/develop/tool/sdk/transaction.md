# 构造交易

`Neo RPC SDK` 封装了交易构造模块，通过该模块可以使用特定的参数和方法构造 Neo3 中的交易，完成个性化的功能，本篇主要介绍这部分的使用方法。

> [!Note]
>
> 如果使用 SDK 中构造交易并附有签名相关的方法，需要维护一份当前所在 NEO 区块链的 protocol.json 在程序运行目录下，例如 \bin 或 \publish 目录，以确保 SDK 使用的 `Magic` 和 区块链一致，否则 SDK 构造的交易在区块链中将无法验签通过。

## 交易构造步骤

1. 构造交易脚本，决定交易要执行什么样的功能，比如转账交易：

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to the receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1);
    ```

2. 初始化 `TransactionManager` ，将 `RpcClient ` 和发起账户的 `ScriptHash ` 作为参数。

    ```c#
    // initialize the TransactionManager with rpc client and the sender scripthash
    TransactionManager txManager = new TransactionManager(client, sender);
    ```

3. 调用 `MakeTransaction` 方法，传入交易脚本、交易属性和cosigner。

  ```c#
    // fill the script, attributes and cosigners
    txManager.MakeTransaction(script, null, cosigners);
  ```

4. 添加签名（单签或者多签），将账户的 `KeyPair` 作为签名的参数。

    - 单签
    
    ```c#
    // add signature for the transaction with sendKey
    txManager.AddSignature(sendKey);
    ```
    - 多签
    
    ```c#
    // add multi-signatures for the transaction with sendKey
    txManager.AddMultiSig(receiverKey, 2, receiverKey.PublicKey, key2.PublicKey, key3.PublicKey);
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
    txManager.Sign();
    Transaction tx = txManager.Tx;
    ```

## 交易构造示例

### 构造 NEP5 转账交易

下面的示例实现了从send账户转账1个NEO到receiver账户的功能。构建不同交易时需要关注交易中脚本和所需签名的不同。

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

`WalletAPI` 封装了上面的过程，NEP5 转账可以简化为：

```c#
WalletAPI walletAPI = new WalletAPI(client);
Transaction tx = walletAPI.Transfer(NativeContract.NEO.Hash, sendKey, receiver, 1);
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
            // choose a neo node with rpc opened
            RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

            // get the KeyPair of your account, which will pay the system and network fee
            KeyPair sendKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            // get the KeyPair of your accounts
            KeyPair key2 = Utility.GetKeyPair("L2ynA5aq6KPJjpisXb8pGXnRvgDqYVkgC2Rw85GM51B9W33YcdiZ");
            KeyPair key3 = Utility.GetKeyPair("L3TbPZ3Gtqh3TTk2CWn44m9iiuUhBGZWoDJQuvVw5Zbx5NAjPbdb");

            // create multi-signatures contract, this contract needs at least 2 of 3 KeyPairs to sign
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

            // broadcasts transaction over the Neo network.
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

### 构造交易从多签账户转账

下面的示例实现了从多签账户转出1个GAS的功能。多签账户的scripthash由多签合约脚本的hash得来。因为需要从多签账户转账，添加签名时要根据多签合约要求的签名数量添加。

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

            // broadcast the transaction over the Neo network.
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

## 阅读下节

[合约部署与调用](contract.md)