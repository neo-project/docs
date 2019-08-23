# Merkle Tree

Merkle Tree is a kind of binary tree: it can be used to quickly check and accommodate massive data, and verify the integrity of block transaction records. NEO uses Merkle Tree to construct block model. NEO's block header stores the Merkle root of all transactions within the block. Block data area stores transaction array.

[![MerkleTree01](../images/blockchain_paradigm/MerkleTree01.png)](../../images/blockchain_paradigm/MerkleTree01.png)

Attributes of Merkle tree：

  - Merkle Tree is basicly a binary tree, with all features of tree structure.

  - Merkle Tree's leaf nodes' value is unit data of data set, or the hash of unit data.

  - The value of a non-leaf node is based on all the leaf node values below it, and then calculated with hash method.

Transaction verification principle:

Transcation001's validity can be verified by comparing original Top Hash value with the value computed from Transcation001, Transcation002 and Hash1 (The direct child of Top Hash on the right side).

Scenarios：

  - A Merkle tree root is built when constructing a block header

  - Use SPV wallet to verify block data

For more information, refer to <https://en.wikipedia.org/wiki/Merkle_tree>.
