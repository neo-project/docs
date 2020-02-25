# Account.IsStandard 方法 (byte[])

根据 scripthash 判断该合约是否是标准账户（单方签名账户）。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool IsStandard(byte[] scripthash)
```

参数：scripthash，账户的脚本散列。

返回值：布尔值，true或false。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        Account.IsStandard(scriptHash);
    }
}
```



[返回上级](../Account.md)