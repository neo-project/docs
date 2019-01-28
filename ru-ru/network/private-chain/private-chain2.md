# Простой способ создать приватную сеть (private chain)

В предыдущем документе мы описали стандартный способ создания приватной сети с использованием четырех компьютеров или виртуальных машин. В этом же документе мы представим вам более простой способ создания приватной сети на компьютере с системой Windows.

## Установка узла NEO 

Установите NEO-CLI и сделайте четыре копии папки узла, назвав их node1, node2, node3 и node4, соответственно.

Допольнительную информацию см. в [Installation of NEO-CLI](../../node/cli/setup.md). 

## Установка плагина 

Установите [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/SimplePolicy.zip) для плагина, чтобы реализовать политику консенсуса. Узлы не смогут достичь консенсуса без плагина. Для получения дополнительной информации см.  [Installing plug-ins](../../node/plugin.md#installing-plug-ins).

## Создание файлов кошелька

В NEO-CLI или NEO-GUI создайте четыре кошелька (1.json, 2.json, 3.json, and 4.json) и поместите каждый в одну из папок четырех узлов.

## Изменение config.json

Произведите следующие конфигурации в config.json каждого узла:

- Укажите порты так, чтобы каждый порт не был продублирован и занят другими приложениями.
- В "UnlockWallet" укажите путь к кошельку, пароль кошелька.
- Задайте StartConsensus и IsActive значение true.


См. следующий пример：

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

## Изменение protocol.json

Настройте следующие параметры в protocol.json каждого узла. Убедитесь в том, что настройки в каждом файле единообразны.

- Magic : ID приватной сети (может быть любым целым числом в диапазоне [0 - 4294967295].

- StandbyValidators: Открытый ключ альтернативного узла консенсуса, куда вводится открытый ключ четырех кошельков.

- SeedList: TIP-адрес и номер порта seed node. Укажите IP-адрес как `localhost` а порты – как четыре P2P-порта, настроенных ранее в config.json.


См. следующий пример：

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

## Создание клавиши быстрого запуска 

Создайте блокнот для удобства запуска приватной сети. В файле введите `dotnet neo-cli.dll /rpc`, переименуйте его в 1Run.cmd, а затем поместите в папку каждого узла.

Приватная сеть создана. Ниже представлены файлы, которые мы изменили:

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

## Запуск приватной сети

Введите каталог каждого узла и дважды щелкните кнопкой мыши по `1Run.cmd`.

Когда процесс консенсуса идет, как показано ниже, приватная цепь устанавлена успешно.

![](../../../assets/privatechain_demo.png)

Приватная цепь будет остановлена, если закрыть все окна.

##  Снятие NEO/GAS

См [Withdrawing NEO and GAS](private-chain.md#withdrawing-neo-and-gas).

Советы：

[Здесь](https://github.com/chenzhitong/NEO-Private-Net) расположена приватная сеть, которая устроена таким образом, чтобы вы могли использовать ее напрямую. NEO и GAS были сняты со счета. Версия узла NEO 2.8.0
