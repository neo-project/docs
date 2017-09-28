# Método getnewaddress

Crea una nueva cuenta/dirreción.

> [!Note]
> El monedero debe estar abierto en el cliente Neo-CLI antes de realizar la llamada.

## Descripción de los parámetros

Petición:

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

Respuesta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

## Descripción de la respuesta:

Devuelve la cuenta/dirreción creada.
