# CLI 命令参考

打开命令行，定位到 NEO-CLI 所在目录，输入下面代码即可启动 NEO 的命令行钱包。

`dotnet neo-cli.dll`

本篇教程将介绍命令行钱包的所有命令，你可以通过输入命令操作钱包，如创建打开钱包、导入导出私钥、转账、启动共识等。在命令行中输入 `help` 可以查看所有命令。

> [!NOTE]
>
> 命令中尖括号 `<>` 表示参数，方括号 `[]` 表示可选参数，或符号 `|` 表示所填的参数可以是其中任意一种，等号 `=` 表示可选参数在不输入情况下的默认值。

## 控制台命令

| 命令      | 功能说明      |
| ------- | --------- |
| version | 显示当前软件的版本 |
| help    | 帮助菜单      |
| clear   | 清除屏幕      |
| exit    | 退出程序      |

## 合约命令

| 命令                                       | 功能说明                              | 备注     |
| ---------------------------------------- | --------------------------------- | ------ |
| deploy \<avmFilePath>...<contractDescription>    | 发布合约                            |        |
| invoke \<scripthash>...<command>                 | 调用合约                            |        |

### 命令说明
👉 `deploy <avmFilePath> <paramTypes> <returnTypeHexString> <hasStorage (true|false)> <hasDynamicInvoke (true|false)> <isPayable (true|false) <contractName> <contractVersion> <contractAuthor> <contractEmail> <contractDescription>` 

发布合约

```
neo> deploy Template.avm 0710 05 true false false aws 1.0.0 owen neo@neo.org hello   
Script hash: 0xee91a961c1464d43c4e80a44a447698973cb818b
VM State: HALT
Gas Consumed: 500
Evaluation Stack: [{"type":"InteropInterface"}]

Signed and relayed transaction with hash=0x81dae9680b75befb450920bdc8693cba34c913aa421cd1226ed1620555c95f23

```

👉 `invoke <scripthash> <command> [optionally quoted params separated by space]` 

调用合约

```
neo> invoke ee91a961c1464d43c4e80a44a447698973cb818b deploy
Invoking script with: '00c1066465706c6f79678b81cb73896947a4440ae8c4434d46c161a991ee'
VM State: HALT
Gas Consumed: 2.191
Evaluation Stack: [{"type":"Integer","value":"1"}]

relay tx(no|yes): yes
Signed and relayed transaction with hash=0x69edfe59bd1cfdb8fecc7eb5623bc44d785a4897cdbee78f9d276924d9ad3946
```


## 钱包命令

| 命令                                       | 功能说明                              | 备注     |
| ---------------------------------------- | --------------------------------- | ------ |
| create wallet \<path>                    | 创建钱包文件                            |        |
| open wallet \<path>                      | 打开钱包文件                            |        |
| close wallet                             | 关闭钱包文件                            |        |
| upgrade wallet \<path>                   | 升级旧版钱包文件                          |        |
| rebuild index                            | 重建钱包索引                            | 需要打开钱包 |
| list address                             | 列出钱包中的所有账户                        | 需要打开钱包 |
| list asset                               | 列出钱包中的所有资产                        | 需要打开钱包 |
| list key                                 | 列出钱包中的所有公钥                        | 需要打开钱包 |
| show utxo [id\|alias]                    | 列出钱包中指定资产的 UTXO                   | 需要打开钱包 |
| show gas                                 | 列出钱包中的所有可提取及不可提取的 GAS             | 需要打开钱包 |
| claim gas [all]                          | 提取钱包中可提取状态的 GAS（前50个地址或所有地址）             | 需要打开钱包 |
| create address [n=1]                     | 创建地址 / 批量创建地址                       | 需要打开钱包 |
| import key \<wif\|path>                  | 导入私钥 / 批量导入私钥                       | 需要打开钱包 |
| export key \[address] [path]             | 导出私钥                              | 需要打开钱包 |
| send \<id\|alias> \<address> \<value>\|all [fee=0] | 向指定地址转账 参数分别为：资产 ID，对方地址，转账金额，手续费 | 需要打开钱包 |
| import multisigaddress m pubkeys...      | 创建多方签名合约                              | 需要打开钱包 |
| sign \<jsonObjectToSign>            | 签名  参数为：记录交易内容的 json 字符串                            | 需要打开钱包 |
| relay \<jsonObjectToSign>                | 广播  参数为：记录交易内容的 json 字符串                            | 需要打开钱包 |

### 命令说明
👉 `upgrade wallet <path>` 

升级旧版钱包文件

```
neo>upgrade wallet cli.db3
Wallet file upgrade complete. Old file has been auto-saved at: cli.old.db3
```

👉 `rebuild index` 

重建钱包索引，此操作将强制钱包从区块高度为0开始同步区块交易。新创建的钱包不用重建钱包索引，只有要导入私钥或者钱包中资产显示异常时才需要重建钱包索引。

或者由于种种原因，钱包中的某笔交易未确认，这时资产已经从钱包中扣除，但并未经过整个区块链网络的确认。如果想删掉这笔未确认的交易使钱包中的资产正常显示也需要重建钱包索引。

👉 `show utxo [id|alias]`

列出钱包中指定资产的 UTXO，示例输出如下所示：

