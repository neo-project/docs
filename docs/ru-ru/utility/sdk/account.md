# Счет

В данном документе используется версия NEO SDK 2.9.0.

### Верификация адреса NEO 

```c#
try
{
    "AV9XwWP1VX1oQWBJR4BAHjSai6VW5vCYVS".ToScriptHash();
    Console.WriteLine("The NEO address is correct");
}
catch (Exception)
{
    Console.WriteLine("The NEO address is wrong");
}
```

Если адрес неверен, генерируется исключение. Для верификации адреса вы можете использовать также API. Дополнительную информацию см. в [validateaddress](../../node/cli/latest-version/api/validateaddress.md).

### Верификация закрытого ключа WIF 

```c#
try
{
    Neo.Wallets.Wallet.GetPrivateKeyFromWIF("KyGnCKKnL1xCZ8V2bo8vZvTpVrwAGnAXTmRqBEwA5JG2mqdgfgSx");
    Console.WriteLine("The private key is correct");
}
catch (Exception)
{
    Console.WriteLine("The private key is correct");
}
```

Если закрытый ключ неверен, генерируется исключение.

### Генерирование закрытого и открытого ключей 

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

### Генерирование стандартного адреса из закрытого ключа 

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"Created successfully. The standard address is：{sc.Address}");
    Console.WriteLine($"Created successfully. The WIF private is：{account.Export()}");
}
```

### Генерирование стандартного адреса из открытого ключа 

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"Created successfully. The standard address is：{sc.Address}");
}
```


