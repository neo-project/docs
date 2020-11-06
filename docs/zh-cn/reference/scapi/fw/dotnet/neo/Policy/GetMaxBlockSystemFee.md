# GetMaxBlockSystemFee 方法 ()

获取区块最大的系统费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern long GetMaxBlockSystemFee();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        long result = Policy.GetMaxBlockSystemFee();
        return result;
    }
}
```

[返回上级](../Policy.md)