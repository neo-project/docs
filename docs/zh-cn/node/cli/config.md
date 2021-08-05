# 配置与启动节点

完成 Neo-CLI 的安装后，本节我们将进行启动前的必要配置以及使用命令启动节点。

## 修改配置文件

Neo-CLI 在执行过程中会访问配置文件 `config.json`。启动 Neo-CLI 前需要对该文件进行必要配置。

### 配置钱包

启动 Neo-CLI 前，你可以在 `config.json` 中开启自动绑定并打开钱包功能，这样节点启动后会默认打开该钱包。配置参数如下：

- `Path`：钱包路径
- `Password`：钱包密码
- `IsActive`：设为 true 允许自动打开钱包

下面是一个标准设置的例子：

```json
{
  "ApplicationConfiguration": {
    "Logger": {
      "Path": "Logs",
      "ConsoleOutput": false,
      "Active": false
    },
    "Storage": {
      "Engine": "LevelDBStore",
      "Path": "Data_LevelDB_{0}"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "UnlockWallet": {
      "Path": "wallet.json",
      "Password": "1",
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Network": 860833102,
    "AddressVersion": 53,
    "MillisecondsPerBlock": 15000,
    "MaxTransactionsPerBlock": 512,
    "MemoryPoolMaxTransactions": 50000,
    "MaxTraceableBlocks": 2102400,
    "InitialGasDistribution": 5200000000000000,
    "ValidatorsCount": 7,
    "StandbyCommittee": [
      "03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c",
      "02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093",
      "03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a",
      "02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554",
      "024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d",
      "02aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e",
      "02486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a70",
      "023a36c72844610b4d34d1968662424011bf783ca9d984efa19a20babf5582f3fe",
      "03708b860c1de5d87f5b151a12c2a99feebd2e8b315ee8e7cf8aa19692a9e18379",
      "03c6aa6e12638b36e88adc1ccdceac4db9929575c3e03576c617c49cce7114a050",
      "03204223f8c86b8cd5c89ef12e4f0dbb314172e9241e30c9ef2293790793537cf0",
      "02a62c915cf19c7f19a50ec217e79fac2439bbaad658493de0c7d8ffa92ab0aa62",
      "03409f31f0d66bdc2f70a9730b66fe186658f84a8018204db01c106edc36553cd0",
      "0288342b141c30dc8ffcde0204929bb46aed5756b41ef4a56778d15ada8f0c6654",
      "020f2887f41474cfeb11fd262e982051c1541418137c02a0f4961af911045de639",
      "0222038884bbd1d8ff109ed3bdef3542e768eef76c1247aea8bc8171f532928c30",
      "03d281b42002647f0113f36c7b8efb30db66078dfaaa9ab3ff76d043a98d512fde",
      "02504acbc1f4b3bdad1d86d6e1a08603771db135a73e61c9d565ae06a1938cd2ad",
      "0226933336f1b75baa42d42b71d9091508b638046d19abd67f4e119bf64a7cfb4d",
      "03cdcea66032b82f5c30450e381e5295cae85c5e6943af716cc6b646352a6067dc",
      "02cd5a5547119e24feaa7c2a0f37b8c9366216bab7054de0065c9be42084003c8a"
    ],
    "SeedList": [
      "seed1.neo.org:10333",
      "seed2.neo.org:10333",
      "seed3.neo.org:10333",
      "seed4.neo.org:10333",
      "seed5.neo.org:10333"
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

节点默认连接到主网，如果要将 Neo-CLI 连接到测试网，需要配置 `config.json` 文件，用 `config.testnet.json` 中的内容去替换即可。

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
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>同步智能合约和 NativeContract 的日志（Notify）</td>
            <td><a href="../../reference/rpc/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/DBFTPlugin.zip">DBFTPlugin</a>
            </td>
            <td>dBFT 共识插件</td>
            <td></td>
            <td>作为共识节点时必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/LevelDBStore.zip">LevelDBStore</a>
            </td>
            <td>区块链数据使用 LevelDB 存储引擎</td>
            <td></td>    
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/OracleService.zip">OracleService</a>
            </td>
            <td>Oracle 服务插件</td>
            <td></td>
            <td>作为 Oracle 服务节点时必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/RocksDBStore.zip">RocksDBStore</a>
            </td>
            <td>区块链数据使用 RocksDBStore 存储引擎</td>
            <td></td>
            <td>和 LevelDBStore 二选一</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/RpcNep17Tracker.zip">RpcNep17Tracker</a>
            </td>
            <td>提供 NEP17 余额及交易历史的 RPC 查询功能。</td>
            <td><a href="../../reference/rpc/latest-version/api/getnep17balances.html">getnep17balances</a><br><a
                    href="../../reference/rpc/latest-version/api/getnep17transfers.html">getnep17transfers</a></td>
            <td>推荐</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/RpcServer.zip">RpcServer</a>
            </td>
            <td>提供节点的 RPC 功能</td>
            <td><a href="../../reference/rpc/latest-version/api.html#命令列表"> RPC API </a></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>导出 Neo-CLI 状态数据</td>
            <td></td>
            <td>可选</td>
        </tr>
        </tr>   
         <tr>
            <td><a
                    href="https://github.com/neo-project/neo-modules/releases/download/v3.0.1/StateService.zip">StateService</a>
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
Downloading from https://github.com/neo-project/neo-modules/releases/download/v3.0.1/StatesDumper.zip
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

