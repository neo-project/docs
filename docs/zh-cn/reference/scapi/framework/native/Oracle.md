# Oracle 类

提供了原生合约Oracle的一系列方法，合约哈希为 `0xfe924b7cfe89ddd271abaf7210a80a7e11178758`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Oracle
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Hash              | 合约哈希                                            |

## 方法

| 名称                                                         | 说明                     |
| ------------------------------------------------------------ | ------------------------ |
| GetPrice()                                                   | 获取一个Oracle请求的价格 |
| [Request(string url, string filter, string callback, object userData, long gasForResponse)](Oracle/Request.md) | 发起Oracle请求           |