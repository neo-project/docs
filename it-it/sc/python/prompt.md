# Utilizzare il prompt

Il Prompt è l'interfaccia predefinita per l'esecuzione e l'interazione con la blockchain NEO.

## prompt.py

Avvia prompt.py sulla TestNet:

```
$ python prompt.py
```

### Sintassi

`prompt.py [-h][-m] [-p][-c CONFIG] [-t {dark,light}][--version]`

**Argomenti opzionali**

- **-h, --help**

  Mostra questo messaggio di aiuto ed esci.

- **-m, --mainnet**

  Utilizza la MainNet invece della predefinita TestNet

- **-p, --privnet**

  Utilizza PrivNet invece della predefinita TestNet

- **-c CONFIG, --config CONFIG**

  Usa un file config specifico

- **-t {dark,light}, --set-default-theme {dark,light}**

  Imposta il tema predefinito da caricare dal file di configurazione. Il predefinito è: 'dark'

- **--version**

  Mostra il numero di versione del programma ed esci

## Operazioni con il wallet

La seguente tabella elenca tutti i comandi disponibili del wallet. 

| Comando                                  | Descrizione                              |
| ---------------------------------------- | ---------------------------------------- |
| `create wallet <wallet_path>`            | Crea un file wallet                    |
| `open wallet <wallet_path>`              | Apre un file wallet                      |
| `wallet`                                 | Ispeziona un wallet                         |
| `wallet <verbose> < rebuild> <rebuild block_height>` | Ricostruisce l'indice del wallet                     |
| `wallet migrated`                        | Migra il tuo wallet                      |
| `export wif <address>`                   | Esporta la chiave privata                     |
| `export nep2 <address>`                  | Esporta un indirizzo come [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) chiave privata criptata |
| `import wif <WIF>`                       | Importa una chiave privata                     |
| `import nep2 <address>`                  | Importa un indirizzo come [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) chiave privata criptata |
| `import watch_addr <address>`            | Importa un indirizzo "watch only"              |
| `import contract_addr <script_hash> <pubkey>` | Importa l'indirizzo di uno smart contract          |
| `send <asset_ID> <address> <amount> [from_address]` | Invia asset all'indirizzo specificato     |
| `wallet delete_addr <address>`           | Elimina un indirizzo                       |

### Dettagli ed Esempi

**Creare un wallet**

```
neo> create wallet path/to/walletfile
[Password 1]> **********
[Password 2]> **********
Wallet {
    "addresses": [
        "AayaivCAcYnM8q79JCrfpRGXrCEHJRN5bV"
    ],
    "claims": {
            "available": 0.0,
        "unavailable": 0.0
    },
    "tokens": [],
    "height": 0,
    "synced_balances": [],
    "path": "Wallets/blahblah.db3",
    "public_keys": [
        {
            "Address": "AayaivCAcYnM8q79JCrfpRGXrCEHJRN5bV",
            "Public Key": "027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef"
        }
    ],
    "percent_synced": 0
}
neo>

```

**Aprire un wallet**

```
neo> open wallet path/to/walletfile
[Password]> ***********
Opened wallet at path/to/walletfile
neo>

```

**Ispezionare un wallet**

```
neo> wallet
Wallet {
    "addresses": [
        "AayaivCAcYnM8q79JCrfpRGXrCEHJRN5bV"
    ],
    "claims": {
        "available": 0.0,
        "unavailable": 0.0
    },
    "tokens": [],
    "height": 75500,
    "synced_balances": [],
    "path": "Wallets/blahblah.db3",
    "public_keys": [
        {
            "Address": "AayaivCAcYnM8q79JCrfpRGXrCEHJRN5bV",
            "Public Key": "027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef"
        }
    ],
    "percent_synced": 9
}

```

**Ricostruire l'indice del wallet**

Se il tuo wallet si sta comportando in modo imprevisto o se hai importato un nuovo indirizzo nel tuo wallet, è una buona idea ricostruire l'indice del tuo wallet. Cioé far sincronizzare il wallet dall'inizio della chain. Opzionalmente, é anche possibile specificare un numero di un blocco in modo da iniziare la sincronizzazione da quel livello.

```
neo> wallet rebuild 700000
restarting at 700000
neo>

```

**Migrare il tuo wallet**

Se ci sono stati cambiamenti nel modello di dati del wallet, potresti aver bisogno di migrare il tuo wallet

```
neo> wallet migrated
migrated wallet
neo>

```

**Importare WIF**

Potresti voler importare una chiave [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) per aggiungere un indirizzo al tuo wallet

