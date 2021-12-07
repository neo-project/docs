# 使用单节点搭建私有链

Neo-CLI 支持单节点模式下正常生成区块，只需一个节点即可正常运行私有链。[NEO-Private-Net](https://github.com/neo-ngd/NEO-Private-Net) 项目是一个已配置好的私有链，下载后可以直接运行。

你也可以自己配置私有链，下文将介绍具体方法。

## 准备工作

1. 首先安装 Neo-CLI，安装过程请参考 [Neo 节点的安装部署](../../../node/cli/setup.md)。
2. 安装插件 [DBFTPlugin](https://github.com/neo-project/neo-modules/releases/download/v3.1.0/DBFTPlugin.zip)。
3. 运行 Neo-CLI，输入 `create wallet <path>` 命令创建一个钱包，如 `create wallet consensus.json`。
4. 设置钱包密码（password），并确认密码。 
5. 记录钱包公钥（pubkey），后面会用到。

## 修改节点配置文件

### 修改config.json

在Neo-CLI的 config.json 文件中进行如下修改：

- 设置 UnlockWallet 下的参数 `Path` 为钱包文件名，`Password` 为钱包密码。
- 设置 `IsActive` 为 `true`。
- 设置 `ConsoleOutput` 和 `Active`  为 `true`。
- 设置 `ValidatorsCount` 为1。
- 在 `StandbyCommittee` 中输入前面创建的`consensus.json`钱包的公钥（`StandbyCommittee` 中只有一个公钥的时候为单节点模式）。

可参照下面的配置：

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
      "Path": "consensus.json",
      "Password": "1",
      "IsActive": true
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Network": 5309138,
    "MillisecondsPerBlock": 15000,
    "MaxTraceableBlocks": 2102400,
    "ValidatorsCount": 1,
    "StandbyCommittee": [
      "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
    ],
    "SeedList": []
  }
}
```

在 `Plugins\DBFTPlugin` 路径下的config文件中进行如下修改：

- 设置 `AutoStart` 为 true，并将`Network` 与 `neo-cli` 的`config.json`中的`Network`设为相同数值，例如：

```
{
  "PluginConfiguration": {
    "RecoveryLogs": "ConsensusState",
    "IgnoreRecoveryLogs": false,
    "AutoStart": true,
    "Network": 5309138,
    "MaxBlockSize": 262144,
    "MaxBlockSystemFee": 900000000000
  }
}
```

## 启动私有链
 > [!Note]
   >
   > 如果运行 Neo-CLI 之前节点同步了 Neo 测试网的区块文件，需要先删除 Data 目录，否则会导致私链无法正常出块。

进入 neo-cli 目录，双击 `neo-cli.exe` 或打开 cmd 并运行`dotnet neo-cli.dll`即可启动私链。成功建立的私链如下图所示。

![](../assets/solo.png)

如果关闭窗口，将停止私有链。

## 提取私有链中的 NEO/GAS

在 Neo 网络的创世块中存放着 1 亿份 NEO 和 3 千万 GAS，当私链搭建起来后，GAS 也将伴着新区块的生成而生成。你可以使用 Neo-CLI 从多方签名合约中提取出这部分 NEO 和 GAS 以便内部开发测试使用。

### 使用 Neo-CLI 提取

1. 复制共识节点成为一个外部节点。
2. 将共识节点的tcp地址localhost:21333加入外部节点config.json中的seedlist。
3. 修改外部节点config.json中的端口使其不与共识冲突。可参照下面的配置：

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
      "Port": 23333,
      "WsPort": 23334
    },
    "UnlockWallet": {
      "Path": "",
      "Password": "",
      "IsActive": false
    },
    "PluginURL": "https://github.com/neo-project/neo-modules/releases/download/v{1}/{0}.zip"
  },
  "ProtocolConfiguration": {
    "Network": 5309138,
    "MillisecondsPerBlock": 15000,
    "MaxTraceableBlocks": 2102400,
    "ValidatorsCount": 1,
    "StandbyCommittee": [
      "02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d"
    ],
    "SeedList": [
    "localhost:21333"
    ]
  }
}
```

4. 启动私链及外部节点，后续操作均在外部节点上。

5. 打开共识节点钱包 `open wallet consensus.json`，使用命令 `import multisigaddress m pubkeys`，创建一个多方签名地址。

   这里设置最小签名数 m 为 1，pubkeys 为钱包 consensus.json 的公钥。例如：

    ``` 
   import multisigaddress 1 02ff249d06faaf0b5ba865e1531bfabe07f89aef39ab59082e3bc140be0318055d
    ```

6. 输入命令 `list asset`，可以看到合约地址中出现了 100,000,000 NEO 和 30,000,000 GAS。

7. 使用命令 `create wallet ` 创建一个新钱包进行后续开发操作，并复制地址。

8. 重新打开共识节点钱包 `open wallet consensus.json`，使用 `send` 指令转出 NEO 和 GAS 到新钱包地址。例：`send neo NWu2gb7PzhZb4ci9LvW4gBYAQFMGb1s1o7 100000000`, `send gas NWu2gb7PzhZb4ci9LvW4gBYAQFMGb1s1o7 10000000`。

   > [!Note]
   >
   > 每次转账都会消耗少量 GAS 作为手续费，请确保转账时有足够的 GAS （一般不超过 0.02 个gas）。

   节点操作详细指令可参照[CLI 命令参考](../../../node/cli/cli.md)。
