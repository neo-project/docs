# Blockchain.GetAsset 方法 (byte[])

根据资产 ID，在区块链中查找该资产。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset(byte[] asset_id)
```

参数：资产ID，32字节的字节数组。

返回值：资产，[Asset](../Asset.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        //以NEO资产为例
        byte[] asset = { 197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 14, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155 };
        Asset ass = Blockchain.GetAsset(asset); 
    }
}
```

其中 asset 可以在外部事先获得，也可以作为参数传入智能合约。下面是在外部代码中调用 SDK 将资产 ID 的 16 进制字符串转成 byte 数组。

```c#
static void Main(string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[返回上级](../Blockchain.md)