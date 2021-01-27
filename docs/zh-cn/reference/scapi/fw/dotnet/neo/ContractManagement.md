# ContractManagement 类

提供了原生合约 ContractManagement 的一系列方法，合约哈希为`0xa501d7d7d10983673b61b7a2d3a813b36f9f0e43`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class ContractManagement
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Name              | 合约名称                                             |
| Hash              | 合约哈希                                             |

## 方法

| 名称                                                         | 说明                       |
| ------------------------------------------------------------ | -------------------------- |
| [GetContract(UInt160 hash)](ContractManagement/GetContract.md) | 根据给定的合约哈希获取合约 |
| [Deploy(byte\[\] nefFile, string manifest)](ContractManagement/Deploy.md) | 部署合约                   |
| [Update(byte\[\] nefFile, string manifest)](ContractManagement/Update.md) | 更新合约                   |
| [Destroy()](ContractManagement/Destroy.md)                   | 销毁合约                   |
