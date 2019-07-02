# Método sendmany

Permite realizar transferencias por lote a distinas cuentas.

> [!Note]
> El monedero debe estar abierto en el cliente Neo-CLI antes de realizar la llamada.

## Descripción de los parámetros

\<outputs_array> \[fee=0] \[change_address]

outputs_array： La estructura de datos de cada elemento es la siguiente:

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset： el id. del activo. El id. de transacción del metodo ResgistTransaction cuando se registra el activo.
	
	NEO：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b
	NeoGas：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

​	El resto de activos se pueden consultar a través del comando `list asset` [cli](../cli.md) o consultando un explorador de blockchain.

​	value: importe de la transferencia.
​	address： cuenta donde realizaremos la transferencia.

fee：tasa, parámetro opcional, el valor por defecto es 0.

change_address： cambiar la cuenta, parámetro opcional. Por defecto usa la primera cuenta/dirrección estandar.

## Ejemplo de llamada

Petición:

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

Respuesta:

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

## Descripción de la respuesta:

Devuelve los detalles de la transacción si se ha realizado la transacción correctamente, de lo contrario, la transacción no pudo enviar.

El formato JSON no es correcto, devolverá un error Parse.

Si la firma está incompleta, devolverá la transacción a firmar.

Si la balance es insuficiente, se devuelve un mensaje de error.