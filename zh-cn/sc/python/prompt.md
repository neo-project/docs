# 使用命令行与NEO区块链交互

Prompt 是用于运行和与NEO区块链交互的默认界面。

在测试网运行prompt.py，如下所示：

```
$ python prompt.py
```

### 句法

`prompt.py [-h][-m] [-p][-c CONFIG] [-t {dark,light}][--version]`

**可选参数**

- **-h, --help**

  显示此帮助信息并退出。

- **-m, --mainnet**

  从默认的测试网切换到主网。

- **-p, --privnet**

  从默认的测试网切换到私网。

- **-c CONFIG, --config CONFIG**

  使用特定的配置文件。

- **-t {dark,light}, --set-de。fault-theme {dark,light}**

  设置从配置文件加载的默认主题。默认："dark"。

- **--version**

  显示程序的版本号并退出。

## 钱包操作

下表列出了所有可用的钱包命令。

| 命令                                       | 描述                                       |
| ---------------------------------------- | ---------------------------------------- |
| `create wallet <wallet_path>`            | 创建钱包文件                                   |
| `open wallet <wallet_path>`              | 打开钱包文件                                   |
| `wallet`                                 | 检查钱包                                     |
| `wallet <verbose> < rebuild> <rebuild block_height>` | 重建钱包索引                                   |
| `wallet migrated`                        | 迁移你的钱包                                   |
| `export wif <address>`                   | 导出私钥                                     |
| `export nep2 <address>`                  | 将地址导出为[NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)加密私钥 |
| `import wif <WIF>`                       | 导入私钥                                     |
| `import nep2 <address>`                  | 将地址导入为[NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)加密私钥 |
| `import watch_addr <address>`            | 导入 watch only 地址                         |
| `import contract_addr <script_hash> <pubkey>` | 导入智能合约地址                                 |
| `send <asset_ID> <address> <amount> [from_address]` | 将资产发送到指定的地址                              |
| `wallet delete_addr <address>`           | 删除地址                                     |

### 解释与示例

**创建钱包**

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

**打开钱包**

```
neo> open wallet path/to/walletfile
[Password]> ***********
Opened wallet at path/to/walletfile
neo>

```

**检查钱包**

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

**重建钱包索引**

如果您的钱包出现异常，或者您已将新地址导入钱包，则可能需要重建钱包索引，从区块头同步钱包。也可以指定一个区块号开始重新同步，如下所示：

```
neo> wallet rebuild 700000
restarting at 700000
neo>

```

**迁移钱包**

如果钱包数据模型发生更改，则可能需要迁移钱包，如下所示：

```
neo> wallet migrated
migrated wallet
neo>

```

**导入私钥**

您可能需要导入一个WIF私钥来添加地址到您的钱包，如下所示：

```
neo> import wif KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Imported key KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Pubkey: 303263383231666338336465373331313039633435653034346136353863386631313337623730303461396232323237613335653262353566613061313630323731
neo>

```

**导出私钥**

您可能需要从钱包导出 [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) 私钥用于另一个程序。指定要导出的 `WIF` 地址，如下所示：

```
neo> export wif AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Wallet Password]> ***********
WIF key export: KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
neo>

```

**导出NEP2密码保护的私钥**

您可以将地址导出为NEP2加密私钥，如下所示：

```
neo> export nep2 AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
[Wallet Password]> ***********
[Key Password 1]> ******************
[Key Password 2]> ******************
NEP2 key export: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
neo>
```

**导入NEP2密码保护的私钥**

您可以将地址导入为NEP2加密私钥，如下所示：

```
neo> import nep2 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
[Key Password]> ******************
Imported nep2 key: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
Pubkey: 303236323431653765323662333862623731353462386164343934353862393766623163343739373434336463393231633563613537373466353131613262626663

```

**导入 *watch only* 地址**

**watch only** 是一种您没有公钥但想观察的地址。**watch only** 地址可以像普通地址一样删除。

```
neo> import watch_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>

```

**导入智能合约地址**

您可能想要使用已部署的智能合约中的资金。根据合约编程，如果其允许您像使用自己的资金一样使用合约中的资金，则您可以通过指定合约的script_hash，以及您希望与合约关联的钱包中地址的公钥来导入合约地址。合约地址可以像钱包中的普通地址一样删除。

```
# import contract_addr {script_hash} {pubkey}
neo> import contract_addr 3c62006802d895974069a1d96398a04b4703f0f8 027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef
Added contract addres AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG to wallet
neo>
```

**删除地址**

```
neo> wallet delete_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
Deleted address AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

**其他说明**

要在主网运行prompt，可以使用cli参数 `-m`：

```
$ python prompt.py -h
usage: prompt.py [-h] [-m] [-c CONFIG]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         use MainNet instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file

```

在 OSX 上，如果您想要在后台运行进程，即使计算机正在休眠，也可以使用内置的caffeinate命令：

```
caffeinate python prompt.py
```

## 发送资产

### 句法

```
send <asset_name> <address to> <amount> [from_addr]
```

### 示例 - 不指定地址发送

在本示例中，发送的资产来自于您的地址，可能是多个地址。 `change_address` 是您钱包的中的某个地址。

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11
[Password]> ***********
Relayed Tx: 468e294b11a9f65cc5e2c372124877472eebf121befb77ceed23a84862a606d3
neo>
```

### 示例 - 指定地址发送

也可以指定一个特定的地址来发送资产，如从合约地址发送资产。

```python
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11 --from-addr=AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Password]> ***********
Relayed Tx: a43dfb30af63bd0e5a510b05f02b3d40932af26d4564e040e3812ce78e76ce71
neo>
```

## NEP5 Tokens

### 导入 NEP5 代币

您可以使用钱包观察 `NEP5` 代币并与之交互，为此，您需要首先注册钱包以观察代币，如下所示：

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