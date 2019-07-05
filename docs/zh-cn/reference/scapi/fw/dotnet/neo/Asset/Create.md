# Asset.CreateAsset 方法 (byte, string, long, byte, byte[], byte[], byte[])

在智能合约中调用此方法可以注册一种在NEO区块链上的资产。

该方法是 RegistTransaction 在 2.0 版本的替代者。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

参数：

asset_type：资产类型，字节类型，请参考 [AssetType](../Asset/AssetType.md)。

name：资产名称，字符串类型。

amount：资产总量，长整型，该值等于实际金额 × 10⁸。

precision：该资产的精度（最小分割数量），单位为小数点之后的位数，字节类型。

owner：该资产的所有人（公钥），33字节的 byte 数组。

admin：该资产的管理员（合约地址），管理员有权对资产的属性（如总量，名称等）进行修改，20字节的字节数组。

issuer：该资产的发行人（合约地址），该发行人有权进行资产的发行，20字节的字节数组。

返回值：创建的资产，[Asset](../Asset.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte assetType = 0x60; //Token
        string name = "星球大战电影票";
        long amount = 1000;
        byte precision = 0;
        byte[] owner = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        byte[] admin = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        byte[] issuer = admin;
        Asset ass = Asset.Create(assetType, name, amount, precision, owner, admin, issuer);
        uint blockIndex = ass.Renew(1);
    }
}
```



[返回上级](../Asset.md)