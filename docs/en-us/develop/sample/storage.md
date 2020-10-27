# Smart Contract Storage

## What is a smart contract storage？

Each smart contract deployed on the Neo blockchain owns a private storage where only the contract itself can read, write, modify, and delete data. Data in the storage is stored in the form of key-value pairs, where Key can be a string or a byte array (ByteArray) and Value can be any type. For more information refer to [Storage Class](../reference/scapi/fw/dotnet/neo/Storage.md).

In Neo, most storage operations are performed through [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md), which appends a prefix to the Storage Key. Different prefixes are equivalent to different database tables. Using StorageMap to operate the storage is more safely.

Smart contract storage operations include the following interfaces:

- `Storage.Find()`：traverses all records in the storage
- `Storage.Get()`：returns a specific record according to the specified key
- `Storage.Put()`：modifies or writes a new record according to the specified key
- `Storage.Delete()`：deletes the record according to the specified key

Usually the contract can only read and write data in its own storage, but there are exceptions: 

- In the case that contracts invokes each other, the invoked contract can access the caller's storage via cross-domain requests if it has been authorized by the caller. 
- For the child contract that is dynamically created at contract runtime, the parent contract gets the read-write access to the child contract's storage immediately.

## Declaring storage

You need to declare a storage in your contract for invoking the storage related methods, otherwise the contract execution will fail. To declare the storage, add a custom feature to the contract class. 

```c#
[Features(ContractFeatures.HasStorage)]
public class NEP5 : SmartContract
{
    ……
}
```

## Declaring StorageMap

If the storage of a contract is equivalent to a database, then StorageMap is equivalent to the tables in that database.

To declare StorageMap:

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
```

or

```c#
var Hash = Storage.CurrentContext.CreateMap("Hash");
```

## Storage operations

Refer to the [Storage](../reference/scapi/fw/dotnet/neo/Storage.md) and [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md) classes. The class [Helper](../../reference/scapi/fw/dotnet/neo/Helper.md) provides StorageMap with extended methods for storage operations. Here are some code examples.

### Write and modify

Without StorageMap：

```c#
Storage.Put("hello-1", new byte[]{ 1, 2, 3});
Storage.Put("hello-2", "world");
```

With StorageMap：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Put("hello-1", new byte[]{ 1, 2, 3});
Hash.Put("hello-2", "world");
```

### Query

Without StorageMap：

```c#
Storage.Get("hello-1");
```

With StorageMap：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Get("hello-1");
```

### Delete

Without StorageMap：

```c#
Storage.Delete("hello-1");
```

With StorageMap：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Delete("hello-1");
```

### Traverse

```c#
var result = Storage.Find("Hash");
while (result.Next())
{
    //process result.Key;
    //process result.Value;
}
```

## Demo: a blockchain storage contract

This section we are going to write a simple blockchain storage contract using the Neo smart contract APIs such as [Storage](../../reference/scapi/fw/dotnet/neo/Storage.md), [StorageMap](../../reference/scapi/fw/dotnet/neo/StorageMap.md), [Helper](../../reference/scapi/fw/dotnet/neo/Helper.md), and etc, and invoke it on the blockchain.

### Writing the contract

This contract has a storage in the following structure:

- key: message as string type；

- value: block height as unit type


This contract contains these methods:

- `put` : Puts the message into the storage
- `get`: Gets the message from the storage
- `exists` : Checks if there is message in the storage

Here is the code：

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace StorageExample
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        [DisplayName("saved")]
        public static event Action<string, uint> Saved;

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Application)
            {
                return method switch
                {
                    "put" => Put((string)args[0]),
                    "get" => Get((string)args[0]),
                    "exists" => Exists((string)args[0]),
                    _ => true
                };
            }
            return true;
        }

        [DisplayName("put")]
        public static bool Put(string message)
        {
            if (Exists(message)) return false;
            var blockChainHeight = Blockchain.GetHeight();
            Storage.Put(message, blockChainHeight);
            Saved(message, blockChainHeight);

            return true;
        }

        [DisplayName("get")]
        public static int Get(string message)
        {
            if (!Exists(message)) return -1;
            return (int)Storage.Get(message).TryToBigInteger();
        }

        [DisplayName("exists")]
        public static bool Exists(string message)
        {
            return Storage.Get(message) != null;
        }

    }

    public static class Helper
    {
        public static BigInteger TryToBigInteger(this byte[] value)
        {
            return value?.ToBigInteger() ?? 0;
        }
    }
}
```

Where：

-  `[DisplayName("getSavedBlock")] ` is for compatibility with the method naming rules of smart contracts (Camel) and C # method naming rules (Pascal).

  The name in `[DisplayName("getSavedBlock")] ` can be found in the manifest.json file. It should be the same as the method name that determines a go-to in the main method.

-  `value?.ToBigInteger() ?? 0` is a new statement in C#6.0 (refer to [Null Conditional Operators](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-6#null-conditional-operators)).

  Since null is returned when the storage can not be reached and an exception is thrown when null is converted to BigInteger, here we didn't use `ToBigInteger()`.

> [!Note]
>
> - In a smart contract, the number of cases in the Main() switch statement must not exceed 7, otherwise an error will be reported when the contract is invoked even it can be compiled through. In that case the if statement is recommended.
> - If you use StorageMap, you must declare StorageMap inside the method as a local variable, otherwise an error will be reported when the contract is invoked even it can be compiled through.

### Invoking the contract

In Neo-CLI command line invoke the contract, as follows:

```
invoke 0x5433e7621059814619390b6eb11cb3ebee07da39 exists abcd
```

```
Invoking script with: '0c046162636411c00c066578697374730c1439da07eeebb31cb16e0b39194681591062e7335441627d5b52'
VM State: HALT
Gas Consumed: 0.0230502
Evaluation Stack: [{"type":"Boolean","value":false}]

relay tx(no|yes): no
```

```
invoke 0x5433e7621059814619390b6eb11cb3ebee07da39 put abcd
```

```
Invoking script with: '0c046162636411c00c037075740c1439da07eeebb31cb16e0b39194681591062e7335441627d5b52'
VM State: HALT
Gas Consumed: 0.0393573
Evaluation Stack: [{"type":"Integer","value":"1"}]

relay tx(no|yes): yes
```

```
invoke 0x5433e7621059814619390b6eb11cb3ebee07da39 get abcd
```

```
Invoking script with: '0c046162636411c00c036765740c1439da07eeebb31cb16e0b39194681591062e7335441627d5b52'
VM State: HALT
Gas Consumed: 0.0335185
Evaluation Stack: [{"type":"Integer","value":"3219"}]

relay tx(no|yes): no
```



