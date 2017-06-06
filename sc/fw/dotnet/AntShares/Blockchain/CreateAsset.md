# Blockchain.CreateAsset 方法 (byte, string, long, byte, byte[], byte[], byte[])

在智能合约中调用此方法可以注册一种在小蚁区块链上的资产。

该方法是 RegistTransaction 在 2.0 版本的替代者。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Asset CreateAsset(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

参数：

asset_type：资产类型，字节类型，请参考 [AssetType](../Asset/AssetType.md)。

name：资产名称，字符串类型。

amount：资产总量，长整型，该值等于实际金额 × 10⁸。

precision：该资产的精度（最小分割数量），单位为小数点之后的位数，20字节的 byte 数组。

owner：该资产的所有人（公钥），33字节的 byte 数组。

admin：该资产的管理员（合约地址），管理员有权对资产的属性（如总量，名称等）进行修改，20字节的字节数组。

issuer：该资产的发行人（合约地址），该发行人有权进行资产的发行，20字节的字节数组。

返回值：创建的资产，[Asset](../Asset.md) 类型。

## 示例

```

```



[返回上级](../Blockchain.md)