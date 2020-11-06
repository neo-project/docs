# SetGasPerBlock 方法 (BigInteger)

设置每出一个区块所产生的GAS数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool SetGasPerBlock(BigInteger gasPerBlock);
```

参数：

- gasPerBlock: 每区块所产生的GAS数

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger gasPerBlock  = 10;
        bool result = NEO.SetGasPerBlock(gasPerBlock);
        return result;
    }
}
```

[返回上级](../Neo.md)