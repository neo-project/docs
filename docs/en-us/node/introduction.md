# NEO Node Introduction
Nodes that store all of the blockchain are called “full-nodes”. They are connected to the blockchain through a P2P network. All the nodes in the blockchain network are equal, they act both as a client interface and as a server.

There are two full-node programs:

- Neo-GUI, which has all the basic functions of a user-client including a graphical user interface and is intended for NEO users. 
- Neo-CLI, which provides an external API for basic wallet functions and is intended for NEO developers. It also helps other nodes achieve consensus with the network and is involved in generating new blocks.

The NEO [network protocol](../tooldev/advanced/network-protocol.md) provides a low level API for some transaction types that are not currently supported by the CLI, such as claiming GAS or sending NEO without an open wallet.

## NEO client download address

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Official website](https://www.neo.org/download) or [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Source code | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## GUI node and CLI node functions comparison

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Graphic Interface | ✅    |      |
| Command Line Interface |      | ✅    |
| Create Wallet | ✅    | ✅    |
| Open Wallet | ✅    | ✅  |
| Reconstruct Wallet Index | ✅    | ✅    |
| Show all key pairs | ✅    | ✅    |
| Import/Export Key Pair | ✅    | ✅    |
| Show all addresses | ✅    | ✅    |
| Show all assets | ✅    | ✅    |
| Create Address | ✅    | ✅    |
| Transfer | ✅    | ✅    |
| Transaction (Asset swap)  | ✅    |      |
| Create a multi-party signature contract | ✅    |      |
| Create a custom smart contract | ✅    | ✅     |
| Signature | ✅    |      |
| Election Consensus Node | ✅    |      |
| Voting | ✅    |      |
| Register assets | ✅    |      |
| Distribution of assets | ✅    |      |
| Extraction of NEO | ✅    |      |
| Batch Generation Address  |      | ✅    |
| JSON-RPC |      | ✅    |
| The consensus of the participating blocks |      | ✅    |

## NEO-CLI security policy

To enable an external program to access the node API, you need to open the firewall port. 

> [!Note]
>
> To avoid the significant security risk, a whitelist or firewall must be used to block external server requests.

NEO-CLI does not provide the function to remotely switching on/off the wallet, and it does not verify the process when opening a wallet. Therefore, you should set your own security policies. The wallet must be kept open all the time to respond to the withdrawal requests of users. For security reasons, the wallets should be run in an independent server on which the firewall is configured properly, as shown below. 

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

For more information, please refer to [test network](../network/testnet.md).
