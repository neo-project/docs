# 配置与启动节点

完成 Neo-CLI 的安装后，本节我们将进行启动前的必要配置以及使用命令启动节点。

## 修改配置文件

Neo-CLI 在执行过程中会访问两个配置文件 `config.json` 和 `protocol.json`。启动 Neo-CLI 前需要对这两个文件进行必要配置。有关这两个文件的具体属性说明，请参见 [Neo-CLI 结构](../../tooldev/neo_cli_structure.md)。

### 配置钱包

启动 Neo-CLI 前，你需要在 `config.json` 中开启自动绑定并打开钱包功能，钱包打开后才可以调用与钱包相关的 API。配置参数如下：

- MaxGasInvoke：允许通过 RPC 调用虚拟机执行消耗的最大 GAS 数额
- Path：钱包路径
- Password：钱包密码
- IsActive：设为 true 允许自动打开钱包

下面是一个标准设置的例子：

```json
  {
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}"
    },
    "P2P": {
      "Port": 20333,
      "WsPort": 20334
    },
    "RPC": {
      "BindAddress": "127.0.0.1",
      "Port": 20332,
      "SslCert": "",
      "SslCertPassword": "",
      "MaxGasInvoke": 10
    },
    "UnlockWallet": {
      "Path": "wallet.json",
      "Password": "11111111",
      "StartConsensus": false,
      "IsActive": true
    }
  }
}
```

> [!Note]
>
> BindAddress 选项，默认为本地 127.0.0.1。若要允许远程调用 RPC，可以设成 0.0.0.0，此时为了保障节点的安全性，请务必设置好对应端口的防火墙策略。

### 配置 HTTPS

如果要通过 HTTPS 的方式访问 RPC 服务器，需要在启动节点前修改配置文件 `config.json`，并设置域名、证书和密码，如下所示： 

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "RPC": {
      "Port": 10331,
      "SslCert": "YourSslCertFile.xxx",
      "SslCertPassword": "YourPassword"
    }
  ...
