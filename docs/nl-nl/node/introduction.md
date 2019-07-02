# NEO Node Introductie
Nodes die de gehele blockchain bijhouden heten "*full-nodes*". Ze zijn verbonden met de blockchain door middel van een P2P netwerk. Alle nodes binnen het blockchain-netwerk zijn gelijk; ze fungeren tegelijkertijd als een client interface en als server.

Er zijn twee full-node programma's. Het eerste is Neo-GUI; deze heeft alle basisfuncties van een gebruikers-interface, inclusief een grafische interface, en is bedoeld voor NEO-gebruikers. Het tweede is Neo-CLI, welke een externe API verschaft voor basale wallet-functies en welke bedoeld is voor NEO-ontwikkelaars. Deze zal ook andere nodes helpen bij het bereiken van een consensus binnen het netwerk, en is betrokken bij het genereren van nieuwe blocks.

Het NEO [netwerkprotocol](network-protocol.md) verstrekt een simpele API voor enkele transactietypes die momenteel nog niet worden ondersteund door de CLI, zoals het claimen van GAS of het zenden van NEO zonder een geopende wallet.

## Neo Node Downloads

|          |                    Neo-GUI                       |                      Neo-CLI                     |
| -------- | :----------------------------------------------- | ------------------------------------------------ |
| Versies  | [Officiële website](https://www.neo.org/download) of [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Broncode | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Vergelijking tussen Functionaliteit van GUI- en CLI-nodes

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
| Create a custom smart contract | ✅    |      |
| Signature | ✅    |      |
| Election Consensus Node | ✅    |      |
| Voting | ✅    |      |
| Register assets | ✅    |      |
| Distribution of assets | ✅    |      |
| Extraction of NEO | ✅    |      |
| Batch Generation Address  |      | ✅    |
| JSON-RPC |      | ✅    |
| The consensus of the participating blocks |      | ✅    |

## Port Omschrijving

Als je wilt dat een extern programma de API van de node kan aanspreken, is een open firewall-port nodig. De volgende ports kunnen op 'volledig open' of op 'open-op-aanvraag' worden gezet.

|                    | Main Net     | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Bekijk voor meer informatie de documentatie van het [testnetwerk](testnet.md).
