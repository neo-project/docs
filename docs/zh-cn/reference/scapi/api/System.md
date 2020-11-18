# System 命名空间

互操作服务层提供了智能合约所能访问区块链数据的一些 API，利用这些 API，可以访问区块信息、交易信息、合约信息、资产信息等。除此之外互操作服务层还为每个合约提供了一个持久化存储区的功能。

**Binary API**:

| API                           | 说明                              |
|--|--|
| System.Binary.Base64Decode| 将Base64编码的字符串解码为字节数组     |
| System.Binary.Base64Encode | 将字节数组编码为Base64字符串            |
| System.Binary.Serialize| 将栈元素序列化为字节数组     |
| System.Binary.Deserialize | 将字节数组反序列化为栈元素            |
| System.Binary.Base58Decode | 将Base58编码的字符串解码为字节数组            |
| System.Binary.Base58Encode| 将字节数组编码为Base58字符串     |

**BlockChain API**:

| API                           | 说明                              |
|--|--|
| System.Blockchain.GetHeight | 获取当前区块的高度           |
| System.Blockchain.GetBlock | 根据区块哈希或者区块高度获取区块 |
| System.Blockchain.GetTransaction | 根据交易ID获取交易 |
|System.Blockchain.GetTransactionHeight|根据交易ID获取交易所在的区块高度|
|System.Blockchain.GetTransactionFromBlock|根据区块中交易ID获取交易|
|System.Blockchain.GetContract|根据合约哈希获取合约|

**Callback API**:

| API                           | 说明                              |
|--|--|
|System.Callback.Create|根据栈指针创建回调服务|
|System.Callback.CreateFromMethod|创建指定合约指定方法的回调服务|
|System.Callback.CreateFromSyscall|创建系统调用的回调服务|
|System.Callback.Invoke|调用回调方法|

**Contract API**:

| API                           | 说明                              |
|--|--|
|System.Contract.Create|部署合约|
|System.Contract.Update|升级合约|
|System.Contract.Destroy|销毁当前合约|
|System.Contract.Call|调用合约|
|System.Contract.CallEx|根据Flag调用合约|
|System.Contract.IsStandard|判断合约是否为标准的单签或多签合约|
|System.Contract.GetCallFlags|获取当前上下文的执行权限|

**Crypto API**:

| API                           | 说明                              |
|--|--|
|System.Crypto.RIPEMD160|计算栈元素的RIPEMD160哈希值|
|System.Crypto.SHA256|计算栈元素的Sha256哈希值|
|System.Crypto.VerifyWithECDsaSecp256r1|使用Secp256r1曲线验证单签|
|System.Crypto.VerifyWithECDsaSecp256k1|使用Secp256k1曲线验证单签|
|System.Crypto.CheckMultisigWithECDsaSecp256r1|使用Secp256r1曲线验证多签|
|System.Crypto.CheckMultisigWithECDsaSecp256k1|使用Secp256k1曲线验证多签|

**Enumerator API**:

| API                           | 说明                              |
|--|--|
|System.Enumerator.Create|创建枚举器|
|System.Enumerator.Next|检查枚举器是否有下一个元素|
|System.Enumerator.Value|获取枚举器当前元素|
|System.Enumerator.Concat|合并枚举器|

**Iterator API**:

| API                           | 说明                              |
|--|--|
|System.Iterator.Create|创建迭代器|
|System.Iterator.Key|获取迭代器当前Key值|
|System.Iterator.Keys|获取迭代器所有Key的迭代器|
|System.Iterator.Values|获取迭代器所有Value的迭代器|
|System.Iterator.Concat|合并迭代器|

**Json API**:

| API                           | 说明                              |
|--|--|
|System.Json.Serialize|将栈元素序列化为字节数组|
|System.Json.Deserialize|将Json对象反序列化为栈元素|

**Runtime API**:

| API                           | 说明                              |
|--|--|
|System.Runtime.Platform|获取当前执行智能合约的平台信息|
|System.Runtime.GetTrigger|获取该智能合约的触发条件|
|System.Runtime.GetTime|获取当前区块的时间戳|
|System.Runtime.GetScriptContainer|获得该智能合约的脚本容器（最开始的触发者）|
|System.Runtime.GetExecutingScriptHash|获得该智能合约执行的脚本散列|
|System.Runtime.GetCallingScriptHash|获得该智能合约的调用者的脚本散列|
|System.Runtime.GetEntryScriptHash|获得该智能合约的入口点（合约调用链的起点）的脚本散列|
|System.Runtime.CheckWitness|验证调用该合约的容器是否被指定账户脚本哈希签名|
|System.Runtime.GetInvocationCounter|获取当前合约的调用次数|
|System.Runtime.Log|记录合约日志信息|
|System.Runtime.Notify|记录合约通知信息|
|System.Runtime.GetNotifications|获取某合约执行的所有通知|
|System.Runtime.GasLeft|获取剩余未消耗的GAS数|

**Storage API**:

| API                           | 说明                              |
|--|--|
|System.Storage.GetContext|获取当前合约存储区的上下文|
|System.Storage.GetReadOnlyContext|以只读方式获取当前合约存储区的上下文|
|System.StorageContext.AsReadOnly|将当前上下文修改为只读模式|
|System.Storage.Get|根据Key值，从存储区获取对应的Value|
|System.Storage.Find|在当前存储上下文中存储区寻找指定前缀内容|
|System.Storage.Put|根据存储上下文，向存储区写入Key|
|System.Storage.PutEx|根据存储上下文，依据flag，向存储区写入Key|
|System.Storage.Delete|根据Key值，从存储区删除存储的Key|

> [!Note]
>
> 以上 API 的源码位于 Neo 项目中的 [src\neo\SmartContract\](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract) 下。
