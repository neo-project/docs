# sendmany Methode

Veranlasst große Transaktionen. Eine spezifische Wechselgeld-Adresse kann festgelegt werden.

> [!Anmerkung]
> Sie müssen die Wallet in NEO-CLI öffnen, bevor Sie den Befehl ausführen können

## Parameter Beschreibung

\<outputs_array> \[fee=0] \[change_address]

Outputs_array: Array, die Datenstruktur in jedem Element des Arrays ist wie folgt:

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset：Asset ID（asset identifier），Die `RegistTransaction` ID des Assets zum Zeitpunkt der Registrierung.

​	Für NEO：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

​	Für NeoGas：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

   Die übrigen Asset-IDs können über die [NEO-CLI](../cli.md) abgefragt werden. Auch Blockchainbrowser können den `list Asset` Befehl ausführen.


​	value： Zu übertragende Menge

​	address： Zieladresse

Fee: Transaktionsgebühr, optionaler Parameter, standardmäßig 0.

Change_address: Wechselgeld-Adresse, optionaler Parameter, standardmäßig die erste Standardadresse der Wallet.

## Beispiel

Anfrage：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

Antwort:

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

Antwortbeschreibung:

Gibt die Transaktionsdetails wie oben gezeigt aus, um anzuzeigen, ob die Transaktion erfolgreich war oder nicht.

Wenn das JSON-Format inkorrekt ist, wird ein Parse-Error ausgegeben
Wenn die Signatur unvollständig ist, wird "Pending transaction" zurückgegeben.
Wenn der Kontostand nicht ausreichend ist, wird eine Fehlermeldung ausgegeben.
