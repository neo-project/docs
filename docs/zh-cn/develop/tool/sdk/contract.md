# 合约部署与调用

由于在 Neo3 中绝大部分功能都是通过合约提供的，所以理解合约是使用 Neo3 的基础，每个合约由脚本哈希 (ScriptHash) 作为唯一标识，通常也是调用合约的必须参数。本文档主要介绍以下 SDK 功能：

- 提供了合约部署交易的构建方法
- 使用只读模式调用合约中方法
- `Nep5API` 类封装了调用 NEP5 合约相关的方法

## 合约部署

`ContractClient` 中提供了合约部署交易的构建方法 `CreateDeployContractTx`, 参数为合约脚本，manifest 和支付系统费和网络费的账户密钥对，其中合约脚本和 manifest 可通过编译获取，账户中需要有足够的 GAS 支付所需费用。

读取合约 nef 和 manifest.json 文件：

```C#
// read nefFile & manifestFile
NefFile nefFile;
using (var stream = new BinaryReader(File.OpenRead(nefFilePath), Encoding.UTF8, false))
{
    nefFile = stream.ReadSerializable<NefFile>();
}

ContractManifest manifest = ContractManifest.Parse(File.ReadAllBytes(manifestFilePath));
```

构造发布合约的交易：

```c#
// create the deploy contract transaction
byte[] script = nefFile.Script;
Transaction transaction = contractClient.CreateDeployContractTx(script, manifest, senderKeyPair);
```

交易构建后需要广播到链上:

```c#
// Broadcast the transaction over the Neo network
client.SendRawTransaction(transaction);
Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");
```

等待交易上链后可以获取交易的执行状态以确保合约部署成功:

```c#
// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
neoAPI.WaitTransaction(transaction)
    .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));

```

下面是完整的示例：

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

            string nefFilePath = "Test.nef";
            string manifestFilePath = "Test.manifest.json";

            // read nefFile & manifestFile
            NefFile nefFile;
            using (var stream = new BinaryReader(File.OpenRead(nefFilePath), Encoding.UTF8, false))
            {
                nefFile = stream.ReadSerializable<NefFile>();
            }

            ContractManifest manifest = ContractManifest.Parse(File.ReadAllBytes(manifestFilePath));

            // deploying contract needs sender to pay the system fee
            KeyPair senderKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");

            // create the deploy transaction
            byte[] script = nefFile.Script;
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

## 合约模拟调用

`ContractClient` 提供了 `TestInvoke` 方法来对合约进行模拟调用，执行后不会影响链上数据。可以直接调用读取信息的合约方法，比如下面的例子调用了NEO原生合约中的name方法

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

或者使用 `MakeScript` 构造想要执行的脚本，再调用 `InvokeScript` 获取执行结果

```c#
// construct the script you want to run in test mode
byte[] script = scriptHash.MakeScript("name");
// call invoke script
name =  client.InvokeScript(script).Stack.Single().ToStackItem().GetString();
```

## 合约调用（上链交易）

上链的合约调用一般要经过以下步骤：

1. 构建调用脚本

    以调用原生合约 NEO 的 `transfer` 方法为例：

    ```c#
    // construct the script, in this example, we will transfer 1 NEO to receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1);
    ```

2. 构建交易：

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

3. 交易构造后广播到链上:

    ```c#
    // broadcasts the transaction over the Neo network
    client.SendRawTransaction(tx);
    ```

4. 等待交易上链后，获取交易的执行状态以确保合约调用成功:

    ```c#
    // print a message after the transaction is on chain
    WalletAPI neoAPI = new WalletAPI(client);
    neoAPI.WaitTransaction(tx)
        .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
    ```

完整示例请参考[构造交易](transaction.md)。

## NEP5 合约

`Nep5API` 封装了转账交易的生成方法，以上交易过程可简化为：

```c#
Nep5API nep5API = new Nep5API(client);
Transaction tx = nep5API.CreateTransferTx(scriptHash, sendKey, receiver, 1);
```

此外 `Nep5API` 还提供了简单的读取方法：

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