```
neo> import wif KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Imported key KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Pubkey: 303263383231666338336465373331313039633435653034346136353863386631313337623730303461396232323237613335653262353566613061313630323731
neo>

```

**Esportare WIF**

Potresti voler esportare una chiave [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) dal tuo wallet da usare in un altro programma. Specifica l'indirizzo del `WIF` che vorresti esportare.

```
neo> export wif AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Wallet Password]> ***********
WIF key export: KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
neo>

```

**Esportare il WIF NEP2 protetto da passphrase**

Puoi esportare un indirizzo come chiave privata criptata [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) come questa:

```
neo> export nep2 AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
[Wallet Password]> ***********
[Key Password 1]> ******************
[Key Password 2]> ******************
NEP2 key export: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
neo>
```

**Importare il WIF NEP2 protetto da passphrase**

Puoi importare una chiave privata criptata [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) come questa:

```
neo> import nep2 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
[Key Password]> ******************
Imported nep2 key: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
Pubkey: 303236323431653765323662333862623731353462386164343934353862393766623163343739373434336463393231633563613537373466353131613262626663

```

**Importa un indirizzo *watch only* **

Un indirizzo **watch only** è un indirizzo per il quale non hai la chiave pubblica che vorresti osservare. Un indirizzo **watch only** può essere eliminato proprio come un indirizzo normale.

```
neo> import watch_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>

```

**Importa l'indirizzo di uno Smart Contract**

Potresti avere uno smart contract già implementato dal quale vorresti utilizzarne i fondi. Dipendendo da come è stato programmato, potrebbe esserti permesso di usare i fondi come se fossero tuoi. In questo caso, puoi importare l'indirizzo di un contratto specificando lo `script_hash` del contratto e la `public key` dell'indirizzo nel tuo wallet con il quale vuoi associare il contratto. L'indirizzo di un contratto può essere eliminato dal tuo wallet nello stesso modo di un normale indirizzo.

```
# import contract_addr {script_hash} {pubkey}
neo> import contract_addr 3c62006802d895974069a1d96398a04b4703f0f8 027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef
Added contract addres AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG to wallet
neo>
```

**Elimina indirizzo**

```
neo> wallet delete_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
Deleted address AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

**Note aggiuntive**

per eseguire il prompt nalla MainNet, puoi usare l'argomento cli `-m`:

```
$ python prompt.py -h
usage: prompt.py [-h] [-m] [-c CONFIG]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         use MainNet instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file

```

Su OSX, se si desidera eseguire il processo in background, anche quando il tuo computer é in standby, é possibile usare il comando `caffeinate`

```
caffeinate python prompt.py
```

## Invio di Assets

### Sintassi

```
send <asset_name> <address to> <amount> [from_addr]
```

### Esempio - Invio semplice

In questo caso, gli asset vengono scelti dai tuoi indirizzi per te e potrebbero provenire da più indirizzi. il `change_address` della transazione è uno degli indirizzi nel tuo wallet.

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11
[Password]> ***********
Relayed Tx: 468e294b11a9f65cc5e2c372124877472eebf121befb77ceed23a84862a606d3
neo>
```

### Esempio - Invia da

Puoi anche specificare un indirizzo particolare dal quale inviare l'asset. Ciò è particolarmente utile quando si invia da indirizzi di contratto.

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11 --from-addr=AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Password]> ***********
Relayed Tx: a43dfb30af63bd0e5a510b05f02b3d40932af26d4564e040e3812ce78e76ce71
neo>
```

## NEP5 Tokens

### Importa un token compatibile con il protocollo NEP5

Potresti voler osservare o interagire con i token `NEP5` con il tuo wallet. Per poterlo fare e osservare un token devi prima registrare il tuo wallet, come mostrato di seguito.

```python
neo> import token f8d448b227991cf07cb96a6f9c0322437f1599b9
added token {
    "name": "NEP5 Standard",
    "script_hash": "f8d448b227991cf07cb96a6f9c0322437f1599b9",
    "decimals": 8,
    "symbol": "NEP5",
   "contract address": "AYhE3Svuqdfh1RtzvE8hUhNR7HSpaSDFQg"
}
neo> wallet
Wallet {
    # truncated ...

    "percent_synced": 100,
    "addresses": [
        "AayaivCAcYnM8q79JCrfpRGXrCEHJRN5bV",
        {
            "balances": {
                "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b": "4051.0",
                "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7": "897.48372409"
            },
            "script_hash": "AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK",
            "votes": [],
            "version": 0,
            "is_watch_only": false,
            "tokens": [
                "[f8d448b227991cf07cb96a6f9c0322437f1599b9] NEP5 : 4519175.65580000"
            ],
            "frozen": false
        },
        {
    }
}
```
