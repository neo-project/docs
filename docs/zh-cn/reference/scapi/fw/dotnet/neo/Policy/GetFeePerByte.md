# GetFeePerByte 方法 ()

获取每字节手续费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger GetFeePerByte();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = Policy.GetFeePerByte();
        return result;
    }
}
```

[返回上级](../Policy.md)