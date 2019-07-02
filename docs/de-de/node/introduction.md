# NEO Node - Einführung

Nodes, die die gesamte Blockchain speichern, werden "Full Nodes" genannt. "Full Nodes" sind über ein Peer-to-Peer Netzwerk mit der Blockchain verbunden. Alle Nodes werden vom Netzwerk gleichwertig behandelt und agieren zeitgleich als Clientinterface und Server.

Es gibt zur Zeit zwei "Full Node"-Programme: NEO-GUI und NEO-CLI. NEO-GUI hat alle Basisfunktionen eines Userclients, inklusive einer grafischen Oberfläche und ist gedacht für NEO Anwender. NEO-CLI bietet eine externe API für einfache Wallet-Funktionen und ist für NEO Entwickler gedacht. NEO-CLI hilft außerdem anderen Nodes bei der Konsensfindung und ist außerdem bei der Schaffung neuer Blöcke involviert.

Das NEO [Netzwerk-Protokoll](network-protocol.md) bietet eine API für eine Transaktionsarten, die zur Zeit noch nicht von NEO-CLI unterstützt werden, unter anderem GAS Claim Transaktionen oder NEO Transaktionen ohne eine geöffnete Wallet.

## NEO Node Download Adressen:

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Offizielle Website](https://www.neo.org/download) oder [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Quellcode | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Vergleich von NEO-GUI- und NEO-CLI-Node Funktionen

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Grafische Oberfläche | ✅    |      |
| Command Line Interface |      | ✅    |
| Wallet generieren | ✅    | ✅    |
| Wallet öffnen | ✅    | ✅  |
| Wallet Index rekonstruieren | ✅    | ✅    |
| Schlüsselpaare anzeigen | ✅    | ✅    |
| Import/Export von Schlüsselpaaren | ✅    | ✅    |
| Alle Adressen anzeigen | ✅    | ✅    |
| Alle Assets anzeigen | ✅    | ✅    |
| Adresse erzeugen | ✅    | ✅    |
| Transfer | ✅    | ✅    |
| Transaktion "(Asset swap)"  | ✅    |      |
| Einen "Multi-party signature" Contract erzeugen | ✅    |      |
| Einen personalisierten "Smart Contract" erzeugen | ✅    |      |
| Signatur | ✅    |      |
| Wahlfunktion für Consensus-Nodes | ✅    |      |
| Voting | ✅    |      |
| Assets registrieren | ✅    |      |
| Assets herausgeben | ✅    |      |
| Extraktion von NEO | ✅    |      |
| "Batch Generation" Addresse  |      | ✅    |
| JSON-RPC |      | ✅    |
| Teilnahme an Konsensbildung |      | ✅    |

## Verwendete Ports:

Wenn externe Programme die API der Node nutzen sollen, müssen folgende Ports der Firewall geöffnet werden.

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Für weitergehende Informationen weisen wir auf das [Test Netzwerk](testnet.md) hin.
