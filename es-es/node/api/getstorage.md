# Método Getstorage

Devuelve el valor del almacenamiento en funcion al script hash y clave especificado.  

## Descripción de los parámetros

script hash: script hash del contrato.

key: string en formato hex

## Ejemplo de llamada

http://node:10332?jsonrpc=2.0&method=getstorage&params=["98f56b5dc40650da5c1ead5894979e0c2fe4bcd6","48656c6c6f"]&id=1

Petición:

```json
{
    "jsonrpc": "2.0",
    "method": "getstorage", 
    "params": ["98f56b5dc40650da5c1ead5894979e0c2fe4bcd6", "48656c6c6f"],
    "id": 1
}
```

Respuesta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "576f726c64"
}
```
