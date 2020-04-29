# 钱包相关接口

Neo 中大部分的操作与账户有关，而钱包是账户的集合，包含一个或多个账户。本篇文档将主要介绍以下内容：

- 账户与钱包的基本概念和操作；
- 使用 `WalletAPI`，该方法封装了钱包相关接口，提供余额查询、GAS 提取、转账等功能。

## 账户与钱包基础

### 账户

Neo 中的账户是用户身份的证明，本质上是一个 `KeyPair` 类型的密钥对，其中包含私钥和公钥。

```c# 
// create a new KeyPair
byte[] privateKey = new byte[32];
using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(privateKey);
}
KeyPair keyPair = new KeyPair(privateKey);
```

### 私钥

私钥用于对交易签名，是授权的工具，掌握了私钥就表示拥有某个账户，可以处理账户的所有资产。私钥本质上是一个32位长的byte数组，可以表示为十六进制的字符串，例如:
`"0x450d6c2a04b5b470339a745427bae6828400cf048400837d73c415063835e005"`

```c# 
  // export private key to hex string
  string privateHex = keyPair.PrivateKey.ToHexString();

  // get KeyPair from private hex string
  keyPair = Utility.GetKeyPair(privateHex);
```

### WIF

WIF是私钥的另一种字符串表示，与私钥在作用上是等价的，比如上面的私钥表示为WIF：
`"KyXwTh1hB76RRMquSvnxZrJzQx7h9nQP2PCRL38v6VDb5ip3nf1p"`

```c# 
  // export KeyPair as WIF
  string wif = keyPair.Export();

  // get KeyPair from WIF
  KeyPair keyPair1 = Utility.GetKeyPair(wif);
```

### 公钥

公钥可以用来验证私钥的签名，在Neo中对应`ECPoint`类型，拥有私钥的情况下可以计算出公钥，公钥一般可以表示为长度为66的十六进制字符串：
`"02f9ec1fd0a98796cf75b586772a4ddd41a0af07a1dbdf86a7238f74fb72503575"`

```c# 
  // export public key hex string
  string publicHex = keyPair.PublicKey.ToString();

  // get public key from hex string
  Neo.Cryptography.ECC.ECPoint publicKey = Neo.Cryptography.ECC.ECPoint.Parse(publicHex, Neo.Cryptography.ECC.ECCurve.Secp256r1);
```

### 账户的脚本哈希 (ScriptHash)

ScriptHash 在 Neo 中对应 `UInt160`，本质上是一个 20 位的 byte 数组，由公钥经过脚本构造和哈希得出（由于哈希算法不可逆，所以不可根据脚本哈希逆向计算出公钥）。ScriptHash 一般表示为反序的十六进制字符串：
`"0xb0a31817c80ad5f87b6ed390ecb3f9d312f7ceb8"`

```c# 
  // get ScriptHash of KeyPair account
  UInt160 scriptHash = Contract.CreateSignatureContract(keyPair.PublicKey).ScriptHash;
  string strScriptHash = scriptHash.ToString();
```

### 地址

地址是 ScriptHash 的另一种字符串表示，可以和 ScriptHash 互相转换。地址作为账户的唯一标识，是最常用的账户形式，相当于传统账户中的账号，比如转账时可以向指定地址转账。地址形式：`"Ncm9TEzrp8SSer6Wa3UCSLTRnqzwVhCfuE"`

```c# 
using Neo.Wallets;

// ScriptHash to address
string adddress = scriptHash.ToAddress();
// address to ScriptHash
scriptHash = adddress.ToScriptHash();
```

### 钱包

钱包是账户的集合，`NEP6` 是Neo中最常用的钱包标准，`NEP6` 钱包可以序列化为一个 JSON 格式的文件，其中保存了加密后的账户私钥，需要对应的密码才能解密获取私钥。

可参考如下示例：

创建新的 NEP6 钱包，添加账户并保存为 JSON 文件：

```c# 
// create wallet
string path = "wallet_new.json";
string password = "MyPass";
NEP6Wallet wallet_new = new NEP6Wallet(path);
using (wallet_new.Unlock(password))
{
    wallet_new.CreateAccount(keyPair.PrivateKey);
}
wallet_new.Save();
```

从 JSON 文件读取 NEP6 钱包，并解密账户：

```c# 
// load wallet from nep6 wallet
NEP6Wallet wallet = new NEP6Wallet(path);
KeyPair keyPair2;
using (wallet.Unlock(password))
{
    keyPair2 = wallet.GetAccounts().First().GetKey();
}
```

