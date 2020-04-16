## Using Neo-CLI

The Neo-CLI client works as an normal node in the P2P network and meanwhile a cross-platform wallet handling various assets transactions. 

### Neo-CLI Security Policies

> [!Caution]
>
> #### Caution
>
> The exchange must use a white list or firewall to block external server requests; otherwise there will be a significant security risk.

Neo-CLI does not provide the function to remotely switching on/off the wallet, and it does not verify the process when opening a wallet. Therefore, exchanges should set their own security policies. The wallet must be kept open all the time to respond to the withdrawal requests of users. For security reasons, the wallets should be run in an independent server on which the firewall is configured properly, as shown below. 

|                    | Mainnet | Testnet |
| ------------------ | ------- | ------- |
| JSON-RPC via HTTPS | 10331   | 20331   |
| JSON-RPC via HTTP  | 10332   | 20332   |
| P2P                | 10333   | 20333   |
| websocket          | 10334   | 20334   |

### About Neo-CLI

Neo-CLI is a command-line client (wallet) for developers. Developers have two ways to interact with it： 

- Using the CLI (command-line interface) commands. For example, you can create a wallet, generate an address, etc.
- Using the Remote Procedure Call (RPC). For example, you can transfer to the designated address, acquire the block information of the designated height, acquire the information of the designated trade, etc.

Neo-CLI provides the following features： 

- As a wallet, manages assets through the command-line.

  To enable the wallet，enter the following command under the Neo-CLI directory：


  ```
  dotnet neo-cli.dll
  ```

  To check all the available commands, enter the following command：

  ```
  help
  ```

  For more information, refer to [CLI Command Reference](../node/cli/cli.md).

- Provides a set of RPC APIs in conjunction with the RpcServer plugin to retrieve blockchain data from nodes. The interfaces are provided through  [JSON-RPC](http://www.jsonrpc.org/specification)，and the underlying communications use HTTP/HTTPS protocols.

  Before you can start a node which provides RPC service, you must has the plugin RpcServer installed with Neo-CLI installation.

  For more API information, refer to [API Reference](../reference/rpc/latest-version/api.md).


- Provides transaction information of NEP-5 assets.


### Creating a Wallet

The exchange needs to create an online wallet to manage the deposit addresses of users. A wallet is used to store the information of the accounts (both public keys and private keys) and the contracts. It is the most important proof that the user holds. Users must keep the wallet files and the wallet passwords secure. They must not lose or disclose these data. Exchanges do not have to create a wallet for every address. An online wallet usually keeps all deposit addresses of users. A cold wallet (offline wallet) is another storage option which provides better security.

> [!Note]
>
> Neo-CLI supports wallets in two formats: the sqlite wallet (.db3) and the new [NEP6 standard](https://github.com/neo-project/proposals/blob/master/nep-6.mediawiki) wallet (.json). For exchanges the sqlite wallet is recommended.

To create a wallet, do the following：

1. enter  `create wallet <path>`.

   <path> is the wallet path and wallet file name. The file extension can be .db3 or .json, depending on the wallet type you are using, for example,  `create wallet /home/mywallet.db3`. If the file extension is not specified, the NEP6 format (.json) is used by default. 

2. Set a password for the wallet. 

### Generating Deposit Addresses

A wallet can store multiple addresses. The exchange needs to generate a deposit address for each user. 

There are two methods to generate deposit addresses: 

- When the user deposit (NEO/GAS) for the first time, the program dynamically generates a NEO address. The advantage is that there is no need to generate addresses at fixed time intervals, while the disadvantage is that it's not convenient for backup.

  To develop the program to dynamically generate addresses, use the RpcServer API  [getnewaddress Method](../reference/rpc/latest-version/api/getnewaddress.md). The created address is returned.

- The exchange creates a batch of NEO addresses in advance. When the user charges (NEO/GAS) for the first time, the exchange assigns a NEO address to him or her. The advantage is the convenience to backup the wallet, while the disadvantage is the need to generate NEO addresses manually.
  To generate addresses in batch, run the NEO- CLI command `create address [n]`. The  addresses are exported automatically to the address.txt file.
  [n] is optional. Its default value is 1. For example, to generate 100 addresses at a time, enter `create address 100`.


> [!Note]
>
> Either way, the exchange must import the addresses into the database and distribute them to users. It is generally recommend the exchange use the second way, so as to reduce the external controls and run the wallet more stably.
