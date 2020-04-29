# Neo Node Introduction
Nodes that store all of the blockchain are called “full-nodes”. They are connected to the blockchain through a P2P network. All the nodes in the blockchain network are equal, they act both as a client interface and as a server.

There are two full-node programs:

- Neo-CLI, which provides a command-line interface and a set of RPC API for developers. It also helps other nodes achieve consensus with the network and is involved in generating new blocks.
- Neo-GUI, which provides a graphical interface for ordinary users and developers, with most functions except consensus.

## Download links

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Download](https://github.com/neo-ngd/Neo3-GUI/releases) | [Download](https://github.com/neo-project/neo-cli/releases) |
| Source code | [Github](https://github.com/neo-ngd/Neo3-GUI) | [Github](https://github.com/neo-project/neo-cli) |

## Neo-GUI and Neo-CLI comparison

|           | Neo-GUI  | Neo-CLI  |
| --------- | :--: | :--: |
| **General** |  |  |
| Graphic interface | ✔   |      |
| Command line interface |      | ✔   |
| Query blocks/transactions/assets | ✔   |      |
| **Wallet** |  |  |
| Create wallet | ✔   | ✔   |
| Open wallet | ✔   | ✔ |
| Import/Export key pair | ✔   | ✔   |
| Import mnemonics into wallet | ✔   |    |
| Upgrade wallet file |    | ✔   |
| Show all key pairs | ✔   | ✔   |
| Show all addresses | ✔   | ✔   |
| Show all assets | ✔   | ✔   |
| Transfer | ✔   | ✔   |
| Claim GAS | ✔   | ✔ |
| Create address | ✔   | ✔   |
| Create multi-party signed address | ✔   | ✔ |
| Generate multiple addresses |      | ✔   |
| Change wallet password | ✔   | ✔    |
| Delete address | ✔   |     |
| **Contract** |  |  |
| Query contract | ✔   |    |
| Deploy contract | ✔   | ✔   |
| Invoke contract | ✔   | ✔   |
| **Advanced** |  |  |
| Consensus nodes election | ✔   |      |
| Voting | ✔   |      |
| Custom transaction construction | ✔   |  |
| Signature | ✔   | ✔ |
| Data conversion | ✔   |  |
| JSON-RPC |      | ✔   |
| Participate in blockchain consensus |      | ✔   |

## NEO-CLI security policy

To enable an external program to access the node API, you need to open the firewall port. 

> [!CAUTION]
>
> To avoid the significant security risk, a whitelist or firewall must be used to block external server requests.

Neo-CLI does not provide the function to remotely switching on/off the wallet, and it does not verify the process when opening a wallet. Therefore, you should set your own security policies. The wallet must be kept open all the time to respond to the withdrawal requests of users. For security reasons, the wallets should be run in an independent server on which the firewall is configured properly, as shown below. 

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |



