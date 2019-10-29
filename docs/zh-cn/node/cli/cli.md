# CLI 命令参考

打开命令行，定位到 NEO-CLI 所在目录，输入下面代码即可启动 NEO 的命令行钱包。

`dotnet neo-cli.dll`

本篇教程将介绍命令行钱包的所有命令，你可以通过输入命令操作钱包，如创建打开钱包、导入导出私钥、转账、启动共识等。在命令行中输入 `help` 可以查看所有命令。

> [!NOTE]
>
> 命令中尖括号 `<>` 表示参数，方括号 `[]` 表示可选参数，或符号 `|` 表示所填的参数可以是其中任意一种，等号 `=` 表示可选参数在不输入情况下的默认值。

## 控制台命令

| 命令               | 功能说明                                                     |
| :----------------- | ------------------------------------------------------------ |
| version            | 显示当前软件的版本                                           |
| help [plugin-name] | 帮助菜单，当安装 ImportBlocks 或 StatesDumper 插件时，可查看对应插件的提示内容 |
| clear              | 清除屏幕                                                     |
| exit               | 退出程序                                                     |

## 合约命令

| 命令                                                         | 功能说明 |
| ------------------------------------------------------------ | -------- |
| deploy \<nefFilePath> [manifestFile]                         | 发布合约 |
| invoke \<scripthash> \<command> [optionally quoted params separated by space] | 调用合约 |

### 命令说明

👉 `deploy <nefFilePath> [manifestFile]` 

发布合约

```
neo> deploy Template.nef Template.manifest.json  
Script hash: 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6
Gas Consumed: 100000000

Signed and relayed transaction with hash=0xab6dd63ea36a7c95580b241f34ba756e62c767813be5d53e02a983f4e561d284

```

👉 `invoke <scripthash> <command> [optionally quoted params separated by space]` 

调用合约

```
neo> invoke 0x1e5ce27b9af630aed82bc94695fa8d424cdbe5c6 name
Invoking script with: '00c1046e616d6514c6e5db4c428dfa9546c92bd8ae30f69a7be25c1e68627d5b52'
VM State: HALT
Gas Consumed: 4320950
Evaluation Stack: [{"type":"ByteArray","value":"6e616d656f66746865746f6b656e"}]

relay tx(no|yes): no
```


## 钱包命令

| 命令                                  | 功能说明                                               | 备注         |
| ------------------------------------- | ------------------------------------------------------ | ------------ |
| create wallet \<path>                 | 创建钱包文件                                           |              |
| open wallet \<path>                   | 打开钱包文件                                           |              |
| close wallet                          | 关闭钱包文件                                           |              |
| upgrade wallet \<path>                | 升级旧版钱包文件                                       |              |
| list address                          | 列出钱包中的所有账户                                   | 需要打开钱包 |
| list asset                            | 列出钱包中的所有资产                                   | 需要打开钱包 |
| list key                              | 列出钱包中的所有公钥                                   | 需要打开钱包 |
| show gas                              | 列出钱包中的所有未提取的 GAS                           | 需要打开钱包 |
| create address [n=1]                  | 创建地址 / 批量创建地址                                | 需要打开钱包 |
| import key \<wif\|path>               | 导入私钥 / 批量导入私钥                                | 需要打开钱包 |
| export key \[address] [path]          | 导出私钥                                               | 需要打开钱包 |
| send \<id\|alias> \<address> \<value> | 向指定地址转账 参数分别为：资产 ID，对方地址，转账金额 | 需要打开钱包 |
| import multisigaddress m pubkeys...   | 创建多方签名合约                                       | 需要打开钱包 |
| sign \<jsonObjectToSign>              | 签名  参数为：记录交易内容的 json 字符串               | 需要打开钱包 |

### 命令说明

👉 `upgrade wallet <path>` 

升级旧版钱包文件

```
neo> upgrade wallet test.db3
Wallet file upgrade complete. New wallet file has been auto-saved at: test.json
```

👉 `show gas` 

列出钱包中的所有未提取的 GAS，输出结果如下：

```
unclaimed gas: 0
```

> [!NOTE]
>
> 这里不包含已提取的 GAS，查看已提取的 GAS 请用 list asset 命令。

在 NEO3 中，某地址每次 NEO 数量发生改变时都会触发其 GAS 的自动提取。

👉 `create address [n=1]` 

可以输入 create address  来创建一个地址，也可以输入 create address 100 来批量创建 100个地址，创建的地址会自动导出到 address.txt 文件中。

👉 `export key [address] [path]`

你可以指定导出哪个地址对应的私钥，也可以指定导出至指定的文件中，例如下面的命令都是合法的。该命令需要验证钱包密码。

