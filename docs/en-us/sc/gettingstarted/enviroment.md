# Setting up local network

## Setting up a private chain

Neo provides a test net for development, debugging and testing purposes. Besides, you can also choose to set up your own private chain where you can get more flexibly with plenty of test tokens. You can pick one of the following options:

- [Set up a private chain with one node](../../network/private-chain/solo.md)
- [Set up a private chain on a Windows host](../../network/private-chain/private-chain2.md)

Refer to the instructions from above links to set up your private chain and withdraw NEO and GAS from genesis block.

## Preparing a wallet file

Now let's create a new wallet file used for deploying smart contracts:

1. Create a new wallet file named 0.json and copy the default address for later usage.
2. Open the wallet where you have withdrawn NEO and GAS from genesis block, transfer all the assets in that wallet to 0.json and wait for the transaction to be confirmed.
3. Open 0.json and assets is displayed in the account.

## What's next?

[Compiling a sample contract](develop.md)
