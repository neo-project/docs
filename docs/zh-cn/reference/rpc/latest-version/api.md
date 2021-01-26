# API 参考

每个 Neo-CLI 节点都可选的提供了一套 API 接口，用于从该节点获取区块链数据，使得开发区块链应用变得十分方便。接口通过 [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) 的方式提供，底层使用 HTTP/HTTPS 协议进行通讯。

要启用 RPC服务，你需要安装 [RpcServer 插件](https://github.com/neo-project/neo-modules/releases)，启动 Neo-CLI 时无需添加参数。

## 插件安装

### 自动安装

启动 neo-cli，输入命令 `install RpcServer` 安装 RpcServer 插件。

安装成功后重新启动 neo-cli。

### 手动安装

在 [GitHub](https://github.com/neo-project/neo-modules/releases) 上下载对应版本的 RpcServer.zip 文件，解压后放到 neo-cli.dll 所在的目录即可。

安装成功后重新启动 neo-cli。

### 常见的安装错误

> 如果自动安装时遇到以下错误
>
> ```
> Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.0-CI01168/RpcServer.zip
> error: The remote server returned an error: (404) Not Found.
> ```
>
> 或手动安装时找不到对应版本的下载文件。
>
> 则表示当前未发布对应版本的 RpcServer 插件，开发者可以自行编译 [neo-modules](https://github.com/neo-project/neo-modules) 项目。在 neo-cli.dll 所在的目录新建 Plugins 文件夹，并将编译后的 RpcServer 文件放到 Plugins 文件夹中。安装成功后重新启动 neo-cli。

## 监听端口

JSON-RPC 服务器启动后，会监听 TCP 端口，默认为本地地址（127.0.0.1）的 10332 端口，即

```
http://127.0.0.1:10332/
```

如需更改可修改 RpcServer 文件夹中的 config.json 配置文件。

## 命令列表

### 区块链

| 方法                                                    | 参数                         | 说明                                                         |
| ------------------------------------------------------- | ---------------------------- | ------------------------------------------------------------ |
| [getbestblockhash](api/getbestblockhash.md)             |                              | 获取当前链中高度最大的区块的散列                             |
| [getblock](api/getblock.md)                             | \<hash \| index> [verbose=0] | 根据指定的哈希或索引，返回对应的区块信息                     |
| [getblockcount](api/getblockcount.md)                   |                              | 获取当前链中区块的数量                                       |
| [getblockhash](api/getblockhash.md)                     | \<index>                     | 根据指定的索引，返回对应区块的散列值                         |
| [getblockheader](api/getblockheader.md)                 | \<hash \| index> [verbose=0] | 根据指定的哈希或索引，返回对应的区块头信息                   |
| [getcommittee](api/getcommittee.md)                     |                              | 获取委员会成员公钥列表                                       |
| [getnativecontracts](api/getnativecontracts.md)         |                              | 获得原生合约的列表                                           |
| [getnextblockvalidators](api/getnextblockvalidators.md) |                              | 获得下个区块的验证人列表                                     |
| [getcontractstate](api/getcontractstate.md)             | \<script_hash>               | 根据合约脚本散列，查询合约信息                               |
| [getrawmempool](api/getrawmempool.md)                   | [shouldGetUnverified=0]      | 获取内存中已确认的交易列表,如果参数为1，则获取内存中所有的交易列表（包括已确认和未确认交易） |
| [getrawtransaction](api/getrawtransaction.md)           | \<txid> [verbose=0]          | 根据指定的散列值，返回对应的交易信息                         |
| [getstorage](api/getstorage.md)                         | \<script_hash>  \<key>       | 根据合约脚本散列和存储的 key，返回存储的 value               |
| [gettransactionheight](api/gettransactionheight.md)     | \<txid>                      | 根据交易哈希获取交易所在的区块高度                           |

### 节点

| 方法                                            | 参数   | 说明                                       |
| ----------------------------------------------- | ------ | ------------------------------------------ |
| [getconnectioncount](api/getconnectioncount.md) |        | 获取节点当前的连接数                       |
| [getpeers](api/getpeers.md)                     |        | 获得节点当前已连接/未连接的节点列表      |
| [getversion](api/getversion.md)                 |        | 获取节点的版本信息                     |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex> | 广播交易                                   |
| [submitblock](api/submitblock.md)               | \<hex> | 提交新的区块<br>**注意**：需要成为共识节点 |

### 智能合约

| 方法                                    | 参数                                    | 说明                                           |
| --------------------------------------- | --------------------------------------- | ---------------------------------------------- |
| [getunclaimedgas](api/getunclaimedgas.md) | \<address> | 查询指定地址未获取的 gas |
| [invokefunction](api/invokefunction.md) | \<script_hash>  \<operation>  \[params] \[sender] \[signers] | 用指定的哈希调用智能合约，传入方法名及参数 |
| [invokescript](api/invokescript.md)     | \<script> \[sender] \[signers]                | 通过虚拟机运行脚本并返回结果                   |

### 工具

| 方法                                      | 参数       | 说明                          |
| ----------------------------------------- | ---------- | ----------------------------- |
| [listplugins](api/listplugins.md)         |            | 列出节点已加载的所有插件      |
| [validateaddress](api/validateaddress.md) | \<address> | 验证地址是否是正确的 Neo 地址 |

### 钱包

| 方法                                       | 参数                                       | 说明                           |
| ---------------------------------------- | ---------------------------------------- | ---------------------------- |
| [calculatenetworkfee](api/calculatenetworkfee.md) | \<key> | 计算指定交易的网络费GasToken |
| [closewallet](api/closewallet.md) |  | 关闭当前打开着的钱包 |
| [dumpprivkey](api/dumpprivkey.md) | \<address>                              | 导出指定地址的私钥 |
| [getnewaddress](api/getnewaddress.md) |  | 创建一个新的地址 |
| [getwalletbalance](api/getwalletbalance.md) | \<asset_id> | 查询资产余额 |
| [getwalletunclaimedgas](api/getwalletunclaimedgas.md) |  | 显示钱包中未提取的 GasToken 数量 |
| [importprivkey](api/importprivkey.md) | \<key> | 导入私钥到钱包 |
| [invokecontractverify](api/invokecontractverify.md) | \<script_hash>   \[params] \[signers] | 调用合约的验证方法 |
| [listaddress](api/listaddress.md) |  | 列出当前钱包内的所有地址 |
| [openwallet](api/openwallet.md) | \<path> \<password> | 打开指定钱包，为了安全该方法默认禁用 |
| [sendfrom](api/sendfrom.md) | \<asset_id>\<from>\<to>\<value> | 从指定地址，向指定地址转账 |
| [sendmany](api/sendmany.md) | \<outputs_array> \[signers] | 在一笔交易中向多个地址发起多笔转账 |
| [sendtoaddress](api/sendtoaddress.md) | \<asset_id>\<address>\<value> \[signers]| 向指定地址转账 |

### ApplicationLogs 插件

| 方法                                          | 参数    | 说明                                  |
| --------------------------------------------- | ------- | ------------------------------------- |
| [getapplicationlog](api/getapplicationlog.md) | \<txid> | 根据交易 txid 获取合约的事件信息 |

## RpcNep17Tracker 插件

| 方法                                          | 参数                  | 说明                                |
| --------------------------------------------- | --------------------- | ----------------------------------- |
| [getnep17balances](api/getnep17balances.md)   | \<address>            | 返回指定地址内的所有 NEP17 资产余额 |
| [getnep17transfers](api/getnep17transfers.md) | \<address>[timestamp] | 返回指定地址内的所有 NEP17 交易记录 |

## GET 请求示例

一次典型的 JSON-RPC GET 请求格式如下：

下面以获取当前链中区块的数量方法为例。

请求 URL：

```
http://127.0.0.1:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

发送请求后，将会得到如下的响应：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POST 请求示例

一次典型的 JSON-RPC Post 请求的格式如下：

下面以获取当前链中区块的数量方法为例。

请求 URL：

```
http://127.0.0.1:10332
```

请求 Body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params": [],
  "id": 1
}
```

发送请求后，将会得到如下的响应：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

> [!Note]
>
> 请将区块同步到最新高度后再使用 API，否则返回的结果可能不是最新的。

## 测试工具

你可以用 [Postman](https://www.postman.com/) 来方便地进行测试，下面是测试截图：

![](../../../assets/api_3.jpg)

## 其它参考

[C# JSON-RPC 使用方法](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)