# 使用单节点搭建私有链

Neo-CLI 2.10.2 及以后版本支持单节点模式下正常生成区块，只需一个节点即可正常运行私有链。

[NEO-Private-Net](https://github.com/chenzhitong/NEO-Private-Net) 项目是一个已配置好的私有链，下载后可以直接运行。此项目基于 Windows 10，且运行 Neo-GUI 需要安装 [.NetFramework 4.7.1](https://www.microsoft.com/net/download/dotnet-framework-runtime)。

你也可以自己配置私有链，下文将介绍具体方法。

## 安装节点

首先安装 Neo-CLI，安装过程请参考 [Neo 节点的安装部署](../../node/cli/setup.md)。

## 安装插件

要使节点达成共识，需要安装 SimplePolicy 插件启用共识策略。下载 [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/) 插件并解压，放到 Neo-CLI 程序的 Plugins 文件夹中。

也可根据需要安装其它插件，可参考如下配置：

```
─Plugins
    │  ApplicationLogs.dll
    │  RpcSecurity.dll
    │  RpcWallet.dll
    │  SimplePolicy.dll
    │
    ├─ApplicationLogs
    │      config.json
    │
    ├─RpcSecurity
    │      config.json
    │
    ├─RpcWallet
    │      config.json
    │
    └─SimplePolicy
            config.json
```

## 创建钱包文件

使用 Neo-CLI 或 Neo-GUI 创建一个钱包文件，命名为 a.json 放置于节点的文件夹中。

## 修改 config.json

在节点下的 config.json 文件中进行如下修改：

- 设置每个端口不重复且不被其它程序占用。
- 设置 UnlockWallet 下的参数 `Path` 为钱包文件名，`Password` 为钱包密码。
- 设置 `StartConsensus` 和 `IsActive` 为 `true`。

可参照下面的配置：

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "Index": "Index_{0}"
    },
    "P2P": {
      "Port": 10003,
      "WsPort": 10004
    },
    "RPC": {
      "BindAddress": "127.0.0.1",
      "Port": 10002,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "a.json",
      "Password": "1",
      "StartConsensus": true,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-plugins/releases/download/v{1}/{0}.zip"
  }
}
```

## 修改 protocol.json

修改 Neo-CLI 下的 protocol.json 文件，对以下参数进行修改。如果之后要配置其它普通节点，请保证所有节点的配置一致。

- Magic ：私有链 ID，可设置为 [0 - 4294967295] 区间内的任意整数。
- StandbyValidators ：备用共识节点的公钥，这里输入 a.json 钱包中的公钥（StandbyValidators  中只有一个公钥的时候为单节点模式）。
- SeedList ：种子节点的 IP 地址和端口号，IP 地址设置为 localhost，端口为 config.json 中配置的 P2P Port。

可参照下面的配置：

```json
{
  "ProtocolConfiguration": {
    "Magic": 1840412,
    "AddressVersion": 23,
    "SecondsPerBlock": 5,
    "LowPriorityThreshold": 0.001,
    "StandbyValidators": [
      "03d08d6f766b54e35745bc99d643c939ec6f3d37004f2a59006be0e53610f0be25"
    ],
    "SeedList": [
      "127.0.0.1:10003"
    ],
    "SystemFee": {
      "EnrollmentTransaction": 1000,
      "IssueTransaction": 500,
      "PublishTransaction": 500,
      "RegisterTransaction": 10000
    }
  }
}
```

## 启动私有链

运行命令行，进入 neo-cli 目录，输入 `neo-cli.exe`。成功建立的私链如下图所示。

![](../assets/solo.png)

如果关闭窗口，将停止私有链。

## 提取私有链中的 NEO/GAS

在 NEO 网络的创世块中存放着 1 亿份 NEO，当私链搭建起来后，GAS 也将伴着新区块的生成而生成。你可以使用 Neo-CLI 或 Neo-GUI 从多方签名合约中提取出这部分 NEO 和 GAS 以便内部开发测试使用。

### 使用 Neo-CLI 提取

1. 在 Neo-CLI 命令行界面中输入命令 `open wallet a.json` 打开钱包

2. 输入命令 `import multisigaddress m pubkeys`，创建一个多方签名地址。

   这里设置最小签名数 m 为 1，pubkeys 为钱包 a.json 的公钥

3. 输入命令 `list asset`，可以看到合约地址中出现了 1 亿 NEO。

4. 使用命令 `send <id|alias> <address> <value>` 将 NEO 转账到其它标准地址即可。

   因为该多方签名地址只需要一个签名，所以转账 NEO 与后续提取 GAS 等操作与标准地址相同。

### 使用 Neo-GUI 提取

#### 安装并配置 Neo-GUI

1. 从 Github 上下载 [Neo-GUI](https://github.com/neo-project/neo-gui/releases) 并解压。

2. 复制前面步骤编辑好的 protocol.json 文件，替换 Neo-GUI 中原有的文件

3. 配置 config.json 文件，设置端口与 Neo-CLI 的端口不冲突。如果端口冲突，Neo-GUI 将无法与 Neo-CLI 同时运行。

   ```json
   {
     "ApplicationConfiguration": {
       "Paths": {
         "Chain": "Chain_{0}",
         "Index": "Index_{0}",
         "CertCache": "Certs"
       },
       "P2P": {
         "Port": 60001,
         "WsPort": 60002
       },
       "Urls": {
         "AddressUrl": "https://neoscan.io/address/{0}",
         "AssetUrl": "https://neoscan.io/api/main_net/v1/get_asset/{0}",
         "TransactionUrl": "https://neoscan.io/transaction/{0}"
       }
     }
   }
   ```

运行 Neo-GUI，打开 a.json，如果左下角有连接数不为零，而且一直在同步区块，表示该客户端已经成功地连接到了私有链中。

#### 提取 NEO/GAS

1. 在 Neo-GUI 中右键单击账户页面空白处，选择 `创建合约地址` -> `多方签名`
2. 在最下方填写钱包 a.json 的公钥，点击 `+`，然后设置最小签名数量为 1，点击确定。

你将看到合约地址中出现了 1 亿 NEO。因为该多方签名地址只需要一个签名，所以转账 NEO 与提取 GAS 等操作与标准地址相同。