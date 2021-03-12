# MerkleTree

## MerkleTree介绍

Merkle Tree是存储hash值， 并用以快速校验的一种数据结构， Merkle树的叶子是数据块（例如区块或者文件的hash值）， 非叶节点是其对应子节点串联字符串的Hash值

## MerkleTree在Neo中的使用场景

作为数据结构， 生成Neo区块的stateRoot, 以便在跨链， 轻节点等 场景中， 用以快速交易区块的有效性
