# ManagementContract 类

提供了原生合约ManagementContract的一系列方法，合约哈希为`0xcd97b70d82d69adfcd9165374109419fade8d6ab`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class ManagementContract
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Name              | 合约名称                                             |
| Hash              | 合约哈希                                             |

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetContract(UInt160 hash)](ManagementContract/GetContract.md)          | 根据给定的合约哈希获取合约                                     |
| [Deploy(byte\[\] nefFile, string manifest)](ManagementContract/Deploy.md)          | 部署合约                                     |
| [Update(byte\[\] nefFile, string manifest)](ManagementContract/Update.md)          | 更新合约                                     |
| [Destroy()](ManagementContract/Destroy.md)          | 销毁合约                                     |
