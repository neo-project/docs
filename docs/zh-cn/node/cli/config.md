# 配置与启动节点

完成 Neo-CLI 的安装后，本节我们将进行启动前的必要配置以及使用命令启动节点。

## 修改配置文件

Neo-CLI 在执行过程中会访问配置文件 `config.json`。启动 Neo-CLI 前需要对该文件进行必要配置。

### 配置钱包

启动 Neo-CLI 前，你可以在 `config.json` 中开启自动绑定并打开钱包功能，钱包打开后才可以调用与钱包相关的 API。配置参数如下：

- Path：钱包路径
- Password：钱包密码
- IsActive：设为 true 允许自动打开钱包

下面是一个标准设置的例子：

```json
{
  "ApplicationConfiguration": {
    "Logger": {
      "Path": "Logs",
      "ConsoleOutput": true,
      "Active": true
    },
    "Storage": {
      "Engine": "LevelDBStore",
      "Path": "Data_LevelDB_{0}"
    },
    "P2P": {
      "Port": 21333,
      "WsPort": 21334
    },
    "UnlockWallet": {
      "Path": "admint.json",
      "Password": "1",
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Magic": 6713213,
    "MillisecondsPerBlock": 15000,
    "MaxTraceableBlocks": 2102400,
    "ValidatorsCount": 7,
    "StandbyCommittee": [
      "02179543000184781e5447b3f0fbace664ea92b7e31227c8e71bc4e7cdafccdb8e",
      "038415d0be8dc12b61d3e3b76b98f464dfab7fddee74271c35e2de624bb51023a6",
      "03c9b1c89c6e2d4abd629a2db8b7d03aced518a56793bc90f4985ef7ed3f1b481a",
      "0302242b1dced63e1bf7eb14876f7ef026b79567f9c5be83de1943dd185ec28e68",
      "025e8494903b93dc369f08a2bd7e221f574c75d9675591f04907cba9daeeb83d10",
      "03e8ab5186e1deabcd10ec0e509ded4fffade6fddf534ac3e0506268bae3fd44a6",
      "020df8858b66ff4d7b0a6a68d11ddedcc7d90d2a64ffa2cd087c4c5dabf4150b40",
      "02f5f04a6036caedd68b5bd36e33105c0e9f43c0592e9f9f2188b1659be993bb5e",
      "0279ed5e9ed91547e332a4f27135eebff5daab6c978b57992d8ee0359ccb9f5e8b",
      "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
    ],
    "SeedList": [
      "seed1t.neo.org:21333",
      "seed2t.neo.org:21333",
      "seed3t.neo.org:21333",
      "seed4t.neo.org:21333",
      "seed5t.neo.org:21333"
    ]
  }
}
```

说明：

- `ConsoleOutput` ：是否在控制台打印出 Log 信息。（true：前后台打印，false：后台记录）
- `Active` ：是否开启 Log 信息。
- `Engine` ：默认 LevelDBStore。表示区块链数据存储使用的引擎。
- `PluginURL`：表示下载插件的地址，使用 CLI 的 install 命令时会用到。

### 将节点连接到网络

将 Neo-CLI 连接到测试网需要配置 `config.json` 文件，用 `*.testnet.json` 中的内容去替换即可。 

> [!Note]
>
> 如果是从源代码发布的Neo-CLI，要成功连接到Neo N3 RC1测试网，还必须将配置文件config.json中的Magic字段值改为 **827601742**。

如果要将节点接入私链，详细信息请参见 [搭建私有链](../../develop/network/private-chain/solo.md) 中的说明。 

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
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/LevelDBStore.zip">LevelDBStore</a>
            </td>
            <td>区块链数据使用 LevelDB 存储引擎</td>
            <td></td>    
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/RocksDBStore.zip">RocksDBStore</a>
            </td>
            <td>区块链数据使用 RocksDBStore 存储引擎</td>
            <td></td>
            <td>和 LevelDBStore 二选一</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/RpcServer.zip">RpcServer</a>
            </td>
            <td>提供节点的 RPC 功能</td>
            <td><a href="../../reference/rpc/latest-version/api.html#命令列表"> RPC API </a></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>同步智能合约和 NativeContract 的日志（Notify）</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/RpcNep17Tracker.zip">RpcNep17Tracker</a>
            </td>
            <td>提供 NEP17 余额及交易历史的 RPC 查询功能。</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep17balances.html">getnep17balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep17transfers.html">getnep17transfers</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>导出 Neo-CLI 状态数据</td>
            <td></td>
            <td>可选</td>
        </tr>   
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/DBFTPlugin.zip">DBFTPlugin</a>
            </td>
            <td>dBFT 共识插件</td>
            <td></td>
            <td>作为共识节点时必选</td>
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/OracleService.zip">OracleService</a>
            </td>
            <td>Oracle 服务插件</td>
            <td></td>
            <td>作为 Oracle 服务节点时必选</td>
        </tr>   
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc1/StateService.zip">StateService</a>
            </td>
            <td>StateRoot 共识服务插件</td>
            <td>
                <a href="../../reference/rpc/latest-version/api/getstateroot.html">getstateroot</a><br>
                <a href="../../reference/rpc/latest-version/api/getproof.html">getproof</a><br>
                <a href="../../reference/rpc/latest-version/api/verifyproof.html">verifyproof</a><br>
                <a href="../../reference/rpc/latest-version/api/getstateheight.html">getstateheight</a>
            </td>
            <td>作为 StateRoot 共识节点时必选</td>
        </tr>   
    </tbody>
</table>

将下载的插件包解压到 neo-cli 根目录下，解压完成后的目录结构应如下图。

![plugins.png](../../assets/PluginsForExchange.png)

### 使用命令下载插件

使用内部命令自动下载或卸载插件，操作更为简便。例如：

```
neo> install StatesDumper
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.0-RC1/StatesDumper.zip
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


如果你想让外部程序访问该节点的 API 需要开放防火墙端口：10331-10334, 20331-20334 

> [!WARNING]
>
> 如果开通了 API 服务，并且在 Neo-CLI 中打开钱包的话，需要设置防火墙策略，例如设置防火墙的白名单，这些端口仅对白名单的 IP 地址开放。如果完全对外开放，其它人可能会通过 API 导出私钥或者进行转账。

