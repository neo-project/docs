# Wallet Interfaces

Most operations in Neo blockchain are related to accounts. A wallet is the collection of accounts that includes one or multiple accounts. This document contains the following topics：

- The basic concepts and operations of accounts and wallets
- The method `WalletAPI`，which encapsulates wallet-related interfaces to provide the functions of balance inquiry, GAS claim, and transfer.

## Account and Wallet

### Account

An account is the user identity in Neo, which is essentially a private and public key pair ( `KeyPair` ) .

```c# 
// create a new KeyPair
byte[] privateKey = new byte[32];
using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(privateKey);
}
KeyPair keyPair = new KeyPair(privateKey);
```

### Private Key

Private key is an authorization tool used to sign transactions. Having a private key means you own an account that you can handle all the assets in it. The private key is essentially a 32-bit byte array that can be represented as a hexadecimal string, for example:

`"0x450d6c2a04b5b470339a745427bae6828400cf048400837d73c415063835e005"`

```c# 
  // export private key to hex string
  string privateHex = keyPair.PrivateKey.ToHexString();

  // get KeyPair from private hex string
  keyPair = Utility.GetKeyPair(privateHex);
```

### WIF

WIF is another string representation of the private key, which is equivalent to the private key. For example, the above private key is represented as the following WIF:

`"KyXwTh1hB76RRMquSvnxZrJzQx7h9nQP2PCRL38v6VDb5ip3nf1p"`

```c# 
  // export KeyPair as WIF
  string wif = keyPair.Export();

  // get KeyPair from WIF
  KeyPair keyPair1 = Utility.GetKeyPair(wif);
```

### Public Key

The public key verifies the signature of the private key. It corresponds to the ECPoint type in Neo. The public key can be calculated with the private key. Typically it is a 66-digit hexadecimal string:

`"02f9ec1fd0a98796cf75b586772a4ddd41a0af07a1dbdf86a7238f74fb72503575"`

```c# 
  // export public key hex string
  string publicHex = keyPair.PublicKey.ToString();

  // get public key from hex string
  Neo.Cryptography.ECC.ECPoint publicKey = Neo.Cryptography.ECC.ECPoint.Parse(publicHex, Neo.Cryptography.ECC.ECCurve.Secp256r1);
```

### Account ScriptHash

ScriptHash, corresponding to `UInt160` in Neo, is essentially a 20-bit byte array generated from the public key by script construction and hash algorithm. Since the hash algorithm is not reversible, the public key cannot be calculated backwards from the script hash. ScriptHash is usually expressed as a reversed hexadecimal string：
`"0xb0a31817c80ad5f87b6ed390ecb3f9d312f7ceb8"`

```c# 
  // get ScriptHash of KeyPair account
  UInt160 scriptHash = Contract.CreateSignatureContract(keyPair.PublicKey).ScriptHash;
  string strScriptHash = scriptHash.ToString();
```

### Address

Address is another string form of ScriptHash and can be transformed to or from ScriptHash. As the unique identifier of the account, address is the most commonly used account form. It is similar to the account number for a traditional account, when you transfer money you transfer it to a specified address. A common address format is: `"Ncm9TEzrp8SSer6Wa3UCSLTRnqzwVhCfuE"`

```c# 
using Neo.Wallets;

// ScriptHash to address
string adddress = scriptHash.ToAddress();
// address to ScriptHash
scriptHash = adddress.ToScriptHash();
```

### Wallet

Wallet is a collection of accounts. NEP6 is the most commonly used wallet standard in Neo. A NEP6 wallet can be serialized into a JSON file, in which the encrypted account private key is saved. The corresponding password is required to decrypt the private key.

Here is an example:

Create a new NEP6 wallet with an account and save as JSON file:

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

Read the NEP6 wallet from the JSON file and decrypt the account:

```c# 
// load wallet from nep6 wallet
NEP6Wallet wallet = new NEP6Wallet(path);
KeyPair keyPair2;
using (wallet.Unlock(password))
{
    keyPair2 = wallet.GetAccounts().First().GetKey();
}
```

## Using WalletAPI

### Initialization
Initializing `WalletAPI`：

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
WalletAPI walletAPI = new WalletAPI(client);
```

### Inquiring balance

> [!Note]
>
> The type of account balance is usually BigInteger, which is a representation after rounding the decimal part. It needs to be divided by Factor to get the actual Token amount.

Inquiry NEP-5 asset balance using the string parameter:

```c#
// get the neo balance of account
string tokenHash = NativeContract.NEO.Hash.ToString();
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
BigInteger balance = walletAPI.GetTokenBalance(tokenHash, address);
```

or using the parameter of ScriptHash type:

```c#
// get the neo balance of account
UInt160 tokenScriptHash = Utility.GetScriptHash(tokenHash);
UInt160 accountHash = Utility.GetScriptHash(address);
Nep5API nep5API = new Nep5API(client);
BigInteger balance = nep5API.BalanceOf(tokenScriptHash, accountHash);
```

In Neo 3 NEO and GAS are both NEP5 assets with the fixed scripthash. Here we provide a simpler interface:

```c#
// get the neo balance
uint neoBalance = walletAPI.GetNeoBalance(address);

// get the neo balance
decimal gasBalance = walletAPI.GetGasBalance(address);
```

## Claiming GAS

In Neo3 GAS is automatically claimed when NEO is transferred. You can construct a transaction transferring to yourself to claim GAS.

1. First check the claimable GAS amount at current address:

    ```c#
    // get the claimable GAS of one address
    string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
    decimal gasAmount = walletAPI.GetUnclaimedGas(address);
    ```
    or use ScriptHash of the account to check:

    ```c#
    string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
    UInt160 accountHash = Utility.GetScriptHash(address);
    decimal gasAmount = walletAPI.GetUnclaimedGas(accountHash);
    ```

2. Construct a transaction sending NEO to yourself:

    ```c#
    // claiming gas needs the KeyPair of account. You can also use wif or private key hex string
    string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
    Transaction transaction = walletAPI.ClaimGas(wif);
    ```
    or use `KeyPair`:
    
    ```c#
    KeyPair keyPair = Utility.GetKeyPair(wif);
    Transaction transaction = walletAPI.ClaimGas(keyPair);
    ```

## Asset Transfer

`WalletAPI` encapsulates transfer methods of NEP-5 assets.

Use string parameters: 

```c#
string tokenHash = NativeContract.NEO.Hash.ToString();
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";

// transfer 10 NEO from wif to address
walletAPI.Transfer(tokenHash, wif, address, 10);

// print a message after the transaction is on chain
WalletAPI neoAPI = new WalletAPI(client);
neoAPI.WaitTransaction(transaction)
    .ContinueWith(async (p) => Console.WriteLine($"Transaction is on block {(await p).BlockHash}"));
```
or use `KeyPair` and  `UInt160` (ScriptHash):

```c#
string wif = "L1rFMTamZj85ENnqNLwmhXKAprHuqr1MxMHmCWCGiXGsAdQ2dnhb";
string address = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";

KeyPair sender = Utility.GetKeyPair(wif);
UInt160 receiver = Utility.GetScriptHash(address);

// transfer 10 NEO from wif to address
walletAPI.Transfer(NativeContract.NEO.Hash, sender, receiver, 10);
```

NEP5 transfer from multi-signature account:

```
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

## What's next?

[Transaction Construction](transaction.md)

