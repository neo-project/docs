# 账户相关用法

### NEO 地址校验

```c#
try
{
    "AV9XwWP1VX1oQWBJR4BAHjSai6VW5vCYVS".ToScriptHash();
    Console.WriteLine("NEO地址正确");
}
catch (Exception)
{
    Console.WriteLine("NEO地址错误");
}
```

当地址错误的时候，会抛出异常。也可以用 API 来进行地址校验，[参考教程](../../reference/rpc/latest-version/api/validateaddress.md)。

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


更多常见用法正在补充中。
