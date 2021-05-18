# Smart Contract Writing Basics

In this tutorial, you will learn the basics of developing a smart contract. 

Let's have a look at our basic hello world contract.

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;

namespace Helloworld
{
    [ManifestExtra("Author", "Neo")]
    [ManifestExtra("Email", "dev@neo.org")]
    [ManifestExtra("Description", "This is a contract example")]
    public class Contract1 : SmartContract
    {
        //TODO: Replace it with your own address.
        [InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default;

        private static bool IsOwner() => Runtime.CheckWitness(Owner);

        // When this contract address is included in the transaction signature,
        // this method will be triggered as a VerificationTrigger to verify that the signature is correct.
        // For example, this method needs to be called when withdrawing token from the contract.
        public static bool Verify() => IsOwner();

        // TODO: Replace it with your methods.
        public static string MyMethod()
        {
            return Storage.Get(Storage.CurrentContext, "Hello");
        }

        public static void _deploy(object data, bool update)
        {
            if (update) return;

            // It will be executed during deploy
            Storage.Put(Storage.CurrentContext, "Hello", "World");
        }

        public static void Update(ByteString nefFile, string manifest)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Update(nefFile, manifest, null);
        }

        public static void Destroy()
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Destroy();
        }
    }
}
```

## Contract property

Inside the contract class, the property defined with `static readonly` or `const` is the contract property which can be used as constants and can not be changed. For instance, when we want to define a Owner of that contract or the factor number which will be used in the later asset transfer, we can define these constants in this way:

```c#
// Represents onwner of this contract, which is a fixed address. Usually should be the contract creator
[InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
static readonly UInt160 Owner = default;

// A constant number
private const ulong factor = 100000000;
```

These properties defined in contract property are usually constants that can be used inside the methods of smart contract and every time the smart contract is running on any instance, these properties keep the same value.

In addition, developer can define static method  in contract and return a constant, which is exposing the method  out of the contract and let end-user can call the method to get the fixed value when they try to query the smart contract. For instance, when you create you own token, you have to define a name which you may want everyone use you contract can check he name with this method.

```c#
public static string Name() => "name of the token";
```

## Storage property

When you develop the smart contract, you have to store your application data on the blockchain. When a Smart Contract is created or when a transaction awakens it, the Contract’s code can read and write to its storage space. All data stored in the storage of the smart contract are automatically persisted between invocations of the smart contract. Full nodes in the blockchain store the state of every smart contract on the chain.

Neo has provided data access interface based on key-value pairs. Data records may be read or deleted from or written to the smart contracts using keys. Besides, smart contracts may retrieve and send their storage contexts to other contracts, thereby entrusting other contracts to manage their storage areas. In C# development, smart contract can use the `Storage` Class to read/write the persistent storage  The `Storage` class is a static class and does not require a constructor. The methods of `Storage` class can be viewed in this [API References](../../reference/scapi/framework/services/Storage.md)

For instance, if you want to store the total supply of your token into storage:

```c#
// Key is totalSupply and value is 100000000
Storage.Put(Storage.CurrentContext, "totalSupply", 100000000);
```

Here `CurrentContext` Returns the current store context. After obtaining the store context, the object can be passed as an argument to other contracts (as a way of authorization), allowing other contracts to perform read/write operations on the persistent store of the current contract.

`Storage` work well for storing primitive values and while you can use an `StorageMap`  which can be used for storing structured data, this will store the entire container in a single key in smart contract storage.

```c#
//Get the totalSupply in the storageMap. The Map is used an entire container with key name "contract"
StorageMap contract = new(Storage.CurrentContext, nameof(contract))
var value = contract.Get("totalSupply");
return value is null ? 0 : (BigInteger)value;;
```

## Data type

When using C# to develop smart contracts, you cannot use the full set of C# features due to the difference between NeoVM and Dotnet IL.

Because NeoVM is more compact, we can only compile limited C# / dotnet features into an NEF file.

NeoVM provides the following basic types：

- `Pointer`
- `Boolean`
- `Integer`
- `ByteString`
- `Buffer`
- `Array`
- `Struct`
- `Map`
- `InteropInterface`

The basic types of C# are:

- `Int8 int16 int32 int64 uint8 uint16 uint32 uint64`
- `float double`
- `Boolean`
- `Char String`

## Your first Neo contract

After analyzing the basic hello world contract, let us move to your first real-world smart contract. Here we provide a very simple DNS system which was written in C#. The main function of the DNS is store the domain for users. It contains all the points above except the events. We can investigate this smart contract to learn how to make a basic smart contract. The source code is here:

```c#
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System.ComponentModel;

namespace Domain
{
    public class Contract1 : SmartContract
    {

        [DisplayName("query")]
        public static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        [DisplayName("register")]
        publilc static bool Register(string domain, byte[] owner)
        {
            // Check if the contract owner is the same as the one who invokes the contract
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        [DisplayName("delete")]
        public static bool Delete(string domain)
        {
            // To do
        }
    }
}
```

Let's slice it and learn it step by step.

### Contract Features

You can declare more features:

```c#
[ManifestExtra("Author", "Neo")]
[ManifestExtra("Email", "dev@neo.org")]
[ManifestExtra("Description", "This is a contract example")]
[SupportedStandards("NEP-17")]
[ContractPermission("*", "onNEP17Payment")]
[ContractTrust("0x0a0b00ff00ff00ff00ff00ff00ff00ff00ff00a4")]
public class Contract1 : SmartContract
{
    public static bool Main(string operation, object[] args)
    {
        // other code
    }
}
```

`ManifestExtra` represents the extra fields in the Manifest file, where you can add `Author`, `Email`,  `Description` and etc.

`SupportedStandards` represents the NEP standards the contract conform to, such as NEP-17, a token standard on Neo. 

`ContractPermission` indicates the permission requested by the contract, and `ContractTrust` indicates which contracts trust the contract to call itself.  See [invocation-permission](... /deploy/invoke.html#invocation-permission).

You can also add other fields, such as:

```c#
[ManifestExtra("Name", "sample contract")]
[ManifestExtra("Version", "1.0.0")]
```

### Entry function

Theoretically, smart contracts can have any entry points. Methods of the public static type in the contract can be used as an entry function to be invoked externally, for example:

```c#
using Neo.SmartContract;
using Neo.SmartContract.Framework;

namespace Neo.Compiler.MSIL.UnitTests.TestClasses
{
    class Contract_a : SmartContract.Framework.SmartContract
    {
        public static object First(string method, object[] args)
        {
            return 'a';
        }
        public static object Second(string method, object[] args)
        {
            return 'b';
        }
    }
}
```

The compiler marks the offset of `First` and `Second` in ABI. When invoking the contract, it assigns the value to initialPosition, finds and executes the matching method according to the offset recorded in the ABI.

### Trigger

A smart contract trigger is a mechanism that triggers the execution of smart contracts. There are three triggers introduced in the Neo smart contract，`Verification`,   `Application`, and `System`. However, for most smart contract development, you only need to implement the Verify method to provide the signature verification logic, without having to decide the trigger. 

#### Verification trigger

A Verification trigger is used to call the contract as a verification function, which can accept multiple parameters and should return a valid Boolean value, indicating the validity of the transaction or block.

```c#
public static bool Verify()
{
    return Runtime.CheckWitness(Owner);
}
```

### CheckWitness

In many, if not all cases, you will probably be wanting to validate whether the address invoking your contract code is really who they say they are.

The `Runtime.CheckWitness` method accepts a single parameter which represents the address that you would like to validate against the address used to invoke the contract code. In more deeper detail, it verifies that the transactions / block of the calling contract has validated the required script hashes.

Usually this method is used to check whether an specified address is the the contract caller,  and then the address can be used to do store change or something else.

Inside our `DNS smart contract`, the `Register` function is firstly check if the owner is the same as the one who invoke the contract. Here we use the `Runtime.CheckWitness` function. Then we try to fetch the domain owner first to see if the domain is already exists in the storage. If not, we can store our domain->owner pair using the `Storage.Put`method.

```c#
private static bool Register(string domain, byte[] owner)
{
    if (!Runtime.CheckWitness(owner)) return false;
    byte[] value = Storage.Get(Storage.CurrentContext, domain);
    if (value != null) return false;
    Storage.Put(Storage.CurrentContext, domain, owner);
    return true;
}
```

Similar to the Register method, the Delete function check the owner first and if it exists and it is the same as the one who invoke the contract, delete the pair using the `Storage.Delete`method. 

### Events

In Smart contract, events are a way  to communicate that something happened on the blockchain to your app front-end (or back-end), which can be 'listening' for certain events and take action when they happen. You might use this to update an external database, do analytics, or update a UI. In some specified contract standard,  it defined some events should be posted. It is not cover in this page, but is very useful for the other smart contracts. For instance, in the NEP-17 Token, the events `transfer` should be fired when user invoke the transfer function.

```c#
//Should be called when caller transfer NEP-17 asset.
[DisplayName("Transfer")]
public static event Action<byte[], byte[], BigInteger> OnTransfer;
```

Transfer is the event name.

### Json serialization

In Neo N3 smart contract, the Json serialization/deserialization feature is added:

```c#
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

namespace Neo.Compiler.MSIL.TestClasses
{
    public class Contract_Json : SmartContract.Framework.SmartContract
    {
        public static string Serialize(object obj)
        {
            return Json.Serialize(obj);
        }

        public static object Deserialize(string json)
        {
            return Json.Deserialize(json);
        }
    }
}
```

