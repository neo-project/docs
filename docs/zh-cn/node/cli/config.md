# 配置与启动节点

完成 Neo-CLI 的安装后，本节我们将进行启动前的必要配置以及使用命令启动节点。

## 修改配置文件

Neo-CLI 在执行过程中会访问两个配置文件 `config.json` 和 `protocol.json`。启动 Neo-CLI 前需要对这两个文件进行必要配置。

### 配置钱包

启动 Neo-CLI 前，你需要在 `config.json` 中开启自动绑定并打开钱包功能，钱包打开后才可以调用与钱包相关的 API。配置参数如下：

- Path：钱包路径
- Password：钱包密码
- IsActive：设为 true 允许自动打开钱包

下面是一个标准设置的例子：

```json
  {
  "ApplicationConfiguration": {
    "Storage": {
      "Engine": "LevelDBStore"
    },
    "P2P": {
      "Port": 20333,
      "WsPort": 20334
    },
    "UnlockWallet": {
      "Path": "wallet.json",
      "Password": "11111111",
      "StartConsensus": false,
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  }
}
```

说明：

- Engine ：默认 LevelDBStore。表示区块链数据存储使用的引擎。
- PluginURL ：表示下载插件的地址，使用 CLI 的 install 命令时会用到。

### 将节点连接到网络

在 Neo3 中连接主网或测试网可以在启动节点时使用参数控制。如果要连接测试网，启动 CLI 时使用命令 `neo-cli --testnet` 或 `neo-cli -t`。

如果要将节点接入私链，需要配置 `protocol.json` 文件。详细信息，请参见[搭建私有链](../../network/private-chain/solo.md)中的修改 `protocol.json` 说明。

## 安装插件

一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 Neo-CLI 时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。

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
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/LevelDBStore.zip">LevelDBStore</a>
            </td>
            <td>区块链数据使用 LevelDB 存储引擎</td>
            <td></td>    
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/RocksDBStore.zip">RocksDBStore</a>
            </td>
            <td>区块链数据使用 RocksDBStore 存储引擎</td>
            <td></td>
            <td>和 LevelDBStore 二选一</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/RpcServer.zip">RpcServer</a>
            </td>
            <td>提供节点的 RPC 功能</td>
            <td><a href="../../reference/rpc/latest-version/api.html#命令列表"> RPC API </a></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>同步智能合约和 NativeContract 的日志（Notify）</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/RpcNep5Tracker.zip">RpcNep5Tracker</a>
            </td>
            <td>提供 NEP-5 余额及交易历史的 RPC 查询功能。</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep5balances.html">getnep5balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep5transfers.html">getnep5transfers</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>导出 Neo-CLI 状态数据</td>
            <td></td>
            <td>可选</td>
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/SystemLog.zip">SystemLog</a>
            </td>
            <td>打印共识日志</td>
            <td></td>
            <td>可选</td>
        </tr>    
    </tbody>
</table>


将下载的插件包解压到 neo-cli 根目录下，解压完成后的目录结构应如下图。

![plugins.png](../../assets/PluginsForExchange.png)

### 使用命令下载插件

使用内部命令自动下载或卸载插件，操作更为简便。例如：

```
neo> install StatesDumper
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.0-preview2-00/StatesDumper.zip
Install successful, please restart neo-cli.
```

```
neo> uninstall StatesDumper
Uninstall successful, please restart neo-cli.
```

在安装或卸载完毕后，请重启 Neo-CLI 使操作生效。

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

如果想在启动节点时接入测试网，可以输入参数 `--testnet` 或 `-t` 如：

```
dotnet neo-cli.dll -t
```

如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 

> [!WARNING]
>
> 如果开通了 API 服务，并且在 Neo-CLI 中打开钱包的话，需要设置防火墙策略，例如设置防火墙的白名单，这些端口仅对白名单的 IP 地址开放。如果完全对外开放，其它人可能会通过 API 导出私钥或者进行转账。

## 阅读下节

[CLI 命令参考](cli.md)

