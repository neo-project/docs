# Callback 类

提供回调相关的方法。

命名空间：[Neo.SmartContract.Framework.Services.System](../System.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Callback
```

## 属性

| 名称                                                         | 说明                                                 |
| ------------------------------------------------------------ | ---------------------------------------------------- |
| [Invoke(object\[\])](Callback/Invoke.md)    | 调用回调函数                     |
| [Create(Func<TResult>)](Callback/Create2.md)        | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |
| [Create(Func<T, TResult>)](Callback/Create.md) | 获得该智能合约执行的脚本散列                         |
| [CreateFromMethod(UInt160, string)](Callback/CreateFromMethod.md) | 获得该智能合约执行的脚本散列                         |
| [CreateFromSyscall(SyscallCallback)](Callback/CreateFromSyscall.md) | 获得该智能合约执行的脚本散列                         |