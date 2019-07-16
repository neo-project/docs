# Build a private chain on local host

In previous document we described the standard way to build a private chain using four computers or virtual machines. In this document we will introduce an easier way to build a private chain on a windows system computer.

## Installing NEO node

Install NEO-CLI and make four copies of the node folder with the name of node1, node2, node3, and node4, successively.

For more information refer to [Installation of NEO-CLI](../../node/cli/setup.md). 

## Installing plug-in

Install [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/) the plug-in to enable the consensus policy. The nodes cannot reach a consensus without the plug-in. For more information, refer to [Installing plug-ins](../../node/cli/setup.md).

## Creating wallet files

From NEO-CLI or NEO-GUI create four wallets, 1.json, 2.json, 3.json, and 4.json, and place each in the folder of four nodes. 

## Modifying config.json

Make the following configurations in config.json of each node:

- Specify the ports so that each port is not duplicated and is not occupied by other applications.
- In "UnlockWallet" specify the wallet path and wallet password.
- Set  StartConsensus and IsActive as true.


You can refer to the following example：

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

## Modifying protocol.json

Configure the following parameters in each node protocol.json. Ensure the configuration in each file is consistent.

- Magic : The private chain ID, which can be any integer in the range of [0 - 4294967295].

- StandbyValidators: The public key of the alternate consensus node. Enter the public keys of four wallets.

- SeedList: The IP address and port number of the seed node. Specify the IP address as `localhost` and the ports as four P2P ports configured before in config.json.


You can refer to the following example：

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

## Creating a shortcut to start

Create a notepad file for ease of starting the private chain. In the file, enter `dotnet neo-cli.dll /rpc`  , rename it as 1Run.cmd, and then place it under the folder of each node.

At this point the private chain has been set up. All the files  we modified are as follows:

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

## Starting the private chain

Enter each node directory and double-click `1Run.cmd`. When the consensus process goes as shown below, the private chain is set up successfully.

![](../../assets/privatechain_demo.png)

The private chain is terminated if you close all the windows. 

## Withdrawing NEO/GAS

Refer to [Withdrawing NEO and GAS](private-chain.md#withdrawing-neo-and-gas).

Tips：

[Here](https://github.com/chenzhitong/NEO-Private-Net) is a private chain which is all set for you to use directly. The NEO and GAS have been withdrawn. The NEO node version is 2.9.4.