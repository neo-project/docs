# Account.GetBalance 方法 (byte[])

通过资产ID获得该账户中这种资产的余额。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern long GetBalance(byte[] asset_id)
```

参数：资产ID，即注册资产时的 RegistTransaction 的交易ID，32字节的byte数组。

返回值：账户中该资产余额，长整形，等于实际金额 × 10⁸。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        Account account = Blockchain.GetAccount(scriptHash);
        //以NEO资产为例
        byte[] asset = { 197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 14, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155 };
        long balance = account.GetBalance(asset);
    }
}
```



[返回上级](../Account.md)