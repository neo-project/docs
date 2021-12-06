# CLI 命令参考

打开命令行，定位到 Neo-CLI 所在目录，输入以下命令即可启动 Neo 的命令行节点。

`dotnet neo-cli.dll`

本节将介绍命令行节点的所有命令，你可以通过输入命令操作节点，如创建打开钱包、导入导出私钥、转账、启动共识、部署、调用合约等。

## 命令概览

以下表格列出了所有 CLI 命令。在命令行中输入 `help` 也可以查看所有命令。

本文中的命令格式均遵循以下约定：

- `<>` ：表示参数
- `[]` ：可选参数
- `|` ：表示所填的参数可以是其中任意一种
- `=` ：表示可选参数在不输入情况下的默认值

#### 控制台命令

| 命令               | 说明                                   |
| :----------------- | -------------------------------------- |
| version            | 显示当前节点的版本                     |
| help [plugin-name] | 帮助菜单，也可以查看部分插件的提示信息 |
| [parse](#parse) \<value> | 根据输入的字符串，转换成各种支持的数据格式 |
| clear              | 清除屏幕                               |
| exit               | 退出程序                               |

#### 钱包命令

| 命令                                              | 参数                                   | 说明                                              |
| ------------------------------------------------- | -------------------------------------- | ------------------------------------------------- |
| [create wallet](#create-wallet)                   | \<path>                                | 创建钱包文件                                      |
| [open wallet](#open-wallet)                       | \<path>                                | 打开钱包文件                                      |
| close wallet                                      |                                        | 关闭钱包文件                                      |
| [upgrade wallet](#upgrade-wallet)                 | \<path>                                | 升级旧版钱包文件                                  |

下表所列命令均需要打开钱包才能使用。

| 命令                                              | 参数                                   | 说明                           |
| ------------------------------------------------- | -------------------------------------- | ------------------------------ |
| [change password](#change-password)               |                                 | 修改钱包密码                 |
| list address                                      |                                        | 列出钱包中的所有账户         |
| list asset                                        |                                        | 列出钱包中的所有资产         |
| list key                                          |                                        | 列出钱包中的所有公钥         |
| [show gas](#show-gas)                             |                                        | 列出钱包中的所有未提取的 GAS |
| [create address](#create-address)                 | [count=1]                           | 创建地址 / 批量创建地址      |
| [import key](#import-key)                         | \<wifOrFile>              | 导入私钥 / 批量导入私钥      |
| [export key](#export-key)                         | \[path=null] \[scriptHash=null] | 导出私钥                     |
| [import multisigaddress](#import-multisigaddress) | \<m> \<publicKeys> | 创建多方签名地址            |
| [import watchonly](#import-watchonly) | \<addressOrFile> | 导入监听地址（如合约账户）            |
| [send](#send)                                     | \<id \| alias> \<address> \<amount> \[from=null] \[data=null] \[signerAccounts=null] | 向指定地址转账               |
| [sign](#sign)                                     | \<jsonObjectToSign>                    | 对 ContractParametersContext 进行签名 |

#### 合约命令

| 命令              | 参数                                                         | 说明     |
| ----------------- | ------------------------------------------------------------ | -------- |
| [deploy](#deploy) | \<nefFilePath> [manifestFile]                                | 发布合约 |
| [invoke](#invoke) | \<scripthash> \<operation> \[contractParameters=null] \[sender=null] \[signerAccounts=null] \[maxGas=20] | 调用合约 |
| [update](#update) | \<scriptHash> \<filePath> \<manifestPath> \<sender> \[signerAccounts=null] | 升级合约 |

#### 节点命令

| 命令       | 参数            | 说明                                           |
| ---------- | --------------- | ---------------------------------------------- |
| show state |                 | 显示当前区块链同步状态                         |
| show pool  | [verbose=False] | 显示内存池中的交易（这些交易处于零确认的状态） |

#### NEP17 命令

| 命令            | 参数                | 说明                                           |
| --------------- | ------------------- | ---------------------------------------------- |
| [balanceof](#balanceof)  |\<tokenHash> \<address>                     | 查询指定 token 指定地址的余额                       |
| [decimals](#decimals)      | \<tokenHash>           | 查询指定 token 的精度 |
| [name](#name)      | \<tokenHash>           | 查询指定 token 的名字 |
| [transfer](#transfer)      | \<tokenHash> \<to> \<amount> \[from=null] \[data=null] \[signersAccounts=null]      | 调用 token 的 transfer 方法转账 |

#### 原生合约命令

| 命令            | 参数                | 说明                                           |
| --------------- | ------------------- | ---------------------------------------------- |
| [list nativecontract](#list-nativecontract) |                     | 列出所有原生合约的名字及 scripthash                         |

#### 网络命令

| 命令            | 参数                | 说明                                           |
| --------------- | ------------------- | ---------------------------------------------- |
| [relay](#relay) | \<jsonObjectToSign> | 将完成签名的交易信息进行广播               |
| [broadcast addr](#broadcast-addr) |  \<payload IP address> \<port>   | 广播节点 IP 地址 |
| [broadcast block](#broadcast-block) |  \<block hash \| block height>  | 广播一个区块 |
| [broadcast getblocks](#broadcast-getblocks) |  \<block hash>  | 广播 getblocks 请求 |
| [broadcast getdata](#broadcast-getdata) |  \<inventory type> \<payload>  | 广播 getdata 请求 |
| [broadcast getheaders](#broadcast-getheaders) |  \<block index>  | 广播 getheaders 请求 |
| [broadcast inv](#broadcast-inv) |  \<inventory type> \<payload>  | 广播 inventory data |
| [broadcast transaction](#broadcast-transaction) |  \<transaction hash>  | 广播一条交易 |

#### 插件命令

| 命令                    | 参数       | 说明         |
| ----------------------- | ---------------- | ---------------- |
| [plugins](#plugins) |  | 显示已加载的插件 |
| [install](#install) | [Plugin name] | 安装指定插件     |
| [uninstall](#install) | [Plugin name] | 卸载指定插件     |
| [dump storage](#dump-storage) | \<key> | 导出全部或指定的状态量数据，需要安装 StatesDumper 插件 |
| [start consensus](#start-consensus) |  | 启动共识，需要安装 DBFTPlugin 插件 |
| [start oracle](#start-oracle) | | 启动 Oracle，需要安装 OracleService 插件 |
| [stop oracle](#stop-oracle) | | 停止 Oracle，需要安装 OracleService 插件 |
| [state root](#state-root) | \<index> | 通过高度查询 state root，需要安装 StateService 插件 |
| state height | | 查询 state 高度，需要安装 StateService 插件 |
| [get proof](#get-proof) | \<rootHash> \<scriptHash> \<key> |  通过 root hash，合约 hash 和 storage key 查询得到 proof |
| [verify proof](#verify-proof) | \<rootHash> \<proof> | 使用 root hash 和 proof 进行验证 |

#### 投票命令

| 命令                    | 参数       | 说明         |
| ----------------------- | ---------------- | ---------------- |
| [get accountstate](#get-accountstate) | \<address> | 获取指定账户最新的投票情况 |
| [get candidates](#get-candidates) |  | 获取候选人公钥及票数 |
| [get committee](#get-committee) |  | 获取委员会成员公钥 |
| [get next validators](#get-next-validators) |  | 获取下一轮验证人公钥 |
| [register candidate](#register-candidate) |\<account> [maxGas=1010] | 注册候选人 |
| [unregister candidate](#unregister-candidate) |\<account>  | 注销候选人 |
| [vote](#vote) |\<senderAccount> \<publicKey>  | 投票 |
| [unvote](#unvote) |\<senderAccount> | 取消投票 |

#### 区块命令

| 命令                                | 参数     | 说明                                                   |
| ----------------------------------- | -------- | ------------------------------------------------------ |
| [export blocks](#export-blocks) | \<start> \[block count] \[export path] | 从指定区块高度导出区块数据，导出的结果可以用作离线同步 |

## 命令说明

### parse

根据输入的字符串，转换成各种支持的数据格式

##### 句法

 `parse <value>`

##### 示例

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
对于无法转换的数据类型可能出现乱码

### create wallet

创建一个 .db3 或 .json 钱包文件。创建过程中需要设置钱包密码。

##### 句法

 `create wallet <path>` 

##### 示例

```
neo> create wallet test.json
password: *
password: *
   Address: NRq91uUULStNMBmsgFQpQVe18YUcwo1rTK
    Pubkey: 02e7ada69ebe8f730c871ea999185a5238c80ab91abe86bfb26fdac5ebb8ae6613
ScriptHash: 0x19d69593a368ba01b2aac8dc0a67d7b675e1e640
```

创建的钱包文件存放在 Neo-CLI 根目录下，如果要指定其它路径，需要先创建好文件夹。

### open wallet

打开指定路径的钱包文件。打开钱包时需要输入钱包密码。

##### 句法

 `open wallet <path>` 

##### 示例

```
neo> open wallet test.json
password: *
```

### change password

修改钱包密码。

##### 句法

 `change password` 

##### 示例

```
neo> change password
password: ***
New password: ***
Re-Enter Password: ***
Password changed successfully
```

### upgrade wallet

升级旧版 .db3 钱包文件。

##### 句法

 `upgrade wallet <path>` 

##### 示例

```
neo> upgrade wallet test.db3
Wallet file upgrade complete. New wallet file has been auto-saved at: test.json
```

### show gas

列出当前钱包中的所有未提取的 GAS。

##### 句法

`show gas` 

##### 示例

```
neo> show gas
Unclaimed gas: 16.7367406
```

> [!NOTE]
>
> 这里不包含已提取的 GAS，查看已提取的 GAS 请用 list asset 命令。

在 Neo N3 中，某地址每次 NEO 数量发生改变时都会触发其 GAS 的自动提取。

### create address

在当前钱包中创建一个地址或批量创建地址。创建的地址会自动导出到 address.txt 文件中。

##### 句法

`create address [n]` 

##### 参数

`n`：要创建的地址数量。n 为正整数，不填默认为1

##### 示例

```
neo> create address 3
The file 'address.txt' already exists, do you want to overwrite it? (yes|no): yes
[3/3]
Export addresses to address.txt
```

### balanceof

查询指定 token 指定地址的余额

##### 句法

 `balanceof <tokenHash> <address>`

##### 参数

- `tokenHash`：指定 token 的 hash

- `address`：指定查询地址

##### 示例

```
neo> balanceof 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o
Invoking script with: '0c14b97b4acd7f820f61d2d4d4f9aea5eb50498ddf5511c00c0962616c616e63654f660c14ec99f691c0f7dfa41400473edd1c2afceb70c2d241627d5b52'
VM State: HALT
Gas Consumed: 0.0373876
Result Stack: [{"type":"Integer","value":"1998380000000000"}]

{{$Token Name}} balance: 19983800
```

### decimals

查询指定 token 的精度

##### 句法

 `decimals <tokenHash>`

##### 参数

- `tokenHash`：指定 token 的 hash

##### 示例

```
neo> decimals 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec
Invoking script with: '10c00c08646563696d616c730c14ec99f691c0f7dfa41400473edd1c2afceb70c2d241627d5b52'
VM State: HALT
Gas Consumed: 0.0125075
Result Stack: [{"type":"Integer","value":"8"}]
Result : 8
```

### transfer

调用指定 token 的 transfer 方法转账

##### 句法

 `transfer <tokenHash> <to> <amount> [from=null] [data=null] [signersAccounts=null]`

##### 参数

- `tokenHash`：指定 token 的 hash
- `to`：指定收款地址
- `amount`：转账金额
- `from`：转出地址
- `data`：transfer 方法的附加参数，默认为空
- `signersAccounts`：添加签名的账户

##### 示例

```
neo> transfer 0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec Nhe4mzfQRoKojkXhqxJHjANvBMT7BYAXDv 6000 NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y transferdata NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y
Relay tx(no|yes): y
Signed and relayed transaction with hash=0x0d82a59ca2106c93e6383893d86a098d1a9fbf950c091772c61790880acc78c5
```

### list nativecontract

列出所有原生合约的名字及 scripthash


##### 句法

 `list nativecontract`

##### 参数

无


##### 示例

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
```

### get accountstate

获取指定账户最新的投票情况，如投票地址，所投票数和投票的区块高度。

##### 句法

 `get accountstate <address>` 

##### 参数

`address`：要查询投票情况的地址

##### 示例

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

获取候选人公钥及票数

##### 句法

 `get candidates`

##### 参数

无

##### 示例

```
neo> get candidates
Invoking script with: '10c00c0d67657443616e646964617465730c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Candidates:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d      49900000
```

### get committee

获取委员会成员公钥

##### 句法

 `get committee`

##### 参数

无

##### 示例

```
neo> get committee
Invoking script with: '10c00c0c676574436f6d6d69747465650c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Committee:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d
```

### get next validators

获取下一轮验证人公钥

##### 句法

 `get next validators`

##### 参数

无

##### 示例

```
neo> get next validators
Invoking script with: '10c00c166765744e657874426c6f636b56616c696461746f72730c1425059ecb4878d3a875f91c51ceded330d4575fde41627d5b52'
VM State: HALT
Gas Consumed: 1.0100757

Next validators:
02344389a36dfc3e95e05ea2adc28cf212c0651418cfcf39e69d19d18b567b221d
```

### register candidate

注册候选人

##### 句法

 `register candidate <account> [maxGas=1010]`

##### 参数

`account`：注册者账户

`maxGas`: 最大花费 GAS，默认为 1010，其中注册费用 1000 GAS。

##### 示例

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

注销候选人

##### 句法

 `unregister candidate <account>`

##### 参数

- `account`：注册者账户

##### 示例

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

投票

##### 句法

 `vote <senderAccount> <publicKey>`

##### 参数

- `senderAccount`：用来投票的账户
- `publickey`：被投票地址的公钥

##### 示例

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

取消投票

##### 句法

 `unvote <senderAccount>`

##### 参数

- `senderAccount`：取消投票的账户

##### 示例

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

导出地址对应的私钥到指定的文件。该命令需要验证钱包密码。

##### 句法

 `export key [address] [path]`

##### 参数

- `address`：指定要导出私钥的地址

- `path`：指定保存私钥的文件路径


##### 示例

将私钥输出到控制台：

```
neo> export key
password: ********
L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
L3raEwVsJHzovTXfgVG1HWxzmH4Zm3vMia8byszhVrvbJ38YnsXv
KywrMAnBWRXUAb4Aq76ZoCCqDvGNL9nidjVwWwDr3DbMPwg1RPBL
KwhNLC9rULxJmevqwYbQzJhYNvaCDPyAUAm7EkHrW5kQwLYfxTFG
```

将私钥输出到指定文件中：

```
neo> export key key1.txt
password: ********
```

```
neo> export key key2.txt NPpH6FxNaVXZCrsecNWEHGLwMe87UkPdm5
password: ********
```

### import key

导入一个私钥或者指定文件中的多个私钥。

##### 句法

 `import key <wif | path>`

##### 参数

`wif | path`：指定要导入的私钥，或者存放私钥的文件路径

##### 示例

```
neo> import key L4q37aCJzjEXhAUJ6npdxbjGGbyTXuWhpgYxkb2NWPmzXv4DdxiD
Address: NPpH6FxNaVXZCrsecNWEHGLwMe87UkPdm5
 Pubkey: 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
```

```
neo> import key key1.txt
```

如果是指定文件的话，文件里的私钥格式请参考 export key key.txt 的输出。

### import multisigaddress

创建多方签名地址。

##### 句法

`import multisigaddress m pubkeys...`

##### 参数

- `m`：以 m 个最小签名数量来创建多方签名的地址，例如两个公钥创建的多方签名地址， m 可以为 1 或 2
- `pubkeys`：创建多方签名地址的各方公钥

##### 示例

```
neo> import multisigaddress 2 03fadbc9b25d1b6827124665c50801e602240c9d8ebdda2bae49de6683f8f86af9 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
Multisig. Addr.: NN58k4Ei4nUzWxrgksHZPantyuDxWgouod
```

### import watchonly

导入只监听的地址，例如合约账户。

##### 句法

`import watchonly <addressOrFile>`

##### 参数

`addressOrFile`：账户地址/ hash 或合约 hash，或者存有这些数据的文件

##### 示例

```
neo> import watchonly 0xbfe215933f29b29dacf0e8383722a62974ac8aa6
Address: Nb6ZUp9h5aCKkNADpdUD5TbuJGP6wyRvE8
```

### send

向指定地址转账。该命令需要验证钱包密码。

##### 句法

`send <id | alias> <address> <amount> [from=null] [data=null] [signerAccounts=null]`

##### 参数

- `id | alias`：资产 ID或资产缩写，如 neo，gas
- `address`：收款地址
- `amount`：转账金额
- `from`：转出地址
- `data`：交易附加信息，默认为空
- `signerAccounts`：需要添加签名的账户

##### 示例

将 100 GAS 转到地址 “Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR”：

```
neo> send 0xd2a4cff31913016155e38e474a2c06d08be276cf Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR 100
password: *
TXID: 0xf8b9824808c037893525a60f2f8d4ec034dffe8ac17d4142ff889e2e712d8df1
```

因为第二个参数除了资产 ID，还可以填写资产缩写，所以以上命令可以写成：

```
neo> send gas Ni5iS2XHazKZtXfzLJbdyDk8UUcGBZGePR 100
password: *
TXID: 0xea2454d0210aefff406097e03abd2137dc416617adac6f23842ca1914d001419
```

要查看资产 ID ，可输入 `list asset` 命令查看钱包中的所有资产。

当从签名数量为 1 以上的多方签名合约地址中转出资产时，需要多方进行签名，此时会返回一段待签名的 json 字符串，如下所示： 

```
neo> send neo NdJ5Nbs7gvmjDmqraVCJy8nPQxue1e5LK1 10
password: *
SignatureContext:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="}}}}
```

如果从合约中转出资产，from 为合约 hash，签名账户需要包含合约 hash 和鉴权账户 verify account，例如：
```
neo> send 0x70e2301955bf1e74cbb31d18c2f96972abadb328 NZttvm9tAhMjyxZATvqN9WFYkHYMNaXD6C 0.000002 0x436b18e7b624c0323b090141a89e79a3ab588b6a transferdata 0x436b18e7b624c0323b090141a89e79a3ab588b6a NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y
password: *
TXID: 0x174bab85eb004a07ae5b411f23cb6d3128346f9249305a768c286707938b4727
```

### sign

该命令用于给 ContractParametersContext 签名。签名完整后才能广播出去，广播交易的方法请参照 relay 方法。

##### 句法

`sign <jsonObjectToSign>` 

##### 参数

`jsonObjectToSign`：记录多方签名交易的 json 字符串

##### 示例

```
neo> sign {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"},{"type":"Signature"}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="}}}}
Signed Output:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature","value":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="},{"type":"Signature","value":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA=="},{"type":"Signature","value":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="},{"type":"Signature","value":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ=="},{"type":"Signature","value":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ==","0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ==","020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ==","025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA==","038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="}}}}
```

返回已签名的 json 字符串。如果签名已完整，则可以通过 relay 指令广播交易。

###  deploy

将智能合约发布到链上。

##### 句法

`deploy <nefFilePath> [manifestFile]` 

##### 参数

- `nefFilePath`：NeoVM的可执行文件 nef 的路径
- `manifestFile`：可选，manifest.json 文件的路径，manifest 记录了合约的各个接口信息以及配置内容,如果为空，则程序会自动匹配与 nef 文件同名的 manifest.json 文件

##### 示例

```
neo> deploy Template.nef Template.manifest.json  
Script hash: 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6
Gas Consumed: 1

Signed and relayed transaction with hash=0xab6dd63ea36a7c95580b241f34ba756e62c767813be5d53e02a983f4e561d284
```

### invoke

调用合约

##### 句法

`invoke <scriptHash> <operation> [contractParameters=null] [sender=null] [signerAccounts=null] [maxGas]` 

##### 参数

- `scripthash` ：要调用的合约脚本散列

- `operation` ：合约内方法名，后面可以输入传入参数，以空格隔开

- `contractParameters` 为调用参数，需要传入 JSON 格式的字符串，如果是 ByteArray，需要提前进行 Base64编码

  示例：地址 `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` 可转换为 16 进制大端序的 ScriptHash `0xe4b0b6fa65a399d7233827502b178ece1912cdd4` 也可转换为 Base64 编码的 ScriptHash `1M0SGc6OFytQJzgj15mjZfq2sOQ=`。JSON 格式的参数如下：

  ```
  [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
  [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
  ```

- `sender` ：交易发送方，即支付 GAS 费的账户

- `signerAccounts` 为附加签名地址数组，只支持标准账户（单签地址），填写后 Neo-CLI 会为调用交易附加该数组内所有地址的签名

- `maxGas`: 最大花费 GAS

##### 示例 1 

示例输入：

```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 symbol
```

示例输出：

```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"VG9rZW5TeW1ib2w="}]

relay tx(no|yes):
```

- VM State：`HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- Gas Consumed ：调用智能合约时消耗的系统手续费。

- Evaluation Stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。

##### 示例 2

示例输入：

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
```

示例输出：

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

示例输入：

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
```

或

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"d4cd1219ce8e172b50273823d799a365fab6b0e4"}]
```

示例输出：

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

##### 示例 3

示例输入：

```
neo> invoke 0x70e2301955bf1e74cbb31d18c2f96972abadb328 transfer [{"type":"Hash160","value":"0x436b18e7b624c0323b090141a89e79a3ab588b6a"},{"type":"Hash160","value":"0xb4ba98beea38621dd96a9804384db24451b1cff2"},{"type":"Integer","value":"1"}] 0x436b18e7b624c0323b090141a89e79a3ab588b6a 0x436b18e7b624c0323b090141a89e79a3ab588b6a NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y
```
示例输出：

```
Invoking script with: '110c14f2cfb15144b24d3804986ad91d6238eabe98bab40c146a8b58aba3799ea84101093b32c024b6e7186b4313c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52'
VM State: HALT
Gas Consumed: 0.0900796
Result Stack: [{"type":"Boolean","value":true}]
Relay tx(no|yes): no
```

> [!Note]
>
> 当输入 invoke 命令后，节点调用合约中的 `operation` 方法，并将 `operation` 和 `contractParameters` 作为实参传入。如果合约里没有对 `operation` 和 `contractParameters` 做处理，将不能返回预期的结果。

###  update

升级合约。

##### 句法

`update <scriptHash> <filePath> <manifestPath> <sender> [signerAccounts=null]` 

##### 参数

- `scriptHash`：要升级的合约hash

- `nefFilePath`：NeoVM的可执行文件 nef 的路径
- `manifestFile`：manifest.json 文件的路径，manifest 记录了合约的各个接口信息以及配置内容,如果为空，则程序会自动匹配与 nef 文件同名的 manifest.json 文件
- `sender` ：交易发送方，即支付 GAS 费的账户
- `signerAccounts` ：附加签名地址数组，只支持标准账户（单签地址），填写后 Neo-CLI 会为调用交易附加该数组内所有地址的签名

##### 示例

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

将完成签名的交易信息进行广播。

##### 句法

`relay <jsonObjectToSign>` 

##### 参数

`jsonObjectToSign`：记录签名交易的 json 字符串

##### 示例

```
neo> relay {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"AFhJmTC0i5cAAAAAAHwNhQAAAAAA12oAAAK\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAD4JGXeIikja1DoxoxIKrkYu6bW7AEAVwsaDBS\u002BqHRB6GdCJbuT4Xv76Od/eEbFVAwU\u002BCRl3iIpI2tQ6MaMSCq5GLum1uwUwB8MCHRyYW5zZmVyDBT1Y\u002BpAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQ==","items":{"0x54c546787fe7e8fb7be193bb254267e84174a8be":{"script":"DCECF5VDAAGEeB5UR7Pw\u002B6zmZOqSt\u002BMSJ8jnG8Tnza/M245BdHR2qg==","parameters":[{"type":"Signature","value":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"gyzhpmI0KRkAJmd8cWtv7PdFLRlS\u002BHqykL0oH/S84Te4DGwRd9ja/TfKW2\u002BHTSrdfUdnN/K8CF0kf0UywcTKCw=="}},"0xecd6a6bb18b92a488cc6e8506b232922de6524f8":{"script":"FQwhAwIkKx3O1j4b9\u002BsUh29\u002B8Ca3lWf5xb6D3hlD3Rhewo5oDCECDfiFi2b/TXsKamjRHd7cx9kNKmT/os0IfExdq/QVC0AMIQIXlUMAAYR4HlRHs/D7rOZk6pK34xInyOcbxOfNr8zbjgwhAl6ElJA7k9w2nwiivX4iH1dMddlnVZHwSQfLqdruuD0QDCEDhBXQvo3BK2HT47drmPRk36t/3e50Jxw14t5iS7UQI6YMIQPJscicbi1KvWKaLbi30DrO1RilZ5O8kPSYXvftPxtIGgwhA\u002BirUYbh3qvNEOwOUJ3tT/\u002Bt5v3fU0rD4FBiaLrj/USmF0F7zmyl","parameters":[{"type":"Signature","value":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="},{"type":"Signature","value":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA=="},{"type":"Signature","value":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ=="},{"type":"Signature","value":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ=="},{"type":"Signature","value":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ=="}],"signatures":{"02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e":"/3oqPLUuFig8B66JNnlyVsA9klLm10LLA5sV/oDr9uzCAPh\u002BDL0yJWx2PfEd\u002BIWijBk/re90CHyJ3w1WkB71eQ==","0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68":"T0PQ9vQNDtDnpa3f9UtN3\u002B22SOFbVG8NBwvu3tq6YchsMbF4OmlBFtNa\u002BZuqT3fxP0r/naAYgnwHMDG8DXAeSQ==","020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40":"cUmlfjxdWmPTSpHsJHqr8lLllclJNGroOmStMLXzOI4fcO3D5/JKru/rU/OC029il\u002B8sVteUmL0rEaLnldKMrQ==","025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10":"DhhX8mwnLRVVU9hRjdGJ/Pdq10ytpn8xJUOXWqy3I8cE/Midc6s3dvzMt1QH\u002BPn2xDGjkzNNcczI34reE\u002BaCpA==","038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6":"QYZ4LuSpqSWZ8RzowvPZ8U0o3HjwhPlDf2jmOV3Rglq4Rm4KvMpIqfmuLdrEkecHe1MSP1AcEvE/c2FhdZ98UQ=="}}}}
Data relay success, the hash is shown as follows:
0xc65c3b3618823238b2b5589dba54c665f86310c85a3460f901cfb0030d4dbf28
```

### broadcast addr
广播一个节点 IP 地址。

##### 句法

`broadcast addr <IPAddress> <port>`

##### 示例

```
neo> broadcast addr 127.0.0.1 10332
neo> 
```

### broadcast block
广播一个区块。

##### 句法

`broadcast block <block-hash> `

`broadcast block <block-height> `

##### 示例

```
neo> broadcast block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast block 537
neo> 
```

### broadcast getblocks
广播 getblocks 请求。

##### 句法

`broadcast getblocks <block-hash> `

##### 示例

```
neo> broadcast getblocks 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getheaders
广播 getheaders 请求。

##### 句法

`broadcast getheaders <block-hash> `

##### 示例

```
neo> broadcast getheaders 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### broadcast getdata
广播 getdata 请求。

##### 句法

`broadcast getdata <inventory type> <payload> `

##### 示例

```
neo> broadcast getdata Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
neo> broadcast getdata TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
neo> broadcast getdata Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo>
```

### broadcast inv
广播 inventory data。

##### 句法

`broadcast inv <inventory type> <payload> `

##### 示例

```
neo> broadcast inv Block 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
 
neo> broadcast inv TX 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052

neo> broadcast inv Consensus 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
```

### broadcast transaction
广播一笔交易。

##### 句法

`broadcast transaction <transaction hash> `

##### 示例

```
neo> broadcast transaction 0xd57bbbadee0b8ff283961f886cdc6d455ab8b5301ccdf5359d7316f209064052
neo> 
```

### plugins

显示所有已加载的插件。

##### 句法

`plugins`

##### 示例

```
neo> plugins
Loaded plugins:
        ApplicationLogs     Synchronizes the smart contract log with the NativeContract log (Notify)
        DBFTPlugin          Consensus plugin with dBFT algorithm.
        LevelDBStore        Uses LevelDB to store the blockchain data
        OracleService       Built-in oracle plugin
        TokensTracker     Enquiries NEP-17 balances and transaction history of accounts through RPC
        RpcServer           Enables RPC for the node
        StatesDumper        Exports Neo-CLI status data
        StateService        Enables MPT for the node
```

### install

安装指定插件

`install [Plugin name]` 

安装指定插件，如下所示。卸载插件与此类似。

```
neo> install RpcServer
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.3/RpcServer.zip
Install successful, please restart neo-cli.
```

以上只是示例插件，更多插件请参考 [安装插件](config.md#安装插件)。

### dump storage

导出全部或指定的状态量数据。

##### 句法

`dump storage <key>`

### export blocks

从指定区块高度导出区块数据，导出的结果可以用作离线同步。

##### 句法

`export blocks <index>`

##### 参数

`<index> `：指定要导出数据的起始区块高度

### start consensus

启动共识。此命令是 DBFTPlugin 插件提供的，使用前需要安装该插件。启动共识的前提是当前钱包有共识的权限，在 Neo 主网上可以通过投票选举获得共识的权限，如果自己部署的私有链，可以在 `protocol.json` 中设置共识节点的公钥，详情可参考 [私链搭建](../../develop/network/private-chain/private-chain2.md)。


### start oracle
启动 Oracle 服务。此命令由 OracleService 插件提供，使用前需要安装该插件。开启 Oracle 服务的前提是当前钱包地址的公钥已经被委员会指定了 Oracle 角色。

### stop oracle
停止 Oracle 服务。此命令由 OracleService 插件提供，使用前需要安装该插件。

### state root
通过高度查询 state root，需要安装 StatePlugin 插件。

##### 句法

`state root <index>`

##### 参数

`<index> `：区块索引

```
neo> state root 20000
{"version":0,"index":20000,"roothash":"0x0121262f9833b21eae7b8d375c1c334fdd4d4500f1d3fad2da669d5b83e94157","witness":{"invocation":"DECny9LhRZpH61UNC/sXG9WEBFMl7cf1rZPT7U0tCvZa\u002BHs6rG/fz2gKTfvLBUp5lcmGDlrMlKCCfKoougYGt7s4DEAuhkhPROcr2FM5SSHCl5LFWSTrcvxa6rvmLc1NGXwpgcRHV9LY5/H6q5SnwdAW3DSspap93FjvSHqU48Mn41nGDEDI5G6bGhGvyLl8rZbT0LzAHRbQUZ2OWIcnFi/Jo/QtwZoCGrK6L3g2miCXsgkckzUsJ1DoruMzKgVEFb4t/KYBDEAWC2fagW\u002BOt6iUGyo\u002BNu0zC1jl105uLyv5bY4tE03vBjbJDTm1T3o17jC8b3HMaeYMro2IGZTSOGt3b9YF6ntiDEBaMGwM/\u002Bd\u002BkTHmBb9c\u002BuCfMkEHOez8XuyoSZotQdDCtaVMCT4wHwIHspxeGGp1iVIEtEYFhJl0EfPEObcO0YfGDEBCC3/hBNLGmusDpr4gDfD6asqjyNCGPNerYIHunu2gsOr6kr3uQJBFqaXSYp\u002BCkz9HBrc6Cq2fNz4HPn/tIo5S","verification":"FgwhAwAqLhjDnN7Qb8Yd2UoHuOnz\u002BgNqcFvu\u002BHZCUpVOgtDXDCECAM1gQDlYokm5qzKbbAjI/955zDMJc2eji/a1GIEJU2EMIQIhkM6Z1WxnvBcDTCedOLpwWTZHFtEduMhLpf3Z/AJgEQwhAzU7wXKtEGB62apHDocfRKJil\u002ByBAIP6J8aLnJSjTL/5DCECNxinjeXEq5HT3NK2m0dPLTUIuN3EeHiMupRY6Sj\u002B/qYMIQKXhyDsbFxYdeA0d\u002BFsbZj5AQhamA13R64ysGgh19j6UwwhAqPXy4P0JIWNvpx5c9df/ut8OUCIRJ9onGacn09vEIVODCEDySUJ5CjN1/ek/dSpfGeJELQPFGXd3k8En3MlrzOAeSkYC0ETje\u002Bv"}}
```

### get proof

通过 root hash，合约 hash 和 storage key 查询得到 proof
##### 句法

`get proof <root hash> <script hash> <key>`

##### 参数
* `<root hash>`: state root 的 hash
* `<script hash>`: 合约 hash
* `<key>`: 存储区的 key值，使用 Base64 编码格式

```
neo> get proof 0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca 0x79bcd398505eb779df6e67e4be6c14cded08e2f2 Fw==
Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA=
```

### verify proof

使用 root hash 和 proof 进行验证，得到 key 对应存储区的值

##### 句法

`verify proof <root hash> <proof>`

##### 参数
* `<root hash>`: state root 的 hash
* `<proof>`: state root 对应的 proof 数据，使用 Base64 编码格式

```
neo> verify proof 0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA=
AAI=
```