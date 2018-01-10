# Rete Test

La TestNet è un ambiente dove l'utente può sviluppare, commissionare e testare programmi. Per testare programmi sulla testnet occorre pagare la commissione di rete in GAS testnet (non GAS reale!!). NEO e GAS testnet possono essere richiesti senza costi, sul sito web ufficiale. 

Tutta la blockchain della rete test è indipendente da quella delle rete principale. Per sviluppo un semplice smart contract o la registrazione di un asset, l'uso della rete test dovrebbe bastare. Successivamente al completamento dei test, lo sviluppo può essere spostato sulla mainnet online di NEO.

Se sei uno sviluppatore, puoi chiedere GAS sulla Testnet qui: https://www.neo.org/Testnet/Create

## Carattestiche della TestNet 

1. Registrazione di asset, distribuzione di asset, esecuzione dei contratti, etc. (senza consumare soldi veri)
2. Esecuzione globalizzata nell'ambiente internet. 
3. Test dei blocchi della rete; Transazioni e altre informazioni possono essere facilmente viste nel browser della blockchain.
4. Esecuzione degli smart contract nell'ambiente test, dove ogniuno nel mondo può implementarlo.
5. La rete test non può essere utilizzata per applicazioni commerciali come ambiente di sbarco.

## Scaricamento dei Client

Il client della rete in test è uguale al client della rete principale. Modificando la configurazione del file del client, lo stesso può essere scambiato tra la rete principale e la rete in test.

Riferimento: [Introduzioni ai Nodi NEO](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Distribuzioni | [Website ufficiale](https://www.neo.org/download) o [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Codice sorgente| [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Metodo di Commutazione alla Rete Test 

1. Copiare i componenti della directory del programma sotto `protocol.testnet.json` in ` protocol.json` come mostrato.

![image](/assets/testnet_1.png)

2. Copiare i contenuti della directory del programma (GUI) `config.testnet.json` in `config.json` come mostrato in figura.

![image](/assets/testnet_2_v2.png)
