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
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": 1,
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
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
        "txid": "27b9a82ed519eec17c5520927b3f472e4df28b835c24dba25645e1650ed8d2ac",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "999998",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "40844144eb6819cb094afee2db5e5da078cfc7bbe29dbc60e47b4c3b4bdf77a5fd97865ae9b5a8d8bb3fa20f1441a58a05f848b2ea49c6c0dbbfc5ed241b226665",
                "verification": "210208c5203d32f960c54c225f140c1020408b114c15d29082fc959dac6874828fccac"
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