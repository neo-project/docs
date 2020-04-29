# Blockchain.GetContract 方法 (byte[])

通过合约哈希获取合约内容。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Contract GetContract(byte[] script_hash)
```

参数：

- script_hash: 脚本哈希，20字节的字节数组。

返回值：智能合约，[Contract](../Contract.md) 类型。

## 示例

```C#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] data = new byte[] { 0x01, 0x01, 0x01 ,0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01 };
        Contract contract = Blockchain.GetContract(data);
    }
}
```



[返回上级](../Blockchain.md)