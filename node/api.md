# API参考

每个小蚁节点 AntSharesCore-CLI 都可选的提供了一套 API 接口，用于从节点获取区块链数据，使得开发区块链应用变得十分方便。接口通过 [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) 的方式提供，底层使用 HTTP/HTTPS 协议进行通讯。要启动一个提供 RPC服务的节点，可运行以下命令：

`dotnet AntSharesDaemon.dll /rpc`

若要通过 HTTPS 的方式访问 RPC 服务器，需要在启动节点前修改配置文件 `config.json`，并设置域名、证书和密码：

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```

JSON-RPC 服务器启动后，会监听 TCP 端口，默认端口如下。P2P 和 WebSocket 的端口详见 [小蚁节点介绍](introduction.md)。

|                | 主网（Main Net） | 测试网（Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## 命令列表

| 方法                                       | 参数                                      | 说明                         | 备注       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getbalance](api/getbalance.md)          | \<asset_id>                             | 根据指定的资产编号，返回钱包中对应资产的余额信息   | 需要打开钱包   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | 获取主链中高度最大的区块的散列            |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | 根据指定的散列值，返回对应的区块信息         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | 根据指定的索引，返回对应的区块信息          |          |
| [getblockcount](api/getblockcount.md)    |                                         | 获取主链中区块的数量                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | 根据指定的索引，返回对应区块的散列值         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | 获取节点当前的连接数                 |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | 获取内存中未确认的交易列表              |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | 根据指定的散列值，返回对应的交易信息         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | 根据指定的散列和索引，返回对应的交易输出（零钱）信息 |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | 广播交易                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | 向指定地址转账                    | 需要打开钱包   |
| submitblock                              | \<hex>                                  | 提交新的区块                     | 需要成为共识节点 |

## GET请求示例

一次典型的 JSON-RPC GET 请求格式如下：

下面以获取主链中区块的数量方法为例。

请求 URL：

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

发送请求后，将会得到如下的响应：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POST请求示例

一次典型的 JSON-RPC Post 请求的格式如下：

下面以获取主链中区块的数量方法为例。

请求 URL：

```
http://somewebsite.com:10332
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

## 测试工具

你可以用 Chrome 扩展程序中的 Postman 来方便地进行测试（安装 Chrome 扩展程序需要科学上网），下面是测试截图

![](~/images/2017-05-17_17-06-20.jpg)

![](~/images/2017-05-17_16-55-58.jpg)

## 其它

[C# JSON-RPC 使用方法](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

