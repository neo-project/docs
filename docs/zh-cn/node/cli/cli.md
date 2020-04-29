# CLI 命令参考

打开命令行，定位到 Neo-CLI 所在目录，输入以下命令即可启动 Neo 的命令行钱包。

`dotnet neo-cli.dll`

本节将介绍命令行钱包的所有命令，你可以通过输入命令操作钱包，如创建打开钱包、导入导出私钥、转账、启动共识等。

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
| version            | 显示当前软件的版本                     |
| help [plugin-name] | 帮助菜单，也可以查看部分插件的提示信息 |
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
| [change password](#change-password)               | \<path>                                | 修改钱包密码                 |
| list address                                      |                                        | 列出钱包中的所有账户         |
| list asset                                        |                                        | 列出钱包中的所有资产         |
| list key                                          |                                        | 列出钱包中的所有公钥         |
| [show gas](#show-gas)                             |                                        | 列出钱包中的所有未提取的 GAS |
| [create address](#create-address)                 | [n=1]                                  | 创建地址 / 批量创建地址      |
| [import key](#import-key)                         | \<wif\|path>                           | 导入私钥 / 批量导入私钥      |
| [export key](#export-key)                         | \[path] [address script hash]          | 导出私钥                     |
| [import multisigaddress](#import-multisigaddress) | \<m> \<pubkey1 pubkey2 ...>            | 创建多方签名合约            |
| [send](#send)                                     | \<id\|alias> \<address> \<amount>\|all | 向指定地址转账               |
| [sign](#sign)                                     | \<jsonObjectToSign>                    | 对多方签名交易进行签名       |

#### 合约命令

| 命令              | 参数                                                         | 说明     |
| ----------------- | ------------------------------------------------------------ | -------- |
| [deploy](#deploy) | \<nefFilePath> [manifestFile]                                | 发布合约 |
| [invoke](#invoke) | \<scripthash> \<command> \[optionally quoted params separated by space\] \[witness address separated by space\]| 调用合约 |

#### 节点命令

| 命令            | 参数                | 说明                                           |
| --------------- | ------------------- | ---------------------------------------------- |
| show state      |                     | 显示当前区块链同步状态                         |
| show pool       | [verbose]           | 显示内存池中的交易（这些交易处于零确认的状态） |

#### 网络命令

| 命令            | 参数                | 说明                                           |
| --------------- | ------------------- | ---------------------------------------------- |
| [relay](#relay) | \<jsonObjectToSign> | 将完成签名的交易信息进行广播               |
| [broadcast addr](#broadcast-addr) |  \<payload IP address> \<port>   | 广播节点 IP 地址 |
| [broadcast block](#broadcast-block) |  \<block hash \| block height>  | 广播一个区块 |
| [broadcast getblocks](#broadcast-getblocks) |  \<block hash>  | 广播 getblocks 请求 |
| [broadcast getdata](#broadcast-getdata) |  \<inventory type> \<payload>  | 广播 getdata 请求 |
| [broadcast getheaders](#broadcast-getheaders) |  \<block hash>  | 广播 getheaders 请求 |
| [broadcast inv](#broadcast-inv) |  \<inventory type> \<payload>  | 广播 inventory data |
| [broadcast transaction](#broadcast-transaction) |  \<transaction hash>  | 广播一条交易 |

#### 插件命令

| 命令                    | 参数       | 说明         |
| ----------------------- | ---------------- | ---------------- |
| [plugins](#plugins) |  | 显示已加载的插件 |
| [install](#install) | [Plugin name] | 安装指定插件     |
| [uninstall](#install) | [Plugin name] | 卸载指定插件     |
| [dump storage](#dump-storage) | \<key> | 导出全部或指定的状态量数据 |
#### 高级命令

| 命令                                | 参数     | 说明                                                   |
| ----------------------------------- | -------- | ------------------------------------------------------ |
| [export blocks](#export-blocks) | \<start> \[block count] \[export path] | 从指定区块高度导出区块数据，导出的结果可以用作离线同步 |
| [start consensus](#start-consensus) |          | 启动共识                                               |

## 命令说明

### create wallet

创建一个 .db3 或 .json 钱包文件。创建过程中需要设置钱包密码。

##### 句法

 `create wallet <path>` 

##### 示例

```
neo> create wallet test.json
password: *
password: *
address: ATGBeteuYJsHwUVt6xMdxZMV9Y7BkV51yn
pubkey: 0399e96a2970c83e26ad66de36a4bad0512a62defd447e3e26723fac73d4072ba1
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
unclaimed gas: 0
```

> [!NOTE]
>
> 这里不包含已提取的 GAS，查看已提取的 GAS 请用 list asset 命令。

在 Neo3 中，某地址每次 NEO 数量发生改变时都会触发其 GAS 的自动提取。

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
export addresses to address.txt
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

```
neo> export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9
password: ********
L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
```

将私钥输出到指定文件中：

```
neo> export key key1.txt
password: ********

```

```
neo> export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9 key2.txt
password: ********

```

### import key

导入一个私钥或者指定文件中的多个私钥。

##### 句法

 `import key <wif|path>`

##### 参数

`wif|path`：指定要导入的私钥，或者存放私钥的文件路径

##### 示例

```
neo> import key L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH
address: AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9
 pubkey: 03768c9fc17a01854084b836d3f0ae4122902b4b59b6c11e855a3f3bf8ea6b205f
```

```
neo> import key key1.txt
```

如果是指定文件的话，文件里的私钥格式请参考 export key key.txt 的输出。

### import multisigaddress

创建多方签名的合约地址。

##### 句法

`import multisigaddress m pubkeys...`

##### 参数

- `m`：以 m 个最小签名数量来创建多方签名的合约地址，例如两个公钥创建的多方签名地址， m 可以为 1 或 2
- `pubkeys`：创建多方签名合约地址的各方公钥

##### 示例

```
neo> import multisigaddress 1 022b386a0ac6fa5abad4bfabc7dff3c016654fa97176811cb64f4831284a7399ca 0288a99d33b6f7f1b19d3be7a7935d2c076fec52d9591336af03e43eec8ca1b16b
Multisig. Addr.: AYpc268sh4tff7CTj5W4tztt1qheVTUa6P
```

### send

向指定地址转账。该命令需要验证钱包密码。

##### 句法

`send <id|alias> <address> <amount>|all`

##### 参数

- `id|alias`：资产 ID或资产缩写，如 neo，gas
- `address`：收款地址
- `amount|all`：转账金额

##### 示例

将 100 GAS 转到地址 “AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e”：

```
neo> send a1760976db5fcdfab2a9930e8f6ce875b2d18225 AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0x8f831d8de723093316c05749a053a226514bc06338b2bceb50db690610e0b92f
```

因为第二个参数除了资产 ID，还可以填写资产缩写，所以以上命令可以写成：

```
neo> send gas AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0xae0675797c2d738dcadb21cec3f1809ff453ac291046a05ac679cbd95b79c856
```

要查看资产 ID ，可输入 `list asset` 命令查看钱包中的所有资产。

当从签名数量为 1 以上的多方签名合约地址中转出资产时，需要多方进行签名，此时会返回一段待签名的 json 字符串，如下所示： 

```
neo> send gas ARfyrX28D2H2wP6KR6xxaUbvqvkv5SbMNe 2
password: ********
SignatureContext:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature"},{"type":"Signature"}],"signatures":{"032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff00":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}}}}
```

### sign

从签名数量为 1 以上的多方签名合约中提取资产时，需要多方进行签名， 签名完整后才能广播出去，广播交易的方法请参照 relay 方法。

##### 句法

`sign <jsonObjectToSign>` 

##### 参数

`jsonObjectToSign`：记录多方签名交易的 json 字符串

##### 示例

```
neo> sign {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature"},{"type":"Signature"}],"signatures":{"032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff00":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}}}}
Signed Output:
{"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature","value":"794f87a810bd30b15f90ddc1898e2e592c1a3fae4b14e34d8a411305e7913d44ab56e388125ef597be46a8958b2ed8c5e298076c2d69ab3337c944f5356c462b"},{"type":"Signature","value":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}]}}}
```

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

`invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]` 

##### 参数

- `scripthash` ：要调用的合约脚本散列

- `operation` ：合约内方法名，后面可以输入传入参数，以空格隔开

- `contractParameters` 为调用参数，需要传入 JSON 格式的字符串，如果是 ByteArray，需要提前进行 Base64编码

  示例：地址 `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` 可转换为 16 进制大端序的 ScriptHash `0xe4b0b6fa65a399d7233827502b178ece1912cdd4` 也可转换为 Base64 编码的 ScriptHash `1M0SGc6OFytQJzgj15mjZfq2sOQ=`。JSON 格式的参数如下：

  ```
  [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
  [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
  ```

- `witnessAddress` 为附加签名地址数组，只支持标准账户（单签地址），填写后 Neo-CLI 会为调用交易附加该数组内所有地址的签名

##### 示例 1 

示例输入：

```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 name
```

示例输出：

```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"TXlUb2tlbg=="}]

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

> [!Note]
>
> 当输入 invoke 命令后，节点并不是直接调用合约中的 `operation` 方法。而是调用该合约的 `main` 方法，并将 `operation` 和 `contractParameters` 作为实参传入。如果 main 方法里没有对 `operation` 和 `contractParameters` 做处理，将不能返回预期的结果。

### relay

将完成签名的交易信息进行广播。

##### 句法

`relay <jsonObjectToSign>` 

##### 参数

`jsonObjectToSign`：记录签名交易的 json 字符串

##### 示例

```
neo> relay {"type":"Neo.Network.P2P.Payloads.Transaction","hex":"0071c0992d42e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c00e1f50500000000ac0c240000000000cb152300000142e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c01550400c2eb0b146c93f190909dea8dfe3caeb2ee90530b4ef21e861442e2a62c8b763b5de5b0e1b2e239a7bbd2952a0c53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1","items":{"0x0c2a95d2bba739e2b2e1b0e55d3b768b2ca6e242":{"script":"5221032528d085e55de82b801374ea91cc51b5e6e990ba2eddb2f461c4d95da54aff002102685dd451efbf38cf859a80f250815f503303dd7b9f6546786164de219ede87735268c7c34cba","parameters":[{"type":"Signature","value":"794f87a810bd30b15f90ddc1898e2e592c1a3fae4b14e34d8a411305e7913d44ab56e388125ef597be46a8958b2ed8c5e298076c2d69ab3337c944f5356c462b"},{"type":"Signature","value":"d9ac57bac4260c60707e0b641585c70789e1a2eb5438c95de972af9aff99f5f4485b81cd2382218583b7f4950da54dbd8d1468f72b91809e14bb1c8139cca637"}]}}}
Data relay success, the hash is shown as follows:
0xdcf144d9ed2d64482fb5caafa719cf6706e9afd607ab043e8bfcb9018795e4d1
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
        ApplicationLogs
        LevelDBStore
        RpcServer
        RpcNep5Tracker
        StatesDumper
        SystemLog
```

### install

安装指定插件

`install [Plugin name]` 

安装指定插件，如下所示。卸载插件与此类似。

```
neo> install RpcServer
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v3.0.0-preview2-00/RpcServer.zip
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

启动共识。启动共识的前提是该钱包有共识的权限，在 Neo 主网上可以通过投票选举获得共识的权限，如果自己部署的私有链，可以在 `protocol.json` 中设置共识节点的公钥，详情可参考 [私链搭建](../../network/private-chain/private-chain2.md)。

> [!NOTE]
>
> 若需要查看共识过程日志，需要先安装 [SystemLog](https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2/SystemLog.zip) 插件 。
