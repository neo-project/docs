# Account related operations

### Verifying NEO address

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

If the address is wrong, an exception is thrown. You can also use API to verify the adderss. For more information refer to [validateaddress](../../reference/rpc/latest-version/api/validateaddress.md).

### Verifying WIF private key

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

If the private key is wrong, an exception is thrown.

### Generating public key and private key

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

### Generating standard address from private key

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"Created successfully. The standard address is：{sc.Address}");
    Console.WriteLine($"Created successfully. The WIF private is：{account.Export()}");
}
```

### Generating standard address from public key

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"Created successfully. The standard address is：{sc.Address}");
}
```


To be continued.
