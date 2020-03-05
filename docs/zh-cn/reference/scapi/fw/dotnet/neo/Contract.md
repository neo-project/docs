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
| Script     | 获得该合约的脚本哈希             |
| HasStorage | 该合约是否包含存储区             |
| IsPayable  | 该合约是否可以收款<sup>[1]</sup> |

[1] 标准的 NEP-5 资产应该在 transfer 方法中判断收款地址的 IsPayable 功能，以确定能否转账。参见 [NEP-5 transfer 方法]( https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki#transfer )

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| [Call(byte\[\] scriptHash, string method, object\[\] arguments)](Contract/Call.md) | 调用智能合约    |
| [CallEx(byte\[\] scriptHash, string method, object\[\] arguments, CallFlags flag)](Contract/CallEx.md) | 根据flag调用合约    |
| [Create(byte\[\] script, string manifest)](Contract/Create.md)      | 新建智能合约 |
| [Update(byte\[\] script, string manifest)](Contract/Update.md)       | 更新智能合约 |
| [Destroy()](Contract/Destroy.md)         | 销毁智能合约 |

## 构造方法

通过 [Blockchain.GetContract(byte\[\] script_hash)](Blockchain/GetContract.md) 方法来构造 Contract 对象。

通过 [Create(byte\[\] script, string manifest)](Contract/Create.md) 方法来部署合约，并返回 Contract 对象。
