# 在服务器中部署 NEO 节点

## 安装节点

1. 安装 NEO 节点的运行环境 [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime)，2.0 或以上版本。
2. 在 GitHub 上下载 [neo-cli](https://github.com/neo-project/neo-cli/releases) 程序包并启动 NEO 节点。

## 安装插件

从 NEO-CLI 2.9.0 开始，一些附加功能被独立封装在插件中用以调用，提升了节点的安全性，稳定性和灵活性。关于插件的详细信息，请参见 [安装插件](../../node/cli/setup.md)。

交易所需要安装以下插件，以保证 API 的正常使用和自动读取离线包的完整性：

- [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/ApplicationLogs.zip)
- [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/ImportBlocks.zip)
- [RpcWallet](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcWallet.zip)
- [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/SimplePolicy.zip)
- [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcSystemAssetTracker.zip)（推荐）
- [CoreMetrics](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/CoreMetrics.zip)（推荐）
- [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/tree/master/RpcNep5Tracker) （推荐）

在 neo-cli 根目录新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中。

![PluginsForExchange.png](../../assets/PluginsForExchange.png)

对于 NEO-CLI 2.9.4 及之后版本，可以使用以下命令自动进行安装：

```
install ImportBlocks
install ApplicationLogs
install RpcWallet
install SimplePolicy
install RpcSystemAssetTracker
install CoreMetrics
install RpcNep5Tracker
```

> [!Note]
>
> - NEO CLI v2.10.2 及之后版本已将钱包相关 RPC API 移至 RpcWallet 插件，请在使用前确保此插件已安装，以保证 API 的正常使用。
> - ApplicationLogs 插件需在初始同步之前就必须安装，否则会遗漏安装前已同步区块中交易日志的内容。

## 修改配置文件

在启动 NEO-CLI 前需先配置 config.json 文件中的以下参数：

- BindAddress：默认为本地127.0.0.1。可以绑定指定网卡的 ipv4 地址以允许远程调用 rpc。若没有指定对象，则可以设成 0.0.0.0。
- UnlockWallet：可选。可以设置开启自动绑定并打开钱包的功能。Path 是钱包的路径， Password 是钱包的密码， IsActive 设为 true 意味着允许自动打开钱包。

下面是一个标准设置的例子。

```json
  {
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "Index": "Index_{0}"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "RPC": {
      "BindAddress": "0.0.0.0",
      "Port": 10332,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "",
      "Password": "",
      "StartConsensus": false,
      "IsActive": false
    },
    "PluginURL": "https://github.com/neo-project/neo-plugins/releases/download/v{1}/{0}.zip"
  }
}

...

```
> [!Note]
   >
   > - 如需使用自动打开钱包的功能，可以在 UnlockWallet 一栏填入 "Path" 如 "1.db3" 和 "Password" 如 "11111111"，并将 "IsActive" 设为 true.
   > - 注意 "Password" 为明文, 请确保防火墙打开并处于安全环境, 请谨慎使用。


更多详细内容，请参阅 [NEO 节点的安装部署](../../node/cli/setup.md)。

