# Blockchain.GetValidators 方法 ()

获得共识人的公钥。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern byte[][] GetValidators()
```

返回值：公钥数组，数组中的每个元素都是 33 字节的字节数组。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[][] validators = Blockchain.GetValidators();
    }
}
```



[返回上级](../Blockchain.md)