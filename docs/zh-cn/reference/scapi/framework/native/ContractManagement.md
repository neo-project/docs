# ContractManagement 类

提供了原生合约 ContractManagement 的一系列方法，合约哈希为`0xfffdc93764dbaddd97c48f252a53ea4643faa3fd`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class ContractManagement
```

## 属性

| 名称 | 说明     |
| ---- | -------- |
| Hash | 合约哈希 |

## 方法

| 名称                                                         | 说明                       |
| ------------------------------------------------------------ | -------------------------- |
| GetMinimumDeploymentFee()                                    | 查询部署合约的最低手续费   |
| [GetContract(UInt160 hash)](ContractManagement/GetContract.md) | 根据给定的合约哈希获取合约 |
| [Deploy(ByteString nefFile, string manifest)](ContractManagement/Deploy.md) | 部署合约                   |
| [Update(ByteString nefFile, string manifest)](ContractManagement/Update.md) | 更新合约                   |
| [Destroy()](ContractManagement/Destroy.md)                   | 销毁合约                   |

