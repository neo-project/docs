# 搭建私有链的简易方法

上篇文章介绍了标准的搭建私有链的方法，需要 4 台电脑或虚拟机，在 Windows 上可以用更简单的方式搭建私有链。

## 1、安装节点

首先安装 neo-cli，并将其复制 4 份，文件夹名分别命名为 node1、node2、node3、node4。

安装过程请参考 [NEO 节点的安装部署](../../node/cli/setup.md)。 

## 2、创建钱包文件

创建 4 个不同的钱包文件，命名为 1.json、2.json、3.json、4.json，分别放置于 4 个节点的文件夹中。

可以使用 neo-cli 或者 neo-gui 创建，具体方法可参照 neo-cli 或 neo-gui 的文档。

## 3、修改 config.json

修改每个节点下的 config.json，修改其端口，使每个端口不重复且不被其它程序占用。

修改 UnlockWallet 下面的 Path 为钱包路径，Password 为钱包密码，StartConsensus 和 IsActive 设置为 true。

可参照下面的配置：

**node1/config.json**

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "ApplicationLogs": "ApplicationLogs_{0}"
    },
    "P2P": {
      "Port": 10001,
      "WsPort": 10002
    },
    "RPC": {
      "Port": 10003,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "1.json",
      "Password": "11111111",
      "StartConsensus": true,
      "IsActive": true
    }
  }
}
```

**node2/config.json**

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "ApplicationLogs": "ApplicationLogs_{0}"
    },
    "P2P": {
      "Port": 20001,
      "WsPort": 20002
    },
    "RPC": {
      "Port": 20003,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "2.json",
      "Password": "11111111",
      "StartConsensus": true,
      "IsActive": true
    }
  }
}
```

**node3/config.json**

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "ApplicationLogs": "ApplicationLogs_{0}"
    },
    "P2P": {
      "Port": 30001,
      "WsPort": 30002
    },
    "RPC": {
      "Port": 30003,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "3.json",
      "Password": "11111111",
      "StartConsensus": true,
      "IsActive": true
    }
  }
}
```

**node4/config.json**

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain_{0}",
      "ApplicationLogs": "ApplicationLogs_{0}"
    },
    "P2P": {
      "Port": 40001,
      "WsPort": 40002
    },
    "RPC": {
      "Port": 40003,
      "SslCert": "",
      "SslCertPassword": ""
    },
    "UnlockWallet": {
      "Path": "4.json",
      "Password": "11111111",
      "StartConsensus": true,
      "IsActive": true
    }
  }
}
```

## 4、修改 protocal.json

修改每个节点下的 protocal.json 并保持所有节点的 protocal.json 一致。

修改说明：

Magic 表示私有链的 ID，可以修改为 [0 - 4294967295] 区间内的任意整数。

StandbyValidators 表示备用共识节点的公钥，这里输入 4 个钱包的公钥

SeedList 表示种子节点的 IP 地址和端口号，IP 地址输入 localhost，端口为 config.json 中配置的 4 个 P2P Port

可参照下面的配置：

```json
{
  "ProtocolConfiguration": {
    "Magic": 123456,
    "AddressVersion": 23,
    "SecondsPerBlock": 15,
    "StandbyValidators": [
      "037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630d",
      "03b34a4be80db4a38f62bb41d63f9b1cb664e5e0416c1ac39db605a8e30ef270cc",
      "03cc384ca982168bf6f08922d27c8acc4357d52a7e8ad8281d4af6683e6f63e94d",
      "03da4ed85a991134bf45592a5b04d6d71399f23a85843f43e6ac1a5d30f5473711"
    ],
    "SeedList": [
      "localhost:10001",
      "localhost:20001",
      "localhost:30001",
      "localhost:40001"
    ],
    "SystemFee": {
      "EnrollmentTransaction": 10,
      "IssueTransaction": 5,
      "PublishTransaction": 5,
      "RegisterTransaction": 100
    }
  }
}
```

## 5、创建快捷启动

为了方便启动，首先创建一个记事本文件，输入 `dotnet neo-cli.dll /rpc` 然后重命名为 1Run.cmd，然后将其复制到 4 个节点下。

到此，私有链已经搭建完成了，所有修改过的文件结构如下

```
├─node1
│      1.json
│      1Run.cmd
│      config.json
│      protocol.json
│
├─node2
│      1Run.cmd
│      2.json
│      config.json
│      protocol.json
│
├─node3
│      1Run.cmd
│      3.json
│      config.json
│      protocol.json
│
└─node4
        1Run.cmd
        4.json
        config.json
        protocol.json
```

## 6、启动私有链

进入 node1 目录，双击 `1Run.cmd`

进入 node2 目录，双击 `1Run.cmd`

进入 node3 目录，双击 `1Run.cmd`

进入 node4 目录，双击 `1Run.cmd`

如图所示：

![](../../../assets/privatechain_demo.png)

## 7、停止私有链

在任务栏中右击 `命令提示符`，点击 `关闭所有窗口`。

## 8、提取私有链中的 NEO/GAS

参照 [提取 NEO、NeoGas](../private-chain.md#5提取-neoneogas)。



最后：

[https://github.com/chenzhitong/NEO-Private-Net](https://github.com/chenzhitong/NEO-Private-Net) 这个项目中是已经配置好的私有链，已提取了 NEO 和 GAS，节点版本为 2.8.0，可以下载后直接使用。
