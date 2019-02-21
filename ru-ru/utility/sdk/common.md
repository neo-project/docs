# Общие случаи применения NEO SDK 

### Преобразование шестнадцатеричных строк в байтовые массивы и наоборот 

```c#
//Convert the hexadecimal string to the byte array
string pubkey = "03335e39ec91a16797ddc2af00feee1cb57c2e6382dc5ba59efa7d65302e4b5a33";
var bytes = pubkey.HexToBytes();
//Convert the byte array to the hexadecimal string
string pubkey2 = bytes.ToHexString();
Console.WriteLine(pubkey2);
```

### Преобразование DateTime во временную метку Unix и наоборот 

```c#
//Convert DateTime to the Unix timestamp
DateTime date = new DateTime(2018,1,1,0,0,0);
uint timestamp = date.ToTimestamp();
//Convert the Unix timestamp to DateTime
DateTime date2 = timestamp.ToDateTime();
Console.WriteLine(date2.ToString());
```

### Верификация адресов NEO 

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

Когда адрес неверен, генерируется исключение. Для верификации адресов NEO вы можете использовать также API. Дополнительную информацию см. в [validateaddress Method](../../node/cli/latest-version/api/validateaddress.md).

### Верификация закрытого ключа WIF 

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

Когда закрытый ключ неверен, выдается исключение.

### Генерирование закрытого (Private) и открытого (Public) ключей

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

### Генерирование адреса закрытым ключом 

```c#
public void Generate(byte[] privateKey)
{
    var account = new Neo.Wallets.KeyPair(privateKey);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(account.PublicKey);
    Console.WriteLine($"The standard address {sc.Address} is created");
    Console.WriteLine($"The WIF {account.Export()} is created");
}
```

### Генерирование адреса открытым ключом 

```c#
public void Generate(byte[] publicKey)
{
    var ecpoint = Neo.Cryptography.ECC.ECPoint.FromBytes(publicKey, Neo.Cryptography.ECC.ECCurve.Secp256r1);
    var sc = Neo.SmartContract.Contract.CreateSignatureContract(ecpoint);
    Console.WriteLine($"The standard address {sc.Address} is created");
}
```

### Создание файла кошелька

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

Вы можете использовать указанные строки кода для создания файла стандартного кошелька NEP-6.

### Открытие файла кошелька

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

Если пароль для разблокировки кошелька неверен, то генерируется исключение.

В настоящий момент данный документ редактируется, в дальнейшем в него будут добавлены новые общие случаи применения NEO SDK.