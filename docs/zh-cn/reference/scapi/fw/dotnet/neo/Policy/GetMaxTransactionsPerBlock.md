# GetMaxTransactionsPerBlock 方法 ()

获取每区块最大交易数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern uint GetMaxTransactionsPerBlock();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        uint result = Policy.GetMaxTransactionsPerBlock();
        return result;
    }
}
```

[返回上级](../Policy.md)