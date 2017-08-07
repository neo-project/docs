# Header 类

用来表示区块头的数据结构。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Header : IScriptContainer
```

## 属性

|                                          | 名称                                       | 说明                         |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | 获得该区块的共识数据（共识节点生成的伪随机数）    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | 获得该区块的散列                   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | 获得该区块中所有交易的 Merkle Tree 的根 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | 获得下一个记账合约的散列值              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | 获得前一个区块的散列                 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | 获得区块的时间戳                   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | 获得区块版本号                    |

## 构造方法

通过 [Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md) 来构造 Header 对象。

通过 [Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md) 来构造 Header 对象。