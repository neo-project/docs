<center><h2> 梅克尔树 </h2></center>

　梅克尔树是一种二叉树，能快速检查和归纳大量数据，可用于验证区块中交易记录的完整性。NEO 使用梅克尔树来构建区块模型。NEO 中每个区块的区块头都会保存一份该区块所有所有交易的梅克尔树根，区块的数据区存放交易数组。

[![MerkleTree01](../../images/blockchain_paradigm/MerkleTree01.png)](../../images/blockchain_paradigm/MerkleTree01.png)

梅克尔树基本特点：

  1. Merkle Tree 是一种树，大多数是二叉树（NEO采用二叉树形式），具有树结构的所有特点；

  2. Merkle Tree 的叶子节点的value是数据集合的单元数据或者单元数据 HASH。

  3. 非叶子节点的 value 是根据它下面所有的叶子节点值，然后按照哈希法计算而得出的。

交易验证原理：

　通过Transcation001、Transcation002、Hash1 计算 Top Hash 与原本的 Top Hash 比对，即可验证 Transcation001 的有效性。


应用场景：

1. 构建区块头时会维护一个 MerkleTree 根

2. 使用 SPV 钱包，验证区块数据

参考文献：

1. <https://en.wikipedia.org/wiki/Merkle_tree>

> [!NOTE]
> 如果发现有死链接，请联系 <feedback@neo.org>
