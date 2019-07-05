# Blockchain.GetAccount 方法 (byte[])

根据合约脚本的散列来获得一个账户（地址）。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Account GetAccount(byte[] script_hash)
```

参数：脚本散列，20 字节的字节数组。

返回值：账户，[Account](../Account.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        Account acc = Blockchain.GetAccount(scriptHash);
    }
}
```

其中 script hash 可以在外部事先获得，也可以作为参数传入智能合约。下面是在外部代码中调用 SDK 将地址转成 script hash。

```c#
static void Main(string[] args)
{
    byte[] scriptHash = Neo.Wallets.Wallet.ToScriptHash("AK4if54jXjSiJBs6jkfZjxAastauJtjjse").ToArray();
}
```



[返回上级](../Blockchain.md)