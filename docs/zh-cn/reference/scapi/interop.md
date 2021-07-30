# 互操作服务

本文列出了 Neo N3 中的互操作服务。

互操作服务是系统底层的 API。有关在高级语言中如何使用框架方便地调用 API 以及调用原生合约，请参阅 [Neo智能合约框架](framework.md)。

**合约**:

| API                                   | 说明                         |
| ------------------------------------- | ---------------------------- |
| System.Contract.Call                  | 动态调用另一个合约           |
| System.Contract.GetCallFlags          | 获取当前上下文的执行权限     |
| System.Contract.CreateStandardAccount | 从公钥转成标准账户的脚本散列 |
| System.Contract.CreateMultisigAccount | 使用公钥创建多签账户的脚本散列 |

**密码学**:

| API                         | 说明                       |
| --------------------------- | -------------------------- |
| System.Crypto.CheckSig      | 检查当前脚本容器的签名     |
| System.Crypto.CheckMultisig | 检查当前脚本容器的多方签名 |

**枚举器**:

| API                    | 说明                               |
| ---------------------- | ---------------------------------- |
| System.Iterator.Next   | 将迭代器推进到集合的下一个元素     |
| System.Iterator.Values | 获取集合中位于迭代器当前位置的元素 |

**运行时**:

| API                                   | 说明                                 |
| ------------------------------------- | ------------------------------------ |
| System.Runtime.Platform               | 获取当前平台的名称                   |
| System.Runtime.GetTrigger             | 获取执行的触发器                     |
| System.Runtime.GetTime                | 获取当前区块的时间戳                 |
| System.Runtime.GetScriptContainer     | 获取当前的脚本容器                   |
| System.Runtime.GetExecutingScriptHash | 获取当前上下文的脚本散列             |
| System.Runtime.GetCallingScriptHash   | 获取调用合约的脚本散列               |
| System.Runtime.GetEntryScriptHash     | 获取上下文入口点的脚本散列           |
| System.Runtime.CheckWitness           | 确定指定账户是否见证了当前交易       |
| System.Runtime.GetInvocationCounter   | 获取当前合约在执行过程中被调用的次数 |
| System.Runtime.Log                    | 写日志                               |
| System.Runtime.GetNotifications       | 获取指定合约在执行过程中发送的通知   |
| System.Runtime.GasLeft                | 获取为了完成执行可以花费的剩余GAS    |
| System.Runtime.BurnGas                | 燃烧 GAS，造福 Neo 生态          |
| System.Runtime.GetNetwork                | 获取当前网络 number         |
| System.Runtime.GetRandom                | 获取随机数         |

**存储**:

| API                               | 说明                                           |
| --------------------------------- | ---------------------------------------------- |
| System.Storage.GetContext         | 获取当前合约的存储上下文                       |
| System.Storage.GetReadOnlyContext | 获取当前合约的只读存储上下文                   |
| System.StorageContext.AsReadOnly  | 将指定的存储上下文转换为一个新的只读存储上下文 |
| System.Storage.Get                | 从存储中获取具有指定键的记录                   |
| System.Storage.Find               | 从存储中查找记录                               |
| System.Storage.Put                | 将一个新的记录放入存储中                       |
| System.Storage.Delete             | 从存储中删除一个记录                           |

