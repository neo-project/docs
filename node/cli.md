# CLI 命令参考

打开命令行，定位到程序所在目录，输入下面代码即可启动小蚁的命令行钱包（即小蚁节点） 。

`dotnet AntSharesDaemon.dll`

本篇教程将介绍命令行钱包的所有命令，你可以通过输入命令的形式操作钱包，如创建打开钱包、导入导出私钥、转账、启动共识等。

首先我们先了解一下该命令行钱包有哪些命令，在命令行中输入 `help` ，回车，你会看到如图所示的命令列表。

![](~/images/2017-05-17_12-30-05.jpg)

下面是所有命令的说明，命令中尖括号 `<>` 表示的是参数，方括号 `[]` 表示的是可选参数，或符号 `|` 表示所填的参数可以是其中任意一种，等号 `=` 表示可选参数在不输入情况下的默认值。

## 1、控制台指令

| 命令      | 功能说明      |
| ------- | --------- |
| version | 显示当前软件的版本 |
| help    | 帮助菜单      |
| clear   | 清除屏幕      |
| exit    | 退出程序      |

## 2、钱包操作

| 命令                                       | 功能说明                             | 备注     |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path>                    | 创建钱包文件                           |        |
| open wallet \<path>                      | 打开钱包文件                           |        |
| rebuild index                            | 重建钱包索引                           | 需要打开钱包 |
| list address                             | 列出钱包中的所有账户                       | 需要打开钱包 |
| list asset                               | 列出钱包中的所有资产                       | 需要打开钱包 |
| list key                                 | 列出钱包中的所有公钥                       | 需要打开钱包 |
| create address [n=1]                     | 创建地址/批量创建地址                      | 需要打开钱包 |
| import key \<wif\|path>                  | 导入私钥/批量导入私钥                      | 需要打开钱包 |
| export key \[address] [path]             | 导出私钥                             | 需要打开钱包 |
| send \<id\|alias> \<address> \<value> [fee=0] | 向指定地址转账 参数分别为：资产ID，对方地址，转账金额，手续费 | 需要打开钱包 |

以下命令可能需要详细解释一下：

👉 `rebuild index` 

重建钱包索引。为什么要重建钱包索引，重建钱包索引有什么用？

钱包中有一个字段，记录了当前钱包同步的区块高度，每新增加一个区块，钱包客户端就会同步区块，将钱包中的资产和交易更新。假设当前记录的区块高度为100，然后你执行了 import key 命令导入了私钥，这时钱包仍然是从区块高度为100开始计算你的资产。如果导入的地址在区块高度小于100的时候有一些交易，这些交易和对应的资产将不会体现在钱包中，所以要重建钱包索引，强制让钱包从区块高度为0开始计算你的资产。

新创建的钱包不用重建钱包索引，只有要导入私钥时才需要重建钱包索引。

👉 `create address [n=1]` 

可以输入 create address  来创建一个地址，也可以输入 create address 100 来批量创建100个地址，批量创建的地址会自动导出到 address.txt 文件中。

👉 `export key [address] [path]`

你可以指定导出哪个地址对应的私钥，也可以指定导出至指定的文件中，例如下面的命令都是合法的。该命令需要验证钱包密码。

export key

export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

export key key.txt

export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉  `import key <wif|path>`

导入私钥，你可以指定导入一个私钥，或者是导入一个文件中的多个私钥，例如下面的命令都是合法的。

import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

import key key.txt

如果是指定文件的话，文件里的私钥格式请参考 export key key.txt 的输出。

👉 `send <id|alias> <address> <value> [fee=0]`

转账，一共有4个参数，第一个参数是资产ID，第二个参数是收款地址，第三个参数是转账金额，第四个参数是手续费（这个参数可不填，默认为0）。该命令需要验证钱包密码。假如我想转100小蚁股转到这个地址“AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b”，我需要输入以下命令。

send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

不知道资产ID怎么办？请输入 list asset 命令查看钱包中的所有资产。

## 3、 查看节点信息

| 命令         | 功能说明                    |
| ---------- | ----------------------- |
| show state | 显示当前区块链同步状态             |
| show node  | 显示当前已连接的节点地址和端口         |
| show pool  | 显示内存池中的交易（这些交易处于零确认的状态） |
## 4、 高级指令

| 命令              | 功能说明 |
| --------------- | ---- |
| start consensus | 启动共识 |
启动共识的前提是该钱包有共识的权限，在小蚁主网上可以通过投票选举获得共识的权限，如果自己部署的私有链可以在 `protocol.json` 中设置共识人的公钥，详情可参考 [私链搭建](private-chain.md)。

