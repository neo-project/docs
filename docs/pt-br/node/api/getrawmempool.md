# `getrawmempool`

Obtém a lista de transações não confirmadas na memória.

## Exemplo

### Requisição:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

### Resposta: 

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

#### Descrição de Resposta:

  - `result`: lista de *hash*'es de transações não confirmadas, isto é, transações com zero confirmações.
