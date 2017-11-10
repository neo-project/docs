# 智能合约 .net 框架

NEO 智能合约的.net 框架是对智能合约 API 的封装，使 .net 程序员可以直接使用 .net 中的类、方法、属性来方便地与 API 交互，进而获得区块链账本数据、操作持久化存储区等。

## 互操作服务层的方法

以下是互操作服务层的命名空间，分别属于 Neo.SmartContract.Framework.Services.NEO 和 Neo.SmartContract.Framework.Services.System 命名空间。点击进去可以了解更详细的类和方法。

| 命名空间                       | 说明                                       |
| -------------------------- | ---------------------------------------- |
| [Neo](dotnet/neo.md)       | NEO 命名空间是 NEO 区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。 |
| [System](dotnet/system.md) | System 命名空间是智能合约执行引擎（NeoVM）提供的 API，提供了访问访问该智能合约的执行环境的方法。 |

## 框架本身提供的常用方法

在智能合约中除了可以调用互操作服务层中的方法，还可以调用框架本身提供的常用方法。这些方法属于 Neo.SmartContract.Framework 命名空间，在合约中可以直接使用这些方法。

### SmartContract 类提供的方法

SmartContract 类提供了一些散列算法以及验签方法等。

|                                          | 名称                                       | 说明                                       |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                             | 对传入的 byte 数组进行 Sha1 运算                   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                           | 对传入的 byte 数组进行 Sha256 运算                 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                          | 对传入的 byte 数组进行 Sha256 运算后，再进行 Ripemd160 运算 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                          | 对传入的 byte 数组进行两次 Sha256 运算               |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] pubkey, byte[] signature) | 通过公钥和已签名的数据来验证验证是否通过                     |

### byte 数组的扩展方法

下面的这些方法是智能合约 .net 框架中的 Helper 类提供给 byte 数组的一些 ` 扩展方法 `。

|                                          | 名称                           | 说明                                   |
| ---------------------------------------- | ---------------------------- | ------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | 连接两个 byte 数组                         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | 截取 byte 数组，参数为：index, count          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | 从 byte 数组中取左侧固定长度的 byte 数组，参数为：count |