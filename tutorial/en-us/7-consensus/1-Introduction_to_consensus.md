# Introduction to Consensus

Multi-Agent Systems (MAS) are the core of Internet-of-Things (IoT), in which autonomous devices are able to interact with each other whilst following their own specific goals. Blockchain consensus operates in the same manner, where autonomous nodes aim to reach an agreement through a negotiation protocol despite the existence of selfish nodes attempting to maximize their own interests. Typically in the literature, MAS protocols are described as having three pillars for reaching agreements: voting, auction, and coordination.

We believe that blockchain protocols are able to safely perform distributed rational decision making during the consensus process. In particular, this may happen if the right incentives are provided. Incentives are not just directly monetary (though rewards) but also involve prestige and the safeguarding of projects that participating nodes are interested in.

In the case of NEO Consensus Nodes (CN), two key points of this interest can be raised, involving two different spheres:

- Stakeholders interested in promoting their image as a reliability link for assisting the creation of blocks; 
- Nodes that want to increase their reputation among the NEO holders, which motivates holders to support their candidature and utilize their services.

The consensus mechanism used by the NEO protocol, named Delegated Byzantine Fault Tolerance (dBFT), has its design rooted in the works of Practical Byzantine Fault Tolerance by Miguel Castro and Barbara Liskov around 1999.

This tutorial will introduce the basic steps for understanding the importance of designing and developing such a mechanism for the NEO ecosystem.

## What we expect that you will learn

After reading this material, it is expected that you will learn:

- Distinguish Proof-of-Work and other consensus mechanisms based on coordination;
- Learn more about cryptography and multi-sig accounts;
- Learn about Byzantine Fault Tolerant systems;
- Comprehend the design of a fully distributed network, in which consensus operates using digital signatures;
- Understand the beauty of **one block finality**.

## What's next?

[PoW and PoS](2-Proof_of_work_and_proof_of_stake.md)