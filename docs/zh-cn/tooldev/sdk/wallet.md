# NEO RPC SDK - 钱包相关接口

> 注：本文档中使用的 NEO 版本为 3.0 及以上。

NEO中大部分的操作与账户有关，而钱包是账户的集合，其中包含一个或多个账户，本篇文档将主要介绍以下2个方面：

- 账户与钱包的基本概念和操作；
- `WalletAPI`提供了对钱包概念相关接口的封装，包括余额查询，GAS Claim，转账等功能。

## 账户与钱包的基础

- 账户：NEO中的账户是用户身份的证明，本质上是一个`KeyPair`类型的密钥对，其中包含私钥和公钥。
    ```c# 
    // create a new KeyPair 创建新账户（密钥对）
    byte[] privateKey = new byte[32];
    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(privateKey);
    }
    KeyPair keyPair = new KeyPair(privateKey);
    ```

- 私钥：其中私钥用于对交易签名，是授权的工具，掌握了私钥就表示拥有某个账户，可以处理账户对应的所有资产。私钥本质上是一个32位长的byte数组，可以表示为十六进制的字符串，例如:
`"0x450d6c2a04b5b470339a745427bae6828400cf048400837d73c415063835e005"`

    ```c# 
    // export private key to hex string
    string privateHex = keyPair.PrivateKey.ToHexString();

    // get KeyPair from private hex string
    keyPair = Utility.GetKeyPair(privateHex);
    ```

- WIF： WIF是私钥的另一种字符串表示，与私钥在作用上是等价的，比如上面的私钥表示为WIF:
`"KyXwTh1hB76RRMquSvnxZrJzQx7h9nQP2PCRL38v6VDb5ip3nf1p"`

    ```c# 
    // export KeyPair as WIF
    string wif = keyPair.Export();

    // get KeyPair from WIF
    KeyPair keyPair1 = Utility.GetKeyPair(wif);
    ```

- 公钥：公钥可以用来验证私钥的签名，在NEO中对应`ECPoint`类型，拥有私钥的情况下可以计算出私钥，公钥一般可以表示为长度为66的十六进制字符串：
`"02f9ec1fd0a98796cf75b586772a4ddd41a0af07a1dbdf86a7238f74fb72503575"`

    ```c# 
    // export public key hex string
    string publicHex = keyPair.PublicKey.ToString();

    // get public key from hex string
    Neo.Cryptography.ECC.ECPoint publicKey = Neo.Cryptography.ECC.ECPoint.Parse(publicHex, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    ```

- 账户脚本哈希(ScriptHash)：ScriptHash在NEO中对应`UInt160`，本质上是一个20位的byte数组，由公钥经过脚本构造和哈希得出（由于哈希算法不可逆，所以不可根据脚本哈希逆向计算出公钥），ScriptHash一般表示为反序的十六进制字符串：
`"0x6a38cd693b615aea24dd00de12a9f5836844da91"`

    ```c# 
    // get ScriptHash of KeyPair account
    UInt160 scriptHash = Contract.CreateSignatureContract(keyPair.PublicKey).ScriptHash;
    string strScriptHash = scriptHash.ToString();
    ```

- 地址：地址是ScriptHash的另一种字符串表示，可以和ScriptHash互相转换。地址作为账户的唯一标识，是最常用的账户形式，相当于传统账户中的账号，比如转账时可以向指定地址转账。地址形式：`"AV556nYUwyJKNv8Xy7hVMLQnkmKPukw6x5"`

    ```c# 
    using Neo.Wallets;

    // ScriptHash to address
    string adddress = scriptHash.ToAddress();
    // address to ScriptHash
    scriptHash = adddress.ToScriptHash();
    ```

