# Introduction to blocks & blockchain

## Concept
When Alice wants to send a transaction to Bob, she will sign her transaction and broadcast it to the nodes in the network. The consensus nodes will select from the available pool of valid transactions, which may then be included into a block. A block is a batch of transactions that are confirmed and stored at the same time. Aside from all transactions that a certain block includes, there are some other fields present in each block which are discussed [here](2-Structure_of_a_block.md).

## Chaining the blocks
One of these fields that is present in each block (b<sub>n</sub>) is a reference to the previous block that was just confirmed before this block (b<sub>n-1</sub>). In more detail, it is the hash of the header of the previous block. It is up to the nodes to calculate the hash to validate the parent block. In turn, this previous block(b<sub>n-1</sub>) also has the same behaviour, linking to the block before it(b<sub>n-2</sub>). This chain of connections leads all the way back to the first block ever created, called the Genesis (b<sub>0</sub>) block. This is the origin of the term 'blockchain' as it is, in fact, a line of blocks that are linked together as a chain.

## Parents & Children
Every block can only have one parent, referenced in the field for the previous block. Most blockchains can have a temporary situation where a single parent block can have multiple children, that is, multiple blocks can point to the same block as its parent. This happens, on average, once every week for Bitcoin. This happens when 2 miners find a valid nonce for a new block ("solve the puzzle") at approximately the same time, both broadcasting valid blocks to the network. This is what is called a fork, which is automatically resolved when new blocks are mined. This is because additional blocks will only continue on one side of the path, and the longest path (path of most difficulty) is accepted as the truth. The second path is abandoned.

Thanks to its dBFT consensus mechanism, the NEO blockchain does not suffer from this behaviour and will, by algorithmic certainty, never fork, and thus will never encounter a situation in which 2 valid versions of the blockchain exists. For more information on this consensus mechanism, you can read the [whitepaper](../../../docs/en-us/basic/technology/dbft.md).

## What's next?

[Structure of a block](2-Structure_of_a_block.md)