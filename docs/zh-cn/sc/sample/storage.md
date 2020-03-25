# 存储区操作

## 什么是智能合约存储区

每一个被部署到 Neo 区块链上的智能合约程序，都会拥有一个只有该合约本身可以读写的私有存储区。智能合约对自己存储区中的数据拥有完全的操作权限：可以读取、写入、修改、删除。数据以键值对的形式来存放。

从存储技术上讲，存储区是 Key-Value 格式的数据库，其中 Key 可以为字符串（String）或字节数组（ByteArray），Value 可以为任意类型。详细存储区操作请参考 [Storage 类](../reference/scapi/fw/dotnet/neo/Storage.md)。但我们平时最常用的存储区操作是通过 [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md) 来进行的。它是在 Storage 的 Key 前面附加了前缀，不同的前缀相当于不同的数据库表。使用 StorageMap 能更安全地操作存储区。

智能合约的存储区操作有这些接口：

- 遍历存储区中的所有记录 `Storage.Find()`；
- 根据指定键返回特定记录 `Storage.Get()`；
- 根据指定键来修改或写入新的记录 `Storage.Put()`；
- 根据指定键来删除记录 `Storage.Delete()`；

一般，合约只能对自己存储区中的数据进行读写，但有一个例外：当发生合约相互调用的时候，被调用合约可以通过跨域请求来访问调用者的存储区，前提是调用者向其提供了授权。此外，对于在合约运行时动态创建的子合约，父合约会即时获得其存储区的读写权限。

跨域请求使得 NeoContract 可以实现更加丰富的库功能，这些库可以为调用者提供高度封装的数据管理能力。

## 声明存储区

每个合约都可以声明一块存储区，声名方式为在合约的类上添加一段自定义特性，如下：

```c#
[Features(ContractFeatures.HasStorage)]
public class NEP5 : SmartContract
{
    ……
}
```

> [!Note]
>
> 如果不声明存储区，则不能调用任何操作存储区的方法。否则合约会执行失败。

## 声明 StorageMap

如果说一个合约的存储区相当于一个数据库，那么 StorageMap 就相当于这个数据库中的表。它的原理是在 Storage 的 Key 前面附加了前缀，使用 StorageMap 能更安全地操作存储区。

声明 StorageMap 的方式如下：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
```

或

```c#
var Hash = Storage.CurrentContext.CreateMap("Hash");
```

## 操作存储区

参考 [Storage 类](../reference/scapi/fw/dotnet/neo/Storage.md) 和 [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md) 类，另外 [Helper](../../reference/scapi/fw/dotnet/neo/Helper.md) 类为 StorageMap 提供了操作存储区的扩展方法。下面为代码示例。

### 写入/修改

不使用 StorageMap

```c#
Storage.Put("hello-1", new byte[]{ 1, 2, 3});
Storage.Put("hello-2", "world");
```

使用 StorageMap

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Put("hello-1", new byte[]{ 1, 2, 3});
Hash.Put("hello-2", "world");
```

### 查询

不使用 StorageMap

```c#
Storage.Get("hello-1");
```

使用 StorageMap

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Get("hello-1");
```

### 删除

不使用 StorageMap

```c#
Storage.Delete("hello-1");
```

使用 StorageMap

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Delete("hello-1");
```

### 遍历

```c#
var result = Storage.Find("Hash");
while (result.Next())
{
    //处理 result.Key;
    //处理 result.Value;
}
```

## 区块链存证合约示例

下面以一个区块链存证合约为例，讲解如何在智能合约中使用存储区。主要用到了智能合约框架中的 [Storage](../../reference/scapi/fw/dotnet/neo/Storage.md)、[StorageMap](../../reference/scapi/fw/dotnet/neo/StorageMap.md)、[Helper](../../reference/scapi/fw/dotnet/neo/Helper.md) 等。

该合约有 4 个方法。

`bool Save(byte[] sha256)` 向存储区存储一个 Sha256 的哈西值。

`uint GetSavedBlock(byte[] sha256)` 查询某个哈西值所存储的区块高度。

`bool IsSaved(byte[] sha256)` 查询某个哈西值是否存在该区块链存证合约中。

`bool IsSavedBefore(byte[] sha256, uint blockHeight)` 查询某个哈西值是否在指定区块高度之前存储过。

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace StorageExample
{
    [Features(ContractFeatures.HasStorage)] //声明存储区
    public class Contract1 : SmartContract
    {
        [DisplayName("saved")]
        public static event Action<byte[], uint> Saved; //智能合约通知

        /// <summary>
        /// Hash:
        /// Key: hash
        /// Value: block index/height
        /// </summary>
        readonly static StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));

        public static object Main(string operation, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "save") return Save((byte[])args[0]);

                if (operation == "getSavedBlock") return GetSavedBlock((byte[])args[0]);

                if (operation == "isSaved") return IsSaved((byte[])args[0]);

                if (operation == "isSavedBefore") return IsSavedBefore((byte[])args[0], (uint)args[1]);
            }
            return true;
        }

        [DisplayName("save")]
        public static bool Save(byte[] sha256)
        {
            if (sha256.Length != 32) return false;
            if (IsSaved(sha256)) return false;

            var blockChainHeight = Blockchain.GetHeight();
            Hash.Put(sha256, blockChainHeight);
            Saved(sha256, blockChainHeight);

            return true;
        }

        [DisplayName("getSavedBlock")]
        public static uint GetSavedBlock(byte[] sha256)
        {
            if (sha256.Length != 32) throw new ArgumentException();
            if (!IsSaved(sha256)) throw new ArgumentException();
            return (uint)Hash.Get(sha256).TryToBigInteger();
        }

        [DisplayName("isSaved")]
        public static bool IsSaved(byte[] sha256)
        {
            if (sha256.Length != 32) return false;
            return Hash.Get(sha256) != null;
        }

        [DisplayName("isSavedBefore")]
        public static bool IsSavedBefore(byte[] sha256, uint blockHeight)
        {
            return GetSavedBlock(sha256) < blockHeight;
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

说明：

为什么要写 `[DisplayName("getSavedBlock")] ` 这句？

因为智能合约的方法命名应该是 Camel 规则（除了第一个单词外的其他单词的开头字母大写）而 C# 的方法命名应该是 Pascal 规则（每个单词开头的字母大写）。加上这句为了二者的兼容。 `[DisplayName("getSavedBlock")] `  这里的名称会在 manifest.json 文件中显示，应当与 main 方法中的判断跳转中的方法名一致。

为什么要用 `value?.ToBigInteger() ?? 0` 而不是直接使用 `ToBigInteger()`？

因为查询存储区时，如果查询不到，会返回 null（在 Neo2 中会返回 `new byte[0]()`），将 null 转了 BigInteger 时会抛出异常。该语句是 C# 6.0 中的新语法，参考 [Null 条件运算符](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-6#null-conditional-operators)。