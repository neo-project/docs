# Storage.CurrentContext 属性

获取当前存储区上下文。获得该存储区上下文后，可以将该对象作为实参传给其它合约（即完成授权），由其它合约来执行对该合约上下文的存储区的读写操作。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern StorageContext CurrentContext { get; }
```

属性值：当前存储区上下文，[StorageContext](../StorageContext.md) 类型。



[返回上级](../Storage.md)
