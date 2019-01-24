# Метод sendmany 

Перевод актива на несколько адресов с указанием адреса для перевода сдачи.


> [!Примечание]
> Этот вызов требует открытого кошелька.

## Принимаемые параметры

`<outputs_array> [fee=0] [change_address]`

- `outputs_array`: массив, каждый элемент которого имеет следующую структуру:

	`{"asset": <asset>,"value": <value>,"address": <address>}`
	
	- asset：ID актива， `RegisterTransaction` ID, полученный в результате регистрации этого актива.<br>
	 Для NEO：`c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b`.<br>
	 Для NeoGas：`602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7`.<br>
     ID других активов можно узнать при помощи [командной строки CLI](../../cli.md). Помимо этого, можно выполнить запрос `list Asset` в блокчейн-браузере.

	- value：количество средств для перевода.
	- address： адрес кошелька получателя.

- `fee`: опциональный параметр. Добавление комиссии поднимает приоритет транзакции в сети. По умолчанию комиссия равна 0, минимальная комиссия составляет 0.00000001.

- `change_address`: адрес для возвращения сдачи. Опциональный параметр, по умолчанию равный первому адресу кошелька.

## Примеры

Пример запроса.

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ]
    ],
    "id": 1
}
```

Пример запроса с комиссией в систему и адресом для зачисления сдачи.

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        0,
        "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
    ],
    "id": 1
}
```

Пример ответа.

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x55ba819b50f5821298328f3bf9bb17e088afc900cf2ad7dbfc03d49940b5cf30",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "0x06de043b9b914f04633c580ab02d89ba55556f775118a292adb6803208857c91",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "495",
                "address": "AK5q8peiC4QKwuZHWX5Dkqhmar1TAGvZBS"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "406e545e30a6b39f71a7a40f1d4937939b9e1ca38851449842a2e2318bd499afd9c89f0c96658923e3e435ee91192e9dbf101d81a240fa7c953ac0c322d2f2b980",
                "verification": "2103cf5ba6a9135f8eaeda771658564a855c1328af6b6808635496a4f51e3d29ac3eac"
            }
        ]
    }
}
```

Описание ответа.

Ответ выше содержит детали успешно сформированной транзакции. Если транзакция сформирована неправильно, возвращается ошибка:
- если формат JSON некорректный, возвращается ошибка парсинга (`Parse error`)
- если транзакция некорректно подписана (`signature`), возвращается незавершенная (`pending`) транзакция
- если средств недостаточно, возвращается сообщение об ошибке.
