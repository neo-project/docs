## NEO Protocol and Networking Tutorial

[NEO](https://neo.org/) is an open-source platform for decentralized applications. It is a blockchain with the [dBFT](https://docs.neo.org/en-us/basic/consensus/consensus.html) consensus protocol, baring similarity to Ethereum in that it can deploy and execute smart contracts.

This tutorial targets developers/students that want to write their own NEO P2P client in order to participate in the distributed system. This tutorial will not go into details of distributed systems and the reader should be familiar with the basics of distributed systems, about networking protocols, and the Golang programming language.

The NEO network consists of two kind of protocols: a protocol to communicate with local clients and wallets, and an external protocol to communicate with other NEO nodes. To connect to a local node, [JSON-RPC](https://www.jsonrpc.org/) is used. This JSON-RPC can also be exposed to other external nodes.

```
                          +--------------+
+----------+              | +----------+ |
|          | NEO Protocol | |          | |
| NEO node +----------------+ NEO peer | |
|          |              | |          | |
+----------+              | +----+-----+ |
                          |      |       |
                          |      |JSON   |
                          |      |RPC    |
                          |      |       |
                          | +----+-----+ |
                          | |          | |
                          | |Local node| |
                          | |          | |
                          | +----------+ |
                          +--------------+
                              NEO node
```
In this tutorial, we will focus on the other protocol, the [NEO protocol](https://docs.neo.org/en-us/network/network-protocol.html). Using the Golang programming language, we will learn how to communicate with a NEO node.

[Follow this link to get started](2-Developing_a_NEO_ping_using_Golang.md) or [return to contents](README.md#contents).
