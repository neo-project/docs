# CLI Command Reference

Open the command line, navigate to the directory where Neo-CLI is located, and enter the following code to start the command line Neo node.

`dotnet neo-cli.dll`

This section will introduce all the commands in the command line node. You can manipulate your node with commands for creating a wallet, importing and exporting of private key, transferring, starting consensus, etc.

## Overview

The following tables list all the commands. You can also enter `help` in the command line to view them all.

All the commands described in this document conform with these conventions:

- `<>` indicate a parameter.
- `[]` is for optional parameters.
- `|` separates multiple parameters where any one of them can be used at your choice.
- `=` indicates the default value of the optional parameter without an input.

#### Console commands

| Command      | Description      |
| ------- | --------- |
| version | Shows the current Neo-CLI version |
| help [plugin-name] | Help menu, which can also show plugin related commands. |
| [parse](#parse) \<value> | Convert the input string into various supported data format |
| clear   | Clear screen      |
| exit    | Exit program      |

#### Wallet commands

| Command                                           | Parameters                             | Description                                                  |
| ------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [create wallet](#create-wallet)                   | \<path>                                | Creates a wallet file.                                       |
| [open wallet](#open-wallet)                       | \<path>                                | Opens a wallet file.                                         |
| close wallet                                      |                                        | Closes the current wallet.                                   |
| [upgrade wallet](#upgrade-wallet)                 | \<path>                                | Upgrades old wallet files.                                   |

The commands listed in the table below requires you to open the wallet before invoking.

| Command                                           | Parameters                    | Description                                          |
| ------------------------------------------------- | ----------------------------- | ---------------------------------------------------- |
| [change password](#change-password)               |                        | Changes the wallet password                          |
| list address                                      |                               | lists all the accounts in the wallet.                |
| list asset                                        |                               | Lists all assets in the wallet.                      |
| list key                                          |                               | Lists all public keys in your wallet.                |
| [show gas](#show-gas)                             |                               | Lists all the GAS in your wallet.                    |
| [create address](#create-address)                 | [count=1]                     | Creates address / batch create address               |
| [import key](#import-key)                         | \<wifOrFile>          | Imports a private key / bulk import of private keys. |
| [export key](#export-key)                         | \[path=null] \[scriptHash=null] | Exports private keys.                                |
| [import multisigaddress](#import-multisigaddress) | \<m> \<publicKeys>                                           | Creates a multi-signature contract.                  |
| [import watchonly](#import-watchonly) | \<addressOrFile> | Imports the watch-only address (e.g. contract address)|
| [send](#send)                                  | \<id \|alias> \<address> \<amount> \[from=null] \[data=null] \[signerAccounts=null] | Sends assets to the specified address.                       |
| [sign](#sign)                                     | \<jsonObjectToSign>                    | Signs the transaction. The parameter is the json string that records the transaction information. |

#### Contract commands

| Command           | Parameters                                                   | Description        |
| ----------------- | ------------------------------------------------------------ | ------------------ |
| [deploy](#deploy) | \<nefFilePath> [manifestFile]                                | Deploys a contract |
| [invoke](#invoke) | \<scripthash> \<operation> \[contractParameters=null] \[sender=null] \[signerAccounts=null] \[maxGas=20] | Invokes a contract |
| [update](#update) | \<scriptHash> \<filePath> \<manifestPath> \<sender> \[signerAccounts=null] | Upgrade a contract |


#### Node commands

| Command    | Parameters      | Description                                                  |
| ---------- | --------------- | ------------------------------------------------------------ |
| show state |                 | Displays the current status of blockchain synchronization.   |
| show pool  | [verbose=False] | Displays the transactions in the memory pool (These transactions are in the state of zero confirmation). |

#### Nep17 commands

| Command                 | Parameters                                                   | Description                                                  |
| ----------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| [balanceof](#balanceof) | \<tokenHash> \<address>                                      | Queries the balance of specified token at the specified address |
| [decimals](#decimals)   | \<tokenHash>                                                 | Queries the precision of specified token                     |
| [name](#name)           | \<tokenHash>                                                 | Queries the specified token name                             |
| [transfer](#transfer)   | \<tokenHash> \<to> \<amount>  \[from=null] \[data=null] \[signersAccounts=null] | Invokes the transfer method to transfer the specified token  |

#### Native contract commands

| Command                                     | Parameters | Description                                        |
| ------------------------------------------- | ---------- | -------------------------------------------------- |
| [list nativecontract](#list-nativecontract) |            | Lists all the native contract names and scripthash |

#### Network commands

| Command         | Parameters          | Description                                                  |
| --------------- | ------------------- | ------------------------------------------------------------ |
| [relay](#relay) | \<jsonObjectToSign> | Broadcasts the transaction. The parameter is the json string that records the transaction information. |
| [broadcast addr](#broadcast-addr) |  \<payload IP address> \<port>   | Broadcasts the IP address of the node |
| [broadcast block](#broadcast-block) |  \<block hash \| block height>  | Broadcasts a block |
| [broadcast getblocks](#broadcast-getblocks) |  \<block hash>  | Broadcasts the getblocks request |
| [broadcast getdata](#broadcast-getdata) |  \<inventory type> \<payload>  | Broadcasts the getdata request |
| [broadcast getheaders](#broadcast-getheaders) |  \<block index>  | Broadcasts the getheaders request |
| [broadcast inv](#broadcast-inv) |  \<inventory type> \<payload>  | Broadcasts the inventory data |
| [broadcast transaction](#broadcast-transaction) |  \<transaction hash>  | Broadcasts a transaction |

#### Plugin commands

| Command                       | Parameters    | Description                              |
| ----------------------------- | ------------- | ---------------------------------------- |
| [plugins](#plugins)           |               | Lists loaded plugins                     |
| [install](#install)           | [Plugin name] | Installs the specified plugin            |
| [uninstall](#install)         | [Plugin name] | Uninstalls the specified plugin          |
| [dump storage](#dump-storage) | \<key>        | Exports all or the specified state data. This command requires installation of the StatesDumper plugin. |
| [start consensus](#start-consensus) |  | Starts consensus. This command requires installation of the DBFTPlugin plugin. |
| [start oracle](#start-oracle) | | Starts Oracle. This command requires installation of the OracleService plugin. |
| [stop oracle](#stop-oracle) | | Stops Oracle. This command requires installation of the OracleService plugin. |
| [state root](#state-root) | \<index> | Queries the state root with index. This command requires installation of the StateService plugin. |
| state height | | Queries the state height. This command requires installation of the StateService plugin. |
| [get proof](#get-proof) | \<rootHash> \<scriptHash> \<key> | Gets proof with root hash, contract hash, and storage key. |
| [verify proof](#verify-proof) | \<rootHash> \<proof> | Verifies with root hash and proof. |

#### Voting commands

| Command                                       | Parameters                    | Description                                                 |
| --------------------------------------------- | ----------------------------- | ----------------------------------------------------------- |
| [get accountstate](#get-accountstate)         | \<address>                    | Gets the latest voting information of the specified account |
| [get candidates](#get-candidates)             |                               | Gets candidates' public keys and votes                      |
| [get committee](#get-committee)               |                               | Gets the committee member's public key                      |
| [get next validators](#get-next-validators)   |                               | Gets the next validator's  public key                       |
| [register candidate](#register-candidate)     | \<account> [maxGas=1010]      | Registers the candidate                                     |
| [unregister candidate](#unregister-candidate) | \<account>                    | Unregisters the candidate                                   |
| [vote](#vote)                                 | \<senderAccount> \<publicKey> | Votes for candidates                                        |
| [unvote](#unvote)                             | \<senderAccount>              | Cancel the voting                                           |

#### Block Commands

| Command                         | Parameters                             | Description                                                  |
| ------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [export blocks](#export-blocks) | \<start> \[block count] \[export path] | Exports the blockchain data from the specified block height. The exported data  can be used for offline synchronization. |

## Command Description

### parse

Converts the input string into various supported data formats.

##### Syntax

 `parse <value>`

##### Example

```
neo> parse NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o
Address to ScriptHash           0x55df8d4950eba5aef9d4d4d2610f827fcd4a7bb9
Address to Base64               uXtKzX+CD2HS1NT5rqXrUEmN31U=
String to Hex String            4e637068746a675479653363335a4c354a356e445a68736633554a4d47416a64376f
String to Base64                TmNwaHRqZ1R5ZTNjM1pMNUo1bkRaaHNmM1VKTUdBamQ3bw==
neo> parse AHVYXVTcKw==
Base64 to Big Integer           12345678900000000
String to Hex String            41485659585654634b773d3d
String to Base64                QUhWWVhWVGNLdz09
neo> parse 0x55df8d4950eba5aef9d4d4d2610f827fcd4a7bb9
ScriptHash to Address           NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o
Hex String to Big Integer       490249589479789641828817600658206854216357149625
String to Hex String            307835356466386434393530656261356165663964346434643236313066383237666364346137626239
String to Base64                MHg1NWRmOGQ0OTUwZWJhNWFlZjlkNGQ0ZDI2MTBmODI3ZmNkNGE3YmI5
```

If you see messy codes that is because some data types cannot be converted. 

### create wallet

Creates a wallet file in the .db3 or .json format. A wallet password is required to be specified during the process. 

##### Syntax

 `create wallet <path>` 

##### Example

```
neo> create wallet test.json
password: *
password: *
   Address: NRq91uUULStNMBmsgFQpQVe18YUcwo1rTK
    Pubkey: 02e7ada69ebe8f730c871ea999185a5238c80ab91abe86bfb26fdac5ebb8ae6613
ScriptHash: 0x19d69593a368ba01b2aac8dc0a67d7b675e1e640
```

The wallet file is generated under the neo-cli root directory. If you want to set other path, you need to create the folder in advance.

### open wallet

Opens the wallet file at the specified path. The wallet password is required to be entered when opening the wallet.

##### Syntax

 `open wallet <path>` 

##### Example

```
neo> open wallet test.json
password: *
```

### change password

Changes the wallet password.

##### Syntax

 `change password` 

##### Example

```
neo> change password
password: ***
New password: ***
Re-Enter Password: ***
Password changed successfully
```

### upgrade wallet

Upgrades the old .db3 wallet file into the .json format.

##### Syntax

 `upgrade wallet <path>` 

##### Example

```
neo> upgrade wallet test.db3
Wallet file upgrade complete. New wallet file has been auto-saved at: test.json
```

### show gas

lists all the unclaimed GAS in the current wallet.

##### Syntax

`show gas` 

##### Example

```
neo> show gas
unclaimed gas: 16.7367406
```

> [!NOTE]
>
> This command does not show the GAS that has been claimed. Use `list asset` instead.

On Neo N3, The GAS in an account is claimed automatically every time when the number of Neo in the account changes.  

### create address

Creates a new address. One can also enter `create address 100` to create 100 new addresses in batches; Addresses are automatically exported to the address.txt file.

##### Syntax

`create address [n]` 

##### Parameters

`n`: Number of addresses to create. n is an integer and defaults to 1.

##### Example

```
neo> create address 3
The file 'address.txt' already exists, do you want to overwrite it? (yes|no): yes
[3/3]
Export addresses to address.txt
```

### balanceof

Queries the balance of specified token at the specified address

##### Syntax

 `balanceof <tokenHash> <address>`

##### Parameters

- `tokenHash`: The token hash

- `address`: The address to query

##### Example

```
neo> balanceof 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o
Invoking script with: '0c14b97b4acd7f820f61d2d4d4f9aea5eb50498ddf5511c00c0962616c616e63654f660c14ec99f691c0f7dfa41400473edd1c2afceb70c2d241627d5b52'
VM State: HALT
Gas Consumed: 0.0373876
Result Stack: [{"type":"Integer","value":"1998380000000000"}]

{{$Token Name}} balance: 19983800
```

### decimals

Queries the precision of specified token

##### Syntax

 `decimals <tokenHash>`

##### Parameters

`tokenHash`: The token hash

##### Example

```
neo> decimals 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec
Invoking script with: '10c00c08646563696d616c730c14ec99f691c0f7dfa41400473edd1c2afceb70c2d241627d5b52'
VM State: HALT
Gas Consumed: 0.0125075
Result Stack: [{"type":"Integer","value":"8"}]
Result : 8
```

### transfer

Invokes the transfer method to transfer the specified token.

##### Syntax

 `transfer <tokenHash> <to> <amount> [from=null] [data=null] [signersAccounts=null]`

##### Parameters

- `tokenHash`: The token hash
- `to`: The address you transfer the token to
- `amount`: The amount to transfer
- `from`: The address you transfer the token from
- `data`：The additional parameter. The default value is null.
- `signersAccounts`: The signer's address

##### Example

```
neo> transfer 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec Nhe4mzfQRoKojkXhqxJHjANvBMT7BYAXDv 6000 NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y transferdata NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y
Relay tx(no|yes): y
Signed and relayed transaction with hash=0x0d82a59ca2106c93e6383893d86a098d1a9fbf950c091772c61790880acc78c5
```

### list nativecontract

Lists all the native contract names and scripthash.


##### Syntax

 `list nativecontract`


##### Example

```
neo> list nativecontract
        ContractManagement  0xfffdc93764dbaddd97c48f252a53ea4643faa3fd
        StdLib              0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0
        CryptoLib           0x726cb6e0cd8628a1350a611384688911ab75f51b
        LedgerContract      0xda65b600f7124ce6c79950c1772a36403104f2be
        NeoToken            0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5
        GasToken            0xd2a4cff31913016155e38e474a2c06d08be276cf
        PolicyContract      0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b
        RoleManagement      0x49cf4e5378ffcd4dec034fd98a174c5491e395e2
        OracleContract      0xfe924b7cfe89ddd271abaf7210a80a7e11178758
        NameService         0x7a8fcf0392cd625647907afa8e45cc66872b596b
```

### get accountstate

Gets the latest voting information of the specific account, including the address it voted, the amount of votes cast and the block height at the time of voting.

##### Syntax

 `get accountstate <address>` 

##### Parameter

`address`：The address you want to query the voting information.

##### Example

```
neo> get accountstate NNz4ppADL3mke7HT8RvRr5nX8zTAbNdWjv
Invoking script with: 'DBQhrr+TO5ru/CWrG+m3Gq80Ff3tORHAHwwPZ2V0QWNjb3VudFN0YXRlDBT1Y+pAvCg9TQ4FxI6jBbPyoHNA70FifVtS'
VM State: HALT
Gas Consumed: 0.0202833
Result Stack: [{"type":"Struct","value":[{"type":"Integer","value":"900"},{"type":"Integer","value":"9774"},{"type":"ByteString","value":"AsNeyvySxknpefBTobcD9O\u002BQiieFUIdCtmzAWZvxQPA4"}]}]

Voted: NNuEErrm2qpLyoWUxtEy7Sgxh1cm71Ngb6
Amount: 900
Block: 9774
```

### get candidates

Gets candidates' public keys and votes

##### Syntax

 `get candidates`

##### Example

```
neo> get candidates
Invoking script with: '10c00c0d67657443616e646964617465730c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Candidates:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d      49900000
```

### get committee

Gets the committee member's public key

##### Syntax

 `get committee`

##### Example

```
neo> get committee
Invoking script with: '10c00c0c676574436f6d6d69747465650c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Committee:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d
```

### get next validators

Gets the next validator's public key

##### Syntax

 `get next validators`

##### Example

```
neo> get next validators
Invoking script with: '10c00c166765744e657874426c6f636b56616c696461746f72730c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Next validators:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d
```

### register candidate

Registers the candidate

##### Syntax

 `register candidate <account> [maxGas=1010]`

##### Parameters

`account`: The account to register candidate

`maxGas`: The maximum GAS can be consumed. Default is 1010, where the registration fee is 1000 GAS.

##### Example

```
neo> register candidate NUNtEBBbJkmPrmhiVSPN6JuM7AcE8FJ5sE
Invoking script with: 'DCECSVwDcw3pu71X7c2DqNv8jNiqsw75XuAGjy+ko6bkt/YRwB8MEXJlZ2lzdGVyQ2FuZGlkYXRlDBT1Y+pAvCg9TQ4FxI6jBbPyoHNA70FifVtS'
VM State: HALT
Gas Consumed: 1000.0104529
Result Stack: [{"type":"Boolean","value":true}]
relay tx(no|yes): y
Signed and relayed transaction with hash=0xc30ecd2e30d2d3347e389dbdb205c6a38a663819ff8b473ad11b03e035c67bb5
```

### unregister candidate

Unregisters the candidate

##### Syntax

 `unregister candidate <account>`

##### Parameters

`account`: The account to unregister candidate

##### Example

```
neo> unregister candidate NUNtEBBbJkmPrmhiVSPN6JuM7AcE8FJ5sE
Invoking script with: 'DCECSVwDcw3pu71X7c2DqNv8jNiqsw75XuAGjy+ko6bkt/YRwB8ME3VucmVnaXN0ZXJDYW5kaWRhdGUMFPVj6kC8KD1NDgXEjqMFs/Kgc0DvQWJ9W1I='
VM State: HALT
Gas Consumed: 0.0301137
Result Stack: [{"type":"Boolean","value":true}]
Relay tx(no|yes): yes
Signed and relayed transaction with hash=0xa799e315956e120a51bf5b5804d9518754a844bbe4dadef3efd37ac3d15a6305
```

### vote

Votes for candidates

##### Syntax

 `vote <senderAccount> <publicKey>`

##### Parameters

- `senderAccount`: The account used to vote
- `publickey`: The public key of the account you vote for

##### Example

```
neo> vote Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z 02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d
Invoking script with: '0c2102344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d0c14ef3b46067f2f47b2f7f0442aa2372085d08708ef12c00c04766f74650c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 5.0100793
Evaluation Stack: [{"type":"Boolean","value":true}]

relay tx(no|yes): y
Signed and relayed transaction with hash=0x8083633ecc4827b7967ba8b0a30f02992dc524e4a5356accebdf080e9cd26df2
```

### unvote

Cancel the voting

##### Syntax

 `unvote <senderAccount>`

##### Parameter

`senderAccount`: The account to unvote

##### Example

```
neo> unvote 0x39edfd1534af1ab7e91bab25fcee9a3b93bfae21
Invoking script with: 'CwwUIa6/kzua7vwlqxvptxqvNBX97TkSwB8MBHZvdGUMFPVj6kC8KD1NDgXEjqMFs/Kgc0DvQWJ9W1I='
VM State: HALT
Gas Consumed: 0.030114
Result Stack: [{"type":"Boolean","value":true}]
Relay tx(no|yes): y
Signed and relayed transaction with hash=0x78f83fd1e0607f078fa0964a97b9972d3f4844191f6702c1750ff6d532cd5019
```

### export key

Exports private key of the address to the specified file. The command also requires the verification of the wallet password.

##### Syntax

 `export key [address] [path]`

##### Parameters

- `address`: Address to export private key.
- `path`: Path to the file used to store the private key.

##### Example

Exports the key to the console:

```
neo> export key
password: ********
L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
L3raEwVsJHzovTXfgVG1HWxzmH4Zm3vMia8byszhVrvbJ38YnsXv
KywrMAnBWRXUAb4Aq76ZoCCqDvGNL9nidjVwWwDr3DbMPwg1RPBL
KwhNLC9rULxJmevqwYbQzJhYNvaCDPyAUAm7EkHrW5kQwLYfxTFG
```

Exports the key to the specified file:

```
neo> export key key1.txt
password: ********
```

```
neo> export key key2.txt NPpH6FxNaVXZCrsecNWEHGLwMe87UkPdm5
password: ********
```

### import key

Imports a private key, or  a file with a number of private keys.

##### Syntax

 `import key <wif | path>`

##### Parameters

`wif | path`: The key to import or the file path.

##### Example

```
neo> import key L4q37aCJzjEXhAUJ6npdxbjGGbyTXuWhpgYxkb2NWPmzXv4DdxiD
Address: NPpH6FxNaVXZCrsecNWEHGLwMe87UkPdm5
 Pubkey: 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
```

```
neo> import key key1.txt
```

If there is a specified file, the file is in the private key format. Refer to export key key.txt output.

### import multisigaddress

Creates a multi-party signed address. 

##### Syntax

`import multisigaddress m pubkeys...`

##### Parameters

- `m`: m is the minimal number of signatures. For example, creating a multi-party signed address with two public keys, m can be 1 or 2.
- `pubkeys`: Public keys of multiple parties involved.

##### Example

```
neo> import multisigaddress 2 03fadbc9b25d1b6827124665c50801e602240c9d8ebdda2bae49de6683f8f86af9 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
Multisig. Addr.: NN58k4Ei4nUzWxrgksHZPantyuDxWgouod
```

### import watchonly

Imports the watch-only address, e.g contract account.

##### Syntax

`import watchonly scriptHash`

##### Parameters

`addressOrFile`：account address, hash, contract hash, or files storing these data

##### Example

```
neo> import watchonly 0xbfe215933f29b29dacf0e8383722a62974ac8aa6
Address: Nb6ZUp9h5aCKkNADpdUD5TbuJGP6wyRvE8
```

### send

Transfers the asset to the specified address. The command requires the verification of the wallet password.

##### Syntax

`send <id | alias> <address> <amount> [from=null] [data=null] [signerAccounts=null]`

##### Parameters

- `id | alias`: asset ID or asset abbreviations, e.g. neo, gas
- `address`: address to transfer assets to
- `amount`: transfer amount
- `from`: address to transfer assets from
- `data`: the additional transaction information, which defaults to null.
- `signerAccounts`: signer's address

##### Example

Transfer 100 Neo to the address Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR: 

```
neo> send 0xd2a4cff31913016155e38e474a2c06d08be276cf Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR 100
password: *
TXID: 0xf8b9824808c037893525a60f2f8d4ec034dffe8ac17d4142ff889e2e712d8df1
```

If you are not sure of the asset ID, you can enter `list asset` to view all assets in the wallet.

In above example, we can also replace the asset ID with asset abbreviation, as shown below:

```
neo> send gas Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR 100
password: *
TXID: 0xea2454d0210aefff406097e03abd2137dc416617adac6f23842ca1914d001419
```

When withdrawing assets from a multi-signed address, multiple signatures are required. A json string is returned requiring signatures, as shown below:

```
neo> send neo NdJ5Nbs7gvmjDmqraVCJy8nPQxue1e5LK1 10
password: *
SignatureContext:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="}}}}
```

When withdrawing assets from a contract, `from` is the contract hash and the signer account must contain the contract hash and verify account, for example:

```
neo> send 0x70e2301955bf1e74cbb31d18c2f96972abadb328 NZttvm9tAhMjyxZATvqN9WFYkHYMNaXD6C 0.000002 0x436b18e7b624c0323b090141a89e79a3ab588b6a transferdata 0x436b18e7b624c0323b090141a89e79a3ab588b6a NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y
password: *
TXID: 0x174bab85eb004a07ae5b411f23cb6d3128346f9249305a768c286707938b4727
```

### sign

This command is used to sign when withdrawing assets from a multi-signed address which requires multiple signatures. The translation can be broadcasted only after signing is completed.

##### Syntax

`sign <jsonObjectToSign>` 

##### Parameters

`jsonObjectToSign`: The json string that records the transaction information. 

##### Example

```
neo> sign {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="}}}}
Signed Output:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature","value":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="},{"type":"Signature","value":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA=="},{"type":"Signature","value":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="},{"type":"Signature","value":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ=="},{"type":"Signature","value":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ==","0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ==","020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ==","025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA==","038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="}}}}
```

The signed json string is returned. If the signature is complete, you can broadcast the transaction using the command `relay`.

### deploy

Deploys a contract on the blockchain.

##### Syntax

`deploy <nefFilePath> [manifestFile]` 

##### Parameters

- `nefFilePath`: Path to the executable file (.nef) of NeoVM.
- `manifestFile`: Path to the file manifest.json, which records each interface information and configuration content of the contract.

##### Example

```
neo> deploy Template.nef Template.manifest.json  
Script hash: 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6
Gas Consumed: 100000000

Signed and relayed transaction with hash=0xab6dd63ea36a7c95580b241f34ba756e62c767813be5d53e02a983f4e561d284
```

### invoke

Invokes a contract. 

##### Syntax

`invoke <scriptHash> <operation> [contractParameters=null] [sender=null] [signerAccounts=null][maxGas]` 

##### Parameters

- `scripthash`: Contract hash to invoke.

- `command`: Method name in the contract, which can be followed by input parameters separated by space. 

- `contractParameters`: Parameters to invoke. You need to pass in JSON-formatted string. For ByteArray type, encode it with Base64 in advance. 

  For example, the address `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` can be converted to the hexadecimal big-endian script hash  `0xe4b0b6fa65a399d7233827502b178ece1912cdd4` or the Base64-encoded script hash `1M0SGc6OFytQJzgj15mjZfq2sOQ=`. The JSON-formatted parameters are:

  ```
  [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
  [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
  ```

- `sender` : Transaction sender, i.e. the GAS payment account.

- `signerAccounts` : An array of co-signed addresses and only supports standard accounts (single address). After filling in Neo-CLI will append signatures of all addresses in the array to the invocation transaction.

- `maxGas`: The maximum GAS can be consumed.

##### Example 1

Input:

```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 symbol
```
Output:

```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"VG9rZW5TeW1ib2w="}]

relay tx(no|yes):
```

- `VM State`: there are two states:
  -  `HALT` : the virtual machine executes successfully.
  -  `FAULT` : the virtual machine exits during execution due to an exception. 
- `Gas Consumed`: the system fees consumed for smart contract invocation.
- `Evaluation Stack`: shows the result of contract execution, where the value is encoded with Base64.

Input:

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
```

Output:

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

Output:

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
```

or

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"d4cd1219ce8e172b50273823d799a365fab6b0e4"}]
```

Output:

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```
##### Example 3

Input:

    neo> invoke 0x70e2301955bf1e74cbb31d18c2f96972abadb328 transfer [{"type":"Hash160","value":"0x436b18e7b624c0323b090141a89e79a3ab588b6a"},{"type":"Hash160","value":"0xb4ba98beea38621dd96a9804384db24451b1cff2"},{"type":"Integer","value":"1"}] 0x436b18e7b624c0323b090141a89e79a3ab588b6a 0x436b18e7b624c0323b090141a89e79a3ab588b6a NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y

Output:

    Invoking script with: '110c14f2cfb15144b24d3804986ad91d6238eabe98bab40c146a8b58aba3799ea84101093b32c024b6e7186b4313c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52'
    VM State: HALT
    Gas Consumed: 0.0900796
    Result Stack: [{"type":"Boolean","value":true}]
    Relay tx(no|yes): no


> [!Note]
>
> After entering the invoke command, the node invokes the `operation` method, and passes `operation` and `contractParameters` as arguments. If `operation` and `contractParameters` are not processed in the contract, the expected result will not be returned.

###  update

Upgrades a contract.

##### Syntax

`update <scriptHash> <filePath> <manifestPath> <sender> [signerAccounts=null]` 

##### Parameters

- `scriptHash`: hash of the contract to update

- `nefFilePath`: File path to the NeoVM executable file nef.
- `manifestFile`: Path of the manifest.json file which records all the contract interfaces and configuration. If not specified, the manifest.json with the same name as nef will be automatically matched.  
- `sender`: The transaction sender that pays for GAS
- `signerAccounts`: An array of co-signed addresses and only supports standard accounts (single address). After filling in Neo-CLI will append signatures of all addresses in the array to the invocation transaction.

##### Example

```
update 0x3096fb5cd0a2a95b29e8e92692f0be77c4cce06f NEP17.nef NEP17.manifest.json 0xf6a3f0fda46abdeacac9eda4600a354d0687c420
Contract hash: 0x3096fb5cd0a2a95b29e8e92692f0be77c4cce06f
Updated times: 0
Gas consumed: 3.3317182
Network fee: 0.0448052
Total fee: 3.3765234 GAS
Relay tx? (no|yes): y
Signed and relayed transaction with hash=0x4587846a2cbc8574e16ce04e95e8c73d76b88250581d81291c23f05c215273ba
```

### relay

After signing completed, this command can be used to broadcast the transaction information.  

##### Syntax

`relay <jsonObjectToSign>` 

##### Parameters

`jsonObjectToSign`: The json string that records the transaction information.

##### Example

```
neo> relay {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature","value":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="},{"type":"Signature","value":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA=="},{"type":"Signature","value":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="},{"type":"Signature","value":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ=="},{"type":"Signature","value":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ==","0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ==","020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ==","025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA==","038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="}}}}
Data relay success, the hash is shown as follows:
0xc65c3b3618823238b2b5589dba54c665f86310c85a3460f901cfb0030d4dbf28
```

### broadcast addr

Broadcasts the IP address of a block.

##### Syntax

`broadcast addr <IPAddress> <port>`

##### Example

```
neo> broadcast addr 127.0.0.1 10332
neo> 
```

### broadcast block

Broadcasts a block.

##### Syntax

`broadcast block <block-hash> `

`broadcast block <block-height> `

##### Example

```
neo> broadcast block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast block 537
neo> 
```

### broadcast getblocks

Broadcasts the getblocks request.

##### Syntax

`broadcast getblocks <block-hash> `

##### Example

```
neo> broadcast getblocks 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getheaders

Broadcasts the getheaders request.

##### Syntax

`broadcast getheaders <block-hash> `

##### Example

```
neo> broadcast getheaders 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getdata

Broadcasts the getdata request.

##### Syntax

`broadcast getdata <inventory type> <payload> `

##### Example

```
neo> broadcast getdata Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast getdata TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
neo> broadcast getdata Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
```

### broadcast inv

Broadcasts inventory data.

##### Syntax

`broadcast inv <inventory type> <payload> `

##### Example

```
neo> broadcast inv Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast inv TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
neo> broadcast inv Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
```

### broadcast transaction

Broadcasts a transaction.

##### Syntax

`broadcast transaction <transaction hash> `

##### Example

```
neo> broadcast transaction 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### plugins

Shows all the loaded plugins.

##### Syntax

`plugins`

##### Example

```
neo> plugins
Loaded plugins:
        ApplicationLogs     Synchronizes the smart contract log with the NativeContract log (Notify)
        DBFTPlugin          Consensus plugin with dBFT algorithm.
        LevelDBStore        Uses LevelDB to store the blockchain data
        OracleService       Built-in oracle plugin
        RpcNep17Tracker     Enquiries NEP-17 balances and transaction history of accounts through RPC
        RpcServer           Enables RPC for the node
        StatesDumper        Exports Neo-CLI status data
        StateService        Enables MPT for the node
```

### install

Installs plugins.

`install [Plugin name]` 

To install a plugin, enter the command as follows:

```
neo> install RpcServer
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v3.0.0-preview5/RpcServer.zip
Install successful, please restart neo-cli.
```

For information about all plugins refer to [Install Plug-ins](config.md).

### dump storage

Exports all or the specified state data.

##### Syntax

`dump storage <key>`

### export blocks

Exports the block data from the specified block height. The output can be used for offline synchronization. 

##### Syntax

`export blocks <index>`

##### Parameters

`<index> `: The height of the starting block from which the data is exported.

### start consensus

Starts the consensus on the premise that the wallet has a consensus authority, allows consensus authority to be obtained on the main net through voting. This command requires  installation of the DBFTPlugin. If a private chain is deployed, public key of the consensus can be set up in the `protocol.json`. For more information refer to [Setting up Private Chain](../../develop/network/private-chain/private-chain2.md).

### start oracle

Starts Oracle. This command requires installation of the OracleService plugin. The Oracle service is enabled only if the public key of the current wallet address has been assigned the Oracle role by the committee.

### stop oracle

Stops Oracle. This command requires installation of the OracleService plugin.

### state root

Queries the state root with index. This command requires installation of the StateService plugin.

##### Syntax

`state root <index>`

##### Parameters

`<index> `: The block index

```
neo> state root 20000
{"version":0,"index":20000,"roothash":"0x0121262f9833b21eae7b8d375c1c334fdd4d4500f1d3fad2da669d5b83e94157","witness":{"invocation":"DECny9LhRZpH61UNC/sXG9WEBFMl7cf1rZPT7U0tCvZa\u002BHs6rG/fz2gKTfvLBUp5lcmGDlrMlKCCfKoougYGt7s4DEAuhkhPROcr2FM5SSHCl5LFWSTrcvxa6rvmLc1NGXwpgcRHV9LY5/H6q5SnwdAW3DSspap93FjvSHqU48Mn41nGDEDI5G6bGhGvyLl8rZbT0LzAHRbQUZ2OWIcnFi/Jo/QtwZoCGrK6L3g2miCXsgkckzUsJ1DoruMzKgVEFb4t/KYBDEAWC2fagW\u002BOt6iUGyo\u002BNu0zC1jl105uLyv5bY4tE03vBjbJDTm1T3o17jC8b3HMaeYMro2IGZTSOGt3b9YF6ntiDEBaMGwM/\u002Bd\u002BkTHmBb9c\u002BuCfMkEHOez8XuyoSZotQdDCtaVMCT4wHwIHspxeGGp1iVIEtEYFhJl0EfPEObcO0YfGDEBCC3/hBNLGmusDpr4gDfD6asqjyNCGPNerYIHunu2gsOr6kr3uQJBFqaXSYp\u002BCkz9HBrc6Cq2fNz4HPn/tIo5S","verification":"FgwhAwAqLhjDnN7Qb8Yd2UoHuOnz\u002BgNqcFvu\u002BHZCUpVOgtDXDCECAM1gQDlYokm5qzKbbAjI/955zDMJc2eji/a1GIEJU2EMIQIhkM6Z1WxnvBcDTCedOLpwWTZHFtEduMhLpf3Z/AJgEQwhAzU7wXKtEGB62apHDocfRKJil\u002ByBAIP6J8aLnJSjTL/5DCECNxinjeXEq5HT3NK2m0dPLTUIuN3EeHiMupRY6Sj\u002B/qYMIQKXhyDsbFxYdeA0d\u002BFsbZj5AQhamA13R64ysGgh19j6UwwhAqPXy4P0JIWNvpx5c9df/ut8OUCIRJ9onGacn09vEIVODCEDySUJ5CjN1/ek/dSpfGeJELQPFGXd3k8En3MlrzOAeSkYC0ETje\u002Bv"}}
```

### get proof

Gets proof with root hash, contract hash, and storage key.

##### Syntax

`get proof <root hash> <script hash> <key>`

##### Parameters

* `<root hash>`: hash of the state root.
* `<script hash>`: Contract hash
* `<key>`: key of the storage; Base64-encoded.

```
neo> get proof 0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca 0x79bcd398505eb779df6e67e4be6c14cded08e2f2 Fw==
Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA=
```

### verify proof

Verifies with root hash and proof.

##### Syntax

`verify proof <root hash> <proof>`

##### Parameters

* `<root hash>`: hash of the state root.
* `<proof>`: proof of the state root; Base64-encoded.

```
neo> verify proof 0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA=
AAI=
```

