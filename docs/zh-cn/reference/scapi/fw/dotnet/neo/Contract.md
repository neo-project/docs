# Contract 类

表示合约的类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Contract
```

## 属性

|                                                        | 名称                                         | 说明                      |
| ------------------------------------------------------ | -------------------------------------------- | ------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [IsPayable](Contract/IsPayable.md)           | 该合约能否接收 NEP-5 资产 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md)                 | 获得该合约的脚本哈西      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [StorageContext](Contract/StorageContext.md) | 获得该合约的存储区上下文  |

## 方法

|                                          | 名称                                       | 说明              |
| ---------------------------------------- | ---------------------------------------- | --------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | `new` 发布智能合约    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | `new` 迁移 / 更新智能合约 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | `new` 销毁智能合约    |

## 构造方法

通过 [Blockchain.GetContract(byte[])](Blockchain/GetContract.md) 方法来构造 Contract 对象。

通过 [Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) 方法来发布智能合约到区块链上，并返回 Contract 对象。

通过 [Contract.Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) 方法来更新智能合约，并返回 Contract 对象。
