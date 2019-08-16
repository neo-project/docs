# NEO SDK 的常用操作

## 常用数据类型转换

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

### Address 与 Script Hash 互转

```c#
UInt160 scriptHash = "AK4LdT5ZXR9DQZjfk5X6Xy79mE8ad8jKAW".ToScriptHash();
string address = scriptHash.ToAddress();
```

如果 Script Hash 是大端序的字符串格式，可以用下面的方法转成 Address：

```c#
string address = new UInt160("0x9121e89e8a0849857262d67c8408601b5e8e0524".Remove(0, 2).HexToBytes().Reverse().ToArray()).ToAddress();
```

### 大端序与小端序互转

```c#
//big-endian 2 little-endian
Console.WriteLine("0x4701ee0b674ff2d8893effc2607be85327733c1f".Remove(0, 2).HexToBytes().Reverse().ToHexString());
//little-endian 2 big-endian
Console.WriteLine("0x" + "1f3c732753e87b60c2ff3e89d8f24f670bee0147".HexToBytes().Reverse().ToHexString());
```

### 16 进制字符与 BigInteger 互转

```c#
BigInteter bigInt = new BigInteger("00e1f505".HexToBytes());
string hexStr = new BigInteger(100000000).ToByteArray().ToHexString();
```

## 常用验证

### 验证 NEO 标准地址

```c#
try
{
    Neo.Wallets.Wallet.ToScriptHash("AV9XwWP1VX1oQWBJR4BAHjSai6VW5vCYVS ");
    Console.WriteLine("NEO address is correct");
}
catch (Exception)
{
    Console.WriteLine("NEO address is wrong");
}
```

如果地址是错误的，验证会抛出异常。另外，你也可以使用API来验证NEO地址。更多信息请参考[validateaddress 方法](../../reference/rpc/latest-version/api/validateaddress.md)。

### 验证 WIF 格式私钥

```c#
try
{
    Neo.Wallets.Wallet.GetPrivateKeyFromWIF("KyGnCKKnL1xCZ8V2bo8vZvTpVrwAGnAXTmRqBEwA5JG2mqdgfgSx");
    Console.WriteLine("WIF is correct");
}
catch (Exception)
{
    Console.WriteLine("WIF is wrong");
}
```

如果私钥是错误的，验证会抛出异常。

## 公钥和私钥相关操作

### 生成公钥和私钥

```c#
using (CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
{
    var privateKey = key.Export(CngKeyBlobFormat.EccPrivateBlob);
    var account = new Neo.Wallets.KeyPair(privateKey);
    var ecpoint = account.PublicKey;
    Console.WriteLine($"WIF private key：{account.Export()}");
    Console.WriteLine($"hexadecimal public key：{ecpoint.ToString()}");
}
```

### 通过私钥生成地址

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"The standard address {sc.Address} is created");
    Console.WriteLine($"The WIF {account.Export()} is created");
}
```

### 通过公钥生成地址

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"The standard address {sc.Address} is created");
}
```

## 钱包文件相关操作

### 创建钱包文件

```c#
//Create a wallet
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //Wallet name
wallet.Unlock("password"); //Specify wallet password
wallet.CreateAccount();
wallet.Save();
//Input wallet address
var accounts = wallet.GetAccounts();
foreach (var item in accounts)
{
    Console.WriteLine(item.Address);
}
```

你可以使用上面的代码来创建一个NEP-6标准的钱包文件。

### 打开钱包文件

```c#
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //Wallet name
try
{
    wallet.Unlock("password"); //Wallet password
    var accounts = wallet.GetAccounts();
    foreach (var item in accounts)
    {
        Console.WriteLine(item.Address);
    }
}
catch (Exception)
{
    Console.WriteLine("Password is wrong");
}
```

如果用于打开钱包的密码是错误的，将会抛出异常。

## 期待更多
更多 NEO SDK 用法正在补充中。
