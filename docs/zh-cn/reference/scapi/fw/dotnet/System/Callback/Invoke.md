# Invoke(object)

调用回调函数。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern object Invoke(object[] args);
```

参数：
- args:回调函数的参数

返回值：回调函数的返回值。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Invoke()
    {
        var callback = Callback.Create(new Func<int, int, int>(test));
        return callback.Invoke(new object[] { 1, 2 });
    }

    public static int test(int a, int b)
    {
        return a + b;
    }
}
```

响应正文：

```json
[{
    "type":"Integer",
    "value":"3"
}]
```

响应说明：

- Integer类型：回调函数的返回值`3`。

- 其他：失败。

[返回上级](../Callback.md)