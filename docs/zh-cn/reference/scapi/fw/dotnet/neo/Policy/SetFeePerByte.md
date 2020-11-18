# SetFeePerByte 方法 (long)

设置每字节手续费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool SetFeePerByte(long value);
```

参数：

- value: 待设置的每字节手续费

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetFeePerByte(1200);
        return result;
    }
}
```

[返回上级](../Policy.md)
