# Introduzione ai Nodi NEO
I nodi che memorizzano tutta la blockchain sono chiamati "full-nodes". Essi sono connessi alla blockchain tramite una rete P2P. Tutti i nodi nella blockchain sono uguali, agiscono sia come interfaccia client sia come server.

Ci sono due programmi full-node. Il primo é Neo-GUI, contenente tutte le funzioni basiche di un client utente, inclusa un'interfaccia grafica per gli utenti di NEO. Il secondo é Neo-CLI: Esso provvede un'API esterna per le funzioni basiche del wallet ed é destinato agli sviluppatori NEO. Inoltre, aiuterá altri nodi a guadagnare il consenso nella rete e sará coinvolto nella generazione di nuovi blocchi.

Il [protocollo di rete](protocollo-di-rete.md) NEO fornirá un'API di basso livello per determinati tipi di transazione che non sono attualmente supportati dal CLI, come richiedere GAS o inviare NEO senza un wallet aperto. 

## Indirizzo di Download del Nodo NEO

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Distribuzioni | [Sito Web Ufficiale](https://www.neo.org/download) o [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Codice Sorgente | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Comparazione tra le Funzioni del Nodo GUI e il Nodo CLI

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Interfaccia Grafica | ✅    |      |
| Interfaccia a Linea Di Comando |      | ✅    |
| Creazione di un Wallet | ✅    | ✅    |
| Wallet Aperto | ✅    | ✅  |
| Ricostruzione dell'Indice del Wallet | ✅    | ✅    |
| Visualizzazione Coppie Di Chiavi | ✅    | ✅    |
| Importazione/Esportazione Della Coppia Di Chiavi| ✅    | ✅    |
| Mostrare Tutti Gli Indirizzi | ✅    | ✅    |
| Mostrare Tutti Gli Asset | ✅    | ✅    |
| Creazione di un Indirizzo | ✅    | ✅    |
| Trasferimento | ✅    | ✅    |
| Transazione (Asset Swap)  | ✅    |      |
| Generazione di un Contratto Con Firma Multi-parte | ✅    |      |
| Creazione di uno Smart Contract Personalizzato | ✅    |      |
| Firma | ✅    |      |
| Elezione di un Nodo di Consenso | ✅    |      |
| Votazione | ✅    |      |
| Registrazione di Asset | ✅    |      |
| Distribuzione di Asset | ✅    |      |
| Estrazione di NEO | ✅    |      |
| Indirizzi Generati in Lotto   |      | ✅    |
| JSON-RPC |      | ✅    |
| Consenso dei Blocchi Partecipanti |      | ✅    |

## Descrizione Delle Porte

Se si vuole far accedere un programma esterno all'API del nodo, é necessario aprire una porta nel firewall. Quanto segue é una descrizione della porta che puó essere impostata Completamente Aperta o Aperta Su Richiesta.

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Per maggiori informazioni, per favore fare riferimento a [test network](testnet.md).
