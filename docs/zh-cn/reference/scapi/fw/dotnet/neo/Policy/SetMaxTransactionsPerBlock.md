# SetMaxTransactionsPerBlock 方法 (uint)

设置每区块最大交易数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool SetMaxTransactionsPerBlock(uint value);
```

参数：

- value: 待设置的最大交易数

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetMaxTransactionsPerBlock(1024);
        return result;
    }
}
```

[返回上级](../Policy.md)