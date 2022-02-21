# Differences between Neo N3 and Neo Legacy

This document describes the main differences in writing smart contracts between Neo N3 and Neo Legacy. Developers who want to migrate Neo Legacy contracts to Neo N3 need to be aware of these changes. Since Neo N3 is still being updated, here we only list significant changes and the document will be updated continuously.

## Development Environment

### .NET Core

In Neo N3, .NET Core version has been upgraded from 3.0 to 5.0. You need to update SDK.

### Visual Studio Extension

In Neo N3, the Visual Studio extensions are updated. You need to uninstall the old NeoContractPlugin plugin, compile, and install the latest NeoContractPlugin.

The new contract templates have major updates. For more information refer to <a href="#合约模板">Contract Template</a>.

### Compiler

In Neo N3, the old neon (Neo.Compiler.MSIL) has been deprecated. You need to use the latest nccs (Neo.Compiler.CSharp) compiler, which has major changes as follows:

* Not support for the language Visual Basic.
* Ability to directly compile the  C# code to smart contracts without the intermediate language IL. 
* Ability to directly compile solutions, projects, and C# files.
* Support for more C# features.
* Deterministic compilation. If the code and compiler are deterministic, the compiled contract is deterministic.
* abi files upgraded to manifest files.
* nvm files upgraded to nef files.
* Compile directory changed from `bin/debug` to `bin/sc`.

## Contract Template

### Namespace

Neo Legacy：

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
```
Neo N3：

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
```

### Contract Feature

