# DApp Integration

After developers complete the development and testing of smart contracts, they need to  proceed with the front-end integration development to enable the interaction between DApp and the block chain, such as obtaining information from the Neo blockchain and invoking smart contracts deployed. In this section we will introduce the DApp integration with Neo blockchain.

As shown in the figure below, DApps can interact with the blockchain in the following ways:

- Use NEO-SDK and send RPC requests;
- Call the DAPI provided by the wallet plugin

![structure](./assets/structure.png)



## Basic interaction functions

The following table lists the basic functions of DApp and blockchain interaction. In addition, different SDKs and wallet plugins may provide more functions. For details, refer to the specific integration tools you use.

| Category           | Function                | Description                                                  |
| ------------------ | ----------------------- | ------------------------------------------------------------ |
| Wallet             | Create a wallet         | Create a new Neo wallet.                                     |
|                    | Import a wallet         | Imports an existing wallet through its wallet file, private key/wif, or NEP2 private key plus password. |
|                    | Query the balance       | Queries the digital assets and balance owned by a wallet through the wallet address. |
|                    | Transfer assets         | Transfers assets such as NEO, GAS, and Nep-5 assets to other wallets |
| Smart Contract     | Invoke a contract       | DApps implement the logic that needs to be deployed on the blockchain through the  smart contract and execute it by invoking the contract when needed. |
| Information  Query | Blocks information      | Queries any block information                                |
|                    | Transaction information | Queries any transaction details on the blockchain            |
|                    | Execution log           | Queries detailed execution logs and events for a certain transaction |

## DApp Integration tools

To fit different developers' needs and facilitate DApp development, Neo development community provides NEO-SDK for multiple languages and wallet plugins supporting DAPI.

### neo-sdk

Neo-sdk provides a relatively easy and flexible way for developers to use. It encapsulates functions such as wallet, digital asset transactions, and smart contract invoking, which can be simply used by including the corresponding neo-sdk into the DApp project.

SDK supports the following functions:

- Wallet
- Transaction
- Contract call
- Blockchain information query

Neo developer community provides the following Neo-SDK：

- JavaScript:

  neon-js：[Github](https://github.com/CityOfZion/neon-js)，[Documentation](http://cityofzion.io/neon-js/en/)

- Java

  neow3j：[Github](https://github.com/neow3j/neow3j)，[Documentation](https://neow3j.io/#/)

- C#

  neo-lux：[Github](https://github.com/CityOfZion/neo-lux)，[Documentation](https://github.com/CityOfZion/neo-lux#usage)

- Golang

  - neo-gogogo：[Github](https://github.com/joeqian10/neo-gogogo)，[Documentation](https://github.com/joeqian10/neo-gogogo#getting-started)
  - neo-utils：[Github](https://github.com/O3Labs/neo-utils)，[Documentation](https://github.com/O3Labs/neo-utils/tree/master/neoutils#neo-utilities)

- python

  neo-python：[Github](https://github.com/CityOfZion/neo-python)，[Documentation](https://neo-python.readthedocs.io/en/latest/overview.html)

### Wallet plugins supporting DAPI

DAPI describes a set of common interfaces for interaction between DApps and wallets. With trusted third-party wallet providers that support DAPI, users can use DApps more securely, and the unified user interface enables DApps to provide a friendly user experience. Some wallets or wallet browser plugins in the Neo ecosystem have implemented DAPI support, and users can use familiar wallet plugins in DApps.

For more information about DAPI functions, refer to [dapi standard](https://github.com/neo-project/proposals/pull/69/files?short_path=b415db4#diff-b415db480373da06c3cb17ece34b2012).

These wallets or wallet plugins support DAPI:

- O3：[Download wallet](https://o3.network/)，[dapi Documentation](https://neodapidocs.o3.network/)
- Neoline：[Download wallet plugin](https://chrome.google.com/webstore/detail/neoline/cphhlgmgameodnhkjdmkpanlelnlohao)，[dapi Documentation](https://neoline.cn/dapi/)
- Teemo：[Download wallet plugin](https://teemo.nel.group/index.html)，[dapi Documentation](https://dapi.nel.group/cn/#neo-dapi)

## DApp Development Tools

### NEO·ONE

[NEO•ONE]( https://neo-one.io/blog/2018/11/14/introducing-neo-one ) is a full end-to-end toolkit adopting TypeScript or JavaScript to develop DApps on the Neo platform. NEO•ONE offers a one-stop solution for DApp development, covering all the tool functions needed throughout the entire development cycle, including: 

- Supports JS / TS application development
- Supports private chain, test net, and main net
- Smart contract writing, testing, and deployment
- Invoking smart contracts directly within the DApp through the client API

NEO·ONE provides comprehensive documentation, learning courses, and tutorials. For more information refer to [NEO·ONE website]( https://neo-one.io/ ).

## What's next?

[A DApp Development Demo](demo.md)