- 钱包：钱包是账户的集合，`NEP6`是NEO中最常用的钱包标准，`NEP6`钱包可以序列化为一个JSON格式的文件，其中保存了加密后的账户私钥，需要对应的密码才能解密获取私钥。

    示例：
    - 创建新NEP6钱包，添加账户并保存为JSON文件：
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

    - 从JSON文件读取NEP6钱包，并解密账户：
        ```c# 
        // load wallet from nep6 wallet
        NEP6Wallet wallet = new NEP6Wallet(path);
        KeyPair keyPair2;
        using (wallet.Unlock(password))
        {
            keyPair2 = wallet.GetAccounts().First().GetKey();
        }
        ```

## `WalletAPI`

### 初始化
`WalletAPI`初始化：

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
WalletAPI walletAPI = new WalletAPI(client);
```

### 查询余额

> 注：账户余额的类型一般是`BigInteger`，这是把小数部分取整后的一种表示，需要除以`Factor`才是Token的实际数量。

- NEP5资产余额查询可以使用字符串参数
    ```c#
    // get the neo balance of account
    string tokenHash = "0x43cf98eddbe047e198a3e5d57006311442a0ca15";
    string address = "AJoQgnkK1i7YSAvFbPiPhwtgdccbaQ7rgq";
    BigInteger balance = walletAPI.GetTokenBalance(tokenHash, address);
    ```

    或者 使用ScriptHash类型的参数
    ```c#
    // get the neo balance of account
    UInt160 tokenScriptHash = Utility.GetScriptHash(tokenHash);
    UInt160 accountHash = Utility.GetScriptHash(address);
    Nep5API nep5API = new Nep5API(client);
    BigInteger balance = nep5API.BalanceOf(tokenScriptHash, accountHash);
    ```

- 在NEO3中NEO和GAS都是NEP5资产，且脚本哈希固定，所以这里提供了更简单的接口：
    ```c#
    // get the neo balance
    uint neoBalance = walletAPI.GetNeoBalance(address);

    // get the neo balance
    decimal gasBalance = walletAPI.GetGasBalance(address);
    ```

## Claim GAS

1. 在Claim GAS之前可以查询当前地址可以Claim的GAS数量：

    ```c#
    // get the claimable GAS of one address
    string address = "AJoQgnkK1i7YSAvFbPiPhwtgdccbaQ7rgq";
    decimal gasAmount = walletAPI.GetUnclaimedGas(address);
    ```
    或者 使用账户的ScriptHash

    ```c#
    string address = "AJoQgnkK1i7YSAvFbPiPhwtgdccbaQ7rgq";
    UInt160 accountHash = Utility.GetScriptHash(address);
    decimal gasAmount = walletAPI.GetUnclaimedGas(accountHash);
    ```

2. 在NEO3中Claim GAS的过程是在NEO转账时自动进行的，所以Claim GAS的操作需要构建一笔账户给自己转账的交易：

    ```c#
    // claiming gas needs the KeyPair of account, you can also use wif or private key hex string
    string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
    Transaction transaction = walletAPI.ClaimGas(wif);
    ```
    或者 使用`KeyPair`
    ```c#
    KeyPair keyPair = Utility.GetKeyPair(wif);
    Transaction transaction = walletAPI.ClaimGas(keyPair);
    ```

## 资产转账

`WalletAPI`中封装了NEP5转账方法:

可以使用字符串参数

```c#
string tokenHash = "0x43cf98eddbe047e198a3e5d57006311442a0ca15";
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "AJoQgnkK1i7YSAvFbPiPhwtgdccbaQ7rgq";

// transfer 10 neo from wif to address
walletAPI.Transfer(tokenHash, wif, address, 10);

// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
neoAPI.WaitTransaction(transaction)
    .ContinueWith(async (p) => Console.WriteLine($"Transaction is on block {(await p).BlockHash}"));
```
或者 使用`KeyPair` 和 `UInt160` (ScriptHash)

```c#
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "AJoQgnkK1i7YSAvFbPiPhwtgdccbaQ7rgq";

KeyPair sender = Utility.GetKeyPair(wif);
UInt160 receiver = Utility.GetScriptHash(address);

// transfer 10 neo from wif to address
walletAPI.Transfer(NativeContract.NEO.Hash, sender, receiver, 10);
```