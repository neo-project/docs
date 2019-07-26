# Consensus Protocol

All public-blockchains run on the peer-to-peer network, their nodes maintain the common account. Therefore, how to motivate the node to supply reliable service, how to solve the "Byzantine Fault Tolerant" problem, and support high performance at the same time, it becomes a big problem for most blockchain projects. Decentralization, scalability and security have become the "Impossible Triangle" problem at present.

On the consensus mechanism, many blockchains can be divided into the following categories:

- POW (Proof of work): Represented by bitcoin, it uses computing power to handle fault tolerance. Criticisms about it consuming a lot of energy and not scaling well, but has been proven to work over 10 years.
- POS (Proof of Stake):  Represented by peercoin, all nodes can mine block, but the reward depends on the coin-age. The more coin you hold, the more rewards you get. It also faces the performance issue.
- DPOS (Delegated Proof of Stake): Represented by eos, the community votes to select 21 super nodes to exercise the block writing rights. When there is an dishonest node, the deposit will be confiscated.

NEO has implemented a delegated Byzantine Fault Tolerant algorithm. The dBFT algorithm provides fault tolerance of `f = ⌊ (n-1) / 3 ⌋` nodes, and 1,000TPS transaction throughput in mainnet. It is possible to reach 10,000TPS in the future for supporting large-scale commercial applications.<br/>

Different from DPoS, NEO stake holders can vote and select the consensus nodes in neo network at any time. Consensus nodes cooperate with other consensus nodes to reach consensus and packet the next block. Consensus nodes get the block's network fee GAS as reward. It overcomes low performance issue in PoS, for it eliminates the necessity of mining.