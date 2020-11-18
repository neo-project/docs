# GetGasPerBlock 方法 ()

获取当前每个区块可产生的GAS数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger GetGasPerBlock();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = NEO.GetGasPerBlock();
        return result;
    }
}
```

[返回上级](../Neo.md)