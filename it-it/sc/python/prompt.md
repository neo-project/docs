## Operazioni con il wallet

La seguente tabella elenca tutti i comandi disponibili del wallet. 

| Comando                                  | Descrizione                              |
| ---------------------------------------- | ---------------------------------------- |
| `create wallet <wallet_path>`            | Creare un file wallet                    |
| `open wallet <wallet_path>`              | Aprire un file wallet                      |
| `wallet`                                 | Ispezionare un wallet                         |
| `wallet <verbose> < rebuild> <rebuild block_height>` | Ricostruire l'indice del wallet                     |
| `wallet migrated`                        | Migrare il tuo wallet                      |
| `export wif <address>`                   | Esportare la chiave privata                     |
| `export nep2 <address>`                  | Esportare un indirizzo come [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) chiave privata criptta |
| `import wif <WIF>`                       | Importare una chiave privata                     |
| `import nep2 <address>`                  | Importare un indirizzo come [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) chiave privata criptata |
| `import watch_addr <address>`            | Importare un indirizzo "watch only"              |
| `import contract_addr <script_hash> <pubkey>` | Importare l'indirizzo di uno smart contract          |
| `send <asset_ID> <address> <amount> [from_address]` | Invia assets all'indirizzo specificato     |
| `wallet delete_addr <address>`           | Elimina un indirizzo                       |
