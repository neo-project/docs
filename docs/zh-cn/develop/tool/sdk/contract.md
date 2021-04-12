# 合约部署与调用

由于在 Neo N3 中绝大部分功能都是通过合约提供的，所以理解合约是使用 Neo N3 的基础，每个合约由脚本哈希 (ScriptHash) 作为唯一标识，通常也是调用合约的必须参数。本文档主要介绍以下 SDK 功能：

- 提供了合约部署交易的构建方法
- 使用只读模式调用合约中方法
- `Nep17API` 类封装了调用 NEP17 合约相关的方法

## 合约部署

`ContractClient` 中提供了合约部署交易的构建方法 `CreateDeployContractTxAsync`, 参数为合约脚本，manifest 和支付系统费和网络费的账户密钥对，其中合约脚本和 manifest 可通过编译获取，账户中需要有足够的 GAS 支付所需费用。

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
Transaction transaction = await contractClient.CreateDeployContractTxAsync(nefFile.ToArray(), manifest, senderKeyPair);
```

交易构建后需要广播到链上:

```c#
// Broadcast the transaction over the Neo network
await client.SendRawTransactionAsync(transaction);
Console.WriteLine($"Transaction {transaction.Hash.ToString()} is broadcasted!");
```

等待交易上链后可以获取交易的执行状态以确保合约部署成功:

```c#
// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
await neoAPI.WaitTransactionAsync(transaction)
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

## 合约模拟调用

`ContractClient` 提供了 `TestInvokeAsync` 方法来对合约进行模拟调用，执行后不会影响链上数据。可以直接调用读取信息的合约方法，比如下面的例子调用了NEO原生合约中的name方法

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
ContractClient contractClient = new ContractClient(client);

// get the contract hash
UInt160 scriptHash = NativeContract.NEO.Hash;

// test invoking the method provided by the contract 
RpcInvokeResult invokeResult = await contractClient.TestInvokeAsync(scriptHash, "name").ConfigureAwait(false);
Console.WriteLine($"The name is {invokeResult.Stack.Single().GetString()}");
```

或者使用 `MakeScript` 构造想要执行的脚本，再调用 `RpcClient`中的方法`InvokeScriptAsync` 获取执行结果

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));

// get the contract hash
UInt160 scriptHash = NativeContract.NEO.Hash;

byte[] script = scriptHash.MakeScript("name");
// call invoke script
RpcInvokeResult invokeResult = await client.InvokeScriptAsync(script).ConfigureAwait(false);
Console.WriteLine($"The name is {invokeResult.Stack.Single().GetString()}");
```

## 合约调用（上链交易）

上链的合约调用一般要经过以下步骤：

1. 构建调用脚本

    以调用原生合约 NEO 的 `transfer` 方法为例：

    ```c#
    // construct the script, in this example, we will transfer 1024 NEO to receiver
    UInt160 scriptHash = NativeContract.NEO.Hash;
    byte[] script = scriptHash.MakeScript("transfer", sender, receiver, 1024);
    ```

2. 构建交易：

    ```c#
    // initialize the TransactionManagerFactory with rpc client and magic
    // fill the script and cosigners
    TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
        .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
    // add signature and sign transaction with the added signature
    Transaction tx = await txManager.AddSignature(sendKey).SignAsync().ConfigureAwait(false);
    ```

3. 交易构造后广播到链上:

    ```c#
    // broadcasts the transaction over the Neo network
    await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
    ```

4. 等待交易上链后，获取交易的执行状态以确保合约调用成功:

    ```c#
    // print a message after the transaction is on chain
    WalletAPI neoAPI = new WalletAPI(client);
    await neoAPI.WaitTransactionAsync(tx)
        .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is  {(await p).VMState}"));
    ```

完整示例请参考[构造交易](transaction.md)。

## NEP17 合约

`Nep17API` 封装了转账交易的生成方法，以上交易过程可简化为：

```c#
Nep17API nep17API = new Nep17API(client);
Transaction tx = await nep17API.CreateTransferTxAsync(scriptHash, sendKey, receiver, 1).ConfigureAwait(false);
```

此外 `Nep17API` 还提供了以下读取方法：

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
