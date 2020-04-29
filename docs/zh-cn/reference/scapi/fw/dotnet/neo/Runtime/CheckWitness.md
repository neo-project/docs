# Runtime.CheckWitness 方法 (byte[])

验证调用该智能合约的交易/区块是否验证过所需的脚本散列。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool CheckWitness(byte[] hashOrPubkey)
```

参数：

- hashOrPubkey：脚本散列或者是公钥，byte 数组类型。其中脚本散列为 20 字节，公钥为 33 字节。

返回值：调用该智能合约的交易/区块是否验证过所需的脚本散列，bool 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        bool result1 = Runtime.CheckWitness(pubKey);
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        bool result2 = Runtime.CheckWitness(scriptHash);
    }
}
```



[返回上级](../Runtime.md)