`export key`

`export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9`

`export key key.txt`

`export key AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9 key.txt`

👉  `import key <wif|path>`

导入私钥，你可以指定导入一个私钥，或者是导入一个文件中的多个私钥，例如下面的命令都是合法的。

`import key L4HoTTfKfzjV8tdWv6vRaMY1cBQbsVc4euGqhPW9Mf8z6993fgMH`

`import key key.txt`

如果是指定文件的话，文件里的私钥格式请参考 export key key.txt 的输出。

👉 `send <id|alias> <address> <value>`

转账，一共有 3 个参数，第一个参数是资产 ID，第二个参数是收款地址，第三个参数是转账金额。该命令需要验证钱包密码。假如我想转 100 GAS 转到这个地址“AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9”，我需要输入以下命令。

send a1760976db5fcdfab2a9930e8f6ce875b2d18225 AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9 100

因为第二个参数除了资产 ID，还可以填写资产缩写，如 neo，gas，所以以上命令可以写成：

send gas AapRvH8FB2jx9S2fmwntAW4QYdXYyyeqQ9 100

要查看资产 ID ，可输入 list asset 命令查看钱包中的所有资产。

👉 `import multisigaddress m pubkeys...`

以 m 个最小签名数量来创建多方签名的合约地址，例如两个公钥创建的多方签名地址， m 可以为 1 或 2， 后面的参数就是两方的公钥。

例如：import multisigaddress 1 022b386a0ac6fa5abad4bfabc7dff3c016654fa97176811cb64f4831284a7399ca 0288a99d33b6f7f1b19d3be7a7935d2c076fec52d9591336af03e43eec8ca1b16b

👉 `sign <jsonObjectToSign>` 

从签名数量为 1 以上的多方签名合约中提取资产时，需要多方进行签名，参数为记录这段交易的 json 字符串。 签名完整后才能广播出去。

👉 `relay <jsonObjectToSign>` 

签名完整后，可以将这段交易信息进行广播。参数同样为记录这段交易的 json 字符串。

## 插件命令

| 命令                    | 功能说明         |
| ----------------------- | ---------------- |
| plugins                 | 显示已加载的插件 |
| install [Plugin name]   | 安装指定插件     |
| uninstall [Plugin name] | 卸载指定插件     |

### 命令说明

👉 `plugins`

显示所有已加载的插件。

```
neo> plugins
Loaded plugins:
        ApplicationLogs
        CoreMetrics
        ImportBlocks
        RpcNep5Tracker
        RpcSecurity
        RpcWallet
        StatesDumper
        SystemLogs
```

👉 `install [Plugin name]` 

安装指定插件，如下所示。卸载插件与此类似。

```
neo>install ImportBlocks
Downloading from https://github.com/neo-project/neo-plugins/releases/download/v3.0.0-preview1/ImportBlocks.zip
Install successful, please restart neo-cli.
```

以上只是示例插件，更多插件请参考 [安装插件](setup.md)。

### 使用插件

特别说明一下 ImportBlocks 和 StatesDumper 这两个插件，它们都有自己对应的命令操作。

👉 ` help ImportBlocks`

```
neo> help ImportBlocks
ImportBlocks Commands:
        export block[s] <index>
```

| 命令                             | 功能说明                                                     |
| -------------------------------- | ------------------------------------------------------------ |
| export block[s] [path=chain.acc] | 导出全部区块数据，导出的结果可以用作离线同步                 |
| export block[s] \<start> [count] | 从指定区块高度导出指定数量的区块数据，导出的结果可以用作离线同步 |

👉 ` help StatesDumper`

```
neo> help StatesDumper
StatesDumper Commands:
        dump storage <key>
```

| 命令                | 功能说明             |
| ------------------- | -------------------- |
| dump storage \<key> | 导出指定的状态量数据 |



## 节点命令

| 命令                      | 功能说明                                       | 备注         |
| ------------------------- | ---------------------------------------------- | ------------ |
| show state                | 显示当前区块链同步状态                         |              |
| show pool [verbose]       | 显示内存池中的交易（这些交易处于零确认的状态） |              |
| relay \<jsonObjectToSign> | 广播 参数为：记录交易内容的 json 字符串        | 需要打开钱包 |

## 高级命令

| 命令            | 功能说明 |
| --------------- | -------- |
| start consensus | 启动共识 |

启动共识的前提是该钱包有共识的权限，在 NEO 主网上可以通过投票选举获得共识的权限，如果自己部署的私有链可以在 `protocol.json` 中设置共识节点的公钥，详情可参考 [私链搭建](../../network/private-chain/private-chain.md)。

