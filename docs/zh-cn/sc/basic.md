# 名词解释

### 脚本（Script）

智能合约脚本就是智能合约的执行代码，所有的脚本都在 NeoVM 中执行。脚本由操作码（OpCode）操作数（Operand）构成。操作码与汇编语言中的指令类似，某些操作码不需要操作数，某些操作码需要一个或多个操作数。下文的系统调用也是一种特殊的操作码。

### 脚本散列（Script Hash）

顾名思义，脚本散列就是智能合约脚本的散列（Hash），脚本散列是合约的唯一标识，每段脚本都有唯一的脚本散列，合约中任何脚本的修改都会导致脚本散列的不同。脚本散列长度为 20 字节（160 位）。脚本散列由脚本单向生成，不能反推出脚本。脚本散列和地址可以互相转换。

### OpCode

操作码。全部 OpCode 请参考 [OpCode 源码](https://github.com/neo-project/neo-vm/blob/master/src/neo-vm/OpCode.cs)。

### 系统调用（SysCall）

系统调用是一种特殊的操作码。通过 SycCall 可以调用互操作服务层接口。 SycCall 打通了 NeoVM 与外部世界的通道。通过调用互操作服务层接口， NeoVM 可以访问智能合约执行时所需要的区块信息、交易信息、合约信息、资产信息等数据。

请参考 [Neo 智能合约模块](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract) 中里面以 `InteropService.` 开头的文件，如 `InteropService.Binary.cs`、`InteropService.Blockchain.cs`

### 动态调用

动态调用是一种特殊的系统调用，它的功能是调用另一个合约。写法为 `Contract.Call(scriptHash, method, params)`。详见智能合约调用一节。

### 存储区

每个合约都可以声明一块存储区，声名方式为在合约的类上添加一段自定义特性，如下：

```c#
[Features(ContractFeatures.HasStorage)]
public class NEP5 : SmartContract
{
    ……
}
```

存储区是 Key-Value 格式的数据库，其中 Key 可以为字符串（String）或字节数组（ByteArray），Value 可以为任意类型。详细存储区操作请参考 [Storage 类](../reference/scapi/fw/dotnet/neo/Storage.md)。但我们平时最常用的存储区操作是通过 [StorageMap](../reference/scapi/fw/dotnet/neo/StorageMap.md) 来进行的。它是在 Storage 的 Key 前面附加了前缀，不同的前缀相当于不同的数据库表。使用 StorageMap 能更安全地操作存储区。示例代码如下：

```c#
StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
contract.Put("totalSupply", TotalSupplyValue);
contract.Put("invokeTimes", invokeTimesValue);

StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
asset.Put(Owner, Amount);
```

### NEF

NEF 全称 Neo Executable Format（Neo 可执行格式）。

智能合约编译器会将源码编译，最终生成 NEF 文件和 Manifest 文件（见下方）。

当部署合约时，需要提供 NEF 文件。NEF 其中规定了以下字段。

| Field      | Length    | Comment                                         |
| ---------- | --------- | ----------------------------------------------- |
| Magic      | 4 bytes   | Magic header                                    |
| Compiler   | 32 bytes  | Compiler used                                   |
| Version    | 16 bytes  | Compiler version (Mayor, Minor, Build, Version) |
| ScriptHash | 20 bytes  | ScriptHash for the script                       |
| Checksum   | 4 bytes   | Sha256 of the header (CRC)                      |
| Script     | Var bytes | Var bytes for the payload                       |
