# 基本用法

使用 neo-python 主要有两种方式：运行 `np-prompt` 和运行自定义代码的节点。

## np-prompt

在测试网运行 `np-prompt` :

```
$ np-prompt
```

显示 help 的所有可用参数：

```
$ np-prompt -h
usage: np-prompt [-h] [-m | -p [host] | --coznet | -c CONFIG]
                 [-t {dark,light}] [-v] [--datadir DATADIR] [--version]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         Use MainNet instead of the default TestNet
  -p [host], --privnet [host]
                        Use a private net instead of the default TestNet,
                        optionally using a custom host (default: 127.0.0.1)
  --coznet              Use the CoZ network instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file
  -t {dark,light}, --set-default-theme {dark,light}
                        Set the default theme to be loaded from the config
                        file. Default: 'dark'
  -v, --verbose         Show smart-contract events by default
  --datadir DATADIR     Absolute path to use for database directories
  --version             show program's version number and exit
```

## 自定义代码节点

查看 `/examples` 目录下的示例：<https://github.com/CityOfZion/neo-python/tree/development/examples>

另外可参考 “Settings and Logging” and “Interacting with Smart Contracts”.

## API 服务器 (JSON / REST)

在主网启动 JSON 和 REST API 服务器：

```
$ np-api-server --mainnet --port-rpc 10332 --port-rest 80
```

示例通知和 help 下的所有可用参数：

```
$ np-api-server --testnet --port-rpc 8080 --port-rest 8088
[I 180315 09:27:09 NotificationDB:44] Created Notification DB At /Users/thomassaunders/.neopython/Chains/Test_Notif
[I 180315 09:27:09 threading:864] [TestNet] Block 5644 / 53999
[I 180315 09:27:09 np-api-server:11] Starting json-rpc api server on http://0.0.0.0:8080
[I 180315 09:27:09 _observer:131] Site starting on 8080
[I 180315 09:27:09 _observer:131] Starting factory <twisted.web.server.Site object at 0x110619828>
[I 180315 09:27:09 np-api-server:11] Starting REST api server on http://0.0.0.0:8088

# view help
$ np-api-server -h
usage: np-api-server [-h]
                   (--mainnet | --testnet | --privnet | --coznet | --config CONFIG)
                   [--port-rpc PORT_RPC] [--port-rest PORT_REST]
                   [--logfile LOGFILE] [--syslog] [--syslog-local [0-7]]
                   [--disable-stderr] [--datadir DATADIR]
                   [--maxpeers MAXPEERS] [--wallet WALLET] [--host HOST]

  optional arguments:
  -h, --help            show this help message and exit
  --datadir DATADIR     Absolute path to use for database directories
  --maxpeers MAXPEERS   Max peers to use for P2P Joining
  --wallet WALLET       Open wallet. Will allow you to use methods that
                        require an open wallet
  --host HOST           Hostname ( for example 127.0.0.1)

  Network options:
  --mainnet             Use MainNet
  --testnet             Use TestNet
  --privnet             Use PrivNet
  --coznet              Use CozNet
  --config CONFIG       Use a specific config file

  Mode(s):
  --port-rpc PORT_RPC     port to use for the json-rpc api (eg. 10332)
  --port-rest PORT_REST   port to use for the rest api (eg. 80)

  Logging options:
  --logfile LOGFILE     Logfile
  --syslog              Log to syslog instead of to log file ('user' is the
                        default facility)
  --syslog-local [0-7]  Log to a local syslog facility instead of 'user'.
                        Value must be between 0 and 7 (e.g. 0 for 'local0').
  --disable-stderr      Disable stderr logger
```

## 端口描述

要使外部程序能访问你的 API 服务器，需要打开防火墙端口。下表显示的端口可以设置为全部打开或按需打开。

|                    | Main Net | Test Net |
| ------------------ | -------- | -------- |
| JSON-RPC via HTTPS | 10331    | 20331    |
| JSON-RPC via HTTP  | 10332    | 20332    |

## 使用 Windows WSL (Ubuntu) 运行 API 服务器

如果在 Windows WSL (Ubuntu) 上运行 neo-python, 除了打开路由器上的相应端口，还需要参考 [这里](https://www.nextofwindows.com/allow-server-running-inside-wsl-to-be-accessible-outside-windows-10-host) 为你的 Windows 防火墙添加一个入站策略。