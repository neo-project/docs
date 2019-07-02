# プロンプトの使用

プロンプトは、NEOブロックチェーンを動かしたり、NEOブロックチェーンと相互作用するための、デフォルトのインターフェイスです。

## prompt.py

prompt.pyをテストネットで開始します。

```
$ python prompt.py
```

### Syntax

`prompt.py [-h][-m] [-p][-c CONFIG] [-t {dark,light}][--version]`

**オプションの実引数（アーギュメント）**

- **-h, --help**
  
  このヘルプメッセージを表示して終了します。

- **-m, --mainnet**
  
  デフォルトのテストネットの代わりにメインネットを使用します。

- **-p, --privnet**
  
  デフォルトのテストネットの代わりにPrivNetを使用します。

- **-c CONFIG, --config CONFIG**
  
  特定のコンフィグファイルを使用します。

- **-t {dark,light}, --set-default-theme {dark,light}**
  
  コンフィグファイルからデフォルトのテーマがロードされるように設定します。デフォルト: 'dark'

- **--version**

  プログラムのバージョンナンバーを表示して終了します。

## ウォレットの操作

使用できるすべてのウォレットコマンドを、下の表に示します。

| コマンド                                  | 説明                              |
| ---------------------------------------- | ---------------------------------------- |
| `create wallet <wallet_path>`            | ウォレットファイルを作成する                     |
| `open wallet <wallet_path>`              | ウォレットファイルを開く                       |
| `wallet`                                 | ウォレットを調べる                         |
| `wallet <verbose> < rebuild> <rebuild block_height>` | ウォレットのインデックスを再構築する                     |
| `wallet migrated`                        | ウォレットを移行させる                      |
| `export wif <address>`                   | 秘密鍵をエクスポートする                     |
| `export nep2 <address>`                  | [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)の暗号化した秘密鍵としてアドレスをエクスポートする |
| `import wif <WIF>`                       | 秘密鍵をインポートする                     |
| `import nep2 <address>`                  | [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)の暗号化した秘密鍵としてアドレスをインポートする |
| `import watch_addr <address>`            | 閲覧専用アドレスをインポートする              |
| `import contract_addr <script_hash> <pubkey>` | スマートコントラクトのアドレスをインポートする          |
| `send <asset_ID> <address> <amount> [from_address]` | 特定のアドレスにアセットを送る     |
| `wallet delete_addr <address>`           | アドレスを削除する                        |

### 詳細と実例

**ウォレットを作成する**

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

**ウォレットを開く**

```
neo> open wallet path/to/walletfile
[Password]> ***********
Opened wallet at path/to/walletfile
neo>

```

**ウォレットを調べる**

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

**ウォレットのインデックスを再構築する**

ウォレットが予期しない挙動を示した場合、あるいは、新しいアドレスをウォレットにインポートした場合、ウォレットインデックスを再構築するのが理想です。これにより、チェーンの初めからウォレットを同期することができます。オプションとして、次のように、再同期を開始したいブロック番号を指定することもできます。

```
neo> wallet rebuild 700000
restarting at 700000
neo>

```

**ウォレットを移行させる**

ウォレットのデータモデルに変更を加えた場合、ウォレットを移行させる必要があるかもしれません。

```
neo> wallet migrated
migrated wallet
neo>

```

**WIFをインポートする**

ウォレットにアドレスを追加するために、[WIF](https://en.bitcoin.it/wiki/Wallet_import_format)鍵をインポートする。

```
neo> import wif KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Imported key KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Pubkey: 303263383231666338336465373331313039633435653034346136353863386631313337623730303461396232323237613335653262353566613061313630323731
neo>

```

**WIFをエクスポートする**

別のプログラムで使っているウォレットからWIF鍵をエクスポートしたいときは、エクスポートしたい[WIF](https://en.bitcoin.it/wiki/Wallet_import_format)のアドレスを指定します。

```
neo> export wif AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Wallet Password]> ***********
WIF key export: KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
neo>

```

**NEP2のパスフレーズで保護されたWIFのエクスポート**

下のように、[NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)の暗号化された秘密鍵として、アドレスをエクスポートします。

```
neo> export nep2 AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
[Wallet Password]> ***********
[Key Password 1]> ******************
[Key Password 2]> ******************
NEP2 key export: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
neo>
```

**NEP2のパスフレーズで保護されたWIFのインポート**

下のように、[NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)の暗号化された秘密鍵をインポートできます。

```
neo> import nep2 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
[Key Password]> ******************
Imported nep2 key: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
Pubkey: 303236323431653765323662333862623731353462386164343934353862393766623163343739373434336463393231633563613537373466353131613262626663

```

**閲覧専用アドレスのインポート**

**閲覧専用アドレス**は、閲覧したいアドレスのうち、パブリックキーを持っていないようなアドレスのことです。**閲覧専用アドレス**は、通常のアドレスと同様に削除することができます。

```
neo> import watch_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>

```

**スマートコントラクトアドレスのインポート**

ファンドの利用を目的としているような、すでに展開されているスマートコントラクトを持つことも可能です。プログラムのされ方によっては、自分が所有するかのごとく、ファンドをそのスマートコントラクトから利用することができるでしょう。この場合、コントラクトと紐づけたいウォレットにおけるコントラクトの`script_hash`とアドレスの`public key`を指定することで、コントラクトアドレスをインポートすることができます。通常のアドレスと同様に、コントラクトアドレスはウォレットから削除することができます。

```
# import contract_addr {script_hash} {pubkey}
neo> import contract_addr 3c62006802d895974069a1d96398a04b4703f0f8 027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef
Added contract addres AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG to wallet
neo>
```

**アドレスの削除**

```
neo> wallet delete_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
Deleted address AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

**その他**

メインネット上でプロンプトを実行するには、cliの引数`-m`を使用できます。

```
$ python prompt.py -h
usage: prompt.py [-h] [-m] [-c CONFIG]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         use MainNet instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file

```

OSXの場合、バックグラウンドでプロセスを実行したいとき、コンピューターがスリープしている状態でも、`caffeinate`コマンドでの構築を使用することができます。

```
caffeinate python prompt.py
```

## アセットの送信

### Syntax

```
send <asset_name> <address to> <amount> [from_addr]
```

### 実例 - 基本的な送信

この場合、自分のアドレスからアセットを選択します。複数のアドレスが存在する場合もあります。トランザクションの`change_address`は、自分のウォレットにある複数のアドレスのうちのひとつです。

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11
[Password]> ***********
Relayed Tx: 468e294b11a9f65cc5e2c372124877472eebf121befb77ceed23a84862a606d3
neo>
```

### 実例 - 送信元

アセットの送信元を、特定のアドレスに指定することもできます。とくに、コントラクトアドレスからの送信を行う場合に便利です。

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11 --from-addr=AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Password]> ***********
Relayed Tx: a43dfb30af63bd0e5a510b05f02b3d40932af26d4564e040e3812ce78e76ce71
neo>
```

## NEP5トークン

### NEP5対応トークンのインポート

自分のウォレットに紐づけた`NEP5`トークンを確認したり、相互作用をさせたいときは、まずはじめに自分のウォレットを登録する必要があります。これは、以下のようにして行います。

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
