# Método dumpprivkey 

Devuelve la clave privada de la cuenta.

> [!Note]
> El monedero debe estar abierto en el cliente Neo-CLI antes de realizar la llamada.

## Descripción de los parámetros

cuenta: Dirección de la cuenta. 

## Ejemplo de llamada

Petición:

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["ASMGHQPzZqxFB2yKmzvfv82jtKVnjhp1ES"],
  "id": 1
}
```

Respuesta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L3FdgAisCmV******************************9XM65cvjYQ1"
}
```

## Descripción de la respuesta:

Devuelve la clave privada de la cuenta estándar.
