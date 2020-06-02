# DApp Development Introduction

To develop DApps on NEO network you need to do two parts of work, the development of smart contracts and integration with the blockchain. If you  have already completed the development, testing, and deployment of your smart contracts, then just skip to the next section [Dapp Integration](integ.md).

Generally, the process of developing a DApp is:

1. Set up a network environment

  Given that development and deployment of smart contracts on Neo charges a certain amount of Gas fee, it is recommended that developers set up their own private chain or use test net where they can operate more flexibly with plenty of test tokens. You can choose one of the following way: 

  - [Set up a Neo private chain](../network/private-chain/solo.md)；
  - [Use Neo-local to set up a local network](../network/private-chain/neolocal.md);
  - [Use Neo test net](../network/testnet.md)

2. Run a Neo node

  Neo provides two nodes, command line and user interface, for different developers to choose. For more information, see [Neo nodes](../node/introduction.md)

3. Develop your smart contract

  Smart contracts implement the core function logic of DApp. Refer to [Smart Contract Development](../sc/gettingstarted/introduction.md) to complete your contracts.

4. Integrate your DApp with blockchain

  After completing the development, testing and deployment of your smart contract, you need to proceed with the front-end integration development to enable the interaction between DApp and the block chain. 
  
