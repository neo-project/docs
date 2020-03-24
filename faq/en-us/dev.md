# Development

## How to apply for test tokens?

Up to 1000 GAS and 1000 NEO per day can be requested via the [NGD faucet](https://neowish.ngd.network/). If you need more than that, go to https://neo.org/testcoin/apply and fill out the application form. If the application is accepted, you will be notified in three to five workdays.

## How to build a private chain?

To build a private chain, you have the following options：

- Quickly build a private chain with one node. See [here](../../docs/en-us/network/private-chain/solo.md).
- Use a virtual machine to build a private chain on a cloud server. See [here](../../docs/en-us/network/private-chain/private-chain.md).
- Quickly build a private chain on your local host. See [here](../../docs/en-us/network/private-chain/private-chain2.md).
- Quickly build a private chain using neo-local. See [here](../../docs/en-us/network/private-chain/neolocal.md).

You can also refer to the [community articles](../../articles/en-us/index.md) to learn more options.

## What languages can I use to develop smart contracts?

NEO supports a variety of mainstream programming languages and can be developed using C#, Python, Go, JS, and Jave. Currently in the NEO ecosystem, the infrastructure for C# and Python is extremely well-developed and various compilers are provided for developers.

## How can I obtain the NEP-5 asset hash?

You can choose one of the following methods:

- Use a blockchain browser, e.g.  https://scan.nel.group, to view the NEP-5 asset hash:

  1. In the browser, click Assets in the top navigation bar. 
  2. In the Assets drop-down list, select NEP-5.
  3. Click the desired asset to view its hash in the details page that appears.

- Download the plugin [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcNep5Tracker.zip) and then invoke the API method [getnep5balances](../../docs/zh-cn/reference/rpc/latest-version/api/getmetricblocktimestamp.md) included. You can find NEP-5 asset hash in the returned response.

## Why is it prompted that there is no object's private key in the wallet when withdrawing assets from a multi-party signature contract?

After the private chain is set up, you need to make the same configurations in all (n/2+1) wallets (n is the node number), that is, add the multi-party signed addresses and then rebuild the wallet index. 

## What SDKs are provided for developers?

NEO developer communities have developed and maintained various NEO SDKs for many mainstream languages including C#, JavaScript, Java, and etc. You can check them here:

- C# SDK: [neo](https://github.com/neo-project/neo)
- JavaScript SDK: [neon-js](http://cityofzion.io/neon-js/)
- Java SDK: [neow3j](https://github.com/neow3j)

