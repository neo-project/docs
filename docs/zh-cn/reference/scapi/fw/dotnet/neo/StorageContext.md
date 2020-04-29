# StorageContext 类

用来表示私有存储区存储上下文的类。

在智能合约中可以通过 Storage.CurrentContext 获得自己的存储区上下文，之后可以将该对象作为实参传给其它合约（即完成授权），由其它合约来执行对该合约上下文的存储区的读写操作。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class StorageContext
```

## 属性

| 名称                                       | 说明         |
| ---------------------------------------- | ---------- |
| AsReadOnly | 以只读方式获取当前存储上下文 |

## 构造方法

通过 [Storage.CurrentContext](Storage/CurrentContext.md) 属性来构造 StorageContext 对象。
