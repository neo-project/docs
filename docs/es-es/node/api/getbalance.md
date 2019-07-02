# Método Getbalance

Devuelve el balance del activo correspodiente en el monedero en función del número del activo especificado.

>[!Note]El monedero se debe abrir en el cliente `neo-cli` antes de realizar la petición.

## Descripción de los parámetros

Asset_id: id. del activo (identificador de activo). Corresponde al id. de transacción (RegistTransaction) cuando se registra
el activo.

Los activos de sistema son:
- NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b <br>
- NEOGas: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

El resto de los ids. de activos se pueden obtener a traves del comando `list asset` en el cliente [neo-cli](../cli.md) o a través de un explorador blockchain de NEO.

## Ejemplo de llamada


http://node:10332?jsonrpc=2.0&method=getbalance&params=["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"]&id=1


Petición:

```json
{
	"jsonrpc": "2.0",
	"method": "getbalance",
	"params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": {
	"Balance": "1.01",
	"Confirmed": "1.01"
	}
}
```

## Descripción de la respuesta:

Balance: El balance del activo en el monedero. Sólo la cantidad que ha sido confirmada se puede utilizar para realizar transferencias.

Balance y Confirmed pueden no ser iguales. Si el monedero está pendiente de una cantidad y no ha habido tiempo para la confirmación entoces el valor será menor que el balance. Una vez que finalizado la transacción pendiente, los dos valores serán iguales.

