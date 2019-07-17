# NEO SDKの一般的な使用方法

### 16進文字列とバイト配列の変換

```c#
//16進文字列をバイト配列へ変換
string pubkey = "03335e39ec91a16797ddc2af00feee1cb57c2e6382dc5ba59efa7d65302e4b5a33";
var bytes = pubkey.HexToBytes();
//バイト配列を16進文字列へ変換
string pubkey2 = bytes.ToHexString();
Console.WriteLine(pubkey2);
```

### DateTimeとUnixタイムスタンプの変換

```c#
//DateTimeをUnixタイムスタンプへ変換
DateTime date = new DateTime(2018,1,1,0,0,0);
uint timestamp = date.ToTimestamp();
//UnixタイムスタンプをDateTimeへ変換
DateTime date2 = timestamp.ToDateTime();
Console.WriteLine(date2.ToString());
```

### NEOアドレスの確認

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

アドレスが間違っていると例外がスローされます。また、APIを使用してNEOアドレスを確認することもできます。詳細については、[validateaddressメソッド](ja-jp/node/api/validateaddress.md)を参照してください。

### WIF秘密鍵の確認

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

秘密鍵が間違っていると例外がスローされます。

### 公開鍵と秘密鍵の生成

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

### 秘密鍵からアドレスを生成

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"The standard address {sc.Address} is created");
    Console.WriteLine($"The WIF {account.Export()} is created");
}
```

### 公開鍵からアドレスを生成

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"The standard address {sc.Address} is created");
}
```

### ウォレットファイルの作成

```c#
//ウォレットの作成
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //ウォレット名
wallet.Unlock("password"); //Specify wallet password
wallet.CreateAccount();
wallet.Save();
//ウォレットアドレスの入力
var accounts = wallet.GetAccounts();
foreach (var item in accounts)
{
    Console.WriteLine(item.Address);
}
```

上記のコードを用いて、NEP-6標準のウォレットファイルを作成することが出来ます。

### ウォレットファイルを開く

```c#
var wallet = new Neo.Implementations.Wallets.NEP6.NEP6Wallet("wallet.json"); //ウォレット名
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

ウォレットをロック解除するためのパスワードが間違っていると、例外がスローされます。

このドキュメントは、NEO SDKの一般的な用途を追加するために編集中です。
