# 使用命令行与 NEO 区块链交互

Prompt 是用于运行和与 NEO 区块链交互的默认界面。

如下所示：

```
$ np-prompt
NEO cli. Type 'help' to get started

neo>
```

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

#### **创建钱包**

```python
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

#### **打开钱包**

```python
neo> open wallet path/to/walletfile
[Password]> ***********
Opened wallet at path/to/walletfile
neo>
```

#### **检查钱包**

```python
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

#### **重建钱包索引**

如果您的钱包出现异常，或者您已将新地址导入钱包，则可能需要重建钱包索引，从区块头同步钱包。也可以指定一个区块号开始重新同步，如下所示：

```python
neo> wallet rebuild 700000
restarting at 700000
neo>
```

#### **迁移钱包**

如果钱包数据模型发生更改，则可能需要迁移钱包，如下所示：

```python
neo> wallet migrated
migrated wallet
neo>
```

#### **重新加密钱包** 

如果你打开钱包时收到如下信息，则必须重新加密以防止之前的钱包漏洞。

```
Could not open wallet: This wallet is currently vulnerable. Please execute the "reencrypt_wallet.py" script on this wallet before continuing
```

要修复此问题，先使用命令 `exit` 退出 neo prompt，然后运行重新加密脚本：

```
python reencrypt_wallet.py path/to/mywallet.db3
```

 你需要输入密码并使用新名称`path/to/new_mywallet.db3`保存重新加密的钱包。

#### **导入私钥**

您可能需要导入一个WIF私钥来添加地址到您的钱包，如下所示：

```python
neo> import wif KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Imported key KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
Pubkey: 303263383231666338336465373331313039633435653034346136353863386631313337623730303461396232323237613335653262353566613061313630323731
neo>
```

#### **导出私钥**

