# Create<T, TResult>(Func<TResult>)

创建回调函数。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Callback Create<TResult>(Func<TResult> func);
```

参数：
- func: 委托方法对象，方法参数为空，返回值类型为`TResult`。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateCallback()
    {
        var callback = Callback.Create(new Func<int>(test));
        return callback.Invoke(new object[0]);
    }

    public static int test()
    {
        return 1024;
    }
}
```

响应正文：

```json
[{
    "type":"Integer",
    "value":"1024"
}]
```

响应说明：

- Integer类型：回调函数返回值`1024`。

- 其他：失败。

[返回上级](../Callback.md)