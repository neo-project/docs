# Introduzione ai Nodi NEO
I nodi che memorizzano tutta la blockchain sono chiamati "full-nodes". Essi sono connessi alla blockchain tramite una rete P2P. Tutti i nodi nella blockchain sono uguali, agiscono sia come interfaccia cliente sia come server.

Ci sono due programmi per un full-node. Il primo é Neo-GUI, contenente tutte le funzioni basiche di un client utente, inclusa un'interfaccia grafica per gli utenti di NEO. Il secondo é Neo-CLI: Esso provvede API esterne per un wallet con funzioni basiche ed é inteso per gli sviluppatori di NEO. Inoltre, aiuterá altri nodi a guadagnare consenso nella rete é sará coinvolto nella generazione di nuovi blocchi.

Il [protocollo di rete](protocollo-di-rete.md) NEO fornirá API di basso livello per determinati tipi di transazioni che non sono attualmente supportate da CLI, come richiedere GAS o inviare NEO senza un portafoglio aperto. 

## Indirizzo Download Del Nodo NEO

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Rilasci | [Website Ufficiale](https://www.neo.org/download) o [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Codice Sorgente | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Comparazione Tra Le Funzioni Nodo GUI e Nodo CLI

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Interfaccia Grafica | ✅    |      |
| Interfaccia a Linea Di Comando |      | ✅    |
| Creazione Portafoglio (Wallet) | ✅    | ✅    |
| Portafoglio (Wallet) Aperto | ✅    | ✅  |
| Ricostruzione Indice Portafoglio (Wallet)| ✅    | ✅    |
| Coppie Di Chiavi | ✅    | ✅    |
| Importazione/Esportazione Della Coppia Di Chiavi| ✅    | ✅    |
| Mostra Tutti Gli Indirizzi | ✅    | ✅    |
| Mostra Tutti Gli Asset | ✅    | ✅    |
| Creazione Indirizzo | ✅    | ✅    |
| Trasferimento | ✅    | ✅    |
| Transazione (Asset swap)  | ✅    |      |
| Generare Contratto Con Firma Multiparte | ✅    |      |
| Creazione Smart Contract Personalizzato | ✅    |      |
| Firma | ✅    |      |
| Elezione Nodo di Consenso | ✅    |      |
| Votazione | ✅    |      |
| Registrare Asset | ✅    |      |
| Distribuzione Di Asset | ✅    |      |
| Estrazione Di NEO | ✅    |      |
| Indirizzi Generati in Lotto   |      | ✅    |
| JSON-RPC |      | ✅    |
| Consenso Dei Blocchi Partecipanti |      | ✅    |

## Descrizione Delle Porte

Se si voglia che un nodo esterno acceda alle API, é necessario aprire una porta del firewall. Quanto segue é una descrizione della porta che puó essere impostata Completamente Aperta o Aperta Su Domanda.

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Per maggiori informazioni, perfavore fare riferimento a [test network](testnet.md).
