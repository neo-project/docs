# Asset 类

用来表示资产的数据结构。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public class Asset 
```

## 属性

|                                          | 名称                              | 说明                                    |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md)         | 获得该资产的管理员（合约地址），有权对资产的属性（如总量，名称等）进行修改 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md)       | 获得该资产的总量                              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md)     | 获得该资产的ID                              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | 获得该资产的类别                              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | 获得该资产的已经发行出去的数量                       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md)       | 获得该资产的发行人（合约地址），有权进行资产的发行             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md)         | 获得该资产的所有人（公钥）                         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | 获得该资产的精度（最小分割数量），单位为小数点之后的位数          |

## 方法

|                                          | 名称                            | 说明          |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md) | `new` 为资产续费 |

## 构造方法

通过 [Blockchain.GetAsset(byte[])](Blockchain/GetAsset.md) 方法来构造 Asset 对象。

通过 [Blockchain.CreateAsset(byte, string, long, byte, byte[], byte[], byte[])](Blockchain/CreateAsset.md) 方法来在区块链上创建新的资产，并返回 Asset 对象。