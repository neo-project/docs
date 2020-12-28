# Contract 类

表示合约的类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Contract
```

## 属性

| 名称       | 说明                             |
| ---------- | -------------------------------- |
| Id     | 合约Id             |
| UpdateCounter | 合约更新次数计数             |
| Hash  | 合约哈希  |
| Script  | 合约脚本数组  |
| Manifest  | 合约Manifest的Json字符串表示  |

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| [Call(UInt160 scriptHash, string method, object\[\] arguments)](Contract/Call.md) | 调用智能合约    |
| [CallEx(UInt160 scriptHash, string method, object\[\] arguments, CallFlags flag)](Contract/CallEx.md) | 根据调用权限 Flag 调用合约    |
| [GetCallFlags()](Contract/GetCallFlags.md)         | 获取合约的调用权限 Flag |
| [CreateStandardAccount()](Contract/CreateStandardAccount.md)         | 根据公钥创建标准账户 |

## 构造方法

通过 [Blockchain.GetContract(UInt60 hash)](ManagementContract/GetContract.md) 方法来构造 Contract 对象。

通过 [Deploy(byte\[\] nefFile, string manifest)](ManagementContract/Deploy.md) 方法来部署合约，并返回 Contract 对象。
