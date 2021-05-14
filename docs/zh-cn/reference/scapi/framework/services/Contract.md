# Contract 类

表示合约的类。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Contract
```

## 属性

| 名称       | 说明                             |
| ---------- | -------------------------------- |
| Id     | 合约Id，原生合约的ID为负整数，普通合约的ID为正整数 |
| UpdateCounter | 合约更新次数计数             |
| Hash  | 合约哈希，合约哈希由部署人的脚本散列、合约NEF校验码、合约名称共同决定 |
| Nef | Nef |
| Manifest  | 合约Manifest的Json字符串表示  |

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| [Call(UInt160 scriptHash, string method, object[] arguments)](Contract/Call.md) | 调用智能合约    |
| [GetCallFlags()](Contract/GetCallFlags.md)         | 获取原生合约的调用权限 Flag |
| [CreateStandardAccount()](Contract/CreateStandardAccount.md)         | 根据公钥创建标准账户的脚本散列 |
| CreateMultisigAccount(int, params Cryptography.ECC.ECPoint[]) | 根据公钥列表和最小签名数，生成多方签名账户的脚本散列 |

## 构造方法

通过 [ContractManagement.GetContract(UInt60 hash)](../native/ContractManagement/GetContract.md) 方法来构造 Contract 对象。

通过 [ContractManagement.Deploy(byte[] nefFile, string manifest)](../native/ContractManagement/Deploy.md) 方法来部署合约，并返回 Contract 对象。

