# Rete di Test

La TestNet è un ambiente dove l'utente può sviluppare, commissionare e testare programmi. Per testare programmi sulla testnet occorre pagare la commissione di rete in GAS testnet (non GAS reale!!). NEO e GAS testnet possono essere richiesti senza costi, sul sito web ufficiale. 

Tutta la blockchain della rete di test è indipendente da quella delle rete principale. Per lo sviluppo di un semplice smart contract o per la registrazione di un asset, l'uso della rete di test dovrebbe bastare. Successivamente al completamento dei test, lo sviluppo può essere spostato sulla mainnet o rete principale online di NEO.

Se sei uno sviluppatore, puoi chiedere GAS per la TestNet qui: https://www.neo.org/Testnet/Create

## Carattestiche della TestNet 

1. Registrazione di asset, distribuzione di asset, esecuzione dei contratti, ecc. (Non consuma soldi veri)
2. Implementazione globalizzata nell'ambiente internet. 
3. Test dei blocchi della rete; Transazioni e altre informazioni possono essere facilmente viste nel browser della blockchain.
4. L'implementazione degli smart contract nell'ambiente test, dove chiunque nel mondo può implementarlo.
5. La rete di test non può essere utilizzata per applicazioni commerciali come ambiente di sbarco.

## Download del Client

Il client della rete di test è uguale al client della rete principale. Modificando il file di configurazione del client, questo può essere commutato tra la rete principale e la rete di test.

Riferimento: [Introduzioni ai Nodi NEO](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Distribuzioni | [Sito ufficiale](https://www.neo.org/download) o [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Codice sorgente| [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Metodo di Commutazione alla Rete di Test 

1. Copiare il contenuto della directory del programma sotto il `protocol.testnet.json` in ` protocol.json` come mostrato.

![image](/assets/testnet_1.png)

2. Copiare il contenuto della directory del programma (GUI) `config.testnet.json` in `config.json` come mostrato in figura.

![image](/assets/testnet_2_v2.png)
