# NEO SDK 常见用法

### 16 进制字符串与 byte 数组互转

```c#
//16进制字符串转Byte数组
string pubkey = "03335e39ec91a16797ddc2af00feee1cb57c2e6382dc5ba59efa7d65302e4b5a33";
var bytes = pubkey.HexToBytes();
//Byte数组转16进制字符串
string pubkey2 = bytes.ToHexString();
Console.WriteLine(pubkey2);
```

### DateTime 与 Unix 时间戳互转

```c#
//DateTime转Unix时间戳
DateTime date = new DateTime(2018,1,1,0,0,0);
uint timestamp = date.ToTimestamp();
//Unix时间戳转DateTime
DateTime date2 = timestamp.ToDateTime();
Console.WriteLine(date2.ToString());
```

### NEO 地址校验

```c#
try
{
    Neo.Wallets.Wallet.ToScriptHash("AV9XwWP1VX1oQWBJR4BAHjSai6VW5vCYVS ");
    Console.WriteLine("NEO地址正确");
}
catch (Exception)
{
    Console.WriteLine("NEO地址错误");
}
```

当地址错误的时候，会抛出异常。也可以用 API 来进行地址校验，[参考教程](../node/api/validateaddress.md)。

### WIF 格式私钥校验

```c#
try
{
    Neo.Wallets.Wallet.GetPrivateKeyFromWIF("KyGnCKKnL1xCZ8V2bo8vZvTpVrwAGnAXTmRqBEwA5JG2mqdgfgSx");
    Console.WriteLine("私钥正确");
}
catch (Exception)
{
    Console.WriteLine("私钥错误");
}
```

当私钥错误的时候，会抛出异常。

### 生成公钥和私钥

```c#
using (CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
{
    var privateKey = key.Export(CngKeyBlobFormat.EccPrivateBlob);
    var account = new Neo.Wallets.KeyPair(privateKey);
    var ecpoint = account.PublicKey;
    Console.WriteLine($"WIF私钥：{account.Export()}");
    Console.WriteLine($"16进制公钥：{ecpoint.ToString()}");
}
```

### 通过私钥生成标准地址

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"创建成功，标准地址为：{sc.Address}");
    Console.WriteLine($"创建成功，WIF私钥为：{account.Export()}");
}
```

### 通过公钥生成标准地址

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"创建成功，标准地址为：{sc.Address}");
}
```

### 创建钱包文件

```c#
//创建钱包
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //钱包文件名
wallet.Unlock("password"); //设置钱包密码
wallet.CreateAccount();
wallet.Save();
//输出钱包地址
var accounts = wallet.GetAccounts();
foreach (var item in accounts)
{
    Console.WriteLine(item.Address);
}
```

使用本段代码可以创建 NEP-6（钱包标准）的钱包文件。

### 打开钱包文件

```c#
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //钱包文件名
try
{
    wallet.Unlock("password"); //钱包密码
    var accounts = wallet.GetAccounts();
    foreach (var item in accounts)
    {
        Console.WriteLine(item.Address);
    }
}
catch (Exception)
{
    Console.WriteLine("密码错误");
}
```

解锁钱包时，如果密码错误，则会抛出异常。



更多 NEO SDK 常见用法正在补充中……