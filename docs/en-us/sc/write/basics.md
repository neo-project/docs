# Smart Contract Writing Basics

In this tutorial, you will learn the basics of developing a smart contract. 

Let's have a look at our basic hello world contract.

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;

namespace Helloworld
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        private const string test_str = "Hello World";
        public static String Main(string operation, object[] args)
        {
            Storage.Put("Hello", "World");
            return test_str;
        }
    }
}
```

## Contract structure

Every Smart Contract inherits the `SmartContract` base class which is in the Neo framework and provides some basic methods.

The `NEO` namespace is the API provided by the Neo blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories:

1. Blockchain ledger. The contract can access all the data on the entire blockchain through interops layer, including complete blocks and transactions, as well as each of their fields.
2. Persistent store. Each application contract deployed on Neo has a storage space that can only be accessed by the contract itself. These methods provided can access the data in the contract.

## Contract property

Inside the contract class, the property defined with `static readonly` or `const` is the contract property which can be used as constants and can not be changed. For instance, when we want to define a Owner of that contract or the factor number which will be used in the later asset transfer, we can define these constants in this way:

```c#
// Represents onwner of this contract, which is a fixed address. Usually should be the contract creator
public static readonly byte[] Owner = "ATrzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr".ToScriptHash();

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

Neo has provided data access interface based on key-value pairs. Data records may be read or deleted from or written to the smart contracts using keys. Besides, smart contracts may retrieve and send their storage contexts to other contracts, thereby entrusting other contracts to manage their storage areas. In C# development, smart contract can use the `Storage` Class to read/write the persistent storage  The `Storage` class is a static class and does not require a constructor. The methods of `Storage` class can be viewed in this [API References](../../reference/scapi/fw/dotnet/neo/Storage.md)

For instance, if you want to store the total supply of your token into storage:

```c#
// Key is totalSupply and value is 100000000
Storage.Put(Storage.CurrentContext, "totalSupply", 100000000);
```

Here `CurrentContext` Returns the current store context. After obtaining the store context, the object can be passed as an argument to other contracts (as a way of authorization), allowing other contracts to perform read/write operations on the persistent store of the current contract.

`Storage` work well for storing primitive values and while you can use an `StorageMap`  which can be used for storing structured data, this will store the entire container in a single key in smart contract storage.

```c#
//Get the totalSupply in the storageMap. The Map is used an entire container with key name "contract"
StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
return contract.Get("totalSupply").AsBigInteger();
```

## Data type

When using C# to develop smart contracts, you cannot use the full set of C# features due to the difference between NeoVM and Dotnet IL.

Because NeoVM is more compact, we can only compile limited C# / dotnet features into an AVM file.

NeoVM provides the following basic types：

- `ByteArray`
- `Integer`
- `Boolean`
- `Array`
- `Struct`
- `Map`
- `Interface`

The basic types that can be directly generated from AVM code are only：

- `ByteArray`（Both Integer and Boolean are represented by ByteArray）
- `Array`
- `Struct`
- `Map`

The basic types of C# are:

- `Int8 int16 int32 int64 uint8 uint16 uint32 uint64`
- `float double`
- `Boolean`
- `Char String`

## Your first Neo contract

After analyzing the basic hello world contract, let us move to your first real-world smart contract. Here we provide a very simple DNS system which was written in C#. The main function of the DNS is store the domain for users. It contains all the points above except the events. We can investigate this smart contract to learn how to make a basic smart contract. The source code is here:

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.ComponentModel;

