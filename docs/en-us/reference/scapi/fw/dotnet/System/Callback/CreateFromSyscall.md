# CreateFromSyscall(SyscallCallback)

创建系统调用的回调函数。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Callback CreateFromSyscall(SyscallCallback method);
```

参数：
- method: 回调函数类型

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateFromSyscall()
    {
        return Callback.CreateFromSyscall(SyscallCallback.System_Binary_Itoa).Invoke(new object[2] { -1, 16});
    }
}
```

响应正文：

```json
[{
    "type":"ByteString",
    "value":"Zg=="
}]
```

响应说明：

- ByteString类型：回调函数返回值。

- 其他：失败。

[返回上级](../Callback.md)