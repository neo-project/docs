# Vote 方法 (byte[], byte[])

投票。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool Vote(byte[] account, byte[] voteTo);
```

参数：

- account: 投票账户的脚本哈希;
- voteTo: 目标账户的公钥。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] voteTo = new byte[] { 0x02, 0xe8, 0xff, 0x17, 0xc5, 0x67, 0xd6, 0x2f, 0x27, 0x4f, 0xe2,
         0x47, 0xcc, 0x88, 0x4a, 0x2a, 0x6c, 0xd3, 0xb8, 0xfd, 0x0d, 0x77, 0x9a, 0x8c, 0x58, 0x56, 0x28, 0x9a, 0x56, 0x0a, 0xcc, 0xac, 0xb4 };
         
    public static object Main()
    {
        bool result = NEO.Vote(account, voteTo);
        return result;
    }
}
```

[返回上级](../Neo.md)