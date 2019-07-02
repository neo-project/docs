# Development

## How to apply for test tokens?

Go to https://neo.org/testcoin/apply and fill out the application form. If the application is accepted, you will be notified in three to five workdays.

## How to build a private chain?

To build a private chain, you have the following options：

- Use a virtual machine to build a private chain on a cloud server. See [here](../network/private-chain/private-chain.md).
- Quickly build a private chain on one Windows serve. See [here](../network/private-chain/private-chain2.md).
- Quickly build a private chain with neo-local. See [here](../network/local-chain.md).

You can also refer to the [community tutorial](../communitydoc.md) to learn more options.

## Which languages can I use to develop smart contracts?

NEO supports a variety of mainstream programming languages and can be developed using C#, Python, Go, JS, and Jave. Currently in the NEO ecosystem, the infrastructure for C# and Python is extremely well-developed and various compilers are provided for developers.

## How can I obtain the NEP-5 assets TXID?

Currently we recommend you use the blockchain browser https://scan.nel.group to view the NEP-5 assets TXID.

1. In the browser, click Assets in the top navigation bar. 
2. In the Assets drop-down list, select NEP-5.
3. Click the desired asset to view its TXID in the details page that appears.

## Why is it prompted that there is no object's private key in the wallet when withdrawing assets from a multi-party signature contract?

After the private chain is set up, you need to make the same configurations in all (n/2+1) wallets (n is the node number), that is, add the multi-party signed addresses and then rebuild the wallet index. 