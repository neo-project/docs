# Create<T, TResult>(Func<T, TResult>)

创建回调函数。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Callback Create<T, TResult>(Func<T, TResult> func);
```

参数：
- func: 委托方法对象，方法参数类型为`T`，返回值类型为`TResult`。

注：当前支持的委托方法参数个数不超过16个。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateCallback2()
    {
        var callback = Callback.Create(new Func<bool, int>(test));
        return callback.Invoke(new object[] { true });
    }

    public static int test(bool flag)
    {
        if (!flag) return -1;
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