您可能需要从钱包导出 [WIF](https://en.bitcoin.it/wiki/Wallet_import_format) 私钥用于另一个程序。指定要导出的 `WIF` 地址，如下所示：

```python
neo> export wif AXjaFSP23Jkbe6Pk9pPGT6NBDs1HVdqaXK
[Wallet Password]> ***********
WIF key export: KxP97gujib35PBEnTq78e5NmYVbeaosU4AdguDzZ4tyf6a7W32UM
neo>
```

#### **导出 NEP2 密码保护的私钥**

您可以将地址导出为 NEP2 加密私钥，如下所示：

```python
neo> export nep2 AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
[Wallet Password]> ***********
[Key Password 1]> ******************
[Key Password 2]> ******************
NEP2 key export: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
neo>
```

#### **导入NEP2密码保护的私钥**

您可以将地址导入为 NEP2 加密私钥，如下所示：

```python
neo> import nep2 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
[Key Password]> ******************
Imported nep2 key: 6PYVPVe1fQznphjbUxXP9KZJqPMVnVwCx5s5pr5axRJ8uHkMtZg97eT5kL
Pubkey: 303236323431653765323662333862623731353462386164343934353862393766623163343739373434336463393231633563613537373466353131613262626663
```

#### **导入 *watch only* 地址**

**watch only** 是一种您没有公钥但想观察的地址。**watch only** 地址可以像普通地址一样删除。

```
neo> import watch_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

#### **导入智能合约地址**

您可能想要使用已部署的智能合约中的资金。根据合约编程，如果其允许您像使用自己的资金一样使用合约中的资金，则您可以通过指定合约的script_hash，以及您希望与合约关联的钱包中地址的公钥来导入合约地址。合约地址可以像钱包中的普通地址一样删除。

```python
# import contract_addr {script_hash} {pubkey}
neo> import contract_addr 3c62006802d895974069a1d96398a04b4703f0f8 027973267230b7cba0724589653e667ddea7aa8479c01a82bf8dd398cec93508ef
Added contract addres AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG to wallet
neo>
```

#### **删除地址**

```
neo> wallet delete_addr AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
Deleted address AStZHy8E6StCqYQbzMqi4poH7YNDHQKxvt
neo>
```

## 发送资产

### 从钱包发送

使用以下命令可以从你的钱包发送资产。使用此命令，发送的资产来自于你的某个地址或者多个地址。 `change_address` 是你钱包的中的某个地址。

```python
# syntax send {asset_name} {address to} {amount} ( optional: --from-addr={from_addr})
neo> send gas AeU8kTJxynwkT3q9ao8aDFuaRJBkU3AfFG 11
[Password]> ***********
Relayed Tx: 468e294b11a9f65cc5e2c372124877472eebf121befb77ceed23a84862a606d3
neo>
```

### 从指定地址发送

也可以指定一个特定的地址来发送资产，如从合约地址发送资产。

```python
# syntax send {asset_name} {address to} {amount} ( optional: --from-addr={from_addr})
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

## 在 prompt 中与智能合约交互

查看在 prompt 中与智能合约交互的完整说明:  [Smart Contracts within the Prompt](https://neo-python.readthedocs.io/en/latest/neo/SmartContract/smartcontracts.html#smart-contracts-within-the-prompt)

## 获取 NEO 测试网资产

本节介绍如何通过 [NEO 官方申请表](https://neo.org/testnet) 获取测试网资产。

获取测试网资产需要两步：

1. 在钱包中添加多方签名地址。
2. 将资产转移到你的地址。

### 添加多方签名地址

你需要准备好以下信息：

1. 你从 NEO 收到的电子邮件中提示的公钥
2. 你自己钱包里的公钥。 打开钱包并在提示符下输入 `wallet` 获取所需信息。

```python
neo> wallet
Wallet {
    ...
    "public_keys": [
        {
            "Address": "ANFLgwKG8Eni9gJmKfM7yFXEaWwoGkSUid",
            "Public Key": "037b8992e8384212f82e05c8836816c0f14dff9528397138731638b17d6357021e" <--- take this
        }
    ],
    ...
}
```

然后使用如下命令创建多方签名地址：

```python
neo> import multisig_addr
please specify multisig contract like such: 'import multisig {pubkey in wallet} {minimum # of signatures required} {signing pubkey 1} {signing pubkey 2}...'

neo> import multisig_addr 037b8992e8384212f82e05c8836816c0f14dff9528397138731638b17d6357021e 1 037b8992e8384212f82e05c8836816c0f14dff9528397138731638b17d6357021e 02883118351f8f47107c83ab634dc7e4
ffe29d274e7d3dcf70159c8935ff769beb
[I 180310 16:49:19 UserWallet:191] contract does not exist yet
Added multi-sig contract address ALXEKioZntX73QawcnfcHUDvTVm8qXjAxf to wallet
```

再次检查你的钱包，应该能查看到余额（特别是查看 synced_balances ）。如果没有看到新增余额，请运行`wallet rebuild` 并等待它完全同步后再次尝试。

```python
neo> wallet
Wallet {
    "path": "test",
    "addresses": [
        {
            "address": "ANFLgwKG8Eni9gJmKfM7yFXEaWwoGkSUid",
            "script_hash": "47028f2a3d33466f29fba10e65c90fd8f3d01e1f",
            "tokens": null
        },
        {
            "version": 0,
            "script_hash": "ALXEKioZntX73QawcnfcHUDvTVm8qXjAxf",
            "frozen": false,
            "votes": [],
            "balances": {
                "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b": "50.0",
                "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7": "50.0"
            },
            "is_watch_only": false
        }
    ],
    ...
    "synced_balances": [
        "[NEO]: 50.0 ",
        "[NEOGas]: 50.0 "
    ],
    "public_keys": [
        {
            "Address": "ANFLgwKG8Eni9gJmKfM7yFXEaWwoGkSUid",
            "Public Key": "037b8992e8384212f82e05c8836816c0f14dff9528397138731638b17d6357021e"
        },
        {
            "Address": "ALXEKioZntX73QawcnfcHUDvTVm8qXjAxf",
            "Public Key": "037b8992e8384212f82e05c8836816c0f14dff9528397138731638b17d6357021e"
        }
    ],
    ...
}
```

### 将资产转账到你自己的地址

现在就可以安装以下操作将资产转移到你自己的地址：

```python
neo> send NEO ANFLgwKG8Eni9gJmKfM7yFXEaWwoGkSUid 5 --from-addr=ALXEKioZntX73QawcnfcHUDvTVm8qXjAxf
[Password]> **********
[I 180310 17:02:42 Transaction:611] Verifying transaction: b'c32b0e3d9adbef6720abfad5106dcd2dacb17b31d4f9d32cbcf8ed6e7f566ef3'
Relayed Tx: c32b0e3d9adbef6720abfad5106dcd2dacb17b31d4f9d32cbcf8ed6e7f566ef3
```

注意参数 `--from-addr` 指定的是提取资产的多方签名合约地址。