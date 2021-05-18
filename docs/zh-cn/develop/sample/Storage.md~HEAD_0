# 存储区操作

## 什么是合约存储区？

每个被部署到 Neo 区块链上的智能合约程序，都拥有一个只有该合约本身可以读写、修改和删除数据的私有存储区。数据以键值对（Key-Value）的形式存放，其中 Key 可以为字符串（String）或字节数组（ByteArray），Value 可以为任意类型。详细存储区操作请参考 [Storage 类](../reference/scapi/fw/dotnet/neo/Storage.md)。

在Neo中，常用的存储区操作是通过 [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md) 来进行的。它在 Storage 的 Key 前面附加了前缀，不同的前缀相当于不同的数据库表。使用 StorageMap 能更安全地操作存储区。

智能合约的存储区操作包含以下接口：

- `Storage.Find()`：遍历存储区中的所有记录
- `Storage.Get()`：根据指定键返回特定记录
- `Storage.Put()`：根据指定键来修改或写入新的记录
- `Storage.Delete()`：根据指定键来删除记录

通常合约只能对自己存储区中的数据进行读写，但也有例外：

- 当合约相互调用的时候，被调用合约可以通过跨域请求来访问调用者的存储区，前提是调用者向其提供了授权。
- 对于在合约运行时动态创建的子合约，父合约会即时获得其存储区的读写权限。

跨域请求使得 NeoContract 可以实现更加丰富的库功能，这些库可以为调用者提供高度封装的数据管理能力。

## 声明 StorageMap

如果说一个合约的存储区相当于一个数据库，那么 StorageMap 就相当于这个数据库中的表。

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

不使用 StorageMap：

```c#
Storage.Put("hello-1", new byte[]{ 1, 2, 3});
Storage.Put("hello-2", "world");
```

使用 StorageMap：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Put("hello-1", new byte[]{ 1, 2, 3});
Hash.Put("hello-2", "world");
```

### 查询

不使用 StorageMap：

```c#
Storage.Get("hello-1");
```

使用 StorageMap：

```c#
StorageMap Hash = Storage.CurrentContext.CreateMap(nameof(Hash));
Hash.Get("hello-1");
```

### 删除

不使用 StorageMap：

```c#
Storage.Delete("hello-1");
```

使用 StorageMap：

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

以下是一个简单的区块链存证合约示例，其中主要用到了智能合约框架中的 [Storage](../../reference/scapi/fw/dotnet/neo/Storage.md)、[StorageMap](../../reference/scapi/fw/dotnet/neo/StorageMap.md)、[Helper](../../reference/scapi/fw/dotnet/neo/Helper.md) 等。

### 编写合约

该合约存储区的结构为：

- key: 消息，string 类型；

- value：区块高度，unit 类型


该合约包含 3 个方法：

- `put` ：向存储区写入消息。
- `get`： 从存储区读取消息。
- `exists` ：查询存储区是否存在消息。

代码如下：

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
    public class Contract1 : SmartContract
    {
        [DisplayName("saved")]
        public static event Action<string, uint> Saved;

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (method == "put") return Put((string)args[0]);
                if (method == "get") return Get((string)args[0]);
                if (method == "exists") return Exists((string)args[0]);
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
            return (int)Storage.Get(message).ToBigInteger();
        }

        [DisplayName("exists")]
        public static bool Exists(string message)
        {
            return Storage.Get(message) != null;
        }
    }
}
```

关于`[DisplayName("getSavedBlock")] ` ：

该语句用于兼容智能合约的方法命名规则（Camel）和C#的方法命名规则（Pascal）。

`[DisplayName("getSavedBlock")] `  中的名称会在 manifest.json 文件中显示，应当与 main 方法中的判断跳转中的方法名一致。

> [!Note]
>
> - 在智能合约中，Main 方法中的switch 语句中 case 的数量不能超过 7 个，否则调用时会报错（可编译通过）。如果 case 数量超过 7 个，建议改为 if 语句。
> - 如果使用 StorageMap，则 StorageMap 的声明必须在方法内（局部变量），不能写在方法外（全局变量），否则调用时会报错（可编译通过）。

### 调用合约

在 Neo-CLI 中通过命令行调用上述合约，调用过程如下：

```
invoke 0x1954ff05763b01b3a8fa48f630729cd35292743e exists abcd
```

```
Invoking script with: '046162636451c106657869737473673e749252d39c7230f648faa8b3013b7605ff5419'
VM State: HALT
Gas Consumed: 0.191
Evaluation Stack: [{"type":"Boolean","value":false}]

relay tx(no|yes): no
```

```
invoke 0x1954ff05763b01b3a8fa48f630729cd35292743e put abcd
```

```
Invoking script with: '046162636451c103707574673e749252d39c7230f648faa8b3013b7605ff5419'
VM State: HALT
Gas Consumed: 1.215
Evaluation Stack: [{"type":"Integer","value":"1"}]

relay tx(no|yes): yes
```

```
invoke 0x1954ff05763b01b3a8fa48f630729cd35292743e get abcd
```

```
Invoking script with: '046162636451c103676574673e749252d39c7230f648faa8b3013b7605ff5419'
VM State: HALT
Gas Consumed: 0.312
Evaluation Stack: [{"type":"Integer","value":"8024"}]

relay tx(no|yes): no
```

