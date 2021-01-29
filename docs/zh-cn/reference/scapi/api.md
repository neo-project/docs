# 智能合约 API 参考

NeoContract 的 API 扩展了智能合约的功能，使其可以访问区块链账本数据、操作持久化存储区、访问执行环境等。它是NEO虚拟机（NeoVM）互操作服务层的一部分。

有关在高级语言中如何使用框架方便地调用 API，请参阅 [NEO智能合约框架](fw.md)。

**Binary API**:

| API                        | 说明                               |
| -------------------------- | ---------------------------------- |
| System.Binary.Base64Decode | 将Base64编码的字符串解码为字节数组 |
| System.Binary.Base64Encode | 将字节数组编码为Base64字符串       |
| System.Binary.Serialize    | 将栈元素序列化为字节数组           |
| System.Binary.Deserialize  | 将字节数组反序列化为栈元素         |
| System.Binary.Base58Decode | 将Base58编码的字符串解码为字节数组 |
| System.Binary.Base58Encode | 将字节数组编码为Base58字符串       |
| System.Binary.Itoa         | 把整数转换为字符串                 |
| System.Binary.Atoi         | 把字符串转换成整型数               |

**Contract API**:

| API                                   | 说明                               |
| ------------------------------------- | ---------------------------------- |
| System.Contract.Call                  | 调用合约                           |
| System.Contract.CallNative            | 调用原生合约                       |
| System.Contract.IsStandard            | 判断合约是否为标准的单签或多签合约 |
| System.Contract.GetCallFlags          | 获取当前上下文的执行权限           |
| System.Contract.CreateStandardAccount | 创建标准账户                       |
| System.Contract.NativeOnPersist       | 触发原生合约 OnPersist 方法        |
| System.Contract.NativePostPersist     | 触发原生合约 PostPersist 方法      |

**Crypto API**:

| API                                        | 说明                        |
| ------------------------------------------ | --------------------------- |
| Neo.Crypto.RIPEMD160                       | 计算栈元素的RIPEMD160哈希值 |
| Neo.Crypto.SHA256                          | 计算栈元素的Sha256哈希值    |
| Neo.Crypto.VerifyWithECDsaSecp256r1        | 使用Secp256r1曲线验证单签   |
| Neo.Crypto.VerifyWithECDsaSecp256k1        | 使用Secp256k1曲线验证单签   |
| Neo.Crypto.CheckMultisigWithECDsaSecp256r1 | 使用Secp256r1曲线验证多签   |
| Neo.Crypto.CheckMultisigWithECDsaSecp256k1 | 使用Secp256k1曲线验证多签   |

**Iterator API**:

| API                    | 说明                        |
| ---------------------- | --------------------------- |
| System.Iterator.Create | 创建迭代器                  |
| System.Iterator.Next   | 迭代器流标向后移动          |
| System.Iterator.Values | 获取迭代器所有Value的迭代器 |

**Json API**:

| API                     | 说明                       |
| ----------------------- | -------------------------- |
| System.Json.Serialize   | 将栈元素序列化为字节数组   |
| System.Json.Deserialize | 将Json对象反序列化为栈元素 |

**Runtime API**:

| API                                   | 说明                                                 |
| ------------------------------------- | ---------------------------------------------------- |
| System.Runtime.Platform               | 获取当前执行智能合约的平台信息                       |
| System.Runtime.GetTrigger             | 获取该智能合约的触发条件                             |
| System.Runtime.GetTime                | 获取当前区块的时间戳                                 |
| System.Runtime.GetScriptContainer     | 获得该智能合约的脚本容器（最开始的触发者）           |
| System.Runtime.GetExecutingScriptHash | 获得该智能合约执行的脚本散列                         |
| System.Runtime.GetCallingScriptHash   | 获得该智能合约的调用者的脚本散列                     |
| System.Runtime.GetEntryScriptHash     | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |
| System.Runtime.CheckWitness           | 验证调用该合约的容器是否被指定账户脚本哈希签名       |
| System.Runtime.GetInvocationCounter   | 获取当前合约的调用次数                               |
| System.Runtime.Log                    | 记录合约日志信息                                     |
| System.Runtime.Notify                 | 记录合约通知信息                                     |
| System.Runtime.GetNotifications       | 获取某合约执行的所有通知                             |
| System.Runtime.GasLeft                | 获取剩余未消耗的GAS数                                |

**Storage API**:

| API                               | 说明                                      |
| --------------------------------- | ----------------------------------------- |
| System.Storage.GetContext         | 获取当前合约存储区的上下文                |
| System.Storage.GetReadOnlyContext | 以只读方式获取当前合约存储区的上下文      |
| System.StorageContext.AsReadOnly  | 将当前上下文修改为只读模式                |
| System.Storage.Get                | 根据Key值，从存储区获取对应的Value        |
| System.Storage.Find               | 在当前存储上下文中存储区寻找指定前缀内容  |
| System.Storage.Put                | 根据存储上下文，向存储区写入Key           |
| System.Storage.PutEx              | 根据存储上下文，依据flag，向存储区写入Key |
| System.Storage.Delete             | 根据Key值，从存储区删除存储的Key          |

> [!Note]
>
> 以上 API 的源码位于 Neo 项目中的 [src\neo\SmartContract\](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract) 下。
