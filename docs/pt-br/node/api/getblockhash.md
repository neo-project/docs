# `getblockhash`

Retorna a *hash* do bloco especificado pelo índice.

## Parâmetro

`index`: Índice do bloco (altura do bloco)

## Exemplo

### Requisição:

```json
{
   "jsonrpc": "2.0",
   "method": "getblockhash",
   "params": [10000],
   "id": 1
}
```

### Resposta:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "4c1e879872344349067c3b1a30781eeb4f9040d3795db7922f513f6f9660b9b2"
}
```
