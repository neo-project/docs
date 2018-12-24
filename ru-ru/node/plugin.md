# Плагины клиента NEO 

Начиная с версии NEO 2.9.0, некоторые дополнительные функции были инкапсулированы в плагины с целью улучшения безопасности, стабильности и гибкости узлов. Пользователь может выбрать желаемое расширение функциональности, вместо того чтобы вызывать ее с дополнительными параметрами при каждом запуске neo-cli. При этом пользователь избегает многих ошибок, вызванных человеческим фактором, и некоторых утомительных инструкций, таких как открытие кошелька и вызов журналов приложений.  Нажмите [here](https://github.com/neo-project/neo-plugins/releases), чтобы загрузить Плагины. 

| Плагин                                                      | Описание                                               |                                      |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------ |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ApplicationLogs.zip) | Автоматически синхронизурует журнал смарт-контракта (ApplicationLogs) в режиме RPC. В данный момент журнал был изменен для того, чтобы он мог храниться в формате LevelDB. | Обязателен для обменов              |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip) | Синхронизурует клиента, используя офф-лайн пакеты.  | Обязательный                            |
| [RpcSecurity](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/RpcDisabled.zip) | Повышает безопасность RPC.                                   | Опциональный                             |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/SimplePolicy.zip) | Реализует политики консенсуса.                              | Обязателен для построения частной цепочки |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/StatesDumper.zip) | Экспортирует данные о статусе NEO-CLI.                                 | Опциональный                            |

## Установка плагинов 

Для того чтобы установить плагин, создайте новую папку **Plugins**  (первая буква заглавная) в корневом каталоге клиента neo-cli root directory и вставьте в нее разархивированные плагины.

![plugins.png](../../assets/plugins.png)

## Методы API 

### getapplicationlog метод

Возвращает журнал контракта согласно указанному txid. Заполненные журналы контракта хранятся в каталоге ApplicationLogs.

Данный метод реализуется благодаря плагину [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ApplicationLogs.zip). Плагин необходимо установить до вызова метода.

#### Описание параметров

txid：ID транзакции

#### Пример

Тело запроса:

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07"],
  "id": 1
}
```

Тело ответа:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x0110a8f666bcc650dc0b544e71c31491b061c79e",
                "vmstate": "HALT, BREAK",
                "gas_consumed": "2.855",
                "stack": [
                    {
                        "type": "Integer",
                        "value": "1"
                    }
                ],
                "notifications": [
                    {
                        "contract": "0xb9d7ea3062e6aeeb3e8ad9548220c4ba1361d263",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "e3069da508f128069a0cd2544b0728ccbacdfb43"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d142f89e93b2717426a8130c37dad93aad70cff5"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00e1f50500000000"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```