namespace Domain
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        public static object Main(string method, params object[] args)
        {
            return method switch
            {
                "query" => Query((string)args[0]),
                "register" => Register((string)args[0], (byte[])args[1]),
                "delete" => Delete((string)args[0]),
                _ => false,
            };
        }

        [DisplayName("query")]
        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        [DisplayName("register")]
        private static bool Register(string domain, byte[] owner)
        {
            // Check if the contract owner is the same as the one who invokes the contract
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        [DisplayName("delete")]
        private static bool Delete(string domain)
        {
            // To do
        }
    }
}
```

Let's slice it and learn it step by step.

## Contract Features

```c#
[Features(ContractFeatures.HasStorage)]
```

Upon the contract class we add a contract feature, which enables the contract to access the storage.

## Main method

Theoretically, smart contracts can have any entry points, but we recommend you use the main function as the entry point of smart contracts for easier invocation. In the main function, user can call other function according to the different entry point calling. Usually in the main method, developer has to handle the `trigger`.

### Trigger

A smart contract trigger is a mechanism that triggers the execution of smart contracts. There are two triggers introduced in the Neo smart contract，`Verification` and  `Application`.

### Verification trigger

A Verification trigger is used to call the contract as a verification function, which can accept multiple parameters and should return a valid Boolean value, indicating the validity of the transaction or block.

When you transfer assets from account A to account B, a verification contract is triggered. All the nodes that received the transaction (including normal nodes and blue consensus nodes) verify account A's contract. If the return value is true, the transfer is completed successfully. If false is returned, the transfer is failed.

Therefore, the verification trigger determines whether the transaction will be relayed to the rest of the network. If return `false`, that means the transaction will not be recorded in the blockchain and the transaction failed.

```c#
public static bool Main(byte[] signature)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*condition A*/)
                return true;
            else
                return false;
    }  
}
```

### Application trigger

An application trigger is used to invoke the contract as a verification function, which can accept multiple parameters, change the blockchain status, and return values of any type.

Unlike the verification trigger which is triggered by a transfer, an application trigger is triggered by a special transaction  `InvocationTransaction`. If the application (Web/App) calls a smart contract, an  `InvocationTransaction`  is constructed, and then signed and broadcast in the blockchain. An application trigger is used to invoke the contract as a verification function, which can accept multiple parameters, change the blockchain status, and return values of any type. After the  `InvocationTransaction`  transaction is confirmed, the smart contract is executed by the consensus node. The common node does not execute the smart contract when forwarding the transaction.

Since the application contract is executed after  `InvocationTransaction`  is confirmed, the transaction is recorded in the blockchain no matter the execution of the application contract is successful or not.

The success and failure of InvocationTransaction is not necessarily related to the success or failure of execution of smart contracts.

Usually in a smart contract, both verification trigger and application trigger can be caught and developer have to handle the trigger.

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*Condition A*/)
                return true;
            else
                return false;
    }  
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
    }  
}

// There is a smart contract entry point and redirected from main method
public static bool FunctionA(params object[] args)
{
    //some code  
}
```

In our `DNS smart contract`, the first function is the `main` function which is the main entry of the smart contract. The main function reads the first argument as operation and the remaining as other arguments.

```c#
public static object Main(string method, params object[] args)
{
    return method switch
    {
        "query" => Query((string)args[0]),
        "register" => Register((string)args[0], (byte[])args[1]),
        "transfer" => Transfer((string)args[0], (byte[])args[1]),
        "delete" => Delete((string)args[0]),
        _ => false,
    };
}
```

Inside the main function, we first use the Trigger to judge whether user invoke smart contract with `invocationTransaction`, which means user calls the smart contract application. Here because it is a normal smart contract without asset transfer, therefore, the only trigger need to be considered is the Application Trigger. In side of the judgment statement, the function will redirect other function depends on the operation type.

Now we can see what happened in each detailed function. The first one is the Query function, which query the owner of the domain address. Here we use the `Storage.Get`method, and the first argument is context, and here we pass the CurrentContext. The second parameter is the key of the storing key-value pair. Here we use the domain.

```c#
private static byte[] Query(string domain)
{
    return Storage.Get(Storage.CurrentContext, domain);
}
```

## CheckWitness

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

Similar to the Register method, the Delete function check the owner first and if it exists and it is the same as the one who invoke the contract, delete the pair using the `Storage.Delete`method.  This method is leaving as a question in the end of this part.

## Events

In Smart contract, events are a way  to communicate that something happened on the blockchain to your app front-end (or back-end), which can be 'listening' for certain events and take action when they happen. You might use this to update an external database, do analytics, or update a UI. In some specified contract standard,  it defined some events should be posted. It is not cover in this page, but is very useful for the other smart contracts. For instance, in the NEP-5 Token, the events `transfer` should be fired when user invoke the transfer function.

```c#
//Should be called when caller transfer nep-5 asset.
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

## Assignment

In the above `DNS` smart contract, there is a delete method. The general idea is  check the owner first and if it exists and it is the same as the one who invoke the contract, delete the pair using the `Storage.Delete`method. Please finish this function.
