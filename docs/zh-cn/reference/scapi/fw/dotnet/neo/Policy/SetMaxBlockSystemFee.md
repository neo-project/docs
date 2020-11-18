# SetMaxBlockSystemFee 方法 (uint)

设置区块最大系统手续费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool SetMaxBlockSystemFee(long value);
```

参数：

- value: 待设置的区块最大系统手续费

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetMaxBlockSystemFee(4007800L);
        return result;
    }
}
```

[返回上级](../Policy.md)

>注：设置的手续费值应不小于4007600。