```

### 将节点连接到网络

Neo-CLI 默认接入主网，如果要连接测试网，你需要用Neo-CLI目录下的`config.testnet.json` 和`protocol.testnet.json` 文件分别替换原有配置文件 `config.json` 和 `protocol.json`。相关信息，请参见[主网与测试网](../../network/testnet.md)。

如果要将节点接入私链，需要配置 `protocol.json` 文件。详细信息，请参见[搭建私有链](../../network/private-chain/solo.md)中的修改`protocol.json` 说明。

## 安装插件

一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 Neo-CLI时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。

安装插件有两种方式：

- 从 GitHub 下载插件包
- 使用内部命令自动下载

### 从 GitHub 下载插件

下表列出了所有插件，选取所需要的插件进行下载。

<table class="table table-hover">
    <thead>
        <tr>
            <th style="width: 25%;">插件</th>
            <th style="width: 35%;">功能</th>
            <th style="width: 20%;">包含 API</th>
            <th style="width: 20%;"></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/ImportBlocks.zip">ImportBlocks</a>
            </td>
            <td>同步离线包。</td>
            <td></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/RpcWallet.zip">RpcWallet</a>
            </td>
            <td>提供钱包相关的 RPC 功能。</td>
            <td><a
                    href="../../reference/rpc/latest-version/api/claimgas.html">claimgas</a><br><a
                    href="../../reference/rpc/latest-version/api/dumpprivkey.html">dumpprivkey</a><br><a
                    href="../../reference/rpc/latest-version/api/getbalance.html">getbalance</a><br><a
                    href="../../reference/rpc/latest-version/api/getnewaddress.html">getnewaddress</a><br><a
                    href="../../reference/rpc/latest-version/api/getunclaimedgas.html">getunclaimedgas</a><br><a
                    href="../../reference/rpc/latest-version/api/getwalletheight.html">getwalletheight</a><br><a
                    href="../../reference/rpc/latest-version/api/importprivkey.html">importprivkey</a><br><a
                    href="../../reference/rpc/latest-version/api/listaddress.html">listaddress</a><br><a
                    href="../../reference/rpc/latest-version/api/sendfrom.html">sendfrom</a><br><a
                    href="../../reference/rpc/latest-version/api/sendmany.html">sendmany</a><br><a
                    href="../../reference/rpc/latest-version/api/sendtoaddress.html">sendtoaddress</a><br><a
                    href="../../reference/rpc/latest-version/api/invokefunction.html">invokefunction</a><br><a
                    href="../../reference/rpc/latest-version/api/invokescript.html">invokescript</a><br></td>
            <td>必选</td>
        </tr>
                <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/SimplePolicy.zip">SimplePolicy</a>
            </td>
            <td>过滤非法交易。</td>
            <td></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/Applicationlogs.zip">ApplicationLogs</a>
            </td>
            <td>在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/CoreMetrics.zip">CoreMetrics</a>
            </td>
            <td>查询历史区块的时间戳。</td>
            <td><a href="../../reference/rpc/latest-version/api/getmetricblocktimestamp.html">getmetricblocktimestamp</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/RpcNep5Tracker.zip">RpcNep5Tracker</a>
            </td>
            <td>提供 NEP-5 余额及交易历史的 RPC 查询功能。</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep5balances.html">getnep5balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep5transfers.html">getnep5transfers</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/RpcSystemAssetTracker.zip">RpcSystemAssetTracker</a>
            </td>
            <td>查询 UTXO 资产相关信息。</td>
            <td><a href="../../reference/rpc/latest-version/api/getunclaimed.html">getunclaimed</a><br><a
                    href="../../reference/rpc/latest-version/api/getclaimable.html">getclaimable</a><br><a
                    href="../../reference/rpc/latest-version/api/getunspents.html">getunspents</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>导出 Neo-CLI 状态数据。</td>
            <td></td>
            <td>可选</td>
        </tr> 
        <tr>            
            <td><a                    
                   href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.3/RpcSecurity.zip">RpcSecurity</a>                        </td>
            <td>对HTTP Request 进行 base64 加密，提升 RPC 请求的安全性。需要在该插件的 config.json 文件中设置 username 和 password</td>
            <td></td>
            <td>可选</td>
        </tr> 
    </tbody>
</table>




将下载的插件包解压到 neo-cli 根目录下，解压完成后的目录结构应如下图。

![plugins.png](../../assets/plugins.png)

### 使用命令下载插件

使用内部命令自动下载或卸载插件，操作更为简便。例如：

```
neo> install ImportBlocks
Downloading from https://github.com/neo-node/neo-plugins/releases/download/v2.10.3/ImportBlocks.zip
Install successful, please restart neo-cli.
```

```
neo> uninstall RpcWallet
Uninstall successful, please restart neo-cli.
```

在安装或卸载完毕后，请重启 Neo-CLI 使操作生效。

## 快速同步区块数据

客户端运行时会自动同步区块数据，打开钱包时也会自动同步钱包数据，当同步完成后才可以正常使用客户端以及查看钱包内资产。由于区块链数据庞大，初次同步时等待时间通常很久，建议采用离线同步包进行同步，相关信息，请参见 [快速同步区块数据](../syncblocks.md)。

## 启动 Neo 节点

打开命令行，定位到 Neo-CLI 所在目录，输入以下命令启动 Neo 节点 。

**Windows 10**:

```
dotnet neo-cli.dll
```

或

```
neo-cli.exe
```

**Linux (ubuntu 16.04/18.04)**:

```
./neo-cli
```

或

```
dotnet neo-cli.dll
```

> [!Note]
>
> 如果使用 dotnet，需要先安装 .net core 环境。

如果想在启动节点的同时启动 API 服务，可以输入参数 `--rpc`  或 `/rpc` 或 `-r`，如：

```
dotnet neo-cli.dll --rpc
```

如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 

> [!WARNING]
>
> 如果开通了 API 服务，并且在 Neo-CLI 中打开钱包的话，需要设置防火墙策略，例如设置防火墙的白名单，这些端口仅对白名单的 IP 地址开放。如果完全对外开放，其它人可能会通过 API 导出私钥或者进行转账。
