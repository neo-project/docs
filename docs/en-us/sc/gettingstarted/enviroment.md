# Setting up local network

## Setting up a private chain

Neo provides a test net for development, debugging and testing purposes. Besides, you may also choose to set up your own private chain where you can operate more flexibly with plenty of test tokens.  You can choose one of the following ways:

- [Set up a private chain using virtual machines](../../network/private-chain/private-chain.md)
- [Set up a private chain on a Windows host](../../network/private-chain/private-chain2.md)
- [Set up a private chain with one node](../../network/private-chain/solo.md) (Applicable to Neo-CLI 2.10.2 and the later)

Refer to the instructions at above links to set up your private chain and withdraw NEO and GAS from genesis block.

> [!Note]
>
> Since GAS is generated with every new block generated, it is recommended you keep the new-built private chain running a while to generate enough GAS. Smart contract deployment and invocation will cost a certain amount of GAS.

## Preparing a wallet file

Now we will create a new wallet file used for deploying smart contracts. 

1. Create a new wallet file named 0.json and copy the default address in case of later use.
2. Open the recipient wallets of NEO and GAS, transfer all the wallet assets to 0.json and wait for the transaction to be confirmed.
3. Open 0.json and assets is displayed in the account. 