|                         | Neo Legacy                                                   | Neo N3                                                       |
| ----------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Contract info           | You need to fill in contract information such as the name, author, email, etc. when deploying the contract. | Add the contract features to the contract file, written as [C# Features](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/attributes/), for example：<br/>[ManifestExtra("Author", "Neo")]<br/>[ManifestExtra("Email", "dev@neo.org")]<br/>[ContractTrust("\*")]<br/>[ContractPermission("\*", "\*")]<br/>[SupportedStandards("NEP-17")]<br/>[ManifestExtra("Description", "This is a contract example")]<br/>public class Contract1 : SmartContract |
| Contract function       | When deploying a contract, you need to declare contract features such as whether to use storage, whether it can be called dynamically, and whether to accept NEP-5 assets. | All contracts can use the storage and dynamic calls by default. You can implement the OnNEP17Payment method to accept NEP-17 assets and implement the OnNEP11Payment method to accept NEP-11 (NFT standard) assets. |
| Declare support for NEP | Code example:<br/>public static string[] SupportedStandards()<br/>{<br/>    string[] result = { "NEP-5", "NEP-7", "NEP-10" };<br/>    return result;<br/>} | Directly add the feature to the contract class name `[SupportedStandards("NEP-17")]` |

### Declaration of static variables

Neo Legacy

```c#
private static readonly byte[] InitialOwnerScriptHash = "AJhZmdHxW44FWMiMxD5bTiF7UgHcp3g2Fr".ToScriptHash();
```

Neo N3

```c#
[InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
static readonly UInt160 Owner = default;
```

### Methods and Events

|                     | Neo Legacy                                                   | Neo N3                                                       |
| ------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| main                |                                                              | Removed. Developers no longer need to write the redundant main method for contract method jumping |
| Verify              | Determined in the Main method, for example：<br/>public static object Main(string method, object[] args)<br/>{<br/>    if (Runtime.Trigger == TriggerType.Verification)<br/>    {<br/>    	return IsOwner();<br/>    )<br/>} | Independent method：<br/> `public static bool Verify() => IsOwner();` |
| Method Name         | To make the method name conform to the smart contract naming rules, the method is declared like this: <br/>[DisplayName("balanceOf")]<br/>public static BigInteger BalanceOf(byte[] account) | The first letter of the method name is automatically compiled to lowercase, so developers no longer have to use DisplayName, but DisplayName is still acceptable. |
| Deployment          | Initialization variables are placed into a separate method that is called manually after deployment. | The method `_deploy` is added, which is executed automatically after deployment. |
| Update and destroy  | You need to write the Update and Destroy methods by yourself. | Update and Destroy methods are built in the contract template |
| transfer event name | `transfer`                                                   | `Transfer`                                                   |

### Permission

#### User's signature

In Neo Legacy all contracts in the call chain can use user signatures by default.

Neo N3 adds the concept of WitnessScope, which by default allows only the entry contract to use the user signature and allows the user to modify it.

#### Permission and trust

In Neo Legacy, contracts can call each other via dynamic invoking function. You need to set invoking permission in the code, but this way has limited effect.

Neo N3：

- Added restrictions on contract invoking permission. You need to declare Permission first and then invoke.
- Added the concept of contract Groups and Trusts to enable wallets to give security warnings.

- Added the concept of CallFlag to restrict the behavior of the called contract.


#### Security method

Neo N3 adds a new security method. You can execute the contract in a read-only manner by adding the [Safe] feature to the method.

## Contract Framework

### Native contracts

Neo N3 introduces a large number of native contracts, moving massive interoperable services from Neo Legacy to native contracts. The major changes are as follows.

- Upgraded the Blockchain class to a Ledger native contract, e.g. `Blockchain.GetBlock()` changed to `Ledger.GetBlock()`.
- Added the ContractManagement native contract to query contracts and manage their updating and destruction.

- Moved the contract part of the Blockchain class to the ContractManagement native contract, e.g. `Blockchain.GetContract()` changed to `ContractManagement .GetContract()`.

- Added the CryptoLib native contract and moved Sha256, ripemd160, VerifyWithECDsa and other methods to this contract.

- Added the StdLib native contract and moved serialization, deserialization, data conversion and other methods from Helper class to this contract.

- Added native contracts such as NEO, GAS, Oracle, Policy, and RoleManagement.

- Moved the functions election, voting, and GAS extraction from specific transactions to the NEO native contract.


### Class

- The Runtime class has been extensively updated. More runtime states are added.
- The Transaction class has been extensively updated to fit the data structure of Neo N3 transactions.
- Added a new Crypto class and moved some of the methods provided by the SmartContract class to this class.
- Moved a number of classes:
  -  Account
  -  Asset
  - Header
  - InvocationTransaction
  - TransactionAttribute
  - TransactionInput
  - TransactionOutput


### Storage

|                 | Neo Legacy                                                   | Neo N3                                                       |
| --------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| StorageMap      | StorageMap cannot be used as static variable. It should be written to each method. | Support for declaration of static StorageMap.                |
| Storage search  | Returns byte[] if no corresponding key is found.             | Returns null if no corresponding key is found. You need to determine whether it is empty, otherwise a null reference exception may occur. |
| Data conversion | Data is converted via the method `ToBigInteger`              | Data is compulsively converted via the method `(BigInteger)` |
|                 | The `Storage.CurrentContext.CreateMap(string name)` method   | Changed to the construction method of StorageMap             |

Neo Legacy ：

```c#
public static readonly string mapName = "asset";

public static void Put(byte[] key, BigInteger value) => Storage.CurrentContext.CreateMap(mapName).Put(key, value);

public static BigInteger Get(byte[] key) => Storage.CurrentContext.CreateMap(mapName).Get(key).ToBigInteger();
```

Neo N3：

```c#
public static readonly string mapName = "asset";

public static void Put(UInt160 key, BigInteger value) => assetMap.Put(key, value);

public static BigInteger Get(UInt160 key)
{
    var value = assetMap.Get(key);
    return value is null ? 0 : (BigInteger)value;
}
```

### TokenSale Operations

#### Contract writing

Neo Legacy：

It is very complicated to do Token Sale due to the deference between UTXO assets and contract assets. Generally, you have to write the mintTokens method, get the transaction that invokes the contract, then analyze the sender from the transaction input, analyze the transfer amount and asset name from the transaction output, and finally transfer the contract asset to the sender.

Neo N3：

TokenSale can be implemented via OnNEP17Payment. The sender and transfer amount no longer need to be analyzed from the transaction one by one and then summed up, but can be directly obtained from the parameters. Here is an example:

```c#
public static void OnNEP17Payment(UInt160 from, BigInteger amount, object data)
{
    if (Runtime.CallingScriptHash == NEO.Hash)
    {
        Mint(amount * TokensPerNEO);
    }
    else if (Runtime.CallingScriptHash == GAS.Hash)
    {
        if (from != null) Mint(amount * TokensPerGAS);
    }
}
```

#### User operations

Neo Legacy：

The user initiates InvocationTransaction, constructs the transaction input and output, transfers the NEO/GAS to the contract address, and calls the mintTokens method of the contract address to complete TokenSale.

Neo N3 ：

The user just need to send NEO/GAS to the contract address, which triggers the OnNEP17Payment method of the contract to complete TokenSale.

### Exception

Neo Legacy：

When invoking a contract, if the contract execution encounters an exception, the exception message is not printed.

Neo N3：

When invoking a contract, the exception message is printed as the result of the call.

### Static call

Neo Legacy ：

```c#
[Appcall("XXXXXXXXXX")]//ScriptHash
public static extern int AnotherContract(string arg);

public static void Main()
{
    AnotherContract("Hello");    
}
```

Neo N3 ：

```c#
[Contract("0102030405060708090A0102030405060708090A")]
public class Contract1
{
    public static extern void MyMethod();
}

public static void Call()
{
    Contract1.MyMethod();
}
```

### Dynamic call

Neo Legacy：

```c#
delegate object Dyncall(string method, object[] args);
public static object Main(string operation, object[] args)
{
    var dyncall = (Dyncall)target.ToDelegate();
    var newArgs = new object[1];
    var method = (string)args[0];
    newArgs[0] = args[1];
    dyncall(method, newArgs);
}
```

Neo N3：

You can invoke `Contract.Call()` to complete the dynamic call of the contract.

```c#
public static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
{
    Contract.Call(to, "onNEP17Payment", CallFlags.All, new object[] { from, amount, data });
}
```

