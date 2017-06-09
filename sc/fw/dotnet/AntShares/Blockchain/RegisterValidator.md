# Blockchain.RegisterValidator 方法 (byte[])

报名成为共识人，仅是报名操作，能否当选需要其它人的投票。

该方法是 RegisterTransaction 在 2.0 版本的替代者。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static extern object RegisterValidator(byte[] pubkey)
```

参数：

pubkey：公钥，长度为33的字节数组。

返回值：object 类型，这是为将来智能合约扩展所留的接口，暂时无意义。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = new byte[] { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        var result = Blockchain.RegisterValidator(pubKey);
    }
}
```



[返回上级](../Blockchain.md)