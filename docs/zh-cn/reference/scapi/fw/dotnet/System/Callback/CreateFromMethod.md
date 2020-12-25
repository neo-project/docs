# CreateFromMethod(UInt160, string)

创建指定合约指定方法的回调函数。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Callback CreateFromMethod(UInt160 hash, string method);
```

参数：
- hash: 合约哈希；
- method：合约方法名

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateFromMethod()
    {
        return Callback.CreateFromMethod(NEO.Hash, "totalSupply").Invoke(new object[0]);
    }
}
```

响应正文：

```json
[{
    "type":"Integer",
    "value":"100000000"
}]
```

响应说明：

- Integer类型：NEO的总供应量`100000000`。

- 其他：失败。

[返回上级](../Callback.md)