## 使用 WalletAPI

### 初始化

`WalletAPI` 初始化：

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
WalletAPI walletAPI = new WalletAPI(client);
```

### 查询余额

> [!Note]
>
> 账户余额的类型一般是 `BigInteger`，这是把小数部分取整后的一种表示，需要除以 `Factor` 才能得出Token 的实际数量。

查询 NEP5 资产余额查询可以使用字符串参数：

```c#
// get the neo balance of account
string tokenHash = NativeContract.NEO.Hash.ToString();
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
BigInteger balance = walletAPI.GetTokenBalance(tokenHash, address);
```

也可以使用 ScriptHash 类型的参数：

```c#
// Get the NEO balance of account
UInt160 tokenScriptHash = Utility.GetScriptHash(tokenHash);
UInt160 accountHash = Utility.GetScriptHash(address);
Nep5API nep5API = new Nep5API(client);
BigInteger balance = nep5API.BalanceOf(tokenScriptHash, accountHash);
```

在 Neo3 中 NEO 和 GAS 都是 NEP5 资产，且脚本哈希固定，所以这里提供了更简单的接口：

```c#
// Get the NEO balance
uint neoBalance = walletAPI.GetNeoBalance(address);

// Get the GAS balance
decimal gasBalance = walletAPI.GetGasBalance(address);
```

## 提取 GAS

在 Neo3 中提取 GAS 的过程是在 NEO 转账时自动进行的，你可以构建一笔给自己转账的交易来提取 GAS。

1. 首先查询当前地址可以提取的 GAS 数量，例如：

    ```c#
    // Get the claimable GAS of one address
    string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
    decimal gasAmount = walletAPI.GetUnclaimedGas(address);
    ```
    
    也可以使用账户的 ScriptHash 查询：

    ```c#
    string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
    UInt160 accountHash = Utility.GetScriptHash(address);
    decimal gasAmount = walletAPI.GetUnclaimedGas(accountHash);
    ```

2. 构建一笔给自己转账的交易，自动提取 GAS：

    ```c#
    // Claiming GAS needs the KeyPair of account. You can also use wif or private key hex string
    string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
    Transaction transaction = walletAPI.ClaimGas(wif);
    ```
    也可以使用`KeyPair`：
    
    ```c#
    KeyPair keyPair = Utility.GetKeyPair(wif);
    Transaction transaction = walletAPI.ClaimGas(keyPair);
    ```

## 资产转账

`WalletAPI` 中封装了 NEP5 转账方法。

可以使用字符串参数：

```c#
string tokenHash = NativeContract.NEO.Hash.ToString();
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";

// Transfer 10 NEO from wif to address
walletAPI.Transfer(tokenHash, wif, address, 10);

// Print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
neoAPI.WaitTransaction(transaction)
    .ContinueWith(async (p) => Console.WriteLine($"Transaction is on block {(await p).BlockHash}"));
```
也可以使用 `KeyPair` 和  `UInt160` (ScriptHash)：

```c#
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";

KeyPair sender = Utility.GetKeyPair(wif);
UInt160 receiver = Utility.GetScriptHash(address);

// Transfer 10 NEO from wif to address
walletAPI.Transfer(NativeContract.NEO.Hash, sender, receiver, 10);
```

多签账户的 NEP5 转账：

```C#
KeyPair receiverKey = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
KeyPair keyPair1 = Utility.GetKeyPair("L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb");
KeyPair keyPair2 = Utility.GetKeyPair("L2ynA5aq6KPJjpisXb8pGXnRvgDqYVkgC2Rw85GM51B9W33YcdiZ");
KeyPair keyPair3 = Utility.GetKeyPair("L3TbPZ3Gtqh3TTk2CWn44m9iiuUhBGZWoDJQuvVw5Zbx5NAjPbdb");
KeyPair keyPair4 = Utility.GetKeyPair("L3Ke1RSBycXmRukv27L6o7sQWzDwDbFcbfR9oBBwXbCKHdBvb4ZM");

//make transaction 
Transaction tx = walletAPI.CreateTransferTx(gas, 3, new ECPoint[] { keyPair1.PublicKey, keyPair2.PublicKey, keyPair3.PublicKey, keyPair4.PublicKey }, new KeyPair[] { keyPair1, keyPair2, keyPair3 }, Contract.CreateSignatureContract(receiverKey.PublicKey).ScriptHash, new BigInteger(10));

//broadcast
RpcClient.SendRawTransaction(tx);
```

## 阅读下节

[构造交易](transaction.md)

