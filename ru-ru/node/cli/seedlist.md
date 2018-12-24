# NEO-CLI SeedList

## Введение

### Что такое SeedList?

Проще говоря, SeedList – это список URL. Они относятся к узлам, к которым NEO-CLI пытается подключиться при запуске. Вы можете найти SeedList в `protcol.json`, внутри каталога neo-cli.

```json
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
    "SystemFee": {
      ...
    }
  }
}
```
Здесь NEO-CLI сконфигурирован для подключения к `seed1.neo.org`, `seed2.neo.org` и тд через `PORT:10333`.

### Потенциальные проблемы на данном этапе

Все это, конечно, замечательно, вот только что произойдет, если ни один узел из нашего списка не будет работать?

Поскольку neo-cli умен, он попытается подключиться к соседним узлам. Однако этот подход имеет один недостаток – большое количество неизвестных факторов. Возможно, соседние узлы так же находятся в нерабочем состоянии. В таком случае время ожидания может слишком затянуться.

## Обновление SeedList

Внося в SeedList адреса узлов, в работоспособности которых нет никаких сомнений, мы можем избежать длительного времени ожидания, упомянутого в разделе **Потенциальные проблемы**.

### Как обновить?

####  Рабочие узлы

И как мы узнаем, какие узлы рабочие? Члены комьюнити **City of Zion** создали отличный[resource](https://github.com/CityOfZion/neo-mon) который постоянно пингует узлы по всему миру. Результаты отображаются в данном [tracker`е](http://monitor.cityofzion.io/).

![seedlist](../../../assets/seedlist.png)
В таблице мы видим список доступных узлов. Последние по времени узлы занимают верхнюю позицию (**2** говорит нам о том, отвечает ли узел). Как правило, мы берем те из них, что отвечают `yes` и имеют зеленый цвет.
Мы стараемся следовать стандартному протоколу для портов.

We try to follow the standard protocol for ports.

|                      | Main Net     | Test Net      |
| -------------------- | ------------ | ------------- |
| JSON-RPC через HTTPS | 10331        | 20331         |
| JSON-RPC через HTTP  | 10332        | 20332         |
| P2P черезTCP         | 10333        | 20333         |
| P2P через WebSocket  | 10334        | 20334         |

При этом мы предпочтем первый узел третьему узлу, поскольку **первый** узел придерживается соглашения, а **третий** - нет.

Мы выберем следующие адреса рабочих узлов:
- `seed3.aphelion-neo.com`
- `seed4.aphelion-neo.com`
- `node2.ams2.bridgeprotocol.io`
- `pyrpc1.nodeneo.ch`
- `node2.nyc3.bridgeprotocol.io`

Главный порт, с которым работает neo-cli, - это `10333`. В данный момент мы пингуем только `RPC`. Принято предполагать: если `RPC`  порт узла работает, то его `P2P` порт тоже должен работать. Если для вас данное утверждение звучит неверно, то потому что так оно и есть! Мы поговорим об этом в одном из наших предстоящих хакатонов, поэтому оставайтесь с нами!


#### Редактирование протокола
Для того чтобы NEO-CLI узнал новый SeedList, мы вставим адреса, выбранные ранее, в `protocol.json`
```json
{
  "ProtocolConfiguration": {
    "Magic": 7630401,
    "AddressVersion": 23,
    "SecondsPerBlock": 15,
    "StandbyValidators": [
      "03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c",
      "02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093",
      "03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a",
      "02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554",
      "024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d",
      "02aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e",
      "02486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a70"
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
    "SystemFee": {
      "EnrollmentTransaction": 1000,
      "IssueTransaction": 500,
      "PublishTransaction": 500,
      "RegisterTransaction": 10000
    }
  }
}
```
Обратите внимание: мы добавили `:10333` в конце каждого из адресов, чтобы NEO-CLI понимал, в каким узлам подключаться, используя протокол `P2P`.

Теперь вы можете запустить neo-cli как обычно.

### Справочные материалы
Если описанные выше шаги слишком утомительны для вас, то вы можете воспользоваться написанным скриптом, который автоматически обновляет`protocol.json`. См. в [here](https://github.com/HandsomeJeff/neo-cli-protocol-maker).
