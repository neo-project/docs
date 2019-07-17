# Setting up local network

## Setting up a private chain

NEO Official provides a test net for development, debugging and testing purposes. Besides, users may also choose to set up their own private chain where they can operate more flexibly with plenty of test tokens.  You can choose one of the following way to set up your private chain:

- [Set up a private chain using virtual machines](../../network/private-chain/private-chain.md)
- [Set up a private chain on a Windows host](../../network/private-chain/private-chain2.md)
- [Set up a private chain with one node](../../network/private-chain/solo.md) (Applicable to NEO-CLI 2.10.2 and the later)

Refer to the instructions at above links to set up your private chain and withdraw NEO and GAS from genesis block.

## Preparing a wallet file

Now we will create a new wallet file named 0.json and place it in the root directory of the nodes for smart contract release. 

1. Create a new wallet file named 0.json and copy the default address in case of later use.
2. Open the recipient wallets of NEO and GAS, transfer all the wallet assets to 0.json and wait for the transaction to be confirmed.
3. Open 0.json and assets is displayed in the account. 

> [!Note]
>
> Smart contract deployment and invocation cost GAS. Since GAS is generated with every new block generated, causing limited GAS generated on freshly-built private chains, therefore users are advised not to shut down private chains now in order to generate enough GAS in case of later use.

## What's next?

[Compiling a contract sample](develop.md)

