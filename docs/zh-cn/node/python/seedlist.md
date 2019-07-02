# NEO-Python SeedList

## 介绍

### 关于 SeedList

SeedList 是一个 URL 列表，是 NEO-Python 在启动时尝试连接的节点。在 NEO-Python 目录下 (`/neo/data`) 的 `protcol.*.json` 文件中可以找到 SeedList。有三个常用 `protocol.*.json` 文件：

```
protocol.mainnet.json
protocol.testnet.json
protocol.privnet.json
```

本文指的是 `protocol.mainnet.json` ，但这些信息是通用的。

```json
json
{
    "ProtocolConfiguration": {
    "Magic": ...,
    "AddressVersion": ...,
    "SecondsPerBlock": ...,
    "StandbyValidators": [
    ...
    ],
    "SeedList": [
      "seed1.neo.org:10333",
      "seed2.neo.org:10333",
      "seed3.neo.org:10333",
      "seed4.neo.org:10333",
      "seed5.neo.org:10333"
    ],
    "RPCList":[
    ...
    ],
    "SystemFee": {
    ...
    }
  }
}
```

在上面的文件中，NEO-Python 配置为通过`PORT:10333` 连接 `seed1.neo.org`, `seed2.neo.org` 等节点 。

## 潜在问题

假如以上列表中的每个节点故障，NEO-Python 会尝试连接相邻节点。但是这种方法存在很多未知因素，例如相邻节点出问题了，可能导致等待时间相当漫长。

## 更新 SeedList

通过使用我们确定的活跃节点更新 SeedList，可以避免上述潜在问题中提到的漫长等待风险。

### 更新 Windows WSL (Ubuntu) 上的 NEO-Python 节点列表

如果是在 Ubuntu 上运行 neo-python ，你应该使用了 venv。你需要修改 venv 目录里 `lib/python3.6/site-packages/neo/data` 路径下的 protocol.mainnet.json 文件。如果该路径不存在，说明你尚未在当前 venv 中使用该文件，那么你可以到 neo/data 路径下的 neo-python 文件夹中修改此文件。或者你也可以删除 venv 文件夹，修改父文件，新建一个 venv 文件夹（`python -m venv venv`）并激活 venv，然后使用 `pip install e .` 重新安装。

## 更新 SeedList

### 活跃节点

要寻找活跃节点，使用 [NEO 网络状态监测网](http://monitor.cityofzion.io/)。要查看更详细的信息，查看该监测网 Github 上的 [存储库](https://github.com/CityOfZion/neo-mon)。

![seedlist](../../../assets/seedlist.png)

如上图所示，列表中显示了可用节点。最新节点显示在最上方。 图中 *2* 标识的地方表示节点是否响应。通常，绿色并显示  `yes` 的节点为活跃节点。

我们会根据以下端口的标准协议进行选择，比如我们会选择上图中的节点 1 而不选节点3，因为节点 1符合标准而节点 3 不符合。

|                    | Main Net | Test Net |
| ------------------ | -------- | -------- |
| JSON-RPC via HTTPS | 10331    | 20331    |
| JSON-RPC via HTTP  | 10332    | 20332    |
| P2P via TCP        | 10333    | 20333    |
| P2P via WebSocket  | 10334    | 20334    |

以下是选出的活跃节点地址：

```python
seed3.aphelion-neo.com
seed4.aphelion-neo.com
node2.ams2.bridgeprotocol.io
pyrpc1.nodeneo.ch
node2.nyc3.bridgeprotocol.io
```

### 编辑 protocol 文件

为了告知 NEO-Python 新的节点列表，需要将前面几个地址粘贴到 `protocol.mainnet.json`，如下所示：

```python
json
{
    "ProtocolConfiguration": {
    "Magic": ...,
    "AddressVersion": ...,
    "SecondsPerBlock": ...,
    "StandbyValidators": [
    ...
    ],
    "SeedList": [
      "seed1.neo.org:10333",
      "seed2.neo.org:10333",
      "seed3.neo.org:10333",
      "seed4.neo.org:10333",
      "seed5.neo.org:10333",
      "seed4.aphelion-neo.com:10333",
      "node2.sgp1.bridgeprotocol.io:10333",
      "seed2.aphelion-neo.com:10333",
      "seed3.aphelion-neo.com:10333",
      "node2.ams2.bridgeprotocol.io:10333",
      "pyrpc1.narrative.network:10333",
      "node2.nyc3.bridgeprotocol.io:10333",
      "pyrpc4.narrative.network:10333",
      "pyrpc2.narrative.network:10333",
      "pyrpc3.narrative.network:10333",
      "seed1.aphelion-neo.com:10333",
      "seed1.switcheo.network:10333",
      "seed2.switcheo.network:10333",
      "seed5.cityofzion.io:10333",
      "seed3.cityofzion.io:10333",
      "seed3.switcheo.network:10333",
      "seed1.o3node.org:10333",
      "seed3.travala.com:10333",
      "seed4.cityofzion.io:10333",
      "seed2.cityofzion.io:10333",
      "seed2.o3node.org:10333",
      "seed3.o3node.org:10333",
      "node1.sgp1.bridgeprotocol.io:10333",
      "seed2.travala.com:10333",
      "seed4.switcheo.network:10333",
      "seed1.spotcoin.com:10333",
      "node1.nyc3.bridgeprotocol.io:10333"
    ],
    "RPCList":[
    ...
    ],
    "SystemFee": {
    ...
    }
  }
}
```

请注意，上例中的每个地址后加上了 `:10333` 以便告知 NEO-Python 使用 P2P 协议连接。

现在就可以像往常一样启动 neo-python 了。

## JSON 和 REST API 服务器

建议你在启动任意 API 服务器之前先更新节点列表以保证最大连接数。有关更多API服务器信息，请查看 [这里](https://neo-python.readthedocs.io/en/latest/basicusage.html#api-server-json-and-or-rest)。