```
neo>show utxo neo
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:2
total: 1 UTXOs
neo>show utxo gas
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:1
total: 1 UTXOs
neo>show utxo 025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4
8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:0
total: 1 UTXOs
```

👉 `show gas` 

列出钱包中的所有可提取（available）及不可提取（unavailable）的 GAS，输出结果如下：

```
unavailable: 133.024
  available: 10.123
```

> [!NOTE]
>
> 这里不包含已提取的 GAS，查看已提取的 GAS 请用 list asset 命令。

要将钱包中的所有 unavailable GAS 转为 available GAS ，只需将钱包中的所有 NEO 转到钱包中的任意一个地址即可。

👉 `claim gas` 

提取钱包中可提取状态下的 GAS，该过程是通过一个特殊的交易 Claim Transaction 完成的，输入命令后，客户端会输出 Claim Transaction 的 ID（提取 GAS 这笔交易的 ID）。用户可以有两种选择，如末尾不带参数，则默认提取钱包前50个地址中的可提取状态的 GAS。如果指定参数 [all]，则会提取钱包中所有地址的可提取状态的 GAS。

执行完 claim gas 命令后，再执行 list asset 会显示 GAS 有增加。

👉 `create address [n=1]` 

可以输入 create address  来创建一个地址，也可以输入 create address 100 来批量创建 100个地址，批量创建的地址会自动导出到 address.txt 文件中。

👉 `export key [address] [path]`

你可以指定导出哪个地址对应的私钥，也可以指定导出至指定的文件中，例如下面的命令都是合法的。该命令需要验证钱包密码。

`export key`

`export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b`

`export key key.txt`

`export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt`

👉  `import key <wif|path>`

导入私钥，你可以指定导入一个私钥，或者是导入一个文件中的多个私钥，例如下面的命令都是合法的。

`import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH`

`import key key.txt`

如果是指定文件的话，文件里的私钥格式请参考 export key key.txt 的输出。

👉 `send <id|alias> <address> <value>|all [fee=0]`

转账，一共有 4 个参数，第一个参数是资产 ID，第二个参数是收款地址，第三个参数是转账金额（当输入 all 即为钱包中该资产的全部数量），第四个参数是手续费（这个参数可不填，默认为0）。该命令需要验证钱包密码。假如我想转 100 NEO 转到这个地址“AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b”，我需要输入以下命令。

send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

因为第二个参数除了资产 ID，还可以填写资产缩写，如 neo，gas，所以以上命令可以写成：

send neo AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

要查看资产 ID ，可输入 list asset 命令查看钱包中的所有资产。

👉 `import multisigaddress m pubkeys...`

以 m 个最小签名数量来创建多方签名的合约地址，例如两个公钥创建的多方签名地址， m 可以为 1 或 2， 后面的参数就是两方的公钥。

例如：import multisigaddress 1 037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630d 03b34a4be80db4a38f62bb41d63f9b1cb664e5e0416c1ac39db605a8e30ef270cc

👉 `sign <jsonObjectToSign>` 

从签名数量为 1 以上的多方签名合约中提取资产时，需要多方进行签名，参数为记录这段交易的 json 字符串。 签名完整后才能广播出去。

👉 `relay <jsonObjectToSign>` 

签名完整后，可以将这段交易信息进行广播。参数同样为记录这段交易的 json 字符串。

## 插件安装

| 命令                    | 功能说明         | 备注 |
| ----------------------- | ---------------- | ---- |
| plugins                 | 显示已加载的插件 |      |
| install [Plugin name]   | 安装指定插件     |      |
| uninstall [Plugin name] | 卸载指定插件     |      |

### 命令说明

👉 `plugins`

显示所有已加载的插件。

```
neo> plugins
Loaded plugins:
RpcSystemAssetTrackerPlugin
RpcNep5Tracker
RpcSecurity
StatesDumper
CoreMetrics
ImportBlocks
RpcWallet
ApplicationLogs
SimplePolicyPlugin
```

👉 `install [Plugin name]` 

安装指定插件，如下所示。卸载插件与此类似。

```
neo>install ImportBlocks
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ImportBlocks.zip
Install successful, please restart neo-cli.

```
```
neo>install ApplicationLogs
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ApplicationLogs.zip
Install successful, please restart neo-cli.

```
以上只是示例插件，更多插件请参考 [安装插件](setup.md)。

## 查看节点信息

| 命令                             | 功能说明                    |
| ------------------------------ | ----------------------- |
| show state                     | 显示当前区块链同步状态             |
| show node                      | 显示当前已连接的节点地址和端口         |
| show pool                      | 显示内存池中的交易（这些交易处于零确认的状态） |
| export blocks [path=chain.acc] | 导出全部区块数据，导出的结果可以用作离线同步  |
| export blocks \<start> [count] | 从指定区块高度导出指定数量的区块数据，导出的结果可以用作离线同步  |

## 高级命令

| 命令              | 功能说明 |
| --------------- | ---- |
| start consensus | 启动共识 |
启动共识的前提是该钱包有共识的权限，在 NEO 主网上可以通过投票选举获得共识的权限，如果自己部署的私有链可以在 `protocol.json` 中设置共识节点的公钥，详情可参考 [私链搭建](../../network/private-chain/private-chain.md)。

