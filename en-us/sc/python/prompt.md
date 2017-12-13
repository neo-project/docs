# Using Prompt

Prompt is the default interface for running and interacting with the NEO blockchain.

## prompt.py

Start prompt.py on TestNet:

```
$ python prompt.py
```

### Syntax

`prompt.py [-h][-m] [-p][-c CONFIG] [-t {dark,light}][--version]`

**Optional arguments**

- **-h, --help**

  Shows this help message and exit

- **-m, --mainnet**

  Uses MainNet instead of the default TestNet

- **-p, --privnet**

  Uses PrivNet instead of the default TestNet

- **-c CONFIG, --config CONFIG**

  Uses a specific config file

- **-t {dark,light}, --set-default-theme {dark,light}**

  Sets the default theme to be loaded from the config file. Default: 'dark'

- **--version**

  Shows program's version number and exit

## Wallet operations

The following table lists all the available wallet commands. 

| Command                                  | Description                              |
| ---------------------------------------- | ---------------------------------------- |
| `create wallet <wallet_path>`            | Create a wallet file                     |
| `open wallet <wallet_path>`              | Open a wallet file                       |
| `wallet`                                 | Inspect a wallet                         |
| `wallet <verbose> < rebuild> <rebuild block_height>` | Rebuild wallet index                     |
| `wallet migrated`                        | Migrate your wallet                      |
| `export wif <address>`                   | Export a private key                     |
| `export nep2 <address>`                  | Export an address as [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) encrypted private key |
| `import wif <WIF>`                       | Import a private key                     |
| `import nep2 <address>`                  | Import an address as [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) encrypted private key |
| `import watch_addr <address>`            | Import a watch only address              |
| `import contract_addr <script_hash> <pubkey>` | Import a smart contract address          |
| `send <asset_ID> <address> <amount> [from_address]` | Send assets to the specified address     |
| `wallet delete_addr <address>`           | Delete an address                        |

### Details and examples

**Create a wallet**

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

**Open a wallet**

```
neo> open wallet path/to/walletfile
[Password]> ***********
Opened wallet at path/to/walletfile
neo>

```

**Inspect a wallet**

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

**Rebuild Wallet Index**

If your wallet is behaving unexepectedly or you have imported a new address into your wallet, it is a good idea to rebuild your wallet index.  This will sync the wallet from the beginning of the chain.  Optionally, you can specify a block number to start the resync at

```
neo> wallet rebuild 700000
restarting at 700000
neo>

```

**Migrate your wallet**

If there have been changes to the wallet data model, you may need to migrate your wallet

```
neo> wallet migrated
migrated wallet
neo>

```

**Import WIF**

You may want to import a [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) key to add an address to your wallet

```
neo> import wif KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Imported key KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Pubkey: 303263383231666338336465373331313039633435653034346136353863386631313337623730303461396232323237613335653262353566613061313630323731
neo>

```

**Export WIF**

You may want to export a [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) key from your wallet to use in another program. Specify the address of the `WIF` you would like to export.

```
neo> export wif AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Wallet Password]> ***********
WIF key export: KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
neo>

```

**Export NEP2 Passphrase protected WIF**

You can export an address as [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) encrypted private key like this:

```
neo> export nep2 AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
[Wallet Password]> ***********
[Key Password 1]> ******************
[Key Password 2]> ******************
NEP2 key export: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
neo>
```

**Import NEP2 Passphrase protected WIF**

You can import a [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) encrypted private key like this:

```
neo> import nep2 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
[Key Password]> ******************
Imported nep2 key: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
Pubkey: 303236323431653765323662333862623731353462386164343934353862393766623163343739373434336463393231633563613537373466353131613262626663

```

**Import *watch only* address**

A **watch only** address is any address that you do not have the public key for that you may want to observe. A **watch only** address can be deleted just like a normal address.

```
neo> import watch_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>

```

**Import a Smart Contract address**

You may have a smart contract which has been deployed that you want to use funds from.  Depending on how it is programmed, it may allow you to use funds from it as if it were your own.  In that case, you can import a contract address by specifying the `script_hash` of the contract and the `public key` of the address in your wallet you want the contract associated with.  A contract address can be deleted from your wallet in the same way as a normal address.

```
# import contract_addr {script_hash} {pubkey}
neo> import contract_addr 3c62006802d895974069a1d96398a04b4703f0f8 027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef
Added contract addres AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG to wallet
neo>
```

**Delete address**

```
neo> wallet delete_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
Deleted address AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

**Extra notes**

To run the prompt on mainnet, you can use the cli argument `-m`:

```
$ python prompt.py -h
usage: prompt.py [-h] [-m] [-c CONFIG]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         use MainNet instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file

```

On OSX, if you would like to run the process in the background, even when your computer is sleeping, you can use the built in `caffeinate` command

```
caffeinate python prompt.py
```

## Sending Assets

### Syntax

```
send <asset_name> <address to> <amount> [from_addr]
```

### Example - Basic send

In this case, assets is chosen from your addresses for you, and may come from multiple addresses.  The `change_address` of the transaction is one of the addresses in your wallet.

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11
[Password]> ***********
Relayed Tx: 468e294b11a9f65cc5e2c372124877472eebf121befb77ceed23a84862a606d3
neo>
```

### Example - Send from

You may also specify a particular address to send assets from. This is especially useful when sending from contract addresses.

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11 --from-addr=AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Password]> ***********
Relayed Tx: a43dfb30af63bd0e5a510b05f02b3d40932af26d4564e040e3812ce78e76ce71
neo>
```

## NEP5 Tokens

### Import NEP5 compliant token

You may want to observe or interact with `NEP5` Tokens with your wallet.  To do so, you must first register your wallet to observe a token, as